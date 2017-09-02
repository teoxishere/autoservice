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
            this.clientCuiCB = new System.Windows.Forms.TextBox();
            this.clientAdressTb = new System.Windows.Forms.TextBox();
            this.clientPhoneTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clientJCb = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            // clientCuiCB
            // 
            this.clientCuiCB.Location = new System.Drawing.Point(95, 60);
            this.clientCuiCB.Name = "clientCuiCB";
            this.clientCuiCB.Size = new System.Drawing.Size(280, 20);
            this.clientCuiCB.TabIndex = 2;
            // 
            // clientAdressTb
            // 
            this.clientAdressTb.Location = new System.Drawing.Point(95, 99);
            this.clientAdressTb.Name = "clientAdressTb";
            this.clientAdressTb.Size = new System.Drawing.Size(280, 20);
            this.clientAdressTb.TabIndex = 3;
            // 
            // clientPhoneTb
            // 
            this.clientPhoneTb.Location = new System.Drawing.Point(95, 133);
            this.clientPhoneTb.Name = "clientPhoneTb";
            this.clientPhoneTb.Size = new System.Drawing.Size(280, 20);
            this.clientPhoneTb.TabIndex = 4;
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
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "CUI";
            // 
            // clientJCb
            // 
            this.clientJCb.AutoSize = true;
            this.clientJCb.Location = new System.Drawing.Point(12, 106);
            this.clientJCb.Name = "clientJCb";
            this.clientJCb.Size = new System.Drawing.Size(40, 13);
            this.clientJCb.TabIndex = 7;
            this.clientJCb.Text = "Adresa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nr Telefon";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClientAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 211);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clientJCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientPhoneTb);
            this.Controls.Add(this.clientAdressTb);
            this.Controls.Add(this.clientCuiCB);
            this.Controls.Add(this.clientNameCB);
            this.Name = "ClientAddForm";
            this.Text = "ClientAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox clientNameCB;
        private System.Windows.Forms.TextBox clientCuiCB;
        private System.Windows.Forms.TextBox clientAdressTb;
        private System.Windows.Forms.TextBox clientPhoneTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label clientJCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}