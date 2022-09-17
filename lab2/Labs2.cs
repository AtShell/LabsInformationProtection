using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
        //BigInteger n;
        ulong n=0;
        ulong d=0;
        ulong ex = 0;
        public Labs2()
        {
            InitializeComponent();
        }
        public static ulong RandPandQ()
        {
            int result = 0;
            string key = "";
            do
            {
                Random rand = new Random();
                result = rand.Next(0, 65535);
                key = Convert.ToString(result, 2);
            }
            while (key.Length < 12 && key.Length > 16);
            return (ulong)result;
        }
        public static ulong RandE()
        {
            ulong[] FermatNumbers = new ulong[] { 3, 5, 17, 257, 65537 };
            Random rand = new Random();
            return FermatNumbers[rand.Next(0, FermatNumbers.Length)];
        }
        public static bool is_prime(ulong n)
        {
            if (n == 2)
                return true;
            if (n == 1)
                return false;
            for(uint i = 2; i <=Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        public static ulong number(int count)
        {
            ulong number = RandPandQ();
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
            ulong p = 0;
            ulong q = 0;
            if (textBox1.Text != "")
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                {
                    textBox3.Text = number(8).ToString();
                    textBox4.Text = number(8).ToString();
                }
                if (textBox3.Text!=""&&(is_prime(Convert.ToUInt64(textBox3.Text)) && is_prime(Convert.ToUInt64(textBox4.Text))))
                {
                    p = Convert.ToUInt64(textBox3.Text);
                    q = Convert.ToUInt64(textBox4.Text);
                    string s = textBox1.Text.ToString();
                    n = p * q;
                    ulong nf = (p - 1) * (q - 1);
                    ex = 5;
                    //ex = RandE();
                    d = Calc_d(ex,nf);
                    //ulong result = RSA_Encode(s, ex, n);
                    //textBox2.Text = result.ToString();
                    textBox2.Text = RSA_Encode(s, ex, n);

                    textBox5.Text = d.ToString();
                    textBox6.Text = n.ToString();
                    textBox7.Text = ex.ToString();
        }
                else
                    MessageBox.Show("введите простые числа");
            }
            else
                MessageBox.Show("исходный текст не введен");
        }
        public static BigInteger fastPow(BigInteger n,ulong pow,ulong mod)
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
        public static string RSA_Encode(string s, ulong ex, ulong n)
        {
            string res = "";
            foreach(char c in s)
            {
                res += fastPow(Convert.ToUInt64(c), ex,n)+" ";
            }
            return res;
            /*ulong result = fastPow(r, (ulong)ex, n);
            return (ulong)result;*/

            /*ulong r = Convert.ToUInt64(s);
            //BigInteger result = (BigInteger.ModPow(r,ex,n));
            BigInteger result = ((BigInteger.Pow(r, (int)ex) % n));
            return (ulong)result;*/

            /*
            byte[] data = Encoding.UTF8.GetBytes(s);
            int pos = 0;
            ulong res = 0;

            foreach (byte by in data)
            {
                res |= ((ulong)by) << pos;
                pos += 8;
            }
            ulong result = (ulong)((Math.Pow(res, ex) % n));
            */
            /*ulong temp = (ulong)((Math.Pow(97, 91494727)) % 12797689200560293421);
            MessageBox.Show(temp.ToString());
            return temp;*/
            /*ulong temp;
            //ulong temp = (ulong)((Math.Pow(111111, 3)) % 9173503);
            //data = Encoding.UTF8.GetBytes(s);
            Encoding encoding = Encoding.ASCII;
            byte[] data = s.ToByteArray(encoding);
            ulong res = 0;
            int pos = 0;
            foreach (byte by in data)
            {
                res |= ((ulong)by) << pos;
                pos += 8;
            }
            temp = (ulong)((res*ex) %n);
            //temp = (ulong)((Math.Pow(res,ex) %n));
            return temp;*/
        }
            public static ulong Calc_d(ulong ex,ulong nf){
            ex %= nf;
            if (ex == 0)
                return nf;
            return Calc_d(nf,ex);
            //return (2 * nf + 1) / 2;
            //return (2 * nf + 1) / ex;
            /*ulong d = nf - 1;

            for (ulong i = 2; i <= nf; i++)
                if ((nf % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }

            return d;*/
            /*Random rand = new Random(DateTime.Now.Millisecond);
            ulong temp_d;
            ulong d = 0;
            ulong check;
            bool quit = false;
            while (!quit)
            {
                temp_d = (ulong)rand.Next(2, 1000);
                d = Convert.ToUInt64(temp_d);
                check = gcd(nf, d);
                if (check == 1)
                    quit = true;
            }
            return d;*/
        }
        private void Labs2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void button3_ClickAsync(object sender, EventArgs e)
        {
            this.textBox3.Text = number(8).ToString();
            this.textBox4.Text = number(8).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox2.Text;
            string res = "";
            string temp="";
           // ulong r = Convert.ToUInt64(s);
            foreach (char c in s)
            {
                if (c != ' ')
                    temp += c;
                else
                {
                    res += fastPow(Convert.ToUInt64(temp), d, n);
                    temp = "";
                }
            }
            textBox2.Text = res;
                /*
                textBox1.Text = textBox2.Text;
                ulong r = Convert.ToUInt64(textBox1.Text);
                ulong result = fastPow(r, d, n);
                textBox2.Text= result.ToString();
                */





                //BigInteger result = ((BigInteger.Pow(r, (int)d) % n));
                /*if (!uint.TryParse(textBox1.Text, out uint number))
                {
                    Encoding encoding = Encoding.ASCII;
                    ulong decrypt = (ulong)((Math.Pow(Convert.ToUInt64(textBox1.Text), d) % n));
                    byte[] data = BitConverter.GetBytes(decrypt);
                    string str = ByteArrayToString(data, encoding);
                    //string str = Convert.ToBase64String(data);
                    textBox2.Text = str;
                }
                else
                    MessageBox.Show("Исходное значение не верно");*/
            }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = generatePorQ();
            this.textBox4.Text = generatePorQ();
            textBox7.Text =RandE().ToString();
        }
        public static string generatePorQ()
        {
            return number(8).ToString();
        }
    }
}