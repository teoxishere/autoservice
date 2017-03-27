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
            _users = db.Users
                    .OrderBy(us => us.Username)
                    .ToList();
            string userName = tbUser.Text;
            string userPw = tbPassword.Text;
            foreach(Models.User u in _users)
            {
                
                if(string.Compare(u.Username.ToLower(),userName.ToLower())==0 && string.Compare(u.Password,userPw)==0)
                {
                    this.Hide();
                    new MainMenu().Show();
                   // this.Close();
                    break;
                }
                else
                {
                    MessageBox.Show("Wrhong username or password!");
                }
               
            }
        }
    }
}
