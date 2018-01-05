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
                            Id = x.Id,
                            NumePiesa = x.Part.Name,
                            Cantitate = x.Quantity,
                            PretPerPiesa = x.Price
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
                        Id = c.Id,
                        NumePiesa = c.Part.Name,
                        Cantitate = c.Quantity,
                        PretperPiesa = c.Price
                    }
                    ).ToList();
                CartService.Cart.CartDetails = lastCart.CartDetails;
                CartService.Cart = lastCart;
                dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        // method to populate client
        public void PopulateClientObject(ClientOfPark client)
        {
            this.client = client;
        }

        //delete cart
        private void button1_Click(object sender, EventArgs e)
        {
            mm.db.CartDetails.RemoveRange(CartService.Cart.CartDetails);
            mm.db.SaveChanges();
            CartService.RefreshCart(mm.db);
            dataListView1.DataSource = CartService.Cart.CartDetails
                .Select(x => new
                {
                    Id = x.Id,
                    NumePiesa = x.Part.Name,
                    Cantitate = x.Quantity,
                    PretPerPiesa = x.Price
                })
                .ToList();

            mm.ReCheck();

            this.Close();
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
                if (cartItem.PartId.HasValue)
                {
                    // this is a part
                    var part = mm.db.Parts.Find(cartItem.PartId.Value);
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
                } else
                {
                    // this is a service
                    // TODO
                }
            }
            DialogResult result = MessageBox.Show("Adaugare date cumparator? ", "Confirmare", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                // client is null here
                new ClientAddForm(this).ShowDialog(); // open the dialog and pass the null client to it to be populated
                // here we have the populated AND SAVED client via PopulateClient method

                if (client == null || client.Id <= 0)
                {
                    client = new ClientOfPark()
                    {
                        Name = "_______________",
                        RegNo = "_______________",
                        J = "_______________",
                        Address = "_______________",
                        BankAccount = "_______________",
                        BankName = "_______________",
                        Phone = "_______________"
                    };
                }
            }
            else if (result == DialogResult.No)
            {
                client = new ClientOfPark()
                {
                    Name = "_______________",
                    RegNo = "_______________",
                    J = "_______________",
                    Address = "_______________",
                    BankAccount = "_______________",
                    BankName = "_______________",
                    Phone= "_______________"
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
            mm.ReCheck();
        }

        private void dataListView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                var selectedRow = dataListView1.SelectedItem;
                if (selectedRow != null && selectedRow.RowObject != null)
                {
                    var theOldDataSource = dataListView1.DataSource as IEnumerable<object>;
                    theOldDataSource = theOldDataSource.Except(new[] { selectedRow.RowObject }).ToList();
                    dataListView1.DataSource = theOldDataSource;

                    // delete from db
                    // get id
                    dynamic dbObject = selectedRow.RowObject;
                    var selectedObjectId = (int)dbObject.Id;
                    var toBeDeleted = mm.db.CartDetails.Find(selectedObjectId);
                    if (toBeDeleted != null)
                    {
                        mm.db.CartDetails.Remove(toBeDeleted);
                        mm.db.SaveChanges();
                    }
                }
            }
        }

        private void CartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mm.ReCheck();
        }
    }
}
