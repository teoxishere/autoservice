namespace AutoService
{
    partial class CarReport
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
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataListView1 = new BrightIdeasSoftware.DataListView();
            this.dataListView2 = new BrightIdeasSoftware.DataListView();
            this.dataListView3 = new BrightIdeasSoftware.DataListView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Masina: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 111);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(627, 397);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataListView3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(619, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Raport Piese Masina";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataListView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(619, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Raport Piese Vandute";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataListView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(619, 415);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Raport Piese Stoc";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataListView1
            // 
            this.dataListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataListView1.DataSource = null;
            this.dataListView1.GridLines = true;
            this.dataListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.dataListView1.Location = new System.Drawing.Point(2, 0);
            this.dataListView1.MultiSelect = false;
            this.dataListView1.Name = "dataListView1";
            this.dataListView1.ShowGroups = false;
            this.dataListView1.ShowSortIndicators = false;
            this.dataListView1.Size = new System.Drawing.Size(614, 409);
            this.dataListView1.SortGroupItemsByPrimaryColumn = false;
            this.dataListView1.TabIndex = 5;
            this.dataListView1.UseCompatibleStateImageBehavior = false;
            this.dataListView1.View = System.Windows.Forms.View.Details;
            // 
            // dataListView2
            // 
            this.dataListView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataListView2.DataSource = null;
            this.dataListView2.GridLines = true;
            this.dataListView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.dataListView2.Location = new System.Drawing.Point(2, 3);
            this.dataListView2.MultiSelect = false;
            this.dataListView2.Name = "dataListView2";
            this.dataListView2.ShowGroups = false;
            this.dataListView2.ShowSortIndicators = false;
            this.dataListView2.Size = new System.Drawing.Size(614, 409);
            this.dataListView2.SortGroupItemsByPrimaryColumn = false;
            this.dataListView2.TabIndex = 6;
            this.dataListView2.UseCompatibleStateImageBehavior = false;
            this.dataListView2.View = System.Windows.Forms.View.Details;
            // 
            // dataListView3
            // 
            this.dataListView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataListView3.DataSource = null;
            this.dataListView3.GridLines = true;
            this.dataListView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.dataListView3.Location = new System.Drawing.Point(2, 0);
            this.dataListView3.MultiSelect = false;
            this.dataListView3.Name = "dataListView3";
            this.dataListView3.ShowGroups = false;
            this.dataListView3.ShowSortIndicators = false;
            this.dataListView3.Size = new System.Drawing.Size(614, 412);
            this.dataListView3.SortGroupItemsByPrimaryColumn = false;
            this.dataListView3.TabIndex = 6;
            this.dataListView3.UseCompatibleStateImageBehavior = false;
            this.dataListView3.View = System.Windows.Forms.View.Details;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(26, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(256, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // CarReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 500);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CarReport";
            this.Text = "CarReport";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private BrightIdeasSoftware.DataListView dataListView3;
        private BrightIdeasSoftware.DataListView dataListView2;
        private BrightIdeasSoftware.DataListView dataListView1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}