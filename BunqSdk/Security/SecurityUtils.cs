using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Security
{
    public class SecurityUtils
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ErrorCouldNotVerifyResponse = "Could not verify server response.";

        /// <summary>
        /// Constants for formatting the request textual representation for signing.
        /// </summary>
        private const string Newline = "\n";
        private const string FormatMethodAndEndpointString = "{0} /v1/{1}";
        private const string HeaderNamePrefixXBunq = "X-Bunq-";
        private const string DelimiterHeaderValue = ",";
        private const string FormatHeaderString = "{0}: {1}";

        /// <summary>
        /// Length of an empty array.
        /// </summary>
        private const int ArrayLengthEmpty = 0;

        /// <summary>
        /// Constants for formatting RSA keys.
        /// </summary>
        private const string PublicKeyStart = "-----BEGIN PUBLIC KEY-----\n";
        private const string PublicKeyEnd = "\n-----END PUBLIC KEY-----\n";
        private const string FormatPublicKey = PublicKeyStart + "{0}" + PublicKeyEnd;
        private const string PrivateKeyStart = "-----BEGIN PRIVATE KEY-----\n";
        private const string PrivateKeyEnd = "\n-----END PRIVATE KEY-----\n";
        private const string FormatPrivateKey = PrivateKeyStart + "{0}" + PrivateKeyEnd;

        /// <summary>
        /// Size of the encryption key.
        /// </summary>
        private const int RsaKeySize = 2048;

        /// <summary>
        /// Encryption-specific headers.
        /// </summary>
        private const string HeaderClientEncryptionHmac = "X-Bunq-Client-Encryption-Hmac";
        private const string HeaderClientEncryptionIv = "X-Bunq-Client-Encryption-Iv";
        private const string HeaderClientEncryptionKey = "X-Bunq-Client-Encryption-Key";
        private const string HeaderServerSignature = "X-Bunq-Server-Signature";

        /// <summary>
        /// Padding modes for the encrypted key and body.
        /// </summary>
        private static readonly RSAEncryptionPadding BunqPaddingModeKey = RSAEncryptionPadding.Pkcs1;
        private const PaddingMode BunqPaddingModeBody = PaddingMode.PKCS7;

        /// <summary>
        /// Sizes of key and IV/block to be used for encrypting bodies of encrypted requests.
        /// </summary>
        private const int BunqKeySizeBits = 256;
        private const int BunqBlockSizeBits = 128;

        /// <summary>
        /// Cipher mode for encrypting bodies of encrypted requests.
        /// </summary>
        private const CipherMode BunqCipherMode = CipherMode.CBC;

        /// <summary>
        /// Number of the very first index in an array or a string.
        /// </summary>
        private const int IndexFirst = 0;

        /// <summary>
        /// The index after the firts character in a string. 
        /// </summary>
        private const int IndexLastFirstChar = 1;
        
        /// <summary>
        /// Regex constants.
        /// </summary>
        private const string RegexForLowercaseHeaders = "(-[a-z])";

        /// <summary>
        /// Generates a base64-representation of RSA/SHA256/PKCS1 signature for a given RequestMessage.
        /// </summary>
        public static string GenerateSignature(HttpRequestMessage requestMessage, RSA keyPair)
        {
            var headBytes = GenerateRequestHeadBytes(requestMessage);
            var bodyBytes = GetRequestBodyBytes(requestMessage);
            var bytesToSign = ConcatenateByteArrays(headBytes, bodyBytes);
            var signature = keyPair.SignData(bytesToSign, 0, bytesToSign.Length, HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);

            return Convert.ToBase64String(signature);
        }

        private static byte[] GetRequestBodyBytes(HttpRequestMessage requestMessage)
        {
            var requestContent = requestMessage.Content;

            return requestContent == null ? new byte[ArrayLengthEmpty] : requestContent.ReadAsByteArrayAsync().Result;
        }

        private static byte[] GenerateRequestHeadBytes(HttpRequestMessage requestMessage)
        {
            var requestHeadString = GenerateMethodAndEndpointString(requestMessage) + Newline +
                GenerateRequestHeadersSortedString(requestMessage) + Newline +
                Newline;

            return Encoding.UTF8.GetBytes(requestHeadString);
        }

        private static string GenerateMethodAndEndpointString(HttpRequestMessage requestMessage)
        {
            var method = requestMessage.Method.ToString();
            var endpoint = requestMessage.RequestUri.ToString();

            return string.Format(FormatMethodAndEndpointString, method, endpoint);
        }

        private static string GenerateRequestHeadersSortedString(HttpRequestMessage requestMessage)
        {
            return GenerateHeadersSortedString(
                requestMessage.Headers.Where(x =>
                    x.Key.StartsWith(HeaderNamePrefixXBunq) ||
                    x.Key.Equals(ApiClient.HeaderCacheControl) ||
                    x.Key.Equals(ApiClient.HeaderUserAgent)
                )
            );
        }

        private static string GetHeaderNameCorrectlyCased(string headerName)
        {
            headerName = headerName.ToLower();
            headerName = headerName.First().ToString().ToUpper() + headerName.Substring(IndexLastFirstChar);
            var matches = Regex.Matches(headerName, RegexForLowercaseHeaders);

            return matches.Cast<Match>().Aggregate(
                headerName,
                (current, match) => current.Replace(
                        match.Groups[IndexFirst].Value, match.Groups[IndexFirst].Value.ToUpper()
                    )
                );
        }

        private static string GenerateHeadersSortedString(
            IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers)
        {
            return headers
                .Select(x => new KeyValuePair<string, string>(x.Key, string.Join(DelimiterHeaderValue, x.Value)))
                .ToImmutableSortedDictionary()
                .Select(x => string.Format(FormatHeaderString, x.Key, x.Value))
                .Aggregate((a, b) => a + Newline + b);
        }

        private static byte[] ConcatenateByteArrays(byte[] byteArray1, byte[] byteArray2)
        {
            var byteArrayConcatenated = new byte[byteArray1.Length + byteArray2.Length];
            Buffer.BlockCopy(byteArray1, 0, byteArrayConcatenated, 0, byteArray1.Length);
            Buffer.BlockCopy(byteArray2, 0, byteArrayConcatenated, byteArray1.Length, byteArray2.Length);

            return byteArrayConcatenated;
        }

        /// <summary>
        /// Creates a X509-formatted public key string from a given RSA key pair.
        /// </summary>
        public static string GetPublicKeyFormattedString(RSA keyPair)
        {
            var publicKey = keyPair.ExportParameters(false);
            var publicKeyBytes = RsaKeyUtils.PublicKeyToX509(publicKey);

            return string.Format(FormatPublicKey, Convert.ToBase64String(publicKeyBytes));
        }

        /// <summary>
        /// If possible, creates a PKCS8-formatted private key string from a given RSA key pair; else returns an empty
        /// string.
        /// </summary>
        public static string GetPrivateKeyFormattedString(RSA keyPair)
        {
            try
            {
                var privateKey = keyPair.ExportParameters(true);
                var privateKeyBytes = RsaKeyUtils.PrivateKeyToPkcs8(privateKey);

                return string.Format(FormatPrivateKey, Convert.ToBase64String(privateKeyBytes));
            }
            catch (SecurityException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Creates an RSA key pair from PKCS8-formatted private key string.
        /// </summary>
        public static RSA CreateKeyPairFromPrivateKeyFormattedString(string privateKeyString)
        {
            var privateKeyStringTrimmed = privateKeyString
                .Replace(PrivateKeyStart, string.Empty)
                .Replace(PrivateKeyEnd, string.Empty);

            return RsaKeyUtils.DecodePrivateKeyInfo(Convert.FromBase64String(privateKeyStringTrimmed));
        }

        /// <summary>
        /// Creates a public-key-only RSA key pair from X509-formatted public key string.
        /// </summary>
        public static RSA CreatePublicKeyFromPublicKeyFormattedString(string publicKeyString)
        {
            var publicKeyStringTrimmed = publicKeyString
                .Replace(PublicKeyStart, string.Empty)
                .Replace(PublicKeyEnd, string.Empty);

            return RsaKeyUtils.DecodePublicKey(Convert.FromBase64String(publicKeyStringTrimmed));
        }

        /// <summary>
        /// Generates a new key pair of pre-determined size.
        /// </summary>
        public static RSA GenerateKeyPair()
        {
            var rsa = RSA.Create();
            rsa.KeySize = RsaKeySize;

            return rsa;
        }

        /// <summary>
        /// Encrypts request body and adds encrypted headers using the bunq way (AES-256-CBC, PKCS7).
        /// </summary>
        public static byte[] Encrypt(ApiContext apiContext, byte[] requestBytes, IDictionary<string, string> headers)
        {
            using (var aes = CreateBunqAes())
            {
                AddHeaderEncryptionKey(apiContext, headers, aes);
                AddHeaderEncryptionIv(headers, aes);
                var requestBytesEncrypted = EncryptBytes(aes, requestBytes);
                AddHeaderEncryptionHmac(headers, aes, requestBytesEncrypted);

                return requestBytesEncrypted;
            }
        }

        private static Aes CreateBunqAes()
        {
            var aes = Aes.Create();
            aes.KeySize = BunqKeySizeBits;
            aes.BlockSize = BunqBlockSizeBits;
            aes.Padding = BunqPaddingModeBody;
            aes.Mode = BunqCipherMode;
            aes.GenerateKey();
            aes.GenerateIV();

            return aes;
        }

        private static void AddHeaderEncryptionKey(ApiContext apiContext, IDictionary<string, string> headers,
            SymmetricAlgorithm aes)
        {
            var keyEncrypted = apiContext.InstallationContext.PublicKeyServer.Encrypt(aes.Key, BunqPaddingModeKey);
            headers.Add(HeaderClientEncryptionKey, Convert.ToBase64String(keyEncrypted));
        }

        private static void AddHeaderEncryptionIv(IDictionary<string, string> headers, SymmetricAlgorithm aes)
        {
            headers.Add(HeaderClientEncryptionIv, Convert.ToBase64String(aes.IV));
        }

        private static byte[] EncryptBytes(SymmetricAlgorithm aes, byte[] bytesToEncrypt)
        {
            using (var encrypt = aes.CreateEncryptor())
            {
                return encrypt.TransformFinalBlock(bytesToEncrypt, IndexFirst, bytesToEncrypt.Length);
            }
        }

        private static void AddHeaderEncryptionHmac(IDictionary<string, string> headers, SymmetricAlgorithm aes,
            byte[] requestBytesEncrypted)
        {
            var hash = HashHmac(aes.IV, requestBytesEncrypted, aes.Key);
            headers.Add(HeaderClientEncryptionHmac, Convert.ToBase64String(hash));
        }

        private static byte[] HashHmac(byte[] iv, byte[] bytes, byte[] key)
        {
            using (var hmacSha1 = new HMACSHA1(key))
            {
                var buffer = new byte[iv.Length + bytes.Length];
                Array.Copy(iv, buffer, iv.Length);
                Array.Copy(bytes, IndexFirst, buffer, iv.Length, bytes.Length);

                return hmacSha1.ComputeHash(buffer);
            }
        }

        public static void ValidateResponse(HttpResponseMessage responseMessage, RSA serverPublicKey)
        {
            var headBytes = GenerateResponseHeadBytes(responseMessage);
            var bodyBytes = responseMessage.Content.ReadAsByteArrayAsync().Result;
            var responseBytes = ConcatenateByteArrays(headBytes, bodyBytes);
            var serverSignatureHeader = string.Join(",", responseMessage.Headers.GetValues(HeaderServerSignature));
            var serverSignature = Convert.FromBase64String(serverSignatureHeader);

            if (!serverPublicKey.VerifyData(responseBytes, serverSignature, HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1))
            {
                throw new BunqException(ErrorCouldNotVerifyResponse);
            }
        }

        private static byte[] GenerateResponseHeadBytes(HttpResponseMessage responseMessage)
        {
            var requestHeadString = (int) responseMessage.StatusCode + Newline +
                GenerateResponseHeadersSortedString(responseMessage) + Newline +
                Newline;

            return Encoding.UTF8.GetBytes(requestHeadString);
        }

        private static string GenerateResponseHeadersSortedString(HttpResponseMessage responseMessage)
        {
            return GenerateHeadersSortedString(
                responseMessage.Headers.Where(x =>
                    GetHeaderNameCorrectlyCased(x.Key).StartsWith(HeaderNamePrefixXBunq) &&
                    !GetHeaderNameCorrectlyCased(x.Key).Equals(HeaderServerSignature)
                )
            );
        }
    }
}
