using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabsInformationProtection.Laba8
{
    public partial class Labs8 : Form
    {
        public Labs8()
        {
            InitializeComponent();
        }

        private void Labs8_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
        }
    }
}
