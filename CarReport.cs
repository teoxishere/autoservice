using AutoService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    public partial class CarReport : Form
    {

        private int _selectedCarId;
        private MainMenu mm;
        public CarReport()
        {
            InitializeComponent();
        }
        public CarReport(MainMenu _aMenu, int id)
        {
            InitializeComponent();
            _selectedCarId = id;

            mm = _aMenu;
            var allTheCars = mm.db.Cars
                .Select(c => new { c.Make, c.Model })
                .ToList();

            //  label2.Text = comboBox1.SelectedText;
            tabControl2.SelectedIndex = 0;
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs arg)
        {
            if (tabControl2.SelectedTab.Text.ToLower() == "raport piese masina")
            {
                populateCarDataListView();
            }
            else if (tabControl2.SelectedTab.Text.ToLower() == "raport piese vandute")
            {
                var soldPartsOfCar = mm.db.Parts.Include("Cars")
                                         .Where(p => p.isAvailable == false)
                                         .Select(p => new
                                         {
                                             Nume = p.Name,
                                             Cod = p.Oem_Code,
                                             Pret = p.Price,
                                             Cantitate_Vanduta = p.SoldQuantity,
                                             Castig_Piesa = (double?)(p.SoldQuantity * p.Price) ?? 0
                                         })

                                         .ToList();
                carReportListView2.DataSource = soldPartsOfCar;
                carReportListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                carReportListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else if (tabControl2.SelectedTab.Text.ToLower() == "raport piese stoc")
            {
                var stockPartsOfCar = mm.db.Parts.Include("Cars")
                                            .Where(p => p.InStock == true)
                                            .Select(p => new
                                            {
                                                Nume = p.Name,
                                                Cod = p.Oem_Code,
                                                Pret = p.Price,
                                                Cantitate_Stoc = p.Quantity,
                                            })

                                            .ToList();
                carReportListView3.DataSource = stockPartsOfCar;
                carReportListView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                carReportListView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbResult_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void populateCarDataListView()
        {
            var allPartsOfCar = mm.db.Cars
                .Where(c => c.Id == _selectedCarId)
                .Include(c => c.Parts)
                .SelectMany(c => c.Parts)
                .Select(p => new
                {
                    Nume = p.Name,
                    Cod = p.Oem_Code,
                    Pret = p.Price,
                    Stoc = p.InStock
                })
                                            .ToList();
            carReportListView1.DataSource = allPartsOfCar;
            carReportListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            carReportListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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

        private void CarReport_Load(object sender, EventArgs e)
        {
            populateCarDataListView();
        }
    }
}
