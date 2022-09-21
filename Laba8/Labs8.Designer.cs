namespace LabsInformationProtection.Laba8
{
    partial class Labs8
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
            this.button1 = new System.Windows.Forms.Button();
            this.InputText = new System.Windows.Forms.TextBox();
            this.outputText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Реализовать шифрование сообщения  методом однократного гаммирования, используя бл" +
    "оки \r\nоткрытого текста длиной 32 бита и используя в алгоритме шифрования операци" +
    "ю сложения. (11)\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Зашифровать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputText
            // 
            this.InputText.Location = new System.Drawing.Point(12, 56);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(547, 23);
            this.InputText.TabIndex = 2;
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(12, 114);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(547, 23);
            this.outputText.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(289, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Расшифровать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Labs8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 164);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Labs8";
            this.Text = "Лабораторная работа №8";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Labs8_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox InputText;
        private TextBox outputText;
        private Button button2;
    }
}