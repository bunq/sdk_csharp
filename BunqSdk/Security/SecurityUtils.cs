using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
        private const string ERROR_COULD_NOT_VERIFY_RESPONSE = "Could not verify server response.";
        private const string ERROR_FILE_NOT_FOUND = "Could not find the specified file.";

        /// <summary>
        /// Constants for formatting the request textual representation for signing.
        /// </summary>
        private const string NEWLINE = "\n";
        private const string WINDOWS_NEWLINE = "\r\n";
        private const string FORMAT_METHOD_AND_ENDPOINT_STRING = "{0} /v1/{1}";
        private const string HEADER_NAME_PREFIX_X_BUNQ = "X-Bunq-";
        private const string DELIMITER_HEADER_VALUE = ",";
        private const string FORMAT_HEADER_STRING = "{0}: {1}";

        /// <summary>
        /// Length of an empty array.
        /// </summary>
        private const int ARRAY_LENGTH_EMPTY = 0;

        /// <summary>
        /// Constants for formatting RSA keys.
        /// </summary>
        private const string PUBLIC_KEY_START = "-----BEGIN PUBLIC KEY-----" + NEWLINE;
        private const string PUBLIC_KEY_END = NEWLINE + "-----END PUBLIC KEY-----";
        private const string FORMAT_PUBLIC_KEY = PUBLIC_KEY_START + "{0}" + PUBLIC_KEY_END + NEWLINE;
        private const string PRIVATE_KEY_START = "-----BEGIN PRIVATE KEY-----" + NEWLINE;
        private const string PRIVATE_KEY_END = NEWLINE + "-----END PRIVATE KEY-----";
        private const string FORMAT_PRIVATE_KEY = PRIVATE_KEY_START + "{0}" + PRIVATE_KEY_END + NEWLINE;
        private const string RSA_PRIVATE_KEY_START = "-----BEGIN RSA PRIVATE KEY-----" + NEWLINE;
        private const string RSA_PRIVATE_KEY_END = NEWLINE + "-----END RSA PRIVATE KEY-----";
        private const string CERTIFICATE_START = "-----BEGIN CERTIFICATE-----" + NEWLINE;
        private const string CERTIFICATE_END = NEWLINE + "-----END CERTIFICATE-----";
        private const string FORMAT_CERTIFICATE = CERTIFICATE_START + "{0}" + CERTIFICATE_END + NEWLINE;

        /// <summary>
        /// Size of the encryption key.
        /// </summary>
        private const int RSA_KEY_SIZE = 2048;

        /// <summary>
        /// Encryption-specific headers.
        /// </summary>
        private const string HEADER_CLIENT_ENCRYPTION_HMAC = "X-Bunq-Client-Encryption-Hmac";
        private const string HEADER_CLIENT_ENCRYPTION_IV = "X-Bunq-Client-Encryption-Iv";
        private const string HEADER_CLIENT_ENCRYPTION_KEY = "X-Bunq-Client-Encryption-Key";
        private const string HEADER_SERVER_SIGNATURE = "X-Bunq-Server-Signature";

        /// <summary>
        /// Padding modes for the encrypted key and body.
        /// </summary>
        private static readonly RSAEncryptionPadding BUNQ_PADDING_MODE_KEY = RSAEncryptionPadding.Pkcs1;
        private const PaddingMode BUNQ_PADDING_MODE_BODY = PaddingMode.PKCS7;

        /// <summary>
        /// Sizes of key and IV/block to be used for encrypting bodies of encrypted requests.
        /// </summary>
        private const int BUNQ_KEY_SIZE_BITS = 256;
        private const int BUNQ_BLOCK_SIZE_BITS = 128;

        /// <summary>
        /// Cipher mode for encrypting bodies of encrypted requests.
        /// </summary>
        private const CipherMode BUNQ_CIPHER_MODE = CipherMode.CBC;

        /// <summary>
        /// Number of the very first index in an array or a string.
        /// </summary>
        private const int INDEX_FIRST = 0;

        /// <summary>
        /// The index after the firts character in a string. 
        /// </summary>
        private const int INDEX_LAST_FIRST_CHAR = 1;
        
        /// <summary>
        /// Regex constants.
        /// </summary>
        private const string REGEX_FOR_LOWERCASE_HEADERS = "(-[a-z])";

        /// <summary>
        /// Generates a base64-representation of RSA/SHA256/PKCS1 signature for a given RequestMessage.
        /// </summary>
        public static string GenerateSignature(HttpRequestMessage requestMessage, RSA keyPair)
        {
            var bodyBytes = GetRequestBodyBytes(requestMessage);
            var signature = keyPair.SignData(bodyBytes, 0, bodyBytes.Length, HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);

            return Convert.ToBase64String(signature);
        }

        private static byte[] GetRequestBodyBytes(HttpRequestMessage requestMessage)
        {
            var requestContent = requestMessage.Content;

            return requestContent == null ? new byte[ARRAY_LENGTH_EMPTY] : requestContent.ReadAsByteArrayAsync().Result;
        }
        
        private static string GetHeaderNameCorrectlyCased(string headerName)
        {
            headerName = headerName.ToLower();
            headerName = headerName.First().ToString().ToUpper() + headerName.Substring(INDEX_LAST_FIRST_CHAR);
            var matches = Regex.Matches(headerName, REGEX_FOR_LOWERCASE_HEADERS);

            return matches.Cast<Match>().Aggregate(
                headerName,
                (current, match) => current.Replace(
                        match.Groups[INDEX_FIRST].Value, match.Groups[INDEX_FIRST].Value.ToUpper()
                    )
                );
        }

        private static string GenerateHeadersSortedString(
            IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers)
        {
            return headers
                .Select(x => new KeyValuePair<string, string>(x.Key, string.Join(DELIMITER_HEADER_VALUE, x.Value)))
                .ToImmutableSortedDictionary()
                .Select(x => string.Format(FORMAT_HEADER_STRING, x.Key, x.Value))
                .Aggregate((a, b) => a + NEWLINE + b);
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

            return string.Format(FORMAT_PUBLIC_KEY, WrapBase64(Convert.ToBase64String(publicKeyBytes)));
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

                return string.Format(FORMAT_PRIVATE_KEY, WrapBase64(Convert.ToBase64String(privateKeyBytes)));
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
                .Replace(WINDOWS_NEWLINE, NEWLINE)
                .Replace(PRIVATE_KEY_START, string.Empty)
                .Replace(PRIVATE_KEY_END, string.Empty)
                .Trim();

            return RsaKeyUtils.DecodePrivateKeyInfo(Convert.FromBase64String(privateKeyStringTrimmed));
        }

        /// <summary>
        /// Creates an RSA key pair from PKCS8-formatted RSA private key string.
        /// </summary>
        public static RSA CreateKeyPairFromRsaPrivateKeyFormattedString(string privateKeyString)
        {
            var privateKeyStringTrimmed = privateKeyString
                .Replace(WINDOWS_NEWLINE, NEWLINE)
                .Replace(RSA_PRIVATE_KEY_START, String.Empty)
                .Replace(RSA_PRIVATE_KEY_END, String.Empty)
                .Trim();

            return RsaKeyUtils.DecodeRsaPrivateKey(Convert.FromBase64String(privateKeyStringTrimmed));
        }

        /// <summary>
        /// Creates a public-key-only RSA key pair from X509-formatted public key string.
        /// </summary>
        public static RSA CreatePublicKeyFromPublicKeyFormattedString(string publicKeyString)
        {
            var publicKeyStringTrimmed = publicKeyString
                .Replace(WINDOWS_NEWLINE, NEWLINE)
                .Replace(PUBLIC_KEY_START, string.Empty)
                .Replace(PUBLIC_KEY_END, string.Empty)
                .Trim();

            return RsaKeyUtils.DecodePublicKey(Convert.FromBase64String(publicKeyStringTrimmed));
        }

        /// <summary>
        /// Generates a new key pair of pre-determined size.
        /// </summary>
        public static RSA GenerateKeyPair()
        {
#if NETSTANDARD2_0 || NET46 || NET45 || NET451 || NET452 || NET40 || NET35
            var rsa = (RSA)new RSACryptoServiceProvider(RSA_KEY_SIZE);
#else
            var rsa = RSA.Create();
            rsa.KeySize = RSA_KEY_SIZE;
#endif
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
            aes.KeySize = BUNQ_KEY_SIZE_BITS;
            aes.BlockSize = BUNQ_BLOCK_SIZE_BITS;
            aes.Padding = BUNQ_PADDING_MODE_BODY;
            aes.Mode = BUNQ_CIPHER_MODE;
            aes.GenerateKey();
            aes.GenerateIV();

            return aes;
        }

        private static void AddHeaderEncryptionKey(ApiContext apiContext, IDictionary<string, string> headers,
            SymmetricAlgorithm aes)
        {
            var keyEncrypted = apiContext.InstallationContext.PublicKeyServer.Encrypt(aes.Key, BUNQ_PADDING_MODE_KEY);
            headers.Add(HEADER_CLIENT_ENCRYPTION_KEY, Convert.ToBase64String(keyEncrypted));
        }

        private static void AddHeaderEncryptionIv(IDictionary<string, string> headers, SymmetricAlgorithm aes)
        {
            headers.Add(HEADER_CLIENT_ENCRYPTION_IV, Convert.ToBase64String(aes.IV));
        }

        private static byte[] EncryptBytes(SymmetricAlgorithm aes, byte[] bytesToEncrypt)
        {
            using (var encrypt = aes.CreateEncryptor())
            {
                return encrypt.TransformFinalBlock(bytesToEncrypt, INDEX_FIRST, bytesToEncrypt.Length);
            }
        }

        private static void AddHeaderEncryptionHmac(IDictionary<string, string> headers, SymmetricAlgorithm aes,
            byte[] requestBytesEncrypted)
        {
            var hash = HashHmac(aes.IV, requestBytesEncrypted, aes.Key);
            headers.Add(HEADER_CLIENT_ENCRYPTION_HMAC, Convert.ToBase64String(hash));
        }

        private static byte[] HashHmac(byte[] iv, byte[] bytes, byte[] key)
        {
            using (var hmacSha1 = new HMACSHA1(key))
            {
                var buffer = new byte[iv.Length + bytes.Length];
                Array.Copy(iv, buffer, iv.Length);
                Array.Copy(bytes, INDEX_FIRST, buffer, iv.Length, bytes.Length);

                return hmacSha1.ComputeHash(buffer);
            }
        }

        public static void ValidateResponse(HttpResponseMessage responseMessage, RSA serverPublicKey)
        {
            var headBytes = GenerateResponseHeadBytes(responseMessage);
            var bodyBytes = responseMessage.Content.ReadAsByteArrayAsync().Result;
            var responseBytes = ConcatenateByteArrays(headBytes, bodyBytes);
            var serverSignatureHeader = string.Join(",", responseMessage.Headers.GetValues(HEADER_SERVER_SIGNATURE));
            var serverSignature = Convert.FromBase64String(serverSignatureHeader);

            if (serverPublicKey.VerifyData(
                responseBytes,
                serverSignature,
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1
            ))
            {
                // Validated signature with headers. (Deprecated, but implemented for backwards compatibility.)
            } else if (serverPublicKey.VerifyData(
                bodyBytes,
                serverSignature,
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1
            ))
            {
                // Validated body signature.
            }
            else
            {
                throw new BunqException(ERROR_COULD_NOT_VERIFY_RESPONSE);
            }
        }

        private static byte[] GenerateResponseHeadBytes(HttpResponseMessage responseMessage)
        {
            var requestHeadString = (int) responseMessage.StatusCode + NEWLINE +
                GenerateResponseHeadersSortedString(responseMessage) + NEWLINE +
                NEWLINE;

            return Encoding.UTF8.GetBytes(requestHeadString);
        }

        private static string GenerateResponseHeadersSortedString(HttpResponseMessage responseMessage)
        {
            return GenerateHeadersSortedString(
                responseMessage.Headers.Where(x =>
                    GetHeaderNameCorrectlyCased(x.Key).StartsWith(HEADER_NAME_PREFIX_X_BUNQ) &&
                    !GetHeaderNameCorrectlyCased(x.Key).Equals(HEADER_SERVER_SIGNATURE)
                )
            );
        }
        
        /// <summary>
        /// Creates a PEM-formatted certificate string from a given X509Certificate object
        /// string.
        /// </summary>
        public static string ExportCertificateToPEM(X509Certificate cert)
        {
            var certificateBytes = cert.Export(X509ContentType.Cert);

            return string.Format(FORMAT_CERTIFICATE, WrapBase64(Convert.ToBase64String(certificateBytes)));
        }
        
        /// <summary>
        /// Wraps a base64 string to 64-character wide lines according to typical certificate/key export rules.
        /// </summary>
        /// <param name="base64">base64 string without line breaks</param>
        /// <returns>base64-string formatted with line breaks</returns>
        private static string WrapBase64(string base64)
        {
            var builder = new StringBuilder();
            for (var ctr = 0; ctr <= base64.Length / 64; ctr++)
            {
                builder.Append(base64.Substring(ctr * 64,
                    ctr * 64 + 64 <= base64.Length
                        ? 64
                        : base64.Length - ctr * 64))
                    .Append(NEWLINE);
            }

            return builder.ToString().Trim();
        }
        
        public static string ExportCertificateCollectionToPEM(X509CertificateCollection certChain)
        {
            var builder = new StringBuilder();
            
            foreach (var chainElement in certChain)
            {
                builder.Append(ExportCertificateToPEM(chainElement)).Append(NEWLINE);
            }

            return builder.ToString();
        }

        public static X509Certificate2 GetCertificateFromFile(string path, string passphrase = null)
        {
            if (File.Exists(path))
            {
                if (passphrase != null)
                {
                    return new X509Certificate2(path, passphrase);
                }
                else
                {
                    return new X509Certificate2(path);
                }
            }
            else
            {
                throw new BunqException(ERROR_FILE_NOT_FOUND);
            }
        }

        public static X509CertificateCollection GetCertificateCollectionFromAllPath(string[] allPath)
        {
            X509CertificateCollection collection = new X509CertificateCollection();
            foreach (string path in allPath)
            {
                collection.Add(GetCertificateFromFile(path));
            }

            return collection;
        }
    }
}
