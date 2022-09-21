using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace LabsInformationProtection.Laba7
{
    public partial class Labs7 : Form
    {
        char[] alphabet =
        {
            '0','1','2','3','4','5','6','7','8','9','.',',','?','!','/','*','-','+','=',
            'а','б','в','г','д','е','ё','ж','з','и','к','л','м','н','о','п','р','с',
            'т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я',
            'А','Б','В','Г','Д','Е','Ё','Ж','З','И','К','Л','М','Н','О','П','Р','С',
            'Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };
        string InputPassword = "";
        string HashPassword = "";
        string key = "";
        bool showKey = false;
        public Labs7()
        {
            InitializeComponent();
            Random rand = new Random();
            key = rand.Next(11111111, 99999999).ToString();
        }

        private void Labs7_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf=new MainForm();
            mf.Show();
        }
        private string GetHash()
        { 
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(InputPassword);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] checkSum = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = checkSum;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray =
      cTransform.TransformFinalBlock(toEncryptArray, 0,
      toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 28)
            {
                textBox2.Text = GetHash();
                HashPassword = textBox2.Text;
            }
            else
                MessageBox.Show("Пароль слишком короткий");
        }
        private string GeneratePassword()
        {
            string result = "";
            while (result.Length != 28)
            {
                Random random1 = new Random();
                result += alphabet[random1.Next(0, alphabet.Length)];
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputPassword = GeneratePassword();
            textBox1.Text = InputPassword;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            InputPassword = textBox1.Text;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            key = rand.Next(11111111, 99999999).ToString();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            showKey = true;
            if (showKey == true)
            {
                label3.Text = key;
                label3.Visible = true;
            }
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            showKey = false;
            label3.Visible = false;
        }
    }
}
