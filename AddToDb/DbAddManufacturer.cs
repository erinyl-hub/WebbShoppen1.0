using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Models;

namespace WebbShoppen1._0.AddToDb
{
    internal class DbAddManufacturer
    {
        public static void AddManufacturer()
        {
            Helpers.AddManufacturer addManufacturer = new Helpers.AddManufacturer();
            Models.Manufacturer manufacturer = addManufacturer.CreateManufacturer();

            using (var dB = new MyDbContext())
            {
                dB.Add(manufacturer);
                dB.SaveChanges();
            }
        }


    }
}
