using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Helpers;
using WebbShoppen1._0.Models;
using WebbShoppen1._0.TheWheel;

namespace WebbShoppen1._0.AddToDb
{
    internal class DbAddProduct
    {
        public async void AddProduct(int x, int y)
        {
            Console.Clear();
            Helpers.Helpers.MenuLogoOut(Start.x, Start.y);

            Task<Models.Product> product = CreateProduct(x, y);


            using (var dB = new Models.MyDbContext())
            {
                dB.Product.Add(await product);
                dB.SaveChanges();
            }
        }

        private async Task<Models.Product> CreateProduct(int x, int y)
        {

            AddToDb.GetInfoDb dbInfo = new AddToDb.GetInfoDb();

            var manufacturers = dbInfo.GetDbInfoAsync<Supplier>();
            var suppliers = dbInfo.GetDbInfoAsync<Supplier>();
            var productCategorys = dbInfo.GetDbInfoAsync<ProductCategory>();


            MenuData.AddProduct addProduct = new MenuData.AddProduct();
            var produktData = new Window("Add product", x, y, addProduct.addProductMenu);
            produktData.Draw(10, 0);

            Console.SetCursorPosition(x + 3, y + 2);
            string name = Console.ReadLine();

            Console.SetCursorPosition(x + 3, y + 4);
            string description = Console.ReadLine();


            Task<List<string>> suppliersListMenu = DisplayList<Supplier>(m => $"[{m.Id}]     {m.Name}", await suppliers);
            Task<List<string>> productCategorysListMenu = DisplayList<ProductCategory>(m => $"[{m.Id}]     {m.CategoryName}", await productCategorys);

            double unitPrice = Helpers.Helpers.checkFormat<double>(x + 3, y + 6, +3, 10);
            int unitsInStock = Helpers.Helpers.checkFormat<int>(x + 3, y + 8, +3, 8);
            int supplierId = someDb(x + 3, y + 12, -12, -2, await suppliersListMenu, "Suppliers", await suppliers);
            int productCategoryId = someDb(x + 3, y + 14, -14, -4, await productCategorysListMenu, "Product Categorys", await productCategorys);

            Models.Product product = new Models.Product
                (name, description, unitPrice, 0, false, false, 0, supplierId, productCategoryId);

            return product;

        }

        private static T checkFormat<T>(int x, int y, int xMsgWindow, int yMsgWindow)
        {
            double value;

            while (true)
            {
                Console.SetCursorPosition(x, y);

                if (double.TryParse(Console.ReadLine(), out value))
                {
                    Helpers.Helpers.clearMsg(x + xMsgWindow, y + yMsgWindow, 30, 5);
                    return (T)Convert.ChangeType(value, typeof(T));
                }

                MenuData.AddProduct wrongFormat = new MenuData.AddProduct();
                Helpers.Helpers.clearMsg(x + xMsgWindow - 5, y + yMsgWindow, 30, 5);
                var notMatch = new Window("", x + xMsgWindow, y + yMsgWindow, wrongFormat.wrongFormatWindow);
                notMatch.Draw(0, 1);
                Console.SetCursorPosition(x, y);
                Console.Write("          ");
            }
        }

        public async Task<List<string>> DisplayList<T>(Func<T, string> formatter, List<T> items) where T : class
        {
            List<string> itemList = new List<string>() { "ID      Name" };

            foreach (var item in items)
            {
                itemList.Add(formatter(item));
            }

            return itemList;
        }


        private int someDb<T>
            (int x, int y, int yModList, int yModErrosMsg, List<string> modelList, string dbValueName, List<T> objects) where T : class, IHasInfo
        {
            var manufacturers = new Window(dbValueName, x + 30, y + yModList, modelList);
            manufacturers.Draw(10, 0);

            while (true)
            {
                MenuData.AddProduct addProduct = new MenuData.AddProduct();
                int returnValue = Helpers.Helpers.checkFormat<int>(x, y, 2, 6 + yModErrosMsg);
                Helpers.Helpers.clearMsg(x + 1, y + 6, 30, addProduct.wrongId.Count() + 2);


                if (valueExistInDb(objects, returnValue))
                {
                    Helpers.Helpers.clearMsg(x + 27, y + yModList, 35, modelList.Count + 2);
                    return returnValue;
                }

                Console.SetCursorPosition(x, y);
                Console.Write("         ");

                var wrongId = new Window("", x + 1, y + 6 + yModErrosMsg, addProduct.wrongId); // Fixa
                wrongId.Draw(10, 1);

            }
        }



        private bool valueExistInDb<T>(List<T> objects, int valueToTest) where T : class, IHasInfo
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
