using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.TheWheel;

namespace WebbShoppen1._0.Helpers
{
    internal class UserProfileHelpers
    {


        public int ChoseAdress(List<Models.UserInfo> objektLista, int x, int y,  int visningsRader, bool chose)
        {
            int aktuellIndex = 0;
            int offset = 0; 



            ConsoleKey knapp;
            do
            {


                Console.SetCursorPosition(x, y - 1);
                Console.Write("[Adress]         [Postal Code]           [City]             [Country]");


                for (int i = 0; i < visningsRader && (offset + i) < objektLista.Count; i++)
                {
                    int objektY = y + i;

                    Console.SetCursorPosition(x, objektY);

                    if ((offset + i) == aktuellIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}",
                        $"> {objektLista[offset + i].Adress}",
                        $"{objektLista[offset + i].PostalCode}",
                        $"{objektLista[offset + i].City}",
                        $"{objektLista[offset + i].Country}");

                        if (objektLista[offset + i].MainInfo)
                        {
                            Console.SetCursorPosition(x + 80, objektY);
                            Console.Write($"Main");
                        }



                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}",
                        $"  {objektLista[offset + i].Adress}",
                        $"{objektLista[offset + i].PostalCode}",
                        $"{objektLista[offset + i].City}",
                        $"{objektLista[offset + i].Country}");

                        if (objektLista[offset + i].MainInfo)
                        {
                            Console.SetCursorPosition(x + 80, objektY);
                            Console.Write($"Main");
                        }


                    }
                }

                if (chose == true)
                {
                    knapp = Console.ReadKey(true).Key;

                    switch (knapp)
                    {
                        case ConsoleKey.UpArrow:
                            if (aktuellIndex > 0)
                            {
                                aktuellIndex--;

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
                                if (aktuellIndex >= offset + visningsRader)
                                {
                                    offset++;
                                }
                            }
                            break;


                        case ConsoleKey.Enter:
                            {
                                chose = false;

                                break;
                            }

                        case ConsoleKey.Escape:
                            return -1;

                    }
                }

            } while (chose == true);

            return objektLista[aktuellIndex].Id;
        }


        public async static void CardOption()
        {


            MenuData.CheckOut checkOut = new MenuData.CheckOut();
            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);

            while (true)
            {
                AddToDb.Connectors connectors = new AddToDb.Connectors();
                var cardInfos = await connectors.GetCardInfo(Start.user.UserId);


                int choise = Helpers.MenuReader(checkOut.cardOption, checkOut.cardOptionLocations, false);
                switch (choise)
                {
                    case 0: // new card

                        if (cardInfos.Count == 0)
                        {
                            List<string> noCard = new List<string>() { "You have no saved cards" };
                            Window window = new Window("", Start.x, Start.y, noCard);
                            window.Draw(0, 1);
                            break;
                        }

                        List<string> info = new List<string>() { "Chose a card" };
                        int cardId = ChoseCardObjects(cardInfos, Start.x + 14, Start.y + 2 + 14, info, 10);


                        return;

                    case 1: // chose old



                        AddToDb.DbAddCardInfo.AddCardInfo();

                        break;

                }
            }

        }
        private static int ChoseCardObjects(List<Models.CardInfo> objektLista, int x, int y, List<string> info, int visningsRader)
        {
            int aktuellIndex = 0;
            int offset = 0; 

            Window window = new Window("", Start.x + 40, Start.y + 13, info);
            ConsoleKey knapp;

            do
            {

                window.Draw(0, 0);


                for (int i = 0; i < visningsRader && (offset + i) < objektLista.Count; i++)
                {
                    int objektY = y + i;

                    Console.SetCursorPosition(x, objektY);

                    if ((offset + i) == aktuellIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,-16} {1,-18} {2,-15} {3,-15}",
                        $"> {objektLista[offset + i].CardType}",
                        $"Card Number: {objektLista[offset + i].CardNumber}  ",
                        $"Card Date: {objektLista[offset + i].CardDate}",
                        $"CVV: {objektLista[offset + i].CardCVV}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("{0,-16} {1,-18} {2,-15} {3,-15}",
                        $"  {objektLista[offset + i].CardType}",
                        $"Card Number: {objektLista[offset + i].CardNumber}  ",
                        $"Card Date: {objektLista[offset + i].CardDate}",
                        $"CVV: {objektLista[offset + i].CardCVV}");
                    }
                }

                knapp = Console.ReadKey(true).Key;

                switch (knapp)
                {
                    case ConsoleKey.UpArrow:
                        if (aktuellIndex > 0)
                        {
                            aktuellIndex--;
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

        public int OrdersOut(List<Models.Order> objektLista, int x, int y, int visningsRader, bool chose)
        {
            int aktuellIndex = 0;
            int offset = 0;


            ConsoleKey knapp;
            do
            {


                Console.SetCursorPosition(x, y - 1);
                Console.Write("[Order placed]        [Products]     [Cost]    [Shiping]        [Arraving]        [Status]");


                for (int i = 0; i < visningsRader && (offset + i) < objektLista.Count; i++)
                {
                    int objektY = y + i;

                    Console.SetCursorPosition(x, objektY);

                    string status = "Processing";
                    if (objektLista[offset + i].OrderUnderway) { status = "Underway"; }
                    else if (objektLista[offset + i].OrderArrived) { status = "Arrived"; }
                    string shiping = objektLista[offset + i].ShipingCost == 50 ? "Express" : "Reguler";
                    string onlyDatePlaced = objektLista[offset + i].OrderDate.ToString("yyyy-MM-dd");
                    string onlyDateArrive = objektLista[offset + i].ArrivalDate.ToString("yyyy-MM-dd");

                    if ((offset + i) == aktuellIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,-25} {1,-10} {2,-10} {3,-15} {4,-15} {5, -15}",
                        $"> {onlyDatePlaced}",
                        $"{objektLista[offset + i].ProductCount}",
                        $"{Math.Round(objektLista[offset + i].TotalCost, 2)}",
                        $"{shiping}",
                        $"{onlyDateArrive}",
                        $"[{status}]");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("{0,-25} {1,-10} {2,-10} {3,-15} {4,-15} {5, -15}",
                        $"  {onlyDatePlaced}",
                        $"{objektLista[offset + i].ProductCount}",
                        $"{Math.Round(objektLista[offset + i].TotalCost, 2)}",
                        $"{shiping}",
                        $"{onlyDateArrive}",
                        $"[{status}]");
                    }
                }

                if (chose == true)
                {
                    knapp = Console.ReadKey(true).Key;


                    switch (knapp)
                    {
                        case ConsoleKey.UpArrow:
                            if (aktuellIndex > 0)
                            {
                                aktuellIndex--;

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

                                if (aktuellIndex >= offset + visningsRader)
                                {
                                    offset++;
                                }
                            }
                            break;


                        case ConsoleKey.Enter:
                            {
                                chose = false;

                                break;
                            }

                        case ConsoleKey.Escape:
                            {
                                return -1;
                            }
                    }
                }

            } while (chose == true);

            return objektLista[aktuellIndex].Id;
        }

       

    }
}
