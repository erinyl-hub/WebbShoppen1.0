using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


    }
}
