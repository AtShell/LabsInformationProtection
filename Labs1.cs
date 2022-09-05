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

namespace LabsInformationProtection
{
    public partial class Labs1 : Form
    {
        EnigmaMachine machine = new EnigmaMachine();
        EnigmaSettings eSettings = new EnigmaSettings();
        public Labs1()
        {
            InitializeComponent();
        }

        private void Labs1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                radioButton2.Checked = false;
            else if (radioButton1.Checked == false)
                radioButton2.Checked = true;
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
            string enc = machine.runEnigma(message);
            textBox2.Text = enc;
        }
        public void Decryped()
        {
            ///write decryped
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                Encryped();
            else
                Decryped();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z ]+$"))&& textBox1.Text.Length>0)
            {
                MessageBox.Show("Недопустимый символ, доступны только A-Z");
            }
        }
    }
}
