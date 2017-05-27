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
using AutoService.Services;

namespace AutoService
{
    public partial class PartInfoForm : Form
    {
        private Car _selectedCar;
        private Part _selectedPart;
        private Context db;

        public PartInfoForm()
        {
            InitializeComponent();
        }

        public PartInfoForm(Car _selectedCar,Part _selectedPart, Context db)
        {
            InitializeComponent();
            this.db = db;
            this._selectedCar = _selectedCar;
            this._selectedPart = _selectedPart;
        //    infoTbCar.Text = _selectedCar.Make + " " + _selectedCar.Model + " an " + _selectedCar.Year + " motor "
        //        + _selectedCar.Capacity + " pret: " + _selectedCar.Price;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Cantitatea este necesara.");
                return;
            }
            int qty;
            if (!int.TryParse(textBox1.Text, out qty))
            {
                MessageBox.Show("Cantitate invalida");
                return;
            }
            if (qty > _selectedPart.Quantity)
            {
                MessageBox.Show("Stoc insuficient.");
                return;
            }
            if (CartService.Cart.Id == 0)
            {
                // save the cart first
                CartService.Cart.Username = UserService.LoggedInUser.Username;
                CartService.Cart.CreatedDate = DateTime.Now;
                db.Carts.Add(CartService.Cart);
                db.SaveChanges();
            }
            // the cart is in the db, add a detail
            var cartDetails = new CartDetail
            {
                CartId = CartService.Cart.Id,
                PartId = _selectedPart.Id,
                Quantity = qty,
                PriceOfPart = _selectedPart.Price
            };
            db.CartDetails.Add(cartDetails);
            db.SaveChanges();
            CartService.RefreshCart(db);
            this.Close();
            MessageBox.Show(qty + " x " + _selectedPart.Name + " au fost adaugate in cos.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var partToRemove = db.Parts
                                 .Where(p=>p.Id==_selectedPart.Id)
                                 .FirstOrDefault();
            partToRemove.InStock = false;
            partToRemove.Quantity = 0;
            db.SaveChanges();
            MessageBox.Show("Piesa casata!");
            this.Close();
        }
    }
}
