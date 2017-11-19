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
    public partial class ClientAddForm : Form
    {
        public Context db = new Context();
        public ClientOfPark myClient;
        public ClientAddForm()
        {
         //   myClient = client;
            InitializeComponent();
            var _selectedClients = db.ClientOfParks.Select(c => c.Name)
                                     .ToList();
            clientNameCB.DataSource = _selectedClients;
   //         clientNameCB.SelectedIndex = -1;
            
        }

        private void clientNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
           // FillUpClientField();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myClient = new ClientOfPark()
            {
                Name = clientNameCB.Text,
                RegNo = clientBankTB.Text,
                J = clientJTB.Text,
                Address = clientJTB.Text,
                BankAccount = clientBankAccountTB.Text,
                BankName=clientBankTB.Text,
                Phone=clientPhoneTB.Text,
             };
            //To be put on main page
            db.ClientOfParks.Add(myClient);
            db.SaveChanges();
            Close();
        }
        private void FillUpClientField()
        {
            if (clientNameCB.SelectedValue.ToString() != null)
            {
                var name = clientNameCB.SelectedValue.ToString();
                var wholeClient = db.ClientOfParks
                    .Select(c => c)
                    .Where(c => c.Name.Equals(name))
                    .FirstOrDefault();
            /*    if (wholeClient.Address != null)
                {
                    clientAdressTb.Text = wholeClient.Address;
                }
                else
                {
                    clientAdressTb.Text = "____________________";
                }
                if (wholeClient.PhoneNumber != "")
                {
                    clientPhoneTb.Text = wholeClient.PhoneNumber;
                }
                else
                {
                    clientPhoneTb.Text = "____________________";
                }
                if (wholeClient.RegNo != "")
                {
                    clientJCb.Text = wholeClient.RegNo;
                }
                else
                {
                    clientJCb.Text = "____________________";
                }*/
            }
        }
    }
}
