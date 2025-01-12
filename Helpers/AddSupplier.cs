using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Helpers
{
    internal class AddSupplier
    {
        public Models.Supplier CreateSupplier()
        {
            int x = 40;
            int y = 10;

            MenuData.AddSupplier addSupplierName = new MenuData.AddSupplier();
            var supplierName = new Window("Add supplier", x, y, addSupplierName.createSupplier);
            supplierName.Draw(1);

            Console.SetCursorPosition(x + 3, y + 2);
            string name = Console.ReadLine();

            Models.Supplier supplier = new Models.Supplier(name);

            return supplier;
        }

    }
}
