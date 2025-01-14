using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Models;

namespace WebbShoppen1._0.Helpers
{
    internal class AddProduct
    {

        public async void CreateProduct()
        {
            int x = 40;
            int y = 10;

            List<Manufacturer> manufacturers = await GetDbInfo<Manufacturer>(); // Okej, får lista av objektet för att använda senare, ta bort resultat använd await
            List<Supplier> suppliers = await GetDbInfo<Supplier>();
            List<ProductCategory> productCategorys = await GetDbInfo<ProductCategory>();

            Task<List<string>> manufacturerListMenu = DisplayList<Manufacturer>(m => $"[{m.Id}]     {m.Name}", manufacturers);
            Task<List<string>> suppliersListMenu = DisplayList<Supplier>(m => $"[{m.Id}]     {m.Name}", suppliers);
            Task<List<string>> productCategorysListMenu = DisplayList<ProductCategory>(m => $"[{m.Id}]     {m.CategoryName}", productCategorys);


            MenuData.AddProduct addProduct = new MenuData.AddProduct();
            var produktData = new Window("Add product", x, y, addProduct.addProductMenu);
            produktData.Draw(10);

            Console.SetCursorPosition(x + 3, y + 2);
            string name = Console.ReadLine();

            Console.SetCursorPosition(x + 3, y + 4);
            string description = Console.ReadLine();

            double unitPrice = checkFormat<double>(x + 3, y + 6, -6, 10);

            int unitsInStock = checkFormat<int>(x + 3, y + 8, -6, 8);


            var manufacturerList = await manufacturerListMenu;
            int manufacturerId = someDb(x + 3, y + 10, -10, 0, manufacturerList, "Manufacturers", manufacturers);

            var suppplierList = await suppliersListMenu;
            int supplierId = someDb(x + 3, y + 12, -12, -2, suppplierList, "Suppliers", suppliers);

            var productCategorysList = await productCategorysListMenu;
            int productCategoryId = someDb(x + 3, y + 14, -14, -4, productCategorysList, "Product Categorys", productCategorys);







        }

        public T checkFormat<T>(int x, int y, int xMsgWindow, int yMsgWindow)
        {
            double value;

            while (true)
            {
                Console.SetCursorPosition(x, y);

                if (double.TryParse(Console.ReadLine(), out value))
                {
                    Helpers.clearMsg(x + xMsgWindow, y + yMsgWindow, 37, 5);
                    return (T)Convert.ChangeType(value, typeof(T));
                }

                MenuData.AddProduct wrongFormat = new MenuData.AddProduct();
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
            (int x, int y, int yModList, int yModErrosMsg, List<string> modelList, string dbValueName, List<T> objects) where T : class, IHasId
        {
            var manufacturers = new Window(dbValueName, x + 27, y + yModList, modelList);
            manufacturers.Draw(10);


            while (true)
            {
                MenuData.AddProduct addProduct = new MenuData.AddProduct();
                Helpers.clearMsg(x - 8, y + 6, 30, addProduct.wrongId.Count() + 2);
                int returnValue = checkFormat<int>(x, y, -6, 6 + yModErrosMsg);

               
                if(valueExistInDb(objects, returnValue))
                {
                    Helpers.clearMsg(x + 27, y + yModList, 35, modelList.Count + 2);
                    return returnValue;
                }

                Console.SetCursorPosition(x, y);
                Console.Write("         ");


                
                var wrongId = new Window("", x - 8, y + 6, addProduct.wrongId); // Fixa
                wrongId.Draw(10);

            }            
        }


        public async Task<List<T>> GetDbInfo<T>() where T : class
        {
            List<T> items;

            using (var db = new MyDbContext())
            {
                items = db.Set<T>().ToList();
            }

            return items;
        }

        public bool valueExistInDb<T>(List<T> objects, int valueToTest) where T : class, IHasId
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
