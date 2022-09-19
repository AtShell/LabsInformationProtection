using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabsInformationProtection.lab2
{
    internal class Euklid
    {
        public static bool checkGCD_1(BigInteger a, BigInteger b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            if (a > 1)
                return false;
            else return true;
        }

        public static BigInteger ExtendedEuclide(BigInteger a, BigInteger b)
        {
            BigInteger x1 = 0;
            BigInteger x2 = 1;
            BigInteger y1 = 1;
            BigInteger y2 = 0;
            BigInteger B = b;
            while (b > 0)
            {
                BigInteger q = a / b;
                BigInteger r = a - q * b;
                BigInteger x = x = x2 - q * x1;
                BigInteger y = y2 - q * y1;
                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            if (x2 < 0)
            {
                x2 += B;
            }
            return x2;
        }
    }
}
