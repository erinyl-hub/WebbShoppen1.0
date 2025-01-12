using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Helpers
{
    internal class AddProductCategory
    {

        public Models.ProductCategory CreateProductCategory()
        {
            int x = 40;
            int y = 10;

            MenuData.AddProductCategory addProductCategoryName = new MenuData.AddProductCategory();
            var productCategoryName = new Window("Add product category", x, y, addProductCategoryName.createProductCategoryName);
            productCategoryName.Draw(4);

            MenuData.AddProductCategory addProductCategoryDescription = new MenuData.AddProductCategory();
            var productCategoryDescription = new Window("", x - 9, y + 4, addProductCategoryDescription.createProductCategoryDescription);
            productCategoryDescription.Draw(42);
                     
            Console.SetCursorPosition(x + 3, y + 2);
            string categoryName = Console.ReadLine();

            Console.SetCursorPosition(x - 6, y + 6);
            string description = Console.ReadLine();

            Models.ProductCategory productCategory = new Models.ProductCategory(categoryName, description);

            return productCategory;
        }
    }
}
