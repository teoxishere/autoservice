using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }

        public bool IsSold { get; set; }
    }
}
