using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Part
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
    }
}
