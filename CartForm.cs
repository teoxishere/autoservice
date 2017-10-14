﻿using AutoService.Models;
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
        private ClientOfPark client;

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
                        .Select(x => new
                        {
                            NumePiesa = x.Part.Name,
                            Cantitate = x.Quantity,
                            PretPerPiesa = x.PriceOfPart
                        })
                        .ToList();

                    dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
            else if (mm.db.Carts.Where(c => c.IsSold == false).Any())
            {
                var lastCart = mm.db.Carts
                                 .Where(cart => cart.IsSold == false)
                                 .ToList()
                                 .FirstOrDefault();
                dataListView1.DataSource = lastCart.CartDetails
                    .Select(c => new
                    {
                        NumePiesa = c.Part.Name,
                        Cantitate = c.Quantity,
                        PretperPiesa = c.PriceOfPart
                    }
                    ).ToList();
                CartService.Cart.CartDetails = lastCart.CartDetails;
                CartService.Cart = lastCart;
                dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        //delete cart
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var cartItem in CartService.Cart.CartDetails)
            {
                var part = mm.db.Parts.Find(cartItem.PartId);
                part.Quantity = 0;
                part.InStock = false;
                part.isAvailable = false;

            }
            mm.db.CartDetails.RemoveRange(CartService.Cart.CartDetails);
            mm.db.SaveChanges();
            CartService.RefreshCart(mm.db);
            dataListView1.DataSource = CartService.Cart.CartDetails
                .Select(x => new
                {
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
                    part.SoldQuantity += cartItem.Quantity;
                    LoggingService.Log(Enums.ActionsEnum.Vanzare_Piesa, part.Price * cartItem.Quantity, "S-a vandut piesa- " + part.Name + " nr bucati vandute- " + cartItem.Quantity + " pret/buc" + part.Price);
                    part.isAvailable = false;
                    if (part.Quantity == 0)
                    {
                        part.InStock = false;
                    }
                }
            }
            DialogResult result = MessageBox.Show("Adaugare date cumparator? ", "Confirmare", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                new ClientAddForm().ShowDialog();
                client = new ClientOfPark();
                client = mm.db.ClientOfParks
                    .Where(c => c.IsActive == true)
                    .Select(c => c)
                    .FirstOrDefault();

            }
            else if (result == DialogResult.No)
            {
                client = new ClientOfPark()
                {
                    Name = "_______________",
                    RegNo = "________________",
                    J = "_______________",
                    Address = "_________________",
                    BankAccount = "__________________",
                    BankName = "__________________"
                };
            }


            var dbCart = mm.db.Carts.Find(CartService.Cart.Id);
            dbCart.IsSold = true;
            client.IsActive = false;
            mm.db.SaveChanges();



            // Trigger PDF gen
            PdfService.GeneratePdf(CartService.Cart, client);

            CartService.Cart = new Cart();
            dataListView1.DataSource = new List<object>();

            this.Close();
            MessageBox.Show("Vandute.");
            mm.ReCheck("");
        }

        private void dataListView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                var selectedRow = dataListView1.SelectedItem;
                if (selectedRow != null && selectedRow.RowObject != null)
                {

                }
            }
        }
    }
}
