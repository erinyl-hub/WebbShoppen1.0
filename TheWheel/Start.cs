using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.TheWheel
{
    internal class Start
    {
        public static Models.User user = new Models.User();
        public static int x = 20;
        public static int y = 1;

        public void StartMenu()
        {
            Helpers.Helpers.MenuLogoOut(Start.x, Start.y);

            while (true)
            {
                MenuData.FrontMenu frontMenu = new MenuData.FrontMenu();
                FrontMenuChoise frontMenuChoise = new FrontMenuChoise();
                int choise;


                if (user.IsAdmin && user.LoggdIn) 
                {
                    choise = Helpers.Helpers.FrontMeny(frontMenu.FrontPageTree, frontMenu.FrontPageTreeLocations);
                    frontMenuChoise.FrontPageAdmin(choise);

                }

                else if (user.LoggdIn) 
                {
                    choise = Helpers.Helpers.FrontMeny(frontMenu.FrontPageTwo, frontMenu.FrontPageTwoLocations);
                    frontMenuChoise.FrontPageCustomer(choise);

                }

                else 
                {
                    choise = Helpers.Helpers.FrontMeny(frontMenu.FrontPageOne, frontMenu.FrontPageOneLocations);
                    frontMenuChoise.FrontPageDefult(choise);

                
                }









            }
            

        }

    }
}
