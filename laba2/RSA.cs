using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LabsInformationProtection.lab2
{
    [Serializable]
    public class RSA
    {
        public RSA()
        {
            P = (ulong)generateNum(0, 65535);
            Q = (ulong)generateNum(0, 65535);
            N = (ulong)mod(P, Q);
            PHI = (ulong)eiler(P, Q);
            E = (ulong)expo(PHI);
            D = (ulong)privateKey(E, PHI);
        }
        [XmlElement("P")]
        public ulong P { get; set; }//Простое число
        [XmlElement("Q")]
        public ulong Q { get; set; }//Простое число
        [XmlElement("N")]
        public ulong N { get; set; }// Модуль n=p*q
        [XmlElement("PHI")]
        public ulong PHI { get; set; }//Функция Эйлера от n
        [XmlElement("E")]
        public ulong E { get; set; }//Взаимно простое число в промежутке от 2 до PHI-1 (открытый ключ)

        private static Random random = new Random();
        [XmlElement("D")]
        public ulong D;//Закрытый ключ

        private BigInteger getRandom(BigInteger min, BigInteger max)
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
        }//Генерирует числа типа BigInteger от min до max

        private BigInteger generateNum(BigInteger min, BigInteger max)
        {
            BigInteger num = getRandom(min, max);
            while (!AlgoritmMillera_Rabina.MillerRabinTest(num, 100))
            {
                num = getRandom(min, max);
            }
            return num;
        }//Генерирует простое число типа BigInteger от min до max

        private BigInteger mod(BigInteger p, BigInteger q)
        {
            return (p * q);
        }

        private BigInteger eiler(BigInteger p, BigInteger q)
        {
            BigInteger phi = (p - 1) * (q - 1);
            return phi;
        }//Функция Эйлера от n

        private BigInteger expo(BigInteger phi)
        {
            BigInteger temp = getRandom(1, phi);
            while (!Euklid.checkGCD_1(phi, temp))
            {
                temp = getRandom(1, phi);
            }
            return temp;
        }//Получение открытого ключа

        private BigInteger privateKey(BigInteger e, BigInteger phi)
        {
            BigInteger result = Euklid.ExtendedEuclide(e, phi);
            return result;
        }//Получение секретного ключа

        public BigInteger encode(BigInteger num)
        {
            BigInteger result = BigInteger.ModPow(num, E, N);
            return result;
        }//Шифрование

        public BigInteger decode(BigInteger num)
        {
            BigInteger result = BigInteger.ModPow(num, D, N);
            return result;
        }//Расшифрование
    }
}
