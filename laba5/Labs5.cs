using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabsInformationProtection.laba5
{
    public partial class Labs5 : Form
    {
        public Labs5()
        {
            InitializeComponent();
        }

        private void Labs5_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void InputMessage_TextChanged(object sender, EventArgs e)
        {
            BinaryInputMessage.Text = "";
            foreach (var v in InputMessage.Text)
                BinaryInputMessage.Text += Convert.ToString(v,2)+$"[{AddControlBit(Convert.ToString(v, 2))}]" +"  ";
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
    }
}
