using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.TheWheel;

namespace WebbShoppen1._0.Helpers
{
    internal class CartHelpers
    {

        private static void DrawCartObjects(List<Models.Cart> objektLista, int x, int y, List<string> info, int visningsRader)
        {
            int aktuellIndex = 0;
            int offset = 0; // För att hålla reda på var vi är i listan när vi rullar

            Window window = new Window("", Start.x + 43, Start.y + 13, info);
            ConsoleKey knapp;

            window.Draw(0, 0);

            // Rita endast de synliga objekten
            for (int i = 0; i < visningsRader && (offset + i) < objektLista.Count; i++)
            {
                int objektY = y + i;

                Console.SetCursorPosition(x, objektY);

                    Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}",
                    $"  {objektLista[offset + i].ProductName}",
                    $"Amount: {objektLista[offset + i].Amount}",
                    $"Price: {objektLista[offset + i].FinalPrice}",
                    $"Total price: {objektLista[offset + i].TotalPriceProducts}");              
            }

        }


        private static int ChoseCartObjects(List<Models.Cart> objektLista, int x, int y, List<string> info, int visningsRader)
        {
            int aktuellIndex = 0;
            int offset = 0; // För att hålla reda på var vi är i listan när vi rullar

            Window window = new Window("", Start.x + 40, Start.y + 13, info);
            ConsoleKey knapp;

            do
            {

                window.Draw(0, 0);

                // Rita endast de synliga objekten
                for (int i = 0; i < visningsRader && (offset + i) < objektLista.Count; i++)
                {
                    int objektY = y + i;

                    Console.SetCursorPosition(x, objektY);

                    if ((offset + i) == aktuellIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}",
                        $"> {objektLista[offset + i].ProductName}",
                        $"Amount: {objektLista[offset + i].Amount}",
                        $"Price: {objektLista[offset + i].FinalPrice}",
                        $"Total price: {objektLista[offset + i].TotalPriceProducts}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}",
                        $"  {objektLista[offset + i].ProductName}",
                        $"Amount: {objektLista[offset + i].Amount}",
                        $"Price: {objektLista[offset + i].FinalPrice}",
                        $"Total price: {objektLista[offset + i].TotalPriceProducts}");
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
                        return 0;

                }

            } while (knapp != ConsoleKey.Enter);

            return objektLista[aktuellIndex].ProductId;
        }



        public void ViewTheCart()
        {
            

            while (true)
            {
                MenuData.Cart cartData = new MenuData.Cart();
                List<string> cartOverView = new List<string> { "  The cart  " };
                Helpers.MenuLogoOut(Start.x, Start.y);
                DrawCartObjects(Models.Cart.TheCart, 40, 19, cartOverView, 20);
                int choise = Helpers.MenuReader(cartData.inCart, cartData.inCartLocation, false);


                switch (choise)
                {
                    case 0: // Edit cart

                        List<string> cartEdit = new List<string> { "  Chose a product ", "Press esc to return" };
                        ChoseCartObjects(Models.Cart.TheCart, 40, 19, cartEdit, 20);

                        break;

                    case 1: // Check out

                        break;

                    case 2: // Back

                        break;
                }


            }


        }


    }
}
