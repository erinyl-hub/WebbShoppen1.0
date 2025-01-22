using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.TheWheel
{
    internal class FrontMenuChoise
    {

        public void FrontPageDefult(int choise)
        {
            switch (choise) 
            { 

                case 0: //Logg in

                    Console.Clear();
                    Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                    Helpers.Helpers.LoggIn(Start.x + 42, Start.y + 13);

                    break;

                case 1: //Register

                    AddToDb.DbAddCustomer dbAddCustomer = new AddToDb.DbAddCustomer();
                    Console.Clear();
                    Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                    dbAddCustomer.AddCustomer(Start.x + 34, Start.y + 13);

                    break;

                case 2: //Categories

                    break;

                case 3: //Search

                    break;

                case 4: //Cart

                    break;

            }

        }

        public void FrontPageCustomer(int choise)
        {
            switch (choise)
            {

                case 0:

                    break;

            }

        }

        public void FrontPageAdmin(int choise)
        {
            switch (choise)
            {

                case 0:

                    break;

            }

        }




    }
}
