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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.carReportListView1 = new BrightIdeasSoftware.DataListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.carReportListView2 = new BrightIdeasSoftware.DataListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.carReportListView3 = new BrightIdeasSoftware.DataListView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carReportListView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carReportListView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carReportListView3)).BeginInit();
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
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(0, 111);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(627, 397);
            this.tabControl2.TabIndex = 2;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.carReportListView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(619, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Raport Piese Masina";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // carReportListView1
            // 
            this.carReportListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.carReportListView1.DataSource = null;
            this.carReportListView1.GridLines = true;
            this.carReportListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.carReportListView1.Location = new System.Drawing.Point(2, 0);
            this.carReportListView1.MultiSelect = false;
            this.carReportListView1.Name = "carReportListView1";
            this.carReportListView1.ShowGroups = false;
            this.carReportListView1.ShowSortIndicators = false;
            this.carReportListView1.Size = new System.Drawing.Size(614, 412);
            this.carReportListView1.SortGroupItemsByPrimaryColumn = false;
            this.carReportListView1.TabIndex = 6;
            this.carReportListView1.UseCompatibleStateImageBehavior = false;
            this.carReportListView1.View = System.Windows.Forms.View.Details;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.carReportListView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(619, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Raport Piese Vandute";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // carReportListView2
            // 
            this.carReportListView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.carReportListView2.DataSource = null;
            this.carReportListView2.GridLines = true;
            this.carReportListView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.carReportListView2.Location = new System.Drawing.Point(2, 3);
            this.carReportListView2.MultiSelect = false;
            this.carReportListView2.Name = "carReportListView2";
            this.carReportListView2.ShowGroups = false;
            this.carReportListView2.ShowSortIndicators = false;
            this.carReportListView2.Size = new System.Drawing.Size(614, 409);
            this.carReportListView2.SortGroupItemsByPrimaryColumn = false;
            this.carReportListView2.TabIndex = 6;
            this.carReportListView2.UseCompatibleStateImageBehavior = false;
            this.carReportListView2.View = System.Windows.Forms.View.Details;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.carReportListView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(619, 371);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Raport Piese Stoc";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // carReportListView3
            // 
            this.carReportListView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.carReportListView3.DataSource = null;
            this.carReportListView3.GridLines = true;
            this.carReportListView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.carReportListView3.Location = new System.Drawing.Point(2, 0);
            this.carReportListView3.MultiSelect = false;
            this.carReportListView3.Name = "carReportListView3";
            this.carReportListView3.ShowGroups = false;
            this.carReportListView3.ShowSortIndicators = false;
            this.carReportListView3.Size = new System.Drawing.Size(614, 409);
            this.carReportListView3.SortGroupItemsByPrimaryColumn = false;
            this.carReportListView3.TabIndex = 5;
            this.carReportListView3.UseCompatibleStateImageBehavior = false;
            this.carReportListView3.View = System.Windows.Forms.View.Details;
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
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CarReport";
            this.Text = "CarReport";
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carReportListView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carReportListView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carReportListView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private BrightIdeasSoftware.DataListView carReportListView1;
        private BrightIdeasSoftware.DataListView carReportListView2;
        private BrightIdeasSoftware.DataListView carReportListView3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}