using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace LabsInformationProtection.laba4
{
    public partial class Labs4 : Form
    {
        string key = "";
        string input, output;
        int sizeBlock = 16;
        string[] Block;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public Labs4()
        {
            InitializeComponent();
        }
        private void OpenFile()
        {
            openFileDialog1.Filter = "txt file (*.txt)|*.txt";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                input = openFileDialog1.FileName;
                saveFileDialog.Filter= "des file |*.des";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    output = saveFileDialog.FileName;
                    EncryptDES(input,output);
                }
                /*StreamReader sr = new StreamReader(openFileDialog1.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();*/
                /*testmessageingit*/
            }
        }
        private void EncryptDES(string source,string destination)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
            ICryptoTransform cryptoTransform = DES.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream(fsEncrypted, cryptoTransform, CryptoStreamMode.Write);
            byte[] byteArray = new byte[fsInput.Length - 0];
            fsInput.Read(byteArray, 0, byteArray.Length);
            cryptoStream.Write(byteArray, 0, byteArray.Length);
            cryptoStream.Close();
            fsInput.Close();
            fsEncrypted.Close();
        }
        private void DecryptDES(string source,string destination)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
            ICryptoTransform cryptoTransform = DES.CreateDecryptor();
            CryptoStream cryptoStream = new CryptoStream(fsEncrypted, cryptoTransform, CryptoStreamMode.Write);
            byte[] byteArray = new byte[fsInput.Length - 0];
            fsInput.Read(byteArray, 0, byteArray.Length);
            cryptoStream.Write(byteArray, 0, byteArray.Length);
            cryptoStream.Close();
            fsInput.Close();
            fsEncrypted.Close();
            MessageBox.Show("Данные расшифрованы");
        }
        private string GenerateKey()
        {
            int rnd=0;
            while (Convert.ToString(rnd,2).Length != 16)
            {
                Random rand = new Random();
                rnd = rand.Next(0, 65535);
            }
            return Convert.ToString(rnd);
        }
        private string KeyVerification(string newKey)
        {
            string tempKey = "";
            if (Regex.IsMatch(newKey, @"^[0-1]+$") && newKey.Length == 16)
                return newKey;
            else
            {
                MessageBox.Show("Введенный ключ имеет не верный формат\nКлюч будет автоматически сгенерирован");
                tempKey = GenerateKey();
            }
            return tempKey;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            key = KeyBox.Text;
            /*if (KeyBox.Text == "")
            {
                MessageBox.Show("Введенный ключ имеет не верный формат\nКлюч будет автоматически сгенерирован");
                key = GenerateKey();
            }
            else
                key = KeyVerification(KeyBox.Text);
            KeyBox.Text = key;*/
        }

        private void Labs4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
        /*private void Encrypt()
        {
            BitTextToBlock(StringToBinary(textBox1.Text));
            string tkey = key;
            for (int j = 0; j < 16; j++)
            {
                for (int i = 0; i < Block.Length; i++)
                    Block[i] = EncodeDES_One_Round(Block[i], tkey);

                tkey = KeyToNextRound(tkey);
            }
           tkey = KeyToPrevRound(tkey);
            //decodekey=StringToBinary
            string res = "";
            for (int i = 0; i < Block.Length; i++)
                res += Block[i];
            textBox2.Text = res;
        }
        private string EncodeDES_One_Round(string input, string key)
        {
            string L = input.Substring(0, input.Length / 2);
            string R = input.Substring(input.Length / 2, input.Length / 2);

            return (R + XOR(L, f(R, key)));
        }
        private string XOR(string str1, string str2)
        {
            string result = "";
            for (int i = 0; i < str1.Length; i++)
            {
                bool a = Convert.ToBoolean(Convert.ToInt32(str1[i].ToString()));
                bool b = Convert.ToBoolean(Convert.ToInt32(str2[i].ToString()));

                if (a ^ b)
                    result += "1";
                else
                    result += "0";
            }
            return result;
        }
        private string f(string s1, string s2)
        {
            return XOR(s1, s2);
        }
        private string KeyToNextRound(string tkey)
        {
            for (int i = 0; i < 2; i++)
            {
                tkey = tkey[tkey.Length - 1] + tkey;
                tkey = tkey.Remove(tkey.Length - 1);
            }
            return tkey;
        }
        private string KeyToPrevRound(string tkey)
        {
            for (int i = 0; i < 2; i++)
            {
                tkey = tkey + tkey[0];
                tkey = tkey.Remove(0, 1);
            }
            return tkey;
        }*/
        private void button4_Click(object sender, EventArgs e)
        {
            /*openFileDialog1.Filter = "txt file (*.txt)|*.txt";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                input = openFileDialog1.FileName;
                saveFileDialog.Filter = "txt file (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    output = saveFileDialog.FileName;
                }*/
                openFileDialog1.Filter = "des file |*.des";
                openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                input = openFileDialog1.FileName;
                saveFileDialog.Filter = "txt file (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    output = saveFileDialog.FileName;
                    DecryptDES(input, output);
                }
            }
            labelText.Text = "Результат дешифрования";
        }

        private void KeyBox_MouseHover(object sender, EventArgs e)
        {
            /*if (KeyBox.Text != "")
            {

            string temp = KeyBox.Text;
                KeyBox.Text = Convert.ToString(Convert.ToInt32(key), 2);
            }*/
        }

        private void KeyBox_MouseLeave(object sender, EventArgs e)
        {
            //KeyBox.Text = key;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFile();
            labelText.Text = "Результат шифрования";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void KeyBox_TextChanged(object sender, EventArgs e)
        {
            key=KeyBox.Text;
        }
    }
}
