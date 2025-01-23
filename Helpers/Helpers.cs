using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Models;
using WebbShoppen1._0.TheWheel;
using Microsoft.EntityFrameworkCore;

namespace WebbShoppen1._0.Helpers
{
    internal class Helpers
    {
        public static string Replacer(int count)
        {
            string replaceWith = "";

            for (int i = 0; i < count; i++)
            {
                replaceWith += " ";
            }

            return replaceWith;
        }

        public static void clearMsg(int x, int y, int clearSpaceX, int clearSpaceY)
        {

            for (int i = 0; i < clearSpaceY; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < clearSpaceX; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }


        public static async void LoggIn(int x, int y)
        {
            UsingDb.GetInfoDb dbInfo = new UsingDb.GetInfoDb();
            var loggInInfoList = dbInfo.GetDbInfoAsync<Models.LoggInInfo>();

            MenuData.LoggIn loggInData = new MenuData.LoggIn();
            Window loggInBox = new Window("Logg In", x, y, loggInData.logginData);
            loggInBox.Draw(0);

            while (true)
            {
                Console.SetCursorPosition(x + 3, y + 2);
                string username = Console.ReadLine();

                string password = Helpers.HidePassword(x + 3, y + 4);

                foreach (var user in await loggInInfoList)
                {
                    if (user.EmailAdress == username && user.Password == password)
                    {
                        Start.user.Id = user.Id;
                        Start.user.LoggdIn = true;

                        if (user.IsAdmin)
                        {
                            Start.user.IsAdmin = true;
                            return;
                        }

                        return;
                    }
                }




            }
        }

        public static void MenuLogoOut(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            MenuData.PureWearaLogo menuLog = new MenuData.PureWearaLogo();
            Window menuLogWindow = new Window("", x, y, menuLog.MenuLog);
            menuLogWindow.Draw(1);
            Window frame = new Window("", x, y + 9, menuLog.frame);
            frame.Draw(97);

            Console.ResetColor();
        }

        public static int MenuReader(List<string> menuItems, int[,] pos)
        {
            int selectedIndex = 0;
            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                for (int i = 0; i < menuItems.Count; i++)
                {
                    Console.SetCursorPosition(pos[i, 0] + Start.x, pos[i, 1] + Start.y);
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"> ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"[{menuItems[i]}]");

                    }
                    else
                    {
                        Console.Write($"  [{menuItems[i]}]");
                    }
                }

                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                { selectedIndex = (selectedIndex - 1 + menuItems.Count) % menuItems.Count; }

                else if (key.Key == ConsoleKey.RightArrow)
                { selectedIndex = (selectedIndex + 1) % menuItems.Count; }

                else if (key.Key == ConsoleKey.Enter)
                { Console.ResetColor(); return selectedIndex; }
            }
        }

        public static string HidePassword(int x, int y)
        {
            string input = "";
            Console.SetCursorPosition(x, y);

            while (true)
            {
                Console.SetCursorPosition(x, y);
                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length != 0)
                    {
                        x--;
                        Console.SetCursorPosition(x, y);
                        Console.Write(" ");
                        input = input.Remove(input.Length - 1);
                    }
                }
                else
                {
                    input += key.KeyChar;
                    Console.Write("*");
                    x++;
                }
            }
            return input;
        }

        public List<Models.Product> ProductsOnSale(List<Models.Product> allProducts)
        {
            List<Models.Product> productsOnSale = new List<Models.Product>();

            foreach (var product in allProducts)
            {
                if (product.OnSale == true)
                {
                    productsOnSale.Add(product);
                }
            }

            return productsOnSale;
        }


        public static int ChoseObject(List<Models.Product> objektLista, int x, int y, List<string> info)
        {
            int aktuellIndex = 0;          
            int maxKolumner = 5; // Antal kolumner innan radbrytning
            Window window = new Window("", Start.x + 35, Start.y + 11,info);


            ConsoleKey knapp;

            do
            {

                Console.Clear();
                Helpers.MenuLogoOut(Start.x, Start.y);
                window.Draw(0);

                // Skriv ut alla objekt från aktuell position
                for (int i = 0; i < objektLista.Count; i++)
                {
                    int objektX = x + (i % maxKolumner) * 15; // Hoppa 15 steg åt höger per kolumn
                    int objektY = y + (i / maxKolumner);      // Öka rad för varje "maxKolumner"
                    string onSale = "";

                    if(objektLista[i].OnSale  == true) { onSale = " *"; };

                    Console.SetCursorPosition(objektX, objektY);

                    if (i == aktuellIndex)
                    {
                        // Markera det valda objektet
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"> {objektLista[i].ProductName} {onSale}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {objektLista[i].ProductName} {onSale}");
                    }
                }


                knapp = Console.ReadKey(true).Key;

                // Navigera mellan objekt
                switch (knapp)
                {
                    case ConsoleKey.UpArrow:
                        aktuellIndex = (aktuellIndex - maxKolumner + objektLista.Count) % objektLista.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        aktuellIndex = (aktuellIndex + maxKolumner) % objektLista.Count;
                        break;

                    case ConsoleKey.LeftArrow:
                        aktuellIndex = (aktuellIndex > 0) ? aktuellIndex - 1 : objektLista.Count - 1;
                        break;

                    case ConsoleKey.RightArrow:
                        aktuellIndex = (aktuellIndex < objektLista.Count - 1) ? aktuellIndex + 1 : 0;
                        break;
                }

            } while (knapp != ConsoleKey.Enter);


            return objektLista[aktuellIndex].Id;


        }
        public static T checkFormat<T>(int x, int y, int xMsgWindow, int yMsgWindow)
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

    }

    
}
