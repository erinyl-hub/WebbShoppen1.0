using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Helpers;

namespace WebbShoppen1._0.Models
{
    internal class Supplier : IHasInfo
    {
        public Supplier() { }

        public Supplier(string name,string adress, string postalCode, string city, string telephoneNumber, bool manufacturer) 
        {
            Name = name;
            Adress = adress;
            PostalCode = postalCode;
            City = city;
            TelephoneNumber = telephoneNumber;
            Manufacturer = manufacturer;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string TelephoneNumber { get; set; }
        public bool Manufacturer { get; set; } = false;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
