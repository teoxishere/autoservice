namespace AutoService
{
    partial class CartForm
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
            this.dataListView1 = new BrightIdeasSoftware.DataListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataListView1
            // 
            this.dataListView1.DataSource = null;
            this.dataListView1.FullRowSelect = true;
            this.dataListView1.GridLines = true;
            this.dataListView1.Location = new System.Drawing.Point(13, 13);
            this.dataListView1.MultiSelect = false;
            this.dataListView1.Name = "dataListView1";
            this.dataListView1.ShowGroups = false;
            this.dataListView1.Size = new System.Drawing.Size(621, 261);
            this.dataListView1.TabIndex = 0;
            this.dataListView1.UseCompatibleStateImageBehavior = false;
            this.dataListView1.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Sterge tot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Vinde tot";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 316);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataListView1);
            this.Name = "CartForm";
            this.Text = "Cos";
            this.Load += new System.EventHandler(this.CartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.DataListView dataListView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}