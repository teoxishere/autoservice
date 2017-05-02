using AutoService.Models;
using AutoService.Services;
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
    public partial class CartForm : Form
    {
        private MainMenu mm;

        public CartForm(MainMenu mm)
        {
            this.mm = mm;
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            if (CartService.Cart.Id > 0)
            {
                CartService.RefreshCart(mm.db);
                if (CartService.Cart.CartDetails != null)
                {
                    dataListView1.DataSource = CartService.Cart.CartDetails
                        .Select(x => new {
                            NumePiesa = x.Part.Name,
                            Cantitate = x.Quantity,
                            PretPerPiesa = x.PriceOfPart
                        })
                        .ToList();

                    dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mm.db.CartDetails.RemoveRange(CartService.Cart.CartDetails);
            mm.db.SaveChanges();
            CartService.RefreshCart(mm.db);
            dataListView1.DataSource = CartService.Cart.CartDetails
                .Select(x => new {
                    NumePiesa = x.Part.Name,
                    Cantitate = x.Quantity,
                    PretPerPiesa = x.PriceOfPart
                })
                .ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CartService.Cart.CartDetails == null || !CartService.Cart.CartDetails.Any())
            {
                MessageBox.Show("Nu aveti nimic in cos.");
                return;
            }
            foreach (var cartItem in CartService.Cart.CartDetails)
            {
                var part = mm.db.Parts.Find(cartItem.PartId);
                if (part != null)
                {
                    part.Quantity -= cartItem.Quantity;
                    LoggingService.Log(Enums.ActionsEnum.VanzarePiesa, part.Price * cartItem.Quantity, "S-a vandut piesa- " + part.Name + " nr bucati vandute- " + cartItem.Quantity + " pret/buc" + part.Price);

                    if (part.Quantity==0)
                    {
                        part.InStock = false;
                    }
                }
                
            }
            var dbCart = mm.db.Carts.Find(CartService.Cart.Id);
            dbCart.IsSold = true;
            mm.db.SaveChanges();

            
           
            // Trigger PDF gen
            PdfService.GeneratePdf(CartService.Cart);

            CartService.Cart = new Cart();
            dataListView1.DataSource = new List<object>();

            this.Close();
            MessageBox.Show("Vandute.");
            mm.ReCheck("");
        }
    }
}
