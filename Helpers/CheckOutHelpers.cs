using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.TheWheel;

namespace WebbShoppen1._0.Helpers
{
    internal class CheckOutHelpers
    {
        public static void CheckOut()
        {
            MenuData.CheckOut checkOut = new MenuData.CheckOut();
            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);
            if (Start.user.LoggdIn)
            {
                AdressOut();
                int choise = Helpers.MenuReader(checkOut.checkOutAdressChoise, checkOut.checkOutAdressChoiseLocations, false);

                switch (choise)
                {
                    case 0: // existerande adress




                        break;

                    case 1: // lägg till ny adress



                        break;
                }



            }





        }

        private static void AdressOut()
        {
            UsingDb.GetInfoDb getInfoDb = new UsingDb.GetInfoDb();
            Models.UserInfo userInfo = getInfoDb.GetDbInfoOneObject<Models.UserInfo>(Start.user.UserId);

            List<string> adressInfo = new List<string>{

                $"Adress: {userInfo.Adress}",
                $"Postalcode: {userInfo.PostalCode}",
                $"City: {userInfo.City}",
                $"Country: {userInfo.Country}",
                $"Telephone Number: {userInfo.TelephoneNumber}" };
            Window window = new Window("", Start.x + 43, Start.y + 12, adressInfo);
            window.Draw(0, 0);

        }

        private static void EnterNewAdress()
        {



        }


    }
}
