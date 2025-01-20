using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class CustomerInfo
    {

        public CustomerInfo
            (string name, string surname, int yearBorn,
            bool gender, string adress, string postalcode, string city, string country, string telephoneNumber)
        {

            Name = name;
            Surname = surname;
            YearBorn = yearBorn;
            Gender = gender;
            Adress = adress;
            PostalCode = postalcode;
            City = city;
            Country = country;
            TelephoneNumber = telephoneNumber;
        }

        public CustomerInfo()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int YearBorn { get; set; }
        public bool Gender { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string TelephoneNumber { get; set; }
        public int LoggInInfoId { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual LoggInInfo LoggInInfo { get; set; }


    }
}
