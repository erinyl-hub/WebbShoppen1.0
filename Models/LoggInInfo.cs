using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class LoggInInfo
    {

        public LoggInInfo() { }

        public LoggInInfo(string emailAdress, string password) 
        {
            EmailAdress = emailAdress;
            Password = password;
            IsAdmin = false;
        }

        public int Id { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public virtual CustomerInfo Customer { get; set; }
    }
}
