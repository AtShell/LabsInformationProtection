namespace LabsInformationProtection.laba4
{
    partial class Labs4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.KeyBox = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.labelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Реализовать шифрование бинарного файла,\r\n методом блочного шифрования, используя " +
    "\r\nблоки длиной 16 бит, ключ длиной 16 бит, \r\nреализуя в алгоритме шифрования мет" +
    "одику DES.  (15)\r\n";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 141);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 23);
            this.button4.TabIndex = 44;
            this.button4.Text = "Расшифровать файл";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // KeyBox
            // 
            this.KeyBox.Location = new System.Drawing.Point(57, 83);
            this.KeyBox.MaxLength = 16;
            this.KeyBox.Name = "KeyBox";
            this.KeyBox.Size = new System.Drawing.Size(141, 23);
            this.KeyBox.TabIndex = 46;
            this.KeyBox.TextChanged += new System.EventHandler(this.KeyBox_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(13, 112);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(131, 23);
            this.button5.TabIndex = 47;
            this.button5.Text = "Зашифровать файл";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 48;
            this.label4.Text = "Ключ";
            // 
            // textOutput
            // 
            this.textOutput.Location = new System.Drawing.Point(329, 23);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.Size = new System.Drawing.Size(459, 163);
            this.textOutput.TabIndex = 49;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(329, 5);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(136, 15);
            this.labelText.TabIndex = 50;
            this.labelText.Text = "Результат шифрования";
            // 
            // Labs4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 198);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.KeyBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Name = "Labs4";
            this.Text = "Лабораторная работа №4 DES";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Labs4_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button4;
        private TextBox KeyBox;
        private Button button5;
        private Label label4;
        private TextBox textOutput;
        private Label labelText;
    }
}