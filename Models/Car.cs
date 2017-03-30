using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Fuel { get; set; }
        public string Body { get; set; }
        public string Oem_Code { get; set; }
        public DateTime Year { get; set; }
        public Double Power { get; set; }
        public Double Capacity { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
