using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public Labs7()
        {
            InitializeComponent();
        }

        private void Labs7_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf=new MainForm();
            mf.Show();
        }
        private string GetHash()
        {
            //using labs4 for hashing password
            return "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = GeneratePassword();
            else
                textBox2.Text=GetHash();
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
    }
}
