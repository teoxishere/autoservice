namespace AutoService
{
    partial class Teste
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
            this.cbMarci = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVersion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca:";
            // 
            // cbMarci
            // 
            this.cbMarci.FormattingEnabled = true;
            this.cbMarci.Location = new System.Drawing.Point(66, 16);
            this.cbMarci.Name = "cbMarci";
            this.cbMarci.Size = new System.Drawing.Size(172, 21);
            this.cbMarci.TabIndex = 1;
            this.cbMarci.SelectedValueChanged += new System.EventHandler(this.cbMarci_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model:";
            // 
            // cbModel
            // 
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(66, 43);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(172, 21);
            this.cbModel.TabIndex = 3;
            this.cbModel.SelectedValueChanged += new System.EventHandler(this.cbModel_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Versiune:";
            // 
            // cbVersion
            // 
            this.cbVersion.FormattingEnabled = true;
            this.cbVersion.Location = new System.Drawing.Point(66, 70);
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(172, 21);
            this.cbVersion.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 352);
            this.Controls.Add(this.cbVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbMarci);
            this.Controls.Add(this.label1);
            this.Name = "MainWindow";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMarci;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVersion;
    }
}

