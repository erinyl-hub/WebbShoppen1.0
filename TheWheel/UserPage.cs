﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.TheWheel
{
    internal class UserPage
    {
        public void FrontPageUser()
        {

            while (true)
            {
                MenuData.UserView userView = new MenuData.UserView();
                int choise = Helpers.Helpers.MenuReader(userView.userFrontPage, userView.userFrontPageLocation,true);
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

                        return;
                }



            }

        }


    }
}
