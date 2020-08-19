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
using System.Linq;

namespace Bunq.Sdk.Security
{
    internal class AsnType
    {
        private static readonly byte[] ZERO = {0};
        private static readonly byte[] EMPTY = { };

        internal AsnType(byte tag, byte octet)
        {
            Raw = false;
            mTag = new[] {tag};
            mOctets = new[] {octet};
        }

        internal AsnType(byte tag, byte[] octets)
        {
            Raw = false;
            mTag = new[] {tag};
            mOctets = octets;
        }

        internal AsnType(byte tag, byte[] length, byte[] octets)
        {
            Raw = true;
            mTag = new[] {tag};
            mLength = length;
            mOctets = octets;
        }

        private bool Raw { get; set; }
        private readonly byte[] mTag;

        internal byte[] Tag
        {
            get { return mTag ?? EMPTY; }
        }

        private byte[] mLength;

        internal byte[] Length
        {
            get { return mLength ?? EMPTY; }
        }

        private byte[] mOctets;

        internal byte[] Octets
        {
            get { return mOctets ?? EMPTY; }
            set { mOctets = value; }
        }

        internal byte[] GetBytes()
        {
            if (Raw)
            {
                return Concatenate(
                    new[] {mTag, mLength, mOctets}
                );
            }

            SetLength();

            return Concatenate(0x05 == mTag[0] ? new[] {mTag, mOctets} : new[] {mTag, mLength, mOctets});
        }

        private void SetLength()
        {
            if (null == mOctets)
            {
                mLength = ZERO;
                return;
            }

            if (0x05 == mTag[0])
            {
                mLength = EMPTY;
                return;
            }

            byte[] length;

            if (mOctets.Length < 0x80)
            {
                length = new byte[1];
                length[0] = (byte) mOctets.Length;
            }
            else if (mOctets.Length <= 0xFF)
            {
                length = new byte[2];
                length[0] = 0x81;
                length[1] = (byte) (mOctets.Length & 0xFF);
            }


            else if (mOctets.Length <= 0xFFFF)
            {
                length = new byte[3];
                length[0] = 0x82;
                length[1] = (byte) ((mOctets.Length & 0xFF00) >> 8);
                length[2] = (byte) (mOctets.Length & 0xFF);
            }

            else if (mOctets.Length <= 0xFFFFFF)
            {
                length = new byte[4];
                length[0] = 0x83;
                length[1] = (byte) ((mOctets.Length & 0xFF0000) >> 16);
                length[2] = (byte) ((mOctets.Length & 0xFF00) >> 8);
                length[3] = (byte) (mOctets.Length & 0xFF);
            }
            else
            {
                length = new byte[5];
                length[0] = 0x84;
                length[1] = (byte) ((mOctets.Length & 0xFF000000) >> 24);
                length[2] = (byte) ((mOctets.Length & 0xFF0000) >> 16);
                length[3] = (byte) ((mOctets.Length & 0xFF00) >> 8);
                length[4] = (byte) (mOctets.Length & 0xFF);
            }

            mLength = length;
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

        private static bool IsEmpty(IReadOnlyCollection<byte[]> octets)
        {
            return null == octets || 0 == octets.Count;
        }
    }
}