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


        public static void LoggIn(int x, int y)
        {
            Helpers helpers = new Helpers();
            var loggInInfoList = helpers.GetDbInfo<Models.LoggInInfo>();

            MenuData.LoggIn loggInData = new MenuData.LoggIn();
            Window loggInBox = new Window("Logg In", x, y, loggInData.logginData);
            loggInBox.Draw(0);

            while(true)
            { 

            Console.SetCursorPosition(x + 3, y + 2);
            string username = Console.ReadLine();

            string password = Helpers.HidePassword(x + 3, y + 4);


            }

            Console.ReadKey();
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

        public static int FrontMeny(List<string> menuItems, int[,] pos)
        {
            int selectedIndex = 0;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                for (int i = 0; i < menuItems.Count; i++)
                {
                    Console.SetCursorPosition(pos[i, 0] + Start.x, pos[i, 1] + Start.y);
                    if (i == selectedIndex)
                        Console.Write($"> [{menuItems[i]}]");
                    else
                    {
                        Console.Write($"  [{menuItems[i]}]");
                    }
                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                { selectedIndex = (selectedIndex - 1 + menuItems.Count) % menuItems.Count; }

                else if (key.Key == ConsoleKey.RightArrow)
                { selectedIndex = (selectedIndex + 1) % menuItems.Count; }

                else if (key.Key == ConsoleKey.Enter)
                { return selectedIndex; }
            }
        }

        public static string HidePassword(int x, int y)
        {
            string input = "";
            Console.SetCursorPosition(x, y);

            while (true)
            {
                Console.SetCursorPosition(x, y);
                var key = Console.ReadKey(intercept: true); // Läs tangent utan att visa den

                if (key.Key == ConsoleKey.Enter) // Avsluta vid Enter
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
                    input += key.KeyChar; // Lägg till tecken i input
                    
                    Console.Write("*");   // Visa ersättningstecken
                    x++;
                }
            }

            return input;
        }

        public async Task<List<T>> GetDbInfo<T>() where T : class
        {
            List<T> items;

            using (var db = new MyDbContext())
            {
                items = await db.Set<T>().ToListAsync();
            }
            return items;

        }
    }
}
