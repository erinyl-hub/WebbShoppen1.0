using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                        break;

                    case 1: //Categories

                        break;

                    case 2: //Search

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
            MenuData.UserView userView = new MenuData.UserView();
            int choise = Helpers.Helpers.MenuReader(userView.userFrontPage, userView.userFrontPageLocation, true);

            switch (choise)
            {

                case 0: // adress - ändra,lätt till ta bort
                    break;


                case 1: // beställningar
                    break;


                case 2: // betalning
                    break;


                case 3:
                    break;


                case 4:
                    break;


                case 5:
                    break;

            }



        }


    }
}
