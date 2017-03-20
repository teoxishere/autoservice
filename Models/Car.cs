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
        public int VersionId { get; set; }
        public Version Version { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
