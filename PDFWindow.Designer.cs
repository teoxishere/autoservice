namespace AutoService
{
    partial class PDFWindow
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
            this.pdfViewer1 = new ceTe.DynamicPDF.Viewer.PdfViewer();
            this.SuspendLayout();
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfViewer1.Location = new System.Drawing.Point(1, -1);
            this.pdfViewer1.MinimumSize = new System.Drawing.Size(200, 150);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.NavigationPanelWidth = 245;
            this.pdfViewer1.Size = new System.Drawing.Size(285, 260);
            this.pdfViewer1.TabIndex = 0;
            this.pdfViewer1.VisibleNavigationPane = ceTe.DynamicPDF.Viewer.NavigationPane.None;
            // 
            // PDFWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pdfViewer1);
            this.Name = "PDFWindow";
            this.Text = "PDFWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private ceTe.DynamicPDF.Viewer.PdfViewer pdfViewer1;
    }
}