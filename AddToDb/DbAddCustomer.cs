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

            Models.LoggInInfo loggInInfo = createCustomerAccount.CreateAcount();
            Models.CustomerInfo customer =  createCustomerAccount.CreatePersonalInfo();

            using (var dB = new Models.MyDbContext())
            {
                customer.LoggInInfo = loggInInfo; 
                dB.CustomerInfo.Add(customer);
                dB.SaveChanges();
            }
        }
    }
}
