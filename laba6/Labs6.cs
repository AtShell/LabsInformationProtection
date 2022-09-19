using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LabsInformationProtection.laba6
{
    public partial class Labs6 : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();//input file
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();//compress file
        SaveFileDialog saveFileDialog2 = new SaveFileDialog();//decompress file
        public Labs6()
        {
            InitializeComponent();
            CompressorAlgorithm = new PbvCompressorLZW();
        }

        private void Labs6_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CompressorAlgorithm = new PbvCompressorLZW();
            if (InputFile.Text != "")
                Compress();
            OutputFile.Text = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName) + ".LZW";
        }
        private void OpenFile()
        {
            string tempSave = "";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                InputFile.Text = openFileDialog1.SafeFileName;
                /*saveFileDialog1.FileName= openFileDialog1.FileName.Remove
                    (openFileDialog1.FileName.Length - 3, 3) + "LZW";
                OutputFile.Text = InputFile.Text.Remove(InputFile.Text.Length - 3, 3) + "LZW";
                FileBeforeLZW.Text= InputFile.Text.Remove(InputFile.Text.Length - 3, 3)+"(NEW)" + InputFile.Text.Remove(0,InputFile.Text.Length - 3);*/
                //saveFileDialog1.FileName= openFileDialog1.FileName;
            }
        }
        private void Compress()
        {
            saveFileDialog1.Filter = "Text file(*.LZW)|*.LZW";
            saveFileDialog1.ShowDialog();
            _compressorAlgorithm.Compress(openFileDialog1.FileName,
                    saveFileDialog1.FileName);
        }        
        private void Decompress()
        {
            saveFileDialog2.ShowDialog();
            _compressorAlgorithm.Decompress(saveFileDialog1.FileName,
                saveFileDialog2.FileName);
        }
        private void SaveFile(bool decode)
        {
            if (decode == true)
            {
                //saveFileDialog2.Filter = "Text file(*.txt)|*.txt";
                saveFileDialog2.ShowDialog();
            }
            if (decode == false)
            {
                saveFileDialog1.Filter = "Text file(*.LZW)|*.LZW";
                saveFileDialog1.ShowDialog();
            }
        }
        private ICompressorAlgorithm _compressorAlgorithm;

        public ICompressorAlgorithm CompressorAlgorithm
        {
            set
            {
                _compressorAlgorithm = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (InputFile.Text != "")
                Decompress();
        }
    }
}
