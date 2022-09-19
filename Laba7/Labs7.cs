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
        public Labs7()
        {
            InitializeComponent();
        }

        private void Labs7_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf=new MainForm();
            mf.Show();
        }
    }
}
