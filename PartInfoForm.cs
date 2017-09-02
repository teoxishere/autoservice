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
        private MainMenu mm;
        private Car _selectedCar;
        private Part _selectedPart;
        private Context db;
        private List<Part> _cartParts;

        public PartInfoForm()
        {
            InitializeComponent();
        }

        public PartInfoForm(Car _selectedCar,Part _selectedPart, Context db, MainMenu mm)
        {
            InitializeComponent();
            this.db = db;
            this.mm = mm;
            this._selectedCar = _selectedCar;
            this._selectedPart = _selectedPart;
            
        //    infoTbCar.Text = _selectedCar.Make + " " + _selectedCar.Model + " an " + _selectedCar.Year + " motor "
        //        + _selectedCar.Capacity + " pret: " + _selectedCar.Price;
            label6.Text = _selectedPart.Name;
            label7.Text = _selectedPart.Details;
            infoTbPrice.Text = string.Concat(_selectedPart.Price);
            infoTbQty.Text = string.Concat(_selectedPart.Quantity);
            label8.Text = _selectedPart.Oem_Code;
            label11.Text = _selectedPart.Color;
            //  infoTbBarcode.Text = _selectedPart.BarCode;
            if (_selectedPart.Content != null)
            {
                pictureBox1.Image = ImageServices.byteArrayToImage(_selectedPart.Content);
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else { pictureBox1.Image = Image.FromFile("./Pics/logo2.png"); }

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

            /*      if (qty > _selectedPart.Quantity)
                  {
                      MessageBox.Show("Stoc insuficient.");
                      return;

                  }
            */
           
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

            if (qty>_selectedPart.Quantity)
            {
                MessageBox.Show("Stoc insuficient. Verifica produsele din cos!");
                return;
            }
            db.CartDetails.Add(cartDetails);
            db.SaveChanges();
            CartService.RefreshCart(db);
            _selectedPart.isAvailable = true;
            this.Close();
            mm.ReCheck("");
            MessageBox.Show(qty + " x " + _selectedPart.Name + " au fost adaugate in cos.");

           
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sunteti sigur ca vreti sa casati piesa?", "Atentie!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!_selectedPart.isAvailable)
                {
                    var partToRemove = db.Parts
                                     .Where(p => p.Id == _selectedPart.Id)
                                     .FirstOrDefault();
                    partToRemove.InStock = false;
                    partToRemove.Quantity = 0;
                    LoggingService.Log(Enums.ActionsEnum.Casare_Piesa, partToRemove.Price, "Casare piesa: " + partToRemove.Name + " de pe masina " + _selectedCar.Make + " " + _selectedCar.Model + " " + _selectedCar.Year);
                    db.SaveChanges();
                    MessageBox.Show("Piesa casata!");
                    this.Close();
                    mm.ReCheck("");
                }else
                {
                    MessageBox.Show("Piesa se afla in cos. Actiunea nu poate fi finalizata!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!_selectedPart.isAvailable)
            {
                bool okPrice = false, okQty = false;
                double price;
                int qty;
                var partToEdit = db.Parts
                                    .Where(p => p.Id == _selectedPart.Id)
                                    .FirstOrDefault();
                if (double.TryParse(infoTbPrice.Text, out price))
                {
                    partToEdit.Price = double.Parse(infoTbPrice.Text);
                    if (partToEdit.Price < 0) { partToEdit.Price = 0; }
                    okPrice = true;
                }
                else
                {
                    MessageBox.Show("Format incorect al pretului!");
                }
                if (int.TryParse(infoTbQty.Text, out qty))
                {
                    partToEdit.Quantity = int.Parse(infoTbQty.Text);
                    if (partToEdit.Quantity < 0) { partToEdit.Quantity = 0; partToEdit.InStock = false; }
                    okQty = true;
                }
                else
                {
                    MessageBox.Show("Format incorect al cantitatii!");
                }
                if (okPrice && okQty)
                {
                    LoggingService.Log(Enums.ActionsEnum.Editare_Piesa, partToEdit.Price, "Editare piesa: " + partToEdit.Name + " de pe masina" + _selectedCar.Make + " " + _selectedCar.Model + " " + _selectedCar.Year);
                    db.SaveChanges();
                    MessageBox.Show("Piesa Editata cu succes!");
                    this.Close();
                    mm.ReCheck("");
                }
                else { MessageBox.Show("Ceva nu a mers bine la editarea piesei! Contacteaza suport!"); }
            }else
            {
                MessageBox.Show("Piesa se afla in cos. Actiunea nu poate fi finalizata!");
            }
        }
    }
}
