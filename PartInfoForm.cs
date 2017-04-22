using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoService.Models;

namespace AutoService
{
    public partial class PartInfoForm : Form
    {
        private Car _selectedCar;
        private Part _selectedPart;

        public PartInfoForm()
        {
            InitializeComponent();
        }

        public PartInfoForm(Car _selectedCar,Part _selectedPart)
        {
            InitializeComponent();

            this._selectedCar = _selectedCar;
            this._selectedPart = _selectedPart;
            infoTbCar.Text = _selectedCar.Make + " " + _selectedCar.Model + " an " + _selectedCar.Year + " motor "
                + _selectedCar.Capacity + " pret: " + _selectedCar.Price;
            infoTbName.Text = _selectedPart.Name;
            infoTbDetails.Text = _selectedPart.Details;
            infoTbPrice.Text = string.Concat(_selectedPart.Price);
            infoTbQty.Text = string.Concat(_selectedPart.Quantity);
            infoTbOEM.Text = _selectedPart.Oem_Code;
            infoTbBarcode.Text = _selectedPart.BarCode;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PartInfoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
