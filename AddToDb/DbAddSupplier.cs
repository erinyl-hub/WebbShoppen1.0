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
        public void AddSupplier(int x, int y)
        {

            Models.Supplier supplier = CreateSupplier(x, y);

            using (var db = new MyDbContext())
            {
                db.Add(supplier);
                db.SaveChanges();
            }
        }

        private Models.Supplier CreateSupplier(int x, int y)
        {


            MenuData.AddSupplier addSupplierName = new MenuData.AddSupplier();
            var supplierName = new Window("Add supplier", x, y, addSupplierName.createSupplier);
            supplierName.Draw(1,0);

            Console.SetCursorPosition(x + 3, y + 2);
            string name = Console.ReadLine();

            Models.Supplier supplier = new Models.Supplier(name,"test", "test", "test", "test", false); //FIXA

            return supplier;
        }


    }
}
