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
using System.IO;

namespace Bunq.Sdk.Security
{
    internal class Helpers
    {
        internal static bool CompareByteArrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
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

        internal static byte[] AlignBytes(byte[] inputBytes, int alignSize)
        {
            var inputBytesSize = inputBytes.Length;

            if (alignSize == -1 || inputBytesSize >= alignSize) return inputBytes;

            var buf = new byte[alignSize];

            for (var i = 0; i < inputBytesSize; ++i)
            {
                buf[i + (alignSize - inputBytesSize)] = inputBytes[i];
            }

            return buf;
        }

        internal static int DecodeIntegerSize(BinaryReader rd)
        {
            byte byteValue;
            int count;

            byteValue = rd.ReadByte();

            if (byteValue != 0x02) return 0;

            byteValue = rd.ReadByte();

            switch (byteValue)
            {
                case 0x81:
                    count = rd.ReadByte();
                    break;
                case 0x82:
                    var hi = rd.ReadByte();
                    var lo = rd.ReadByte();
                    count = BitConverter.ToUInt16(new[] {lo, hi}, 0);
                    break;
                default:
                    count = byteValue;
                    break;
            }

            while (rd.ReadByte() == 0x00)
            {
                count -= 1;
            }

            rd.BaseStream.Seek(-1, SeekOrigin.Current);

            return count;
        }
    }
}