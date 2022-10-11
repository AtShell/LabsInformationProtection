using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabsInformationProtection.Laba8
{
    public partial class Labs8 : Form
    {
        static char[] alphabet =
                {
            '0','1','2','3','4','5','6','7','8','9','.',',','?','!','/','*','-','+','=',' ',
            'а','б','в','г','д','е','ё','ж','з','и','й','к','л','м','н','о','п','р','с',
            'т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я',
            'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р','С',
            'Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };
        int N = alphabet.Length;
        string key = "";
        int k, x, z ;
        public Labs8()
        {
            InitializeComponent();
        }
        private void CreateKey()
        {
            key = "";
            Random random = new Random();
            Random random2 = new Random();
            int count = random2.Next(1, 10);
            for(int i = 0; i < InputText.Text.Length; i++)
                key += alphabet[random.Next(0, alphabet.Length)];
        }
        private void Labs8_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
        }
        private string CuteBlock(string inputString)
        {
            string encryptedText="";
            //int size=inputString.Length;
            while (inputString.Length % 2 != 0)
            {
                string tmp = inputString;
                inputString = 0 + tmp;
            }
               // inputString.Insert(0, "0");
            int countBlock = inputString.Length / 2;
            for (int i = 0; i <= countBlock; i+=2)
            {
                string temp = inputString[i].ToString() + inputString[i + 1].ToString();
                encryptedText += Encrypt(temp);
            }
            return encryptedText;
            /*edit and release
            string input = InputText.Text;
            return Encrypt(input);
            //return "";*/
        }
        private string Encrypt(string input)
        {
            string res = "";
            int key_index = 0;
            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(alphabet, symbol) +
                    Array.IndexOf(alphabet, key[key_index])) % N;

                res += alphabet[c];
                key_index++;

                if ((key_index + 1) == key.Length)
                    key_index = 0;
            }

            return res;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           button2.Enabled = false;
            if (outputText.Text != "")
                outputText.Text = Decrypt(CheckString(outputText.Text));
        }

        private string Decrypt(string input)
        {
            string res = "";
            int key_index = 0;
            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(alphabet, symbol) + N -
                    Array.IndexOf(alphabet, key[key_index])) % N;

                res += alphabet[p];

                key_index++;

                if ((key_index + 1) == key.Length)
                    key_index = 0;
            }
            return res;
        }
        private string CheckString(string res)
        {
            int input = InputText.Text.Length;
            while (res.Length != input)
            {
               res=res.Remove(0, 1);
            }
            return res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (InputText.Text.Length > 0)
            {
                CreateKey();
                outputText.Text = CuteBlock(InputText.Text);
                button2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Исходное сообщение иммет не верный формат\nиспользуйте русские буквы или цифры");
                InputText.Text = "";
            }
        }
    }
}
