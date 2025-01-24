using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class UserInfo
    {
        public UserInfo()
        { }


        public UserInfo
            (string adress, string postalcode, string city, string country, string telephoneNumber)
        {
            Adress = adress;
            PostalCode = postalcode;
            City = city;
            Country = country;
            TelephoneNumber = telephoneNumber;
        }


        public int Id { get; set; }      
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string TelephoneNumber { get; set; }
        public bool MainInfo { get; set; }


        public int UserId { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual User User { get; set; }



    }
}
