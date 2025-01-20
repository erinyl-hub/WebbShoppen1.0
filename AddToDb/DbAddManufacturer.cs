using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Helpers;
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

        public Models.Manufacturer CreateManufacturer()
        {
            int x = 40;
            int y = 10;

            MenuData.AddManufacturer addManufacturerName = new MenuData.AddManufacturer();
            var manufacturerName = new Window("Add manufacturer", x, y, addManufacturerName.createManufacturer);
            manufacturerName.Draw(1);

            Console.SetCursorPosition(x + 3, y + 2);
            string name = Console.ReadLine();

            Models.Manufacturer manufacturer = new Models.Manufacturer(name);

            return manufacturer;

        }


    }
}
