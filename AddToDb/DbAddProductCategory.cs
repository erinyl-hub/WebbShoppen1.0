using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Models;

namespace WebbShoppen1._0.AddToDb
{
    internal class DbAddProductCategory
    {
        public static void AddProductCategory()
        {
            Helpers.AddProductCategory addProductCategory = new Helpers.AddProductCategory();
            Models.ProductCategory productCategory = addProductCategory.CreateProductCategory();

            using(var dB = new MyDbContext())
            {
                dB.Add(productCategory);

                dB.SaveChanges();
            }

        }



    }
}
