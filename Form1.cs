using LabsInformationProtection.lab1;
using LabsInformationProtection.lab2;

namespace LabsInformationProtection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Labs1 labs1 = new Labs1();
            labs1.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Labs2 labs2 = new Labs2();
            labs2.Show();
        }
    }
}