using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Engine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public string Fuel { get; set; }
        public double Cc { get; set; }

        public virtual ICollection<Version> Versions { get; set; }
    }
}
