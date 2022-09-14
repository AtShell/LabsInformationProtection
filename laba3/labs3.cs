using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LabsInformationProtection.laba3
{
    public partial class labs3 : Form
    {
        Generator g = new Generator();
        BigInteger x=0;
        BigInteger y=0;
        BigInteger gk=0;
        BigInteger pk=0;
        ulong secretKey = 0;
        public labs3()
        {
            InitializeComponent();
        }
        public BigInteger GetPRoot(BigInteger p)
        {
            for (BigInteger i = 0; i < p; i++)
                if (IsPRoot(p, i))
                    return i;
            return 0;
        }

        public bool IsPRoot(BigInteger p, BigInteger a)
        {
            if (a == 0 || a == 1)
                return false;
            BigInteger last = 1;
            HashSet<BigInteger> set = new HashSet<BigInteger>();
            for (BigInteger i = 0; i < p - 1; i++)
            {
                last = (last * a) % p;
                if (set.Contains(last)) // Если повтор
                    return false;
                set.Add(last);
            }
            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            x= g.Generate();
            y= g.Generate();
            gk = rand.Next(1, 10000);
            pk = rand.Next(1, 10000);
            xPrime.Text = x.ToString();
            yPrime.Text = y.ToString();
            secretKey = (ulong)g.fastPow(x * y, gk, pk);
            textBox6.Text = secretKey.ToString();
            if (textBox1.Text != "")
                textBox2.Text = Encryped();
        }

        private void labs3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt file (*.txt)|*.txt";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
        private void SaveFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text file(*.txt)|*.txt";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine(textBox2.Text);
                sw.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        public string Encryped()
        {
                string encrypedMessage = "";
                char[] message = textBox1.Text.ToCharArray();
                foreach (char c in message)
                {
                    encrypedMessage += (c + secretKey);
                }
                return encrypedMessage;
        }
        public string Decryped()
        {
            string secret = secretKey.ToString();
            string temp="";
            string encrypedMessage = "";
            char[] ci = new char[5];
            char[] message = textBox2.Text.ToCharArray();
            foreach (char c in message)
            {
                    temp += c.ToString();
                if (temp.Length == secret.Length)
                {
                    char ctmp = (char)(Convert.ToInt64(temp) -(long)secretKey);
                    encrypedMessage += ctmp.ToString();
                    temp = "";
                }
            }
            return encrypedMessage;
        }
        private void button4_Click(object sender, EventArgs e)
        {
                textBox2.Text = Decryped();
            button4.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (secretKey !=0)
                textBox2.Text = Encryped();
            button4.Enabled = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
                secretKey = 0;
            else
            secretKey=Convert.ToUInt64(textBox6.Text);
            textBox2.Text = Encryped();
        }
    }
}
