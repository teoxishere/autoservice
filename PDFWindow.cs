using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    public partial class PDFWindow : Form
    {
        public PDFWindow(string name)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            openAndDisplay(name);
        }

        private void openAndDisplay(string x)
        {
            pdfViewer1.Open(@"./facturi/" + x);
        }
    }
}
