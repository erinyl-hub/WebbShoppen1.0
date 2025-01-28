using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.MenuData;
using WebbShoppen1._0.TheWheel;

namespace WebbShoppen1._0.Helpers
{
    internal class CheckOutHelpers
    {
        public async static void CheckOut() // Order, orderDet, PayInfo
        {

            Models.Order order = new Models.Order();
            Models.PaymentInfo paymentInfo = new Models.PaymentInfo();

            int adressToUse;

            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);
            Models.UserInfo userInfo = AdressToUse();
            order.UserInfoId = userInfo.Id;

            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);
            paymentInfo = await PaymentOptions();

            int shipingOption = Shiping();
            if (shipingOption == 0)
            {
                order.ShipingCost = 25;
                order.ArrivalDate = DateTime.Now.AddDays(5);
            }
            else
            {
                order.ShipingCost = 50;
                order.ArrivalDate = DateTime.Now.AddDays(2);
            }

            order.OrderDate = DateTime.Now;
            order.ProductCount = Models.Cart.TheCart.Count;

            order.OrderArrived = false;
            order.OrderUnderway = false;
            order.OrderProcessing = true;

            foreach (var product in Models.Cart.TheCart)
            {
                order.TotalCost += product.TotalPriceProducts;

            }

            List<Models.OrderDetail> orderDetails = CreateOrderDetails(order);

            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);
            LastOrderView(paymentInfo, order, userInfo);
            MenuData.CheckOut checkOut = new MenuData.CheckOut();
            int choise = Helpers.MenuReader(checkOut.confirmOrder, checkOut.confirmOrderLocations, false);

            if (choise == 0)
            {
                AddToDb.DbAddOrder dbAddOrder = new AddToDb.DbAddOrder();
                dbAddOrder.AddOrder(order, orderDetails, paymentInfo);
                LowerProducts(orderDetails);
                Models.Cart.TheCart.Clear();
                Console.Clear();
                Helpers.MenuLogoOut(Start.x, Start.y);
                List<string> orderPlaced = new List<string>()
                {"Order has been placed", "Press key to continue.." };
                ;
                Window window = new Window("", Start.x + 37, Start.y + 14, orderPlaced);
                window.Draw(0, 0);
                Console.ReadKey(true);

            }
            else
                return;





        }

        public static Models.UserInfo AdressToUse()
        {
            MenuData.CheckOut checkOut = new MenuData.CheckOut();
            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);
            Models.UserInfo userInfo = AdressOut();

            int choise = Helpers.MenuReader(checkOut.checkOutAdressChoise, checkOut.checkOutAdressChoiseLocations, false);

            switch (choise)
            {
                case 0: // existerande adress


                    return userInfo;


                case 1: // lägg till ny adress

                    Console.Clear();
                    Helpers.MenuLogoOut(Start.x, Start.y);
                    return userInfo = EnterNewAdress();
            }
            return userInfo;

        }

        private static Models.UserInfo AdressOut()
        {
            AddToDb.GetInfoDb getInfoDb = new AddToDb.GetInfoDb();
            Models.UserInfo userInfo = getInfoDb.GetDbInfoOneObject<Models.UserInfo>(Start.user.UserId);

            List<string> adressInfo = new List<string>{

                $"Adress: {userInfo.Adress}",
                $"Postalcode: {userInfo.PostalCode}",
                $"City: {userInfo.City}",
                $"Country: {userInfo.Country}",
                $"Telephone Number: {userInfo.TelephoneNumber}" };
            Window window = new Window("", Start.x + 39, Start.y + 12, adressInfo);
            window.Draw(0, 0);
            return userInfo;

        }

        public static Models.UserInfo EnterNewAdress()
        {
            AddToDb.DbAddCustomer addAdress = new AddToDb.DbAddCustomer();
            Models.UserInfo userInfo = addAdress.AddNewAdress(Start.x, Start.y);
            AddToDb.Connectors connectors = new AddToDb.Connectors();
            connectors.AddAdress(userInfo);

            return userInfo;

        }

        private async static Task<Models.PaymentInfo> PaymentOptions() // Fixa CardInfo
        {
            Models.PaymentInfo paymentInfo = new Models.PaymentInfo();

            MenuData.CheckOut checkOut = new MenuData.CheckOut();
            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);
            List<string> payMethod = new List<string>() { "Choose a pay method" };
            Window payMethodWindow = new Window("", Start.x + 39, Start.y + 10, payMethod);
            payMethodWindow.Draw(0, 1);
            int choise = Helpers.MenuReader(checkOut.paymentOptions, checkOut.paymentOptionsLocations, false);

            switch (choise)
            {
                case 0:
                    {
                        paymentInfo.Card = true;
                        CardOption(paymentInfo);



                        return paymentInfo;
                    }
                case 1:
                    {
                        paymentInfo.Invoice = true;


                        return paymentInfo;
                    }
                case 2:
                    {
                        Console.Clear();
                        Helpers.MenuLogoOut(Start.x, Start.y);
                        paymentInfo.Installment = true;
                        List<string> invoiceMsg = new List<string>() { "How many mounths to pay:  ", ">" };
                        Window window = new Window("", Start.x + 35, Start.y + 12, invoiceMsg);
                        window.Draw(0, 0);
                        int timeToPay = Helpers.checkFormat<int>(Start.x + 38, Start.y + 14, Start.x - 17, Start.y + 1);
                        paymentInfo.MountCount = timeToPay;

                        return paymentInfo;
                    }



            }
            return paymentInfo;
        }

        private async static void CardOption(Models.PaymentInfo payInfo)
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
                        payInfo.CardInfoId = cardId;

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

        private static int Shiping()
        {
            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);
            MenuData.CheckOut checkOut = new MenuData.CheckOut();
            List<string> payMethod = new List<string>() { "Choose shiping option" };
            Window payMethodWindow = new Window("", Start.x + 39, Start.y + 11, payMethod);
            payMethodWindow.Draw(0, 1);
            int choise = Helpers.MenuReader(checkOut.shipingOption, checkOut.shipingOptionLocations, false);
            return choise;

        }

        private static List<Models.OrderDetail> CreateOrderDetails(Models.Order order)
        {
            List<Models.OrderDetail> orderDetails = new List<Models.OrderDetail>();

            foreach (var product in Models.Cart.TheCart)
            {
                Models.OrderDetail orderDetail = new Models.OrderDetail()
                {
                    ProductId = product.ProductId,
                    Quantity = product.Amount,
                    OrderId = order.Id

                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }

        private static void LastOrderView(Models.PaymentInfo paymentInfo, Models.Order order, Models.UserInfo userInfo)
        {
            List<string> adress = new List<string>()
            {
                $"Adress: {userInfo.Adress}",
                $"Postal Code: {userInfo.PostalCode}",
                $"City: {userInfo.City}",
                $"Country: {userInfo.Country}",
                $"Telephone Number: {userInfo.TelephoneNumber}"
            };

            List<string> products = new List<string>();
            double totalPrice = 0;

            foreach (var product in Models.Cart.TheCart)
            {
                string nameSpace = Spacer(product.ProductName, 20);
                string amountSpace = Spacer(product.Amount.ToString(), 5);
                string priceSpace = Spacer(Math.Round(product.TotalPriceProducts, 2).ToString(), 5);

                string add = $"" +
                    $"{product.ProductName}{nameSpace}" +
                    $"{product.Amount}{amountSpace}" +
                    $"{Math.Round(product.TotalPriceProducts, 2)}$";
                products.Add(add);
                totalPrice += product.TotalPriceProducts;
            }

            string onlyDate = order.ArrivalDate.ToString("yyyy-MM-dd");

            List<string> shipingInfo = new List<string>()
            {
                $"Arrival: {onlyDate}"
            };

            if (order.ShipingCost == 25)
            {
                string reguler = "Shiping: Reguler";
                shipingInfo.Add(reguler);
            }
            else if (order.ShipingCost == 50)
            {
                string express = "Shiping: Express";
                shipingInfo.Add(express);
            }

            List<string> cost = new List<string>()
            {
                $"Total cost with shiping: {Math.Round(totalPrice,2)}$",
                $"VAT:{Math.Round(totalPrice * 0.2,2)}$"};

            AllOut("Adress", adress, Start.x + 5, Start.y + 11);
            AllOut("Products", products, Start.x + 5, Start.y + 19);
            AllOut("Shiping Info", shipingInfo, Start.x + 65, Start.y + 11);
            AllOut("Cost", cost, Start.x + 65, Start.y + 15);

        }

        private static void AllOut(string msg, List<string> list, int x, int y)
        {
            Window window = new Window(msg, x, y, list);
            window.Draw(0, 0);

        }

        public static string Spacer(string countString, int size)
        {
            string returner = "";
            for (int i = 0; i < (size - countString.Length); i++)
            {
                returner += " ";
            }

            return returner;
        }

        private async static void LowerProducts(List<Models.OrderDetail> orderDetail)
        {

            AddToDb.Connectors connectors = new AddToDb.Connectors();

            foreach (var product in orderDetail)
            {
                connectors.LowerProductDb(product.ProductId, product.Quantity);

            }

        }




    }
}
