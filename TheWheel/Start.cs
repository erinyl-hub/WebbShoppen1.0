﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.TheWheel
{
    internal class Start
    {
        public static Models.UserInProgram user = new Models.UserInProgram();
        public static int x = 20;
        public static int y = 1;

        public async void StartMenu()
        {



            while (true)
            {
                AddToDb.GetInfoDb dbInfo = new AddToDb.GetInfoDb();
                var loggInInfoList = dbInfo.GetDbInfoAsync<Models.User>();
                MenuData.FrontMenu frontMenu = new MenuData.FrontMenu();
                FrontMenuChoise frontMenuChoise = new FrontMenuChoise();
                Console.Clear();
                Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                int choise;


                

                if (user.IsAdmin && user.LoggdIn)
                {
                    TheWheel.AdminPages adminPages = new TheWheel.AdminPages();
                    adminPages.FrontPageAdmin();

                }

                else if (user.LoggdIn) 
                {                 
                    TheWheel.UserPage userPage = new TheWheel.UserPage();
                    userPage.FrontPageUser();
                }

                else 
                {

                    choise = Helpers.Helpers.MenuReader(frontMenu.FrontPageOne, frontMenu.FrontPageOneLocations, false);
                    frontMenuChoise.FrontPageDefult(choise, await loggInInfoList);
          
                }









            }
            

        }

    }
}
