using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace LabsInformationProtection.lab2
{
    public partial class Labs2 : Form
    {
        char[] characters = new char[]{   
            '#',' ','0','1','2','3','4','5','6','7','8','9','.',',','?','!','/','*','-','+','=',
            'а','б','в','г','д','е','ё','ж','з','и','к','л','м','н','о','п','р','с',
            'т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я',
            'А','Б','В','Г','Д','Е','Ё','Ж','З','И','К','Л','М','Н','О','П','Р','С',
            'Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я'
        };
        RSA r = new RSA();
        List<BigInteger> BlockText=new List<BigInteger>();
        public Labs2()
        {
            InitializeComponent();
        }
        private List<BigInteger> getListBlockData(string str)
        {
            List<BigInteger> list = new List<BigInteger>();
            for(int i = 0; i < str.Length; i++)
                list.Add(Array.IndexOf(characters, str[i]));
            return list;
        }
        private void CreateKey()
        {
            DialogResult result=MessageBox.Show("Ключи отсутсвуют\nЗагрузить ключ?", "Предупреждение",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OpenFile();
            }
        }
        private void OpenFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RSA));
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt file (*.xml)|*.xml";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate))
                {
                    r = xmlSerializer.Deserialize(fs) as RSA;
                    textP.Text = r.P.ToString();
                    textQ.Text = r.Q.ToString();
                    textD.Text = r.D.ToString();
                    textN.Text = r.N.ToString();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textInput.Text, @"^@""^[а-яА-Яa-zA-Z ]+$")) && textInput.Text.Length > 0)
                MessageBox.Show("Недопустимый символ, доступны только русские буквы, символы и цифры");
            else
            {
                if ((textP.Text != "") || (textQ.Text != "") || (textN.Text != "") || (textD.Text != ""))
                {
                    textOutput.Text = "";
                    BlockText = getListBlockData(textInput.Text);
                    foreach (var v in BlockText)
                        textOutput.Text += r.encode(v) + " ";
                }
                else
                {
                    CreateKey();
                }
            }
        }
        
        private void Labs2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm form1 = new MainForm();
            form1.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textOutput.Text, @"^[а-яА-Яa-zA-Z ]+$")) && textOutput.Text.Length > 0)
                MessageBox.Show("Недопустимый формат ввода");
            else
            {
                if ((textP.Text != "") || (textQ.Text != "") || (textN.Text != "") || (textD.Text != ""))
                {
                    List<BigInteger> list = new List<BigInteger>();
                    string temp = "";
                    foreach (var v in textOutput.Text)
                    {
                        if (v == ' ')
                        {
                            list.Add(Convert.ToUInt64(temp));
                            temp = "";
                        }
                        else
                            temp += v;
                    }
                    textOutput.Text = "";
                    foreach (var v in list)
                        textOutput.Text += characters[(int)r.decode(v)].ToString();
                }
                else
                {
                    CreateKey();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            r = new RSA();
            textP.Text = r.P.ToString();
            textQ.Text = r.Q.ToString();
            textD.Text = r.D.ToString();
            textN.Text = r.N.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveKey();
        }
        private void SaveKey()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RSA));
            using (FileStream fs = new FileStream("Labs2Key.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, r);

                MessageBox.Show("Ключ успешно сохранен");
            }
        }
    }
}