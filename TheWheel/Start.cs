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



            while (true)
            {
                MenuData.FrontMenu frontMenu = new MenuData.FrontMenu();
                FrontMenuChoise frontMenuChoise = new FrontMenuChoise();
                int choise;


                

                if (user.IsAdmin && user.LoggdIn)
                {
                    TheWheel.AdminPages adminPages = new TheWheel.AdminPages();
                    adminPages.FrontPageAdmin();

                }

                else if (user.LoggdIn) 
                {
                    

                    choise = Helpers.Helpers.MenuReader(frontMenu.FrontPageTwo, frontMenu.FrontPageTwoLocations);
                    frontMenuChoise.FrontPageCustomer(choise);

                }

                else 
                {
                    choise = Helpers.Helpers.MenuReader(frontMenu.FrontPageOne, frontMenu.FrontPageOneLocations);
                    frontMenuChoise.FrontPageDefult(choise);

                
                }









            }
            

        }

    }
}
