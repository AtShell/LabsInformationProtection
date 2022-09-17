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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LabsInformationProtection.laba5
{
    public partial class Labs5 : Form
    {
        string[,] errors;
        bool interferences = false;
        public Labs5()
        {
            InitializeComponent();
        }

        private void Labs5_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
        }
        private string CheckString(char c)
        {
            string res = Convert.ToString(c, 2);
            while (res.Length < 8)
                res = "0" + res;
            return res;
        }
        private void ContinuousTransmission()
        {
            BinaryInputMessage.Text = "";
            foreach (var v in InputMessage.Text)
                BinaryInputMessage.Text += CheckString(v) + $"[{AddControlBit(Convert.ToString(v, 2))}]" + " ";
            BinaryOutputMessage.Text = Decrypt(BinaryInputMessage.Text);
            ListErrors();
        }
        private void InputMessage_TextChanged(object sender, EventArgs e)
        {
            if ((!Regex.IsMatch(InputMessage.Text, @"^[a-zA-Z0-9 ]+$"))&&InputMessage.Text.Length>0)
                MessageBox.Show("Доступны только 0-9 и a-z(A-Z)");
            else
                ContinuousTransmission();
        }
        private string AddControlBit(string s)
        {
            int[] mass = s.Select(ch => int.Parse(ch.ToString())).ToArray();
            int[] mass1 = new int[mass.Length];
            mass1 = mass;
            int count = 0;
            string result = "";
            for (int i = 0; i < mass.Length; i++)
                count += mass[i] * mass1[i];
            if (count > 1)
                result = Convert.ToString(count % 2);
            else
                result = Convert.ToString(count);
            return result;
        }
        private string ControlBitDecoding(string str)
        {
            int[] mass = str.Select(ch => int.Parse(ch.ToString())).ToArray();
            int a = Convert.ToInt16(mass[mass.Length - 1]);
            int[] mass1 = new int[mass.Length];
            mass1 = mass;
            int count = 0;
            int result;
            for (int i = 0; i < mass.Length - 1; i++)
                count += mass[i] * mass1[i];
            if (count > 1)
                result = count % 2;
            else
                result = count;
            if (result == a)
                return "Нет ошибки";
            else
                return "Ошибка";
        }
        private string Interferences(string input)
        {
            string temp = "";
            Random rand = new Random();
            int error = rand.Next(0, 2);
            foreach (var v in input)
            {
                if (v != ' ')
                {
                    if (v == '1' && error == 1)
                    {
                        temp += 0;
                        error = 0;
                    }
                    else
                        temp += v;
                }
                else
                {
                    temp += " ";
                    error = rand.Next(0, 2);
                }
            }
            return temp;
        }
        private string Decrypt(string encryptedText)
        {
            if (interferences == true)
                encryptedText = Interferences(encryptedText);
            int count = 1;
            foreach (var v in encryptedText)
                if (v == ' ')
                    count++;
            errors = new string[count - 1, 2];
            string result = "";
            string temp = "";
            int i = 0;
            foreach (var v in encryptedText)
            {
                if (v != ' ')
                {
                    if (v != '[' && v != ']')
                        temp += v;
                }
                else
                {
                    var strArr = Enumerable.Range(0, temp.Length / 8).Select(i => Convert.ToByte(temp.Substring(i * 8, 8), 2)).ToArray();
                    result += Encoding.UTF8.GetString(strArr);
                    errors[i, 0] = temp;
                    errors[i, 1] = ControlBitDecoding(temp);
                    i++;
                    temp = "";
                }
            }
            OutputMessage.Text = result;
            return encryptedText;
        }
        private void ListErrors()
        {
            ErrorArray.Text = "";
            for (int i = 0; i < errors.Length / 2; i++)
                ErrorArray.Text += $"[{i + 1}] {errors[i, 0]} => {errors[i, 1]}{Environment.NewLine}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Создать помехи\r\n")
            {
                interferences = true;
                button2.Text = "Убрать помехи";
            }
            else
            {
                interferences = false;
                button2.Text = "Создать помехи\r\n";
            }
            ContinuousTransmission();
        }
    }
}
