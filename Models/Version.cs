using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Models
{
    public class Version
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int EngineId {get;set;}
        public Engine Engine { get; set; }
        public int BodyId { get; set; }
        public Body Body { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public override string ToString()
        {
            var s = Name;
            if (Year > 0)
            {
                s += " ("+Year+")";
            }
            return s;
        }
    }
}
