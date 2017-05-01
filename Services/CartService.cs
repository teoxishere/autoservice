using AutoService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Services
{
    public class CartService
    {
        public static Cart Cart { get; set; } = new Cart();

        public static void RefreshCart(Context db)
        {
            Cart = db.Carts.Where(c => c.Id == Cart.Id)
                .Include(c => c.CartDetails.Select(x => x.Part))
                .FirstOrDefault();
        }
    }
}
