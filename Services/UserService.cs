using AutoService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Services
{
    public class UserService
    {
        public static User LoggedInUser { get; set; } // TO BE POPULATED ON LOGIN
    }
}
