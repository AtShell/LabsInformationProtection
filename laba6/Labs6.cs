using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabsInformationProtection.laba6
{
    public partial class Labs6 : Form
    {
        public Labs6()
        {
            InitializeComponent();
        }

        private void Labs6_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
        }
    }
}
