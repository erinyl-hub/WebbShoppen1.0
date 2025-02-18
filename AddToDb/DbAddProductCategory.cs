﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Helpers;
using WebbShoppen1._0.Models;

namespace WebbShoppen1._0.AddToDb
{
    internal class DbAddProductCategory
    {
        public void AddProductCategory(int x, int y)
        {

            Models.ProductCategory productCategory = CreateProductCategory(x,y);

            using(var dB = new MyDbContext())
            {
                dB.Add(productCategory);

                dB.SaveChanges();
            }

        }

        private Models.ProductCategory CreateProductCategory(int x, int y)
        {

            MenuData.AddProductCategory addProductCategoryName = new MenuData.AddProductCategory();
            var productCategoryName = new Window("Add product category", x, y, addProductCategoryName.createProductCategoryName);
            productCategoryName.Draw(4,0);

            MenuData.AddProductCategory addProductCategoryDescription = new MenuData.AddProductCategory();
            var productCategoryDescription = new Window("", x - 9, y + 4, addProductCategoryDescription.createProductCategoryDescription);
            productCategoryDescription.Draw(42,0);

            Console.SetCursorPosition(x + 3, y + 2);
            string categoryName = Console.ReadLine();

            Console.SetCursorPosition(x - 6, y + 6);
            string description = Console.ReadLine();

            Models.ProductCategory productCategory = new Models.ProductCategory(categoryName, description);

            return productCategory;
        }



    }
}
