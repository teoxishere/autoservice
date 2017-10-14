namespace AutoService
{
    partial class ClientAddForm
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
            this.clientNameCB = new System.Windows.Forms.ComboBox();
            this.clientBankTB = new System.Windows.Forms.TextBox();
            this.clientJTB = new System.Windows.Forms.TextBox();
            this.clientBankAccountTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clientJCb = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.clientRegTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clientAddressTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clientPhoneTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // clientNameCB
            // 
            this.clientNameCB.FormattingEnabled = true;
            this.clientNameCB.Location = new System.Drawing.Point(95, 24);
            this.clientNameCB.Name = "clientNameCB";
            this.clientNameCB.Size = new System.Drawing.Size(280, 21);
            this.clientNameCB.TabIndex = 1;
            this.clientNameCB.SelectedIndexChanged += new System.EventHandler(this.clientNameCB_SelectedIndexChanged);
            // 
            // clientBankTB
            // 
            this.clientBankTB.Location = new System.Drawing.Point(95, 214);
            this.clientBankTB.Name = "clientBankTB";
            this.clientBankTB.Size = new System.Drawing.Size(280, 20);
            this.clientBankTB.TabIndex = 6;
            // 
            // clientJTB
            // 
            this.clientJTB.Location = new System.Drawing.Point(95, 139);
            this.clientJTB.Name = "clientJTB";
            this.clientJTB.Size = new System.Drawing.Size(280, 20);
            this.clientJTB.TabIndex = 4;
            // 
            // clientBankAccountTB
            // 
            this.clientBankAccountTB.Location = new System.Drawing.Point(95, 179);
            this.clientBankAccountTB.Name = "clientBankAccountTB";
            this.clientBankAccountTB.Size = new System.Drawing.Size(280, 20);
            this.clientBankAccountTB.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "CUI";
            // 
            // clientJCb
            // 
            this.clientJCb.AutoSize = true;
            this.clientJCb.Location = new System.Drawing.Point(12, 142);
            this.clientJCb.Name = "clientJCb";
            this.clientJCb.Size = new System.Drawing.Size(12, 13);
            this.clientJCb.TabIndex = 7;
            this.clientJCb.Text = "J";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Banca";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clientRegTB
            // 
            this.clientRegTB.Location = new System.Drawing.Point(95, 99);
            this.clientRegTB.Name = "clientRegTB";
            this.clientRegTB.Size = new System.Drawing.Size(280, 20);
            this.clientRegTB.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cont Bancar";
            // 
            // clientAddressTB
            // 
            this.clientAddressTB.Location = new System.Drawing.Point(95, 61);
            this.clientAddressTB.Name = "clientAddressTB";
            this.clientAddressTB.Size = new System.Drawing.Size(280, 20);
            this.clientAddressTB.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Adresa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Telefon";
            // 
            // clientPhoneTB
            // 
            this.clientPhoneTB.Location = new System.Drawing.Point(95, 248);
            this.clientPhoneTB.Name = "clientPhoneTB";
            this.clientPhoneTB.Size = new System.Drawing.Size(280, 20);
            this.clientPhoneTB.TabIndex = 15;
            // 
            // ClientAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 343);
            this.Controls.Add(this.clientPhoneTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clientAddressTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clientRegTB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clientJCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientBankAccountTB);
            this.Controls.Add(this.clientJTB);
            this.Controls.Add(this.clientBankTB);
            this.Controls.Add(this.clientNameCB);
            this.Name = "ClientAddForm";
            this.Text = "ClientAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox clientNameCB;
        private System.Windows.Forms.TextBox clientBankTB;
        private System.Windows.Forms.TextBox clientJTB;
        private System.Windows.Forms.TextBox clientBankAccountTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label clientJCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox clientRegTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clientAddressTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox clientPhoneTB;
    }
}