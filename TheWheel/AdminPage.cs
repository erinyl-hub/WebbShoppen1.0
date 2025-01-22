using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.MenuData;

namespace WebbShoppen1._0.TheWheel
{
    internal class AdminPages
    {



        public void FrontPageAdmin()
        {
            while (true)
            {
                MenuData.AdminView adminView = new MenuData.AdminView();
                int choise = Helpers.Helpers.MenuReader(adminView.adminPageDefult, adminView.adminPageDefultLocations);
                switch (choise)
                {

                    case 0: //Profile

                        break;

                    case 1: //Admin

                        AdminPage(adminView);

                        break;

                    case 2: //Categories

                        break;

                    case 3: //Search

                        break;
                }
            }

        }

        public static void AdminPage(AdminView adminView)
        {


            while (true)
            {

                int choise = Helpers.Helpers.MenuReader(adminView.adminPage, adminView.adminPageLocations);

                switch (choise)
                {
                    case 0: //Product

                        AdminProductView(adminView);

                        break;

                    case 1: // 


                        break;

                    case 2: //

                        break;

                    case 3: //

                        break;



                }
            }



        }

        public static void AdminProductView(AdminView adminView)
        {

            while (true)
            {
                int choise = Helpers.Helpers.MenuReader(adminView.adminProductViewPage, adminView.adminProductViewPageLocations);

                switch (choise)
                {
                    case 0: // Add Product

                        UsingDb.DbAddProduct dbAddProduct = new UsingDb.DbAddProduct();
                        dbAddProduct.AddProduct(Start.x + 3,Start.y + 11);

                        break;

                    case 1:
                        break;

                    case 2:
                        break;
                }
            }

        }

    }
}
