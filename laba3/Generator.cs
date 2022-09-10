using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabsInformationProtection.laba3
{
    internal class Generator
    {
        public ulong Generate()
        {
            Random rand = new Random();
            byte[] buffer = new byte[8];
            rand.NextBytes(buffer);
            ulong result = (ulong)Math.Abs(BitConverter.ToInt64(buffer, 0) / 100000);
            while (true)
            {
                if (is_prime(result) == false)
                    result++;
                else
                    break;
            }
            return result;
        }
        public static bool is_prime(ulong n)
        {
            if (n == 2)
                return true;
            if (n == 1)
                return false;
            for (uint i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        public BigInteger fastPow(BigInteger n, BigInteger pow, BigInteger mod)
        {
            BigInteger v = 1;
            while (pow != 0)
            {
                if ((pow & 1) != 0)
                    v *= n;
                n *= n;
                pow >>= 1;
            }
            return v % mod;
        }
    }
}
