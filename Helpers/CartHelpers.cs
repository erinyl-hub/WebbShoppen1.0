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
            TotalPrice(Start.x + 60, Start.y + 13);


            Window window = new Window("", Start.x + 43, Start.y + 13, info);
            ConsoleKey knapp;


            window.Draw(0, 0);

            // Rita endast de synliga objekten
            for (int i = 0; i < visningsRader && (offset + i) < objektLista.Count; i++)
            {
                int objektY = y + i;

                Console.SetCursorPosition(x, objektY);

                Console.WriteLine("{0,-18} {1,-18} {2,-18} {3,-18}",
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
                        Console.WriteLine("{0,-18} {1,-18} {2,-18} {3,-18}",
                        $"> {objektLista[offset + i].ProductName}     ",
                        $"Amount: {objektLista[offset + i].Amount}     ",
                        $"Price: {objektLista[offset + i].FinalPrice}     ",
                        $"Total price: {objektLista[offset + i].TotalPriceProducts}     ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("{0,-18} {1,-18} {2,-18} {3,-18}",
                        $"  {objektLista[offset + i].ProductName}     ",
                        $"Amount: {objektLista[offset + i].Amount}     ",
                        $"Price: {objektLista[offset + i].FinalPrice}     ",
                        $"Total price: {objektLista[offset + i].TotalPriceProducts}     ");
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

            return objektLista[aktuellIndex].ProductId;
        }



        public void ViewTheCart()
        {


            while (true)
            {
                MenuData.Cart cartData = new MenuData.Cart();
                List<string> cartOverView = new List<string> { "  The cart  " };
                Helpers.MenuLogoOut(Start.x, Start.y);
                DrawCartObjects(Models.Cart.TheCart, Start.x + 15, Start.y + 18, cartOverView, 18);
                int choise = Helpers.MenuReader(cartData.inCart, cartData.inCartLocation, false);


                switch (choise)
                {
                    case 0: // Edit cart
                        int product = 66;
                        while (product != -1)
                        {
                            Console.Clear();
                            Helpers.MenuLogoOut(Start.x, Start.y);
                            List<string> cartEdit = new List<string> { "  Chose a product ", "Press esc to return" };
                            product = ChoseCartObjects(Models.Cart.TheCart, Start.x + 15, Start.y + 18, cartEdit, 18);
                            if (product != -1)
                            {
                                Console.Clear();
                                Helpers.MenuLogoOut(Start.x, Start.y);
                                EditProductAmountInCart(product);
                            }
                        }
                        break;

                    case 1: // Check out

                        if (Models.Cart.TheCart.Count > 0)
                        {
                            CheckOutHelpers.CheckOut();
                            return;
                        }
                        break;

                    case 2: // Back
                        Console.Clear();
                        return;

                }


            }


        }

        private static void EditProductAmountInCart(int productIdInCart)
        {
            List<string> editProduct = new List<string> { "New amount: ", "Put 0 to remove" };
            Window window = new Window("Enter new amount", Start.x + 37, Start.y + 13, editProduct);
            window.Draw(5, 0);

            int productAmount = Helpers.checkFormat<int>(Start.x + 50, Start.y + 14, Start.x + -26, Start.y + 2);

            var theProduct = Models.Cart.TheCart.FirstOrDefault(o => o.ProductId == productIdInCart);

            if (productAmount == 0)
            {
                Models.Cart.TheCart.Remove(theProduct);
                return;
            }
            else
            {
                theProduct.Amount = productAmount;
            }
        }

        public static void TotalPrice(int x, int y)
        {
            double totalPrice = 0;

            foreach (var item in Models.Cart.TheCart)
            {
                totalPrice += item.TotalPriceProducts;
            }



            List<string> priceSign = new List<string>
            { $"Total price:{Math.Round(totalPrice, 2)}$",
             $"VAT:{Math.Round(totalPrice * 0.2,2)}$"};

            Window windowTotalPriceDisplay = new Window("", Start.x + 60, Start.y + 13, priceSign);
            windowTotalPriceDisplay.Draw(0, 0);

        }
    }
}
