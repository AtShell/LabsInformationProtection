using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabsInformationProtection.lab2
{
    internal class AlgoritmMillera_Rabina
    {
        private static Random random = new Random();

        private static BigInteger getRandom(BigInteger min, BigInteger max)
        {
            byte[] data = max.ToByteArray();
            byte[] temp = new byte[data.Length];
            random.NextBytes(temp);
            BigInteger result = new BigInteger(temp);
            while (result < min || result > max)
            {
                random.NextBytes(temp);
                result = new BigInteger(temp);
            }
            return result;
        }

        public static bool MillerRabinTest(BigInteger n, int k)
        {
            if (n <= 1)
                return false;
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;
            int s = 0;
            BigInteger d = n - 1;
            while (d % 2 == 0)
            {
                d /= 2;
                s++;
            }
            for (int i = 0; i < k; i++)
            {
                BigInteger a = getRandom(2, n - 1);
                BigInteger x = BigInteger.ModPow(a, d, n);
                if (x == 1 || x == n - 1)
                    continue;
                for (int j = 0; j < s - 1; j++)
                {
                    x = (x * x) % n;
                    if (x == 1)
                        return false;
                    if (x == n - 1)
                        break;
                }
                if (x != n - 1)
                    return false;
            }
            return true;
        }
    }
}
