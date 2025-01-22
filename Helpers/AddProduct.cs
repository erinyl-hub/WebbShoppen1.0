using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebbShoppen1._0.Models;

namespace WebbShoppen1._0.Helpers
{
    internal class AddProduct
    {

        public async void CreateProduct(int x, int y)
        {

            Helpers helpers = new Helpers();

            var manufacturers = helpers.GetDbInfo<Manufacturer>();
            var suppliers = helpers.GetDbInfo<Supplier>();
            var productCategorys = helpers.GetDbInfo<ProductCategory>();


            MenuData.AddProduct addProduct = new MenuData.AddProduct();
            var produktData = new Window("Add product", x, y, addProduct.addProductMenu);
            produktData.Draw(10);

            Console.SetCursorPosition(x + 3, y + 2);
            string name = Console.ReadLine();

            Console.SetCursorPosition(x + 3, y + 4);
            string description = Console.ReadLine();

            Task<List<string>> manufacturerListMenu = DisplayList<Manufacturer>(m => $"[{m.Id}]     {m.Name}", await manufacturers);
            Task<List<string>> suppliersListMenu = DisplayList<Supplier>(m => $"[{m.Id}]     {m.Name}", await suppliers);
            Task<List<string>> productCategorysListMenu = DisplayList<ProductCategory>(m => $"[{m.Id}]     {m.CategoryName}", await productCategorys);

            double unitPrice = checkFormat<double>(x + 3, y + 6, +3, 10);
            int unitsInStock = checkFormat<int>(x + 3, y + 8, +3, 8);
            int manufacturerId = someDb(x + 3, y + 10, -10, 0, await manufacturerListMenu, "Manufacturers", await manufacturers);
            int supplierId = someDb(x + 3, y + 12, -12, -2, await suppliersListMenu, "Suppliers", await suppliers);
            int productCategoryId = someDb(x + 3, y + 14, -14, -4, await productCategorysListMenu, "Product Categorys", await productCategorys);

        }

        public T checkFormat<T>(int x, int y, int xMsgWindow, int yMsgWindow)
        {
            double value;



            while (true)
            {
                Console.SetCursorPosition(x, y);

                if (double.TryParse(Console.ReadLine(), out value))
                {
                    Helpers.clearMsg(x + xMsgWindow, y + yMsgWindow, 30, 5);
                    return (T)Convert.ChangeType(value, typeof(T));
                }
       
                MenuData.AddProduct wrongFormat = new MenuData.AddProduct();
                Helpers.clearMsg(x + xMsgWindow - 5, y + yMsgWindow, 30, 5);
                var notMatch = new Window("", x + xMsgWindow, y + yMsgWindow, wrongFormat.wrongFormatWindow);
                notMatch.Draw(0);
                Console.SetCursorPosition(x, y);
                Console.Write("          ");
            }
        }

        public async Task<List<string>> DisplayList<T>(Func<T, string> formatter, List<T> items) where T : class // lär dig
        {
            List<string> itemList = new List<string>() { "ID      Name" };

            foreach (var item in items)
            {
                itemList.Add(formatter(item));
            }

            return itemList;
        }



        //Du får input, och funkar, men måste kolla att Id existerar, samt skriv ut namnet på Fronten
        public int someDb<T>
            (int x, int y, int yModList, int yModErrosMsg, List<string> modelList, string dbValueName, List<T> objects) where T : class, IHasInfo
        {
            var manufacturers = new Window(dbValueName, x + 30, y + yModList, modelList);
            manufacturers.Draw(10);

            while (true)
            {
                MenuData.AddProduct addProduct = new MenuData.AddProduct();
                int returnValue = checkFormat<int>(x, y, 2, 6 + yModErrosMsg);
                Helpers.clearMsg(x + 1, y + 6, 30, addProduct.wrongId.Count() + 2);


                if (valueExistInDb(objects, returnValue))
                {
                    Helpers.clearMsg(x + 27, y + yModList, 35, modelList.Count + 2);
                    return returnValue;
                }

                Console.SetCursorPosition(x, y);
                Console.Write("         ");
             
                var wrongId = new Window("", x + 1, y + 6 + yModErrosMsg, addProduct.wrongId); // Fixa
                wrongId.Draw(10);

            }            
        }



        public bool valueExistInDb<T>(List<T> objects, int valueToTest) where T : class, IHasInfo
        {
            foreach (var item in objects)
            {
                if (valueToTest == item.Id)

                { return true; }
            }
            return false;
        }


    }
}
