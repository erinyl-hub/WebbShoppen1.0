using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Helpers;
using WebbShoppen1._0.MenuData;

namespace WebbShoppen1._0.TheWheel
{
    internal class UserPage
    {
        public void FrontPageUser()
        {

            while (true)
            {
                MenuData.UserView userView = new MenuData.UserView();
                Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                int choise = Helpers.Helpers.MenuReader(userView.userFrontPage, userView.userFrontPageLocation, true);
                switch (choise)
                {

                    case 0: //Profile

                        Profile();

                        break;

                    case 1: //Categories
                        Helpers.ProductCategoryHelpers productCategoryHelpers = new Helpers.ProductCategoryHelpers();
                        productCategoryHelpers.TheCategory();

                        break;

                    case 2: //Search

                        Helpers.SearchHelpers searchHelpers = new Helpers.SearchHelpers();
                        searchHelpers.TheSearcher();

                        break;

                    case 3: //Cart

                        Helpers.CartHelpers cartHelpers = new Helpers.CartHelpers();
                        cartHelpers.ViewTheCart();

                        break;
                    case 4: //Logg out

                        Helpers.Helpers.LoggOut();
                        Models.Cart.TheCart.Clear();

                        return;
                }



            }

        }

        private static void Profile()
        {

            Console.Clear();
            Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
            MenuData.UserView userView = new MenuData.UserView();
            int choise = Helpers.Helpers.MenuReader(userView.userProfilePage, userView.userProfilePageLocation, false);

            switch (choise)
            {

                case 0: // adress - ändra,lägg till, sätt ny main

                    Adress();


                    break;


                case 1: // beställningar - se alla, status, kostnad , beställning gjord, när anländer ,välja för tydligare info, 

                    break;


                case 2: // betalning - se kort, ta bort, lägg till

                    Console.Clear();
                    Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                    UserProfileHelpers.CardOption();

                    break;

                case 3:

                    return;


            }



        }

        private static void Adress()
        {
            Console.Clear();
            Helpers.Helpers.MenuLogoOut(Start.x, Start.y);

            AddToDb.Connectors connectors = new AddToDb.Connectors();
            var userInfo = connectors.GetUserInfo(Start.user.UserId);


            Helpers.UserProfileHelpers profileHelpers = new Helpers.UserProfileHelpers();
            profileHelpers.ChoseAdress(userInfo, Start.x + 15, Start.y + 15, 20, false);

            MenuData.UserView userView = new MenuData.UserView();
            int choise = Helpers.Helpers.MenuReader(userView.userProfileAdressPage, userView.userProfileAdressLocation, false);




            switch (choise)
            {

                case 0: //  sätt ny main

                    int adressIdMain = profileHelpers.ChoseAdress(userInfo, Start.x + 15, Start.y + 15, 20, true);
                    connectors.SetNewMainAdress(adressIdMain, Start.user.UserId);

                    break;


                case 1: // Lägg till

                    Console.Clear();
                    Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                    CheckOutHelpers.EnterNewAdress();
                    


                    break;


                case 2: // ändra

                    int adressIdChange = profileHelpers.ChoseAdress(userInfo, Start.x + 15, Start.y + 15, 20, true);
                    AddToDb.DbAddCustomer dbAddCustomer = new AddToDb.DbAddCustomer();
                    Console.Clear();
                    Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                    Models.UserInfo newUserInfo = dbAddCustomer.AddNewAdress(Start.x, Start.y);


                    connectors.ChagneAdress
                        (adressIdChange, newUserInfo.Adress, newUserInfo.PostalCode, newUserInfo.City, newUserInfo.Country, newUserInfo.TelephoneNumber);


                    break;


            }



        }

        private static void Orders()
        {
            MenuData.UserView userView = new MenuData.UserView();
            int choise = Helpers.Helpers.MenuReader(userView.userFrontPage, userView.userFrontPageLocation, true);

            switch (choise)
            {

                case 0: // adress - ändra,lägg till, sätt ny main
                    break;


                case 1: // beställningar - se alla, status, kostnad , beställning gjord, när anländer ,välja för tydligare info, 
                    break;


                case 2: // betalning - se kort, ta bort, lägg till
                    break;


            }


        }

        private static void PayCards()
        {
            MenuData.UserView userView = new MenuData.UserView();
            int choise = Helpers.Helpers.MenuReader(userView.userFrontPage, userView.userFrontPageLocation, true);

            switch (choise)
            {

                case 0: // adress - ändra,lägg till, sätt ny main
                    break;


                case 1: // beställningar - se alla, status, kostnad , beställning gjord, när anländer ,välja för tydligare info, 
                    break;


                case 2: // betalning - se kort, ta bort, lägg till
                    break;


            }


        }


    }
}
