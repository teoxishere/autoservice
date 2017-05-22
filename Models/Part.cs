﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Part
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Oem_Code { get; set; }
        public string BarCode { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public string Color { get; set; }

        public bool InStock { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public override string ToString()
        {
            var s = Name;
            return s;

    }
    }
    
}
