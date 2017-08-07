/*
Copyright (c) 2000  JavaScience Consulting,  Michel Gallant

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Bunq.Sdk.Security
{
    public class RsaKeyUtils
    {
        #region PUBLIC KEY TO X509 BLOB

        internal static byte[] PublicKeyToX509(RSAParameters publicKey)
        {
            var oid = CreateOid("1.2.840.113549.1.1.1");
            var algorithmId = CreateSequence(new[] {oid, CreateNull()});
            var n = CreateIntegerPos(publicKey.Modulus);
            var e = CreateIntegerPos(publicKey.Exponent);
            var key = CreateBitString(CreateSequence(new[] {n, e}));
            var publicKeyInfo = CreateSequence(new[] {algorithmId, key});

            return new AsnMessage(publicKeyInfo.GetBytes(), "X.509").GetBytes();
        }

        #endregion BLOB

        #region PRIVATE KEY TO PKCS8 BLOB

        internal static byte[] PrivateKeyToPkcs8(RSAParameters privateKey)
        {
            var version = CreateInteger(new byte[] {0});
            var n = CreateIntegerPos(privateKey.Modulus);
            var e = CreateIntegerPos(privateKey.Exponent);
            var d = CreateIntegerPos(privateKey.D);
            var p = CreateIntegerPos(privateKey.P);
            var q = CreateIntegerPos(privateKey.Q);
            var dp = CreateIntegerPos(privateKey.DP);
            var dq = CreateIntegerPos(privateKey.DQ);
            var iq = CreateIntegerPos(privateKey.InverseQ);
            var key = CreateOctetString(CreateSequence(new[] {version, n, e, d, p, q, dp, dq, iq}));
            var algorithmId = CreateSequence(new[] {CreateOid("1.2.840.113549.1.1.1"), CreateNull()});
            var privateKeyInfo = CreateSequence(new[] {version, algorithmId, key});

            return new AsnMessage(privateKeyInfo.GetBytes(), "PKCS#8").GetBytes();
        }

        internal static byte[] PrivateKeyToPkcs8(byte[] privateKeyBytes)
        {
            var rsaParam = DecodeRsaPrivateKeyToRsaParameters(privateKeyBytes);
            var n = CreateIntegerPos(rsaParam.Modulus);
            var e = CreateIntegerPos(rsaParam.Exponent);
            var d = CreateIntegerPos(rsaParam.D);
            var p = CreateIntegerPos(rsaParam.P);
            var q = CreateIntegerPos(rsaParam.Q);
            var dp = CreateIntegerPos(rsaParam.DP);
            var dq = CreateIntegerPos(rsaParam.DQ);
            var iq = CreateIntegerPos(rsaParam.InverseQ);
            var version = CreateInteger(new byte[] {0});
            var key = CreateOctetString(CreateSequence(new[] {version, n, e, d, p, q, dp, dq, iq}));
            var algorithmId = CreateSequence(new[] {CreateOid("1.2.840.113549.1.1.1"), CreateNull()});
            var privateKeyInfo = CreateSequence(new[] {version, algorithmId, key});

            return new AsnMessage(privateKeyInfo.GetBytes(), "PKCS#8").GetBytes();
        }

        #endregion

        #region X509 PUBLIC KEY BLOB TO RSACRYPTOPROVIDER

        internal static RSA DecodePublicKey(byte[] publicKeyBytes)
        {
            var ms = new MemoryStream(publicKeyBytes);
            var binaryReader = new BinaryReader(ms);
            byte[] seqOid = {0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00};

            try
            {
                byte byteValue;
                ushort shortValue;

                shortValue = binaryReader.ReadUInt16();

                switch (shortValue)
                {
                    case 0x8130:
                        binaryReader.ReadByte();
                        break;
                    case 0x8230:
                        binaryReader.ReadInt16();
                        break;
                    default:
                        return null;
                }

                var seq = binaryReader.ReadBytes(15);

                if (!Helpers.CompareBytearrays(seq, seqOid)) return null;

                shortValue = binaryReader.ReadUInt16();

                switch (shortValue)
                {
                    case 0x8103:
                        binaryReader.ReadByte();
                        break;
                    case 0x8203:
                        binaryReader.ReadInt16();
                        break;
                    default:
                        return null;
                }

                byteValue = binaryReader.ReadByte();

                if (byteValue != 0x00) return null;

                shortValue = binaryReader.ReadUInt16();

                switch (shortValue)
                {
                    case 0x8130:
                        binaryReader.ReadByte();
                        break;
                    case 0x8230:
                        binaryReader.ReadInt16();
                        break;
                    default:
                        return null;
                }

                var rsa = RSA.Create();
                var rsaParams = new RSAParameters
                {
                    Modulus = binaryReader.ReadBytes(Helpers.DecodeIntegerSize(binaryReader))
                };
                var traits = new RsaParameterTraits(rsaParams.Modulus.Length * 8);

                rsaParams.Modulus = Helpers.AlignBytes(rsaParams.Modulus, traits.SizeMod);
                rsaParams.Exponent = Helpers.AlignBytes(binaryReader.ReadBytes(Helpers.DecodeIntegerSize(binaryReader)),
                    traits.SizeExp);

                rsa.ImportParameters(rsaParams);

                return rsa;
            }
            catch (System.Exception)
            {
                return null;
            }
            finally
            {
                binaryReader.Dispose();
            }
        }

        #endregion

        #region PKCS8 PRIVATE KEY BLOB TO RSACRYPTOPROVIDER

        internal static RSA DecodePrivateKeyInfo(byte[] pkcs8)
        {
            byte[] seqOid = {0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00};
            var mem = new MemoryStream(pkcs8);
            var lenstream = (int) mem.Length;
            var binaryReader = new BinaryReader(mem);

            try
            {
                var twobytes = binaryReader.ReadUInt16();

                switch (twobytes)
                {
                    case 0x8130:
                        binaryReader.ReadByte();
                        break;
                    case 0x8230:
                        binaryReader.ReadInt16();
                        break;
                    default:
                        return null;
                }

                var bt = binaryReader.ReadByte();

                if (bt != 0x02)
                    return null;

                twobytes = binaryReader.ReadUInt16();

                if (twobytes != 0x0001)
                    return null;

                var seq = binaryReader.ReadBytes(15);

                if (!CompareByteArrays(seq, seqOid)) return null;

                bt = binaryReader.ReadByte();

                if (bt != 0x04) return null;

                bt = binaryReader.ReadByte();

                switch (bt)
                {
                    case 0x81:
                        binaryReader.ReadByte();
                        break;
                    case 0x82:
                        binaryReader.ReadUInt16();
                        break;
                }

                var rsaPrivateKeyBytes = binaryReader.ReadBytes((int) (lenstream - mem.Position));

                return DecodeRsaPrivateKey(rsaPrivateKeyBytes);
            }

            catch (System.Exception)
            {
                return null;
            }

            finally
            {
                binaryReader.Dispose();
            }
        }

        #endregion

        private static RSA DecodeRsaPrivateKey(byte[] rsaPrivateKeyBytes)
        {
            try
            {
                var rsa = RSA.Create();
                var rsaParams = DecodeRsaPrivateKeyToRsaParameters(rsaPrivateKeyBytes);
                rsa.ImportParameters(rsaParams);

                return rsa;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        #region UTIL METHODS

        private static RSAParameters DecodeRsaPrivateKeyToRsaParameters(byte[] privkey)
        {
            var rsaParams = new RSAParameters();
            var memoryStream = new MemoryStream(privkey);
            var binaryReader = new BinaryReader(memoryStream);

            try
            {
                var twoBytes = binaryReader.ReadUInt16();

                switch (twoBytes)
                {
                    case 0x8130:
                        binaryReader.ReadByte();
                        break;
                    case 0x8230:
                        binaryReader.ReadInt16();
                        break;
                    default:
                        return rsaParams;
                }

                twoBytes = binaryReader.ReadUInt16();

                if (twoBytes != 0x0102)
                    return rsaParams;

                var bt = binaryReader.ReadByte();

                if (bt != 0x00)
                    return rsaParams;

                var elems = GetIntegerSize(binaryReader);
                rsaParams.Modulus = binaryReader.ReadBytes(elems);

                elems = GetIntegerSize(binaryReader);
                rsaParams.Exponent = binaryReader.ReadBytes(elems);

                elems = GetIntegerSize(binaryReader);
                rsaParams.D = binaryReader.ReadBytes(elems);

                elems = GetIntegerSize(binaryReader);
                rsaParams.P = binaryReader.ReadBytes(elems);

                elems = GetIntegerSize(binaryReader);
                rsaParams.Q = binaryReader.ReadBytes(elems);

                elems = GetIntegerSize(binaryReader);
                rsaParams.DP = binaryReader.ReadBytes(elems);

                elems = GetIntegerSize(binaryReader);
                rsaParams.DQ = binaryReader.ReadBytes(elems);

                elems = GetIntegerSize(binaryReader);
                rsaParams.InverseQ = binaryReader.ReadBytes(elems);

                return rsaParams;
            }
            catch (System.Exception)
            {
                return rsaParams;
            }
            finally
            {
                binaryReader.Dispose();
            }
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt;
            int count;
            bt = binr.ReadByte();
            if (bt != 0x02) return 0;
            bt = binr.ReadByte();

            switch (bt)
            {
                case 0x81:
                    count = binr.ReadByte();
                    break;
                case 0x82:
                    var highByte = binr.ReadByte();
                    var lowByte = binr.ReadByte();
                    byte[] modInt = {lowByte, highByte, 0x00, 0x00};
                    count = BitConverter.ToInt32(modInt, 0);
                    break;
                default:
                    count = bt;
                    break;
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);

            return count;
        }


        private static bool CompareByteArrays(IReadOnlyCollection<byte> a, IReadOnlyList<byte> b)
        {
            if (a.Count != b.Count)
                return false;

            var i = 0;

            foreach (var c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }

            return true;
        }

        private static AsnType CreateOctetString(AsnType value)
        {
            return IsEmpty(value) ? new AsnType(0x04, 0x00) : new AsnType(0x04, value.GetBytes());
        }

        private static AsnType CreateBitString(byte[] octets, uint unusedBits)
        {
            if (IsEmpty(octets))
            {
                return new AsnType(0x03, EMPTY);
            }

            if (!(unusedBits < 8))
            {
                throw new ArgumentException("Unused bits must be less than 8.");
            }

            var b = Concatenate(new[] {(byte) unusedBits}, octets);

            return new AsnType(0x03, b);
        }

        private static AsnType CreateBitString(AsnType value)
        {
            return IsEmpty(value) ? new AsnType(0x03, EMPTY) : CreateBitString(value.GetBytes(), 0x00);
        }

        private static readonly byte[] ZERO = {0};
        private static readonly byte[] EMPTY = { };

        private static bool IsEmpty(IReadOnlyCollection<byte> octets)
        {
            return null == octets || 0 == octets.Count;
        }

        private static bool IsEmpty(string s)
        {
            return string.IsNullOrEmpty(s);
        }

        private static bool IsEmpty(IReadOnlyCollection<string> strings)
        {
            return null == strings || 0 == strings.Count;
        }

        private static bool IsEmpty(AsnType value)
        {
            return null == value;
        }

        private static bool IsEmpty(IReadOnlyCollection<AsnType> values)
        {
            return null == values || 0 == values.Count;
        }

        private static bool IsEmpty(IReadOnlyCollection<byte[]> arrays)
        {
            return null == arrays || 0 == arrays.Count;
        }

        private static AsnType CreateInteger(byte[] value)
        {
            return IsEmpty(value) ? new AsnType(0x02, ZERO) : new AsnType(0x02, value);
        }

        private static AsnType CreateNull()
        {
            return new AsnType(0x05, new byte[] {0x00});
        }

        private static byte[] Duplicate(byte[] b)
        {
            if (IsEmpty(b))
            {
                return EMPTY;
            }

            var d = new byte[b.Length];
            Array.Copy(b, d, b.Length);

            return d;
        }

        private static AsnType CreateIntegerPos(byte[] value)
        {
            byte[] i, d = Duplicate(value);

            if (IsEmpty(d))
            {
                d = ZERO;
            }

            if (d.Length > 0 && d[0] > 0x7F)
            {
                i = new byte[d.Length + 1];
                i[0] = 0x00;
                Array.Copy(d, 0, i, 1, value.Length);
            }
            else
            {
                i = d;
            }

            return CreateInteger(i);
        }

        private static byte[] Concatenate(IReadOnlyCollection<AsnType> values)
        {
            if (IsEmpty(values))
                return new byte[] { };

            var length = 0;
            foreach (AsnType t in values)
            {
                if (null != t)
                {
                    length += t.GetBytes().Length;
                }
            }

            var cated = new byte[length];

            var current = 0;

            foreach (var t in values)
            {
                if (null == t) continue;
                var b = t.GetBytes();

                Array.Copy(b, 0, cated, current, b.Length);
                current += b.Length;
            }

            return cated;
        }

        private static byte[] Concatenate(byte[] first, byte[] second)
        {
            return Concatenate(new[] {first, second});
        }

        private static byte[] Concatenate(IReadOnlyCollection<byte[]> values)
        {
            if (IsEmpty(values))
                return new byte[] { };

            var length = values.Where(b => null != b).Sum(b => b.Length);
            var cated = new byte[length];
            var current = 0;

            foreach (var b in values)
            {
                if (null == b) continue;
                Array.Copy(b, 0, cated, current, b.Length);
                current += b.Length;
            }

            return cated;
        }

        private static AsnType CreateSequence(IReadOnlyCollection<AsnType> values)
        {
            if (IsEmpty(values))
            {
                throw new ArgumentException("A sequence requires at least one value.");
            }

            return new AsnType(0x10 | 0x20, Concatenate(values));
        }

        private static AsnType CreateOid(string value)
        {
            if (IsEmpty(value))
                return null;

            var tokens = value.Split(' ', '.');

            if (IsEmpty(tokens))
                return null;

            ulong a = 0;

            var arcs = new List<ulong>();

            foreach (var t in tokens)
            {
                if (t.Length == 0)
                {
                    break;
                }

                try
                {
                    a = Convert.ToUInt64(t, CultureInfo.InvariantCulture);
                }
                catch (FormatException /*e*/)
                {
                    break;
                }
                catch (OverflowException /*e*/)
                {
                    break;
                }

                arcs.Add(a);
            }

            if (0 == arcs.Count)
                return null;

            var octets = new List<byte>();

            if (arcs.Count >= 1)
            {
                a = arcs[0] * 40;
            }
            if (arcs.Count >= 2)
            {
                a += arcs[1];
            }
            octets.Add((byte) (a));

            for (var i = 2; i < arcs.Count; i++)
            {
                var temp = new List<byte>();
                var arc = arcs[i];

                do
                {
                    temp.Add((byte) (0x80 | (arc & 0x7F)));
                    arc >>= 7;
                } while (0 != arc);

                var t = temp.ToArray();

                t[0] = (byte) (0x7F & t[0]);
                Array.Reverse(t);
                octets.AddRange(t);
            }

            return CreateOid(octets.ToArray());
        }

        private static AsnType CreateOid(byte[] value)
        {
            return IsEmpty(value) ? null : new AsnType(0x06, value);
        }

        #endregion
    }
}
