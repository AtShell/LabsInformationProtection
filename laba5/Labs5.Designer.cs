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
            this.SuspendLayout();
            // 
            // InputMessage
            // 
            this.InputMessage.Location = new System.Drawing.Point(11, 77);
            this.InputMessage.Name = "InputMessage";
            this.InputMessage.Size = new System.Drawing.Size(274, 23);
            this.InputMessage.TabIndex = 0;
            this.InputMessage.TextChanged += new System.EventHandler(this.InputMessage_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Исходное сообщение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Полученное сообщение";
            // 
            // BinaryInputMessage
            // 
            this.BinaryInputMessage.Location = new System.Drawing.Point(11, 127);
            this.BinaryInputMessage.Multiline = true;
            this.BinaryInputMessage.Name = "BinaryInputMessage";
            this.BinaryInputMessage.Size = new System.Drawing.Size(274, 62);
            this.BinaryInputMessage.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Двоичное представление";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Двоичное представление";
            // 
            // BinaryOutputMessage
            // 
            this.BinaryOutputMessage.Location = new System.Drawing.Point(343, 127);
            this.BinaryOutputMessage.Multiline = true;
            this.BinaryOutputMessage.Name = "BinaryOutputMessage";
            this.BinaryOutputMessage.Size = new System.Drawing.Size(274, 62);
            this.BinaryOutputMessage.TabIndex = 7;
            // 
            // OutputMessage
            // 
            this.OutputMessage.Location = new System.Drawing.Point(343, 77);
            this.OutputMessage.Name = "OutputMessage";
            this.OutputMessage.Size = new System.Drawing.Size(274, 23);
            this.OutputMessage.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(495, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "Реализовать проверку  правильности передачи двоичной кодовой последовательности \r" +
    "\nдлиной 8 бит, используя метод кода с одиночным битом четности. (11)";
            // 
            // Labs5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}