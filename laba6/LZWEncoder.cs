using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsInformationProtection.laba6
{
    internal class LZWEncoder
    {
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        ANSI table = null;

        int codeLen = 8;
        public LZWEncoder()
        {
            table = new ANSI();
            dict = table.Table;
        }

        public string EncodeToCodes(string input)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            string w = "";
            while (i < input.Length)
            {
                w = input[i].ToString();

                i++;

                while (dict.ContainsKey(w) && i < input.Length)
                {
                    w += input[i];
                    i++;
                }

                if (dict.ContainsKey(w) == false)
                {
                    string matchKey = w.Substring(0, w.Length - 1);
                    sb.Append(dict[matchKey] + ", ");

                    dict.Add(w, dict.Count);
                    i--;
                }
                else
                {
                    sb.Append(dict[w] + ", ");
                }
            }

            return sb.ToString();
        }

        public string Encode(string input)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            string w = "";
            while (i < input.Length)
            {
                w = input[i].ToString();

                i++;

                while (dict.ContainsKey(w) && i < input.Length)
                {
                    w += input[i];
                    i++;
                }

                if (dict.ContainsKey(w) == false)
                {
                    string matchKey = w.Substring(0, w.Length - 1);
                    sb.Append(Convert.ToString(dict[matchKey], 2).FillWithZero(codeLen));

                    if (Convert.ToString(dict.Count, 2).Length > codeLen)
                        codeLen++;

                    dict.Add(w, dict.Count);
                    i--;
                }
                else
                {
                    sb.Append(Convert.ToString(dict[w], 2).FillWithZero(codeLen));

                    if (Convert.ToString(dict.Count, 2).Length > codeLen)
                        codeLen++;

                }
            }

            return sb.ToString();
        }

        public byte[] EncodeToByteList(string input)
        {
            string encodedInput = Encode(input);
            return encodedInput.ToByteArray();
        }
    }
}
