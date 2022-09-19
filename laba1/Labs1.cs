using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabsInformationProtection.lab1;

namespace LabsInformationProtection
{
    public partial class Labs1 : Form
    {
        EnigmaMachine machine = new EnigmaMachine();
        EnigmaSettings eSettings = new EnigmaSettings();
        public Labs1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            textBox4.Text = "AAA";
            textBox5.Text = "AAA";
        }

        private void Labs1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm form1 = new MainForm();
            form1.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                radioButton2.Checked = false;
            else if (radioButton1.Checked == false)
            {
                radioButton2.Checked = true;
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
        }
        public void Encryped()
        {
            string message = textBox1.Text;
            message = message.Replace(" ", "").ToUpper();
            machine.setSettings(eSettings.rings, eSettings.grund, eSettings.order, eSettings.reflector);
            foreach (string plug in eSettings.plugs)
            {
                char[] p = plug.ToCharArray();
                machine.addPlug(p[0], p[1]);
            }
            textBox2.Text = machine.runEnigma(message);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SettingEngima(eSettings);
            Encryped();
            textBox3.Text = textBox4.Text + textBox5.Text + comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z ]+$")) && textBox1.Text.Length > 0)
            {
                MessageBox.Show("Недопустимый символ, доступны только A-Z");
            }
        }
        public void SettingEngima(EnigmaSettings e)
        {
            string rings = textBox4.Text;
            string rotors = textBox5.Text;
            string order = comboBox1.SelectedItem.ToString();
            string reflector = comboBox2.SelectedItem.ToString();
            if (textBox3.Text == "")
                e.setDefault();
            else
            {
                //rings
                if (rings == "")
                    e.grund = new char[] { 'A', 'A', 'A' };
                else
                    e.grund = rings.ToCharArray();
                //rotors
                if (rotors == "")
                    e.grund = new char[] { 'A', 'A', 'A' };
                else
                    e.grund = rotors.ToCharArray();
                //order
                e.order = "I-II-III";
                e.order = order;
                //reflector
                e.reflector = 'B';
                e.reflector = reflector.ToCharArray()[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            string order = "";
            char[] key = textBox3.Text.ToCharArray();
            for (int i = 0; i < 3; i++)
                textBox4.Text += key[i].ToString();
            for (int i = 3; i < 6; i++)
                textBox5.Text += key[i].ToString();
            for (int i = 6; i < 14; i++)
            {
                order += key[i];
                for (int j = 0; j < 6; j++)
                {
                    if (comboBox1.Items[j].ToString() == order)
                        comboBox1.SelectedIndex = j;
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (comboBox2.Items[j].ToString() == key[14].ToString())
                    comboBox2.SelectedIndex = j;
            }
        }
        /*
         * Алгоритм
         * Исходную строку посимвольно шифруем:
         * 1 ротором-2 ротором-3 ротором прохходит через рефлектор и шифруется в обратном порядке 3-2-1
         * После шифрования роторы "поворачиваются"
         */ 
    }
}
