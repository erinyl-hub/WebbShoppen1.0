using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.MenuData;

namespace WebbShoppen1._0.TheWheel
{
    internal class FrontMenuChoise
    {

        public void FrontPageDefult(int choise, List<Models.User> loggInInfoList)
        {
            switch (choise) 
            { 

                case 0: //Logg in

                    Console.Clear();
                    Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                    Helpers.Helpers.LoggIn(Start.x + 42, Start.y + 13, loggInInfoList);

                    break;

                case 1: //Register

                    AddToDb.DbAddCustomer dbAddCustomer = new AddToDb.DbAddCustomer();
                    Console.Clear();
                    Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                    dbAddCustomer.AddCustomer(Start.x + 34, Start.y + 13);

                    break;



            }

        }



        




    }
}
