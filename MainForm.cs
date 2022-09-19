using LabsInformationProtection.lab1;
using LabsInformationProtection.lab2;
using LabsInformationProtection.laba3;
using LabsInformationProtection.laba4;
using LabsInformationProtection.laba5;
using LabsInformationProtection.laba6;
using LabsInformationProtection.Laba7;
using LabsInformationProtection.Laba8;

namespace LabsInformationProtection
{
    public partial class MainForm : Form
    {
        public MainForm()
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            labs3 laba3 = new labs3();
            laba3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Labs4 labs4 = new Labs4();
            labs4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Labs5 laba5 = new Labs5();
            laba5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Labs6 laba6 = new Labs6();
            laba6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Labs7 laba7 = new Labs7();
            laba7.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Labs8 laba8 = new Labs8();
            laba8.Show();
        }
    }
}