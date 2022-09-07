using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace LabsInformationProtection.lab2
{
    public partial class Labs2 : Form
    {
        static char[] characters=new char[] {'#', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0' };
        public Labs2()
        {
            InitializeComponent();
        }
        public ulong Rand()
        {
            Random rand1 = new Random();
            byte[] buffer = new byte[8];
            rand1.NextBytes(buffer);
            ulong result = (ulong)Math.Abs(BitConverter.ToInt64(buffer, 0) / 100000);
            return result;
        }
        public bool is_prime(ulong n)
        {
            for(uint i = 2; i < n+1; i++)
            {
                if (n % i == 0)
                    return is_prime(n / i);
            }
            if (n == 1)
            {
                MessageBox.Show("No");
                return false;
            }
            else
            {
                MessageBox.Show("Yes");
                return true;
            }
        }
        public ulong number()
        {
            ulong number = Convert.ToUInt64(textBox3.Text);
            //ulong number = Rand();
            while (true)
            {
                if (is_prime(number)==false)
                    number++;
                else
                    break;
            }
            return number;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
            ///
            ulong p = 0;
            ulong q = 0;
            if (textBox1.Text != " ")
            {
                if (textBox3.Text == "")
                    textBox3.Text = number().ToString();
                if (textBox4.Text == "")
                    textBox4.Text = number().ToString();
                if (is_prime(Convert.ToUInt64(textBox3.Text)) && is_prime(Convert.ToUInt64(textBox4.Text)))
                {
                    p = Convert.ToUInt64(textBox3.Text);
                    q = Convert.ToUInt64(textBox4.Text);
                    string s = textBox1.Text.ToString().ToUpper();
                    ulong n = p * q;
                    ulong m = (p - 1) * (q - 1);
                    ulong d = Calc_d(m);
                    ulong ex = Calc_ex(d, m);
                    List<string> result = RSA_Encode(s, ex, n);
                    textBox2.Text = result.ToString();
                    textBox5.Text = d.ToString();
                    textBox6.Text = n.ToString();
                }
                else
                    MessageBox.Show("Введите простые числа");
            }
            else
                MessageBox.Show("исходный текст не введен");
        }
        public static List<string> RSA_Encode(string s,ulong ex,ulong n)
        {
            List<string> result = new List<string>();
            BigInteger bi;
            for(int j = 0; j < s.Length; j++)
            {
                int index = Array.IndexOf(characters, s[j]);
                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)ex);
                BigInteger nbi = new BigInteger((int)n);
                bi = bi % nbi;
                result.Add(bi.ToString());
            }
            return result;
        }
        public static ulong Calc_d(ulong m)
        {
            ulong d = m - 1;
            for(ulong i=2;i<=m;i++)
                if ((m % i == 0) && (d % i == 0))
                {
                    d--;
                    i = 1;
                }
            return d;
        }
        public static ulong Calc_ex(ulong d,ulong m)
        {
            ulong ex = 10;
            while (true)
            {
                if ((ex * d) % m == 1)
                    break;
                else ex++;
            }
            return ex;
        }
        private void Labs2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = number().ToString();
            //textBox4.Text = number().ToString();
        }
    }
}
