using System;
using System.Numerics;

namespace Tester.Types
{
    internal static class Integer
    {
        public static Bits SubBigInteger(this BigInteger x, int highIndex, int lowIndex) // ASL: "<:>".
        {
            if (highIndex < lowIndex)
            {
                throw new IndexOutOfRangeException();
            }

            Bits src = new Bits(x.ToByteArray());
            bool[] dst = new bool[highIndex - lowIndex + 1];

            for (int i = lowIndex, n = 0; i <= highIndex; i++, n++)
            {
                if (i <= src.Count - 1)
                {
                    dst[n] = src[i];
                }
                else
                {
                    dst[n] = (x.Sign != -1 ? false : true); // Zero / Sign Extension.
                }
            }

            return new Bits(dst);
        }

        public static bool SubBigInteger(this BigInteger x, int index) // ASL: "<>".
        {
            Bits dst = x.SubBigInteger(index, index);

            return (bool)dst;
        }
    }
}
