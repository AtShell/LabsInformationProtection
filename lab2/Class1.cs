using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsInformationProtection.lab2
{
    public static class Extention
    {
        public static byte[] ToByteArray(this string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }
        public static string ByteArrayToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }
    }
}
