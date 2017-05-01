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
    public partial class LoginForm : Form
    {
        private List<Models.User> _users;

        private Context db = new Context();


       
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUser.Text))
            {
                MessageBox.Show("Introduceti utilizatorul!");
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Introduceti parola!");
                return;
            }
            var theUserWithThatUsername = db.Users.FirstOrDefault(u => u.Username.ToLower().Equals(tbUser.Text.ToLower()));
            if (theUserWithThatUsername == null)
            {
                MessageBox.Show("Utilizatorul nu exista!");
                return;
            }
            if (!tbPassword.Text.Equals(theUserWithThatUsername.Password))
            {
                MessageBox.Show("Parola este incorecta!");
                return;
            }
            theUserWithThatUsername.Password = null;
            UserService.LoggedInUser = theUserWithThatUsername;
            var mw = new MainMenu();
            mw.Show();
            this.Hide();
        }
    }
}
