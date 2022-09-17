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
                saveFileDialog.Filter = "des file |*.des";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    output = saveFileDialog.FileName;
                    EncryptDES(input, output);
                    StreamReader sr = new StreamReader(saveFileDialog.FileName);
                    textOutput.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }
        private void EncryptDES(string source, string destination)
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
        private void DecryptDES(string source, string destination)
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
        }
        private string GenerateKey()
        {
            string rnd = "";
            while (rnd.Length != 8)
            {
                Random rand = new Random();
                rnd = rand.Next(0, 99999999).ToString();
            }
            return rnd;
        }
        private void Labs4_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm form1 = new MainForm();
            form1.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
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
            StreamReader sr = new StreamReader(saveFileDialog.FileName);
            textOutput.Text = sr.ReadToEnd();
            sr.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (KeyBox.Text == "" || KeyBox.Text.Length > 8)
            {
                key = GenerateKey();
                KeyBox.Text = key;
            }
            OpenFile();
            labelText.Text = "Результат шифрования";
        }
        private void KeyBox_TextChanged(object sender, EventArgs e)
        {
            key = KeyBox.Text;
        }
    }
}