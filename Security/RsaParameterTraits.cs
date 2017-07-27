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
using System.Diagnostics;

namespace Bunq.Sdk.Security
{
    internal class RsaParameterTraits
    {
        private const double TOLERANCE = 0.000001;
        internal int SizeMod { get; private set; }
        internal int SizeExp { get; private set; }
        internal int SizeD { get; private set; }
        internal int SizeP { get; private set; }
        internal int SizeQ { get; private set; }
        internal int SizeDp { get; private set; }
        internal int SizeDq { get; private set; }
        internal int SizeInvQ { get; private set; }

        internal RsaParameterTraits(int modulusLengthInBits)
        {
            SizeInvQ = -1;
            SizeDq = -1;
            SizeDp = -1;
            SizeQ = -1;
            SizeP = -1;
            SizeD = -1;
            SizeExp = -1;
            SizeMod = -1;

            int assumedLength;
            var logbase = Math.Log(modulusLengthInBits, 2);

            if (Math.Abs(logbase - (int) logbase) < TOLERANCE)
            {
                assumedLength = modulusLengthInBits;
            }
            else
            {
                assumedLength = (int) (logbase + 1.0);
                assumedLength = (int) (Math.Pow(2, assumedLength));
                Debug.Assert(false);
            }

            switch (assumedLength)
            {
                case 512:
                    SizeMod = 0x40;
                    SizeExp = -1;
                    SizeD = 0x40;
                    SizeP = 0x20;
                    SizeQ = 0x20;
                    SizeDp = 0x20;
                    SizeDq = 0x20;
                    SizeInvQ = 0x20;
                    break;
                case 1024:
                    SizeMod = 0x80;
                    SizeExp = -1;
                    SizeD = 0x80;
                    SizeP = 0x40;
                    SizeQ = 0x40;
                    SizeDp = 0x40;
                    SizeDq = 0x40;
                    SizeInvQ = 0x40;
                    break;
                case 2048:
                    SizeMod = 0x100;
                    SizeExp = -1;
                    SizeD = 0x100;
                    SizeP = 0x80;
                    SizeQ = 0x80;
                    SizeDp = 0x80;
                    SizeDq = 0x80;
                    SizeInvQ = 0x80;
                    break;
                case 4096:
                    SizeMod = 0x200;
                    SizeExp = -1;
                    SizeD = 0x200;
                    SizeP = 0x100;
                    SizeQ = 0x100;
                    SizeDp = 0x100;
                    SizeDq = 0x100;
                    SizeInvQ = 0x100;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }
    }
}
