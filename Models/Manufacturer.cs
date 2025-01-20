using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Helpers;

namespace WebbShoppen1._0.Models
{
    internal class Manufacturer : IHasInfo
    {
        public Manufacturer() { }

        public Manufacturer(string name) 
        { 
            Name = name;
        }



        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
