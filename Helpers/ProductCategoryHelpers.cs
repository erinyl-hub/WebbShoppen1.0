using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.AddToDb;
using WebbShoppen1._0.TheWheel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebbShoppen1._0.Helpers
{
    internal class ProductCategoryHelpers
    {
        public void TheCategory()
        {
            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);
            GetInfoDb getInfoDb = new GetInfoDb();
            var productCategories = getInfoDb.GetDbInfo<Models.ProductCategory>();
            List<string> productCatMsg = new List<string>() { "Chose product category" };
            int categoriId = ChoseProductCategory(productCategories, Start.x + 20, Start.y + 15, productCatMsg, 40);
            Connectors connectors = new Connectors();

            if (categoriId != -1)
            {
                Console.Clear();
                Helpers.MenuLogoOut(Start.x, Start.y);
                List<Models.Product> products = connectors.GetProducts(categoriId);
                List<string> productMsg = new List<string>()
                {
                    "Choose product and press enter to add to cart" ,
                    "             Press esc to return"

                };
                ChoseProduct(products, Start.x + 15, Start.y + 15, productMsg, 20);
            }


        }


        private static int ChoseProductCategory(List<Models.ProductCategory> objektLista, int x, int y, List<string> info, int visningsRader)
        {
            int aktuellIndex = 0;
            int offset = 0; // För att hålla reda på var vi är i listan när vi rullar


            Window window = new Window("", Start.x + 40, Start.y + 11, info);
            ConsoleKey knapp;
            do
            {

                window.Draw(0, 0);
                Console.SetCursorPosition(x, y - 1);
                Console.Write("[Category]            [Description]");

                // Rita endast de synliga objekten
                for (int i = 0; i < visningsRader && (offset + i) < objektLista.Count; i++)
                {
                    int objektY = y + i;

                    Console.SetCursorPosition(x, objektY);

                    if ((offset + i) == aktuellIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,-18} {1,-18}",
                        $"> {objektLista[offset + i].CategoryName}",
                        $"{objektLista[offset + i].Description}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("{0,-18} {1,-18}",
                        $"  {objektLista[offset + i].CategoryName}",
                        $"{objektLista[offset + i].Description}");
                    }
                }

                knapp = Console.ReadKey(true).Key;

                // Navigera mellan objekten
                switch (knapp)
                {
                    case ConsoleKey.UpArrow:
                        if (aktuellIndex > 0)
                        {
                            aktuellIndex--;
                            // Rulla upp om vi är högre än offset
                            if (aktuellIndex < offset)
                            {
                                offset--;
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (aktuellIndex < objektLista.Count - 1)
                        {
                            aktuellIndex++;
                            // Rulla ner om vi går utanför visningsområdet
                            if (aktuellIndex >= offset + visningsRader)
                            {
                                offset++;
                            }
                        }
                        break;

                    case ConsoleKey.Escape:
                        return -1;

                }

            } while (knapp != ConsoleKey.Enter);

            return objektLista[aktuellIndex].Id;
        }

        private static int ChoseProduct(List<Models.Product> objektLista, int x, int y, List<string> info, int visningsRader)
        {
            int aktuellIndex = 0;
            int offset = 0; // För att hålla reda på var vi är i listan när vi rullar


            Window window = new Window("", Start.x + 30, Start.y + 10, info);
            ConsoleKey knapp;
            do
            {

                window.Draw(0, 0);
                Console.SetCursorPosition(x, y - 1);
                Console.Write(" [Product]        [Price]            [Description]");

                // Rita endast de synliga objekten
                for (int i = 0; i < visningsRader && (offset + i) < objektLista.Count; i++)
                {
                    int objektY = y + i;

                    Console.SetCursorPosition(x, objektY);

                    if ((offset + i) == aktuellIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,-18} {1,-12} {2,-18}",
                        $"> {objektLista[offset + i].ProductName}",
                        $"{objektLista[offset + i].ProductPrice}",
                        $"{objektLista[offset + i].Description}");


                        if (objektLista[offset + i].OnSale)
                        {
                            Console.SetCursorPosition(x + 65, objektY);
                            Console.Write($"On Sale ${objektLista[offset + i].DiscountAmount}-");
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("{0,-18} {1,-12} {2,-18}",
                        $"> {objektLista[offset + i].ProductName}",
                        $"{objektLista[offset + i].ProductPrice}",
                        $"{objektLista[offset + i].Description}");

                        if (objektLista[offset + i].OnSale)
                        {
                            Console.SetCursorPosition(x + 65, objektY);
                            Console.Write($"On Sale ${objektLista[offset + i].DiscountAmount}-");
                        }


                    }
                }

                knapp = Console.ReadKey(true).Key;

                // Navigera mellan objekten
                switch (knapp)
                {
                    case ConsoleKey.UpArrow:
                        if (aktuellIndex > 0)
                        {
                            aktuellIndex--;
                            // Rulla upp om vi är högre än offset
                            if (aktuellIndex < offset)
                            {
                                offset--;
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (aktuellIndex < objektLista.Count - 1)
                        {
                            aktuellIndex++;
                            // Rulla ner om vi går utanför visningsområdet
                            if (aktuellIndex >= offset + visningsRader)
                            {
                                offset++;
                            }
                        }
                        break;


                    case ConsoleKey.Enter:
                        {
                            Models.Cart cart = new Models.Cart();

                            cart.AddToCartFromMenuSingel(objektLista[aktuellIndex].Id, cart);

                            break;
                        }

                    case ConsoleKey.Escape:
                        return -1;

                }

            } while (true);


        }
    }
}
