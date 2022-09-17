using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsInformationProtection.laba6
{
    internal class LZWDecoder
    {
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        int codeLen = 8;
        ANSI table;
        public LZWDecoder()
        {
            table = new ANSI();
            dict = table.Table;
        }

        public string DecodeFromCodes(byte[] bytes)
        {
            string output = bytes.GetBinaryString();

            return Decode(output);
        }

        public string Decode(string output)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            string w = "";
            int prevValue = -1;

            while (i < output.Length)
            {
                if (i + codeLen + 8 <= output.Length)
                {
                    w = output.Substring(i, codeLen);
                }
                else if (i + codeLen <= output.Length)
                {
                    int encodedLen = i + codeLen;
                    int trimBitsLen = output.Length - encodedLen;

                    w = output.Substring(i, codeLen - (8 - trimBitsLen)) + output.Substring(output.Length - (8 - trimBitsLen), (8 - trimBitsLen));
                }
                else
                {
                    break;
                }

                i += codeLen;

                int value = Convert.ToInt32(w, 2);

                string key = dict.FindKey(value);
                string prevKey = dict.FindKey(prevValue);

                if (prevKey == null)
                {
                    prevKey = "";
                }

                if (key == null)
                {
                    //handles the situation cScSc
                    key = prevKey;

                    sb.Append(prevKey + key.Substring(0, 1));
                }
                else
                {
                    sb.Append(key);
                }

                string finalKey = prevKey + key.Substring(0, 1);

                if (dict.ContainsKey(finalKey) == false)
                {
                    dict[finalKey] = dict.Count;
                }

                if (Convert.ToString(dict.Count, 2).Length > codeLen)
                    codeLen++;

                prevValue = value;
            }

            return sb.ToString();
        }
    }
}
