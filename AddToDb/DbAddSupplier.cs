using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Helpers;
using WebbShoppen1._0.Models;

namespace WebbShoppen1._0.AddToDb
{
    internal class DbAddSupplier
    {
        public static void AddSupplier()
        {
            Helpers.AddSupplier addSupplier = new Helpers.AddSupplier();
            Models.Supplier supplier = addSupplier.CreateSupplier();

            using (var db = new MyDbContext())
            {
                db.Add(supplier);
                db.SaveChanges();
            }
        }

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
