using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            MenuData.LoggIn loggIn = new MenuData.LoggIn();
            var supplierName = new Window("Logg In", x, y, loggIn.loggIn);
            supplierName.Draw(1);

        }

        public static void MenuLogoOut(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            MenuData.PureWearaLogo menuLog = new MenuData.PureWearaLogo();
            Window menuLogWindow = new Window("", x, y, menuLog.MenuLog);
            menuLogWindow.Draw(1);
            Window frame = new Window("",x, y + 9, menuLog.frame);
            frame.Draw(97);

            Console.ResetColor();
        }

        public static void TangentMeny() 
        {
            string[] menuItems = { "Alternativ 1", "Alternativ 2", "Alternativ 3", "Alternativ 4", "Alternativ 5", "Avsluta" };
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                        Console.WriteLine($"> {menuItems[i]}");
                    else
                        Console.WriteLine($"  {menuItems[i]}");
                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                    selectedIndex = (selectedIndex - 1 + menuItems.Length) % menuItems.Length;
                else if (key.Key == ConsoleKey.DownArrow)
                    selectedIndex = (selectedIndex + 1) % menuItems.Length;
                else if (key.Key == ConsoleKey.Enter)
                    break; // Välj alternativ
            }

            Console.Clear();
            Console.WriteLine($"Du valde: {menuItems[selectedIndex]}");


        }
    }
}
