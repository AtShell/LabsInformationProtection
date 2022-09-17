using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsInformationProtection.laba6
{
    internal class ANSI
    {
        Dictionary<string, int> table = new Dictionary<string, int>();
        public Dictionary<string, int> Table
        {
            get
            {
                return table;
            }
        }

        public ANSI()
        {
            for (int i = 0; i < 256; i++)
            {
                table.Add(System.Text.Encoding.Default.GetString(new byte[1] { Convert.ToByte(i) }), i);
            }
        }

        public void WriteLine()
        {
            table.WriteLine();
        }

        public void WriteToFile()
        {
            File.WriteAllText("ANSI.txt", table.ToStringLines(), Encoding.Default);
        }
    }
}
