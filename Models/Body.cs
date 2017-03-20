using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Body
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<Version> Versions { get; set; }
    }
}
