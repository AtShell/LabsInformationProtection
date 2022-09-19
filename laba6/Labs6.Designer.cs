namespace LabsInformationProtection.laba6
{
    partial class Labs6
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.InputFile = new System.Windows.Forms.TextBox();
            this.OutputFile = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выполнить первое сжатие, используя двухступенчатое кодирование \r\n- алгоритм Лемпе" +
    "ля-Зива, и повторное, используя алгоритм Лемпеля-Зива-Велча. (20)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Сжать файл";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputFile
            // 
            this.InputFile.Location = new System.Drawing.Point(25, 54);
            this.InputFile.Name = "InputFile";
            this.InputFile.PlaceholderText = "Исходный файл";
            this.InputFile.Size = new System.Drawing.Size(341, 23);
            this.InputFile.TabIndex = 4;
            // 
            // OutputFile
            // 
            this.OutputFile.Location = new System.Drawing.Point(25, 83);
            this.OutputFile.Name = "OutputFile";
            this.OutputFile.PlaceholderText = "Файл после сжатия";
            this.OutputFile.Size = new System.Drawing.Size(341, 23);
            this.OutputFile.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(272, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Восстановить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Labs6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.OutputFile);
            this.Controls.Add(this.InputFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Name = "Labs6";
            this.Text = "Лабораторная работа №6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Labs6_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button2;
        private Button button1;
        private TextBox InputFile;
        private TextBox OutputFile;
        private Button button3;
    }
}