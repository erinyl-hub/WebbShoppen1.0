using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class User
    {

        public User() { }

        public User(string emailAdress, string password, string name, string surname, int yearBorn, bool gender) 
        {
            Name = name;
            Surname = surname;
            YearBorn = yearBorn;
            Gender = gender;
            EmailAdress = emailAdress;
            Password = password;
            IsAdmin = false;
        }

        public int Id { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int YearBorn { get; set; }
        public bool Gender { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; } = new List<UserInfo>();


    }
}
