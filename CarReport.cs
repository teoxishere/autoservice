using AutoService.Models;
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
    public partial class CarReport : Form
    {
        
        private Car _selectedCar;
        private MainMenu mm;
        public CarReport()
        {
            InitializeComponent();
        }
        public CarReport(MainMenu _aMenu)
        {
            InitializeComponent();
           // _selectedCar = _aCar;
            mm = _aMenu;
            var allTheCars = mm.db.Cars
                .Select(c => new { c.Make, c.Model })
                .ToList();
            comboBox1.DataSource = allTheCars;
            label2.Text = comboBox1.SelectedText;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbResult_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void lbParts_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void searchCbEngine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchCbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchCbModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchCbMake_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
