using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.AddToDb
{
    internal class AddCustomerDb
    {

        public static void AddCustomer()
        {
            Helpers.CreateCustomerAccount createCustomerAccount = new Helpers.CreateCustomerAccount();

            Models.Customer customer =  createCustomerAccount.CreateAcount();

            using (var dB = new Models.MyDbContext())
            {
                dB.Customers.Add(customer);

                dB.SaveChanges();

            }
        }


    }
}
