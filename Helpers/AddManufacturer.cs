using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Helpers
{
    internal class AddManufacturer
    {
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
