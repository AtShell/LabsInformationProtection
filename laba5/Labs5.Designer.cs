namespace LabsInformationProtection.laba5
{
    partial class Labs5
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
            this.InputMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BinaryInputMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BinaryOutputMessage = new System.Windows.Forms.TextBox();
            this.OutputMessage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ErrorArray = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputMessage
            // 
            this.InputMessage.Location = new System.Drawing.Point(14, 77);
            this.InputMessage.Name = "InputMessage";
            this.InputMessage.Size = new System.Drawing.Size(274, 23);
            this.InputMessage.TabIndex = 0;
            this.InputMessage.TextChanged += new System.EventHandler(this.InputMessage_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Исходное сообщение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Полученное сообщение";
            // 
            // BinaryInputMessage
            // 
            this.BinaryInputMessage.Location = new System.Drawing.Point(14, 127);
            this.BinaryInputMessage.Multiline = true;
            this.BinaryInputMessage.Name = "BinaryInputMessage";
            this.BinaryInputMessage.Size = new System.Drawing.Size(274, 170);
            this.BinaryInputMessage.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Двоичное представление";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Двоичное представление";
            // 
            // BinaryOutputMessage
            // 
            this.BinaryOutputMessage.Location = new System.Drawing.Point(360, 127);
            this.BinaryOutputMessage.Multiline = true;
            this.BinaryOutputMessage.Name = "BinaryOutputMessage";
            this.BinaryOutputMessage.Size = new System.Drawing.Size(274, 170);
            this.BinaryOutputMessage.TabIndex = 7;
            // 
            // OutputMessage
            // 
            this.OutputMessage.Location = new System.Drawing.Point(360, 77);
            this.OutputMessage.Name = "OutputMessage";
            this.OutputMessage.Size = new System.Drawing.Size(274, 23);
            this.OutputMessage.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(573, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "Реализовать проверку  правильности передачи двоичной кодовой последовательности д" +
    "линой 8 бит, \r\n                                             используя метод кода" +
    " с одиночным битом четности. (11)";
            // 
            // ErrorArray
            // 
            this.ErrorArray.Location = new System.Drawing.Point(640, 77);
            this.ErrorArray.Multiline = true;
            this.ErrorArray.Name = "ErrorArray";
            this.ErrorArray.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ErrorArray.Size = new System.Drawing.Size(240, 221);
            this.ErrorArray.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(640, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Статус полученных блоков";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(291, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 42);
            this.button2.TabIndex = 13;
            this.button2.Text = "Создать помехи\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Labs5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 311);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ErrorArray);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BinaryOutputMessage);
            this.Controls.Add(this.OutputMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BinaryInputMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputMessage);
            this.Name = "Labs5";
            this.Text = "Лабораторная работа №5";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Labs5_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox InputMessage;
        private Label label1;
        private Label label2;
        private TextBox BinaryInputMessage;
        private Label label3;
        private Label label4;
        private TextBox BinaryOutputMessage;
        private TextBox OutputMessage;
        private Label label5;
        private TextBox ErrorArray;
        private Label label6;
        private Button button2;
    }
}