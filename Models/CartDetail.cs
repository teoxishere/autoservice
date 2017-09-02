using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class CartDetail
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public int Quantity { get; set; }
        public int PartId { get; set; }
        public virtual Part Part { get; set; }
        public double PriceOfPart { get; set; }

      
    }
}
