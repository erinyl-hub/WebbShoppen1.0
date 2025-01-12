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

        public void CreateProduct()
        {
            int x = 40;
            int y = 10;

            MenuData.AddProduct addProduct = new MenuData.AddProduct();
            var produktData = new Window("Add product", x, y, addProduct.addProductMenu);
            produktData.Draw(10);

            Console.SetCursorPosition(x + 3, y + 2);
            string name = Console.ReadLine();

            Console.SetCursorPosition(x + 3, y + 4);
            string description = Console.ReadLine();

            double unitPrice = checkFormat<double>(x + 3, y + 6, -6, 10);

            int unitsInStock = checkFormat<int>(x + 3, y + 8, -6, 8);





            Console.SetCursorPosition(x + 3, y + 10);
            int manufacturerId = int.Parse(Console.ReadLine()); // skriver ut lista av manufa

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

        public void ManufacturerList()
        {
            List <Manufacturer> manufacturer = new List<Manufacturer>();

            using (var dB = new MyDbContext())
            {
                manufacturer = dB.Manufacturers.ToList();
            }

            List<string> manufacturerList = new List<string>() {"ID      Name" };

            foreach(var unit in manufacturer)
            {
                string toString = "[" + unit.Id.ToString() + "]     " + unit.Name;
                manufacturerList.Add(toString);
            }

            var manufacturers = new Window("Manufacturers", 10, 5, manufacturerList);
            manufacturers.Draw(0);
            Console.ReadKey();
        }

        public void DisplayList<T>(Func<T, string> formatter) where T : class
        {
            List<T> items;

            using (var db = new MyDbContext())
            {
                items = db.Set<T>().ToList();
            }

            List<string> itemList = new List<string>() { "ID      Name" };

            foreach (var item in items)
            {
                itemList.Add(formatter(item));
            }

            var window = new Window(typeof(T).Name + "s", 10, 5, itemList);
            window.Draw(0);
            Console.ReadKey();
        }


    }
}
