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

            List<Manufacturer> manufacturers = GetDbInfo<Manufacturer>().Result; // Okej, får lista av objektet för att använda senare, ta bort resultat använd await
            

            Task<List<string>> manufacturerListMenu = DisplayList<Manufacturer>(m => $"[{m.Id}]     {m.Name}", manufacturers);
            // skriv om lite, måste "<Manufacturer>" stå med?



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
            int manufacturerId = someDb(x, y, manufacturerList, "Manufacturers");










            Console.SetCursorPosition(x + 3, y + 12);
            int supplierId = int.Parse(Console.ReadLine()); // skriver ut lista av sup

            Console.SetCursorPosition(x + 3, y + 14);
            int productCatergoryId = int.Parse(Console.ReadLine()); // bla bla bla


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
        public int someDb(int x, int y, List<string> modelList, string dbValue)
        {
            var manufacturers = new Window(dbValue, x + 30, y, modelList);
            manufacturers.Draw(10);

            int returnValue = checkFormat<int>(x + 3, y + 10, -6, 6);
            Helpers.clearMsg(x + 30, y, 35, modelList.Count + 2);

            return returnValue;
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


    }
}
