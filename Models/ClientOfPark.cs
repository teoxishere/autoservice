﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class ClientOfPark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string Address { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string J { get; set; }
        public bool IsActive { get; set; }
        public string Phone { get; set; }
    }
}
