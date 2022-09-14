using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        int sizeBlock = 16;
        string planeText = "";
        public Labs4()
        {
            InitializeComponent();
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
        private string GenerateKey()
        {
            string key = "";
            while (key.Length != 16)
            {
                Random rand = new Random();
                key = Convert.ToString(rand.Next(0, 65535), 2);
            }
            return key;
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
            if (KeyBox.Text == "")
                key = GenerateKey();
            else
                key = KeyVerification(KeyBox.Text);
            KeyBox.Text = key;
        }

        private void Labs4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
        private string StringToBinary(string input)
        {
            StringBuilder output = new StringBuilder();
            foreach (byte b in System.Text.Encoding.Default.GetBytes(input))
                output.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            while (true)
            {
                if (output.Length % sizeBlock != 0)
                    output.Append(Convert.ToString('#',2));
                else
                    break;
            }
            return output.ToString();
        }
        private string[] BitTextToBlock(string input)
        {
            string[] output = new string[input.Length/sizeBlock];
            return output;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
               textBox2.Text= StringToBinary(textBox1.Text);
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

        private void button4_Click(object sender, EventArgs e)
        {
            //Decode();
        }
    }
}
