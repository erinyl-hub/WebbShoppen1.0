using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.AddToDb
{
    internal class DbAddCustomer
    {

        public static void AddCustomer()
        {
            Helpers.AddCustomerAccount createCustomerAccount = new Helpers.AddCustomerAccount();

            Models.Customer customer =  createCustomerAccount.CreateAcount();

            using (var dB = new Models.MyDbContext())
            {
                dB.Customers.Add(customer);
                dB.SaveChanges();
            }
        }
    }
}
