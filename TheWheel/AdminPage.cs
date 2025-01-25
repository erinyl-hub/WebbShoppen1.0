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
                Console.Clear();
                Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                MenuData.AdminView adminView = new MenuData.AdminView();
                int choise = Helpers.Helpers.MenuReader(adminView.adminPageDefult, adminView.adminPageDefultLocations,false);


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
                    case 4: //Logg out

                        return;
                }
            }

        }

        public static void AdminPage(AdminView adminView)
        {


            while (true)
            {
                Console.Clear();
                Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                int choise = Helpers.Helpers.MenuReader(adminView.adminPage, adminView.adminPageLocations,false);


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
                    case 4: //

                        return;



                }
            }



        }

        public static void AdminProductView(AdminView adminView)
        {

            while (true)
            {
                Console.Clear();
                Helpers.Helpers.MenuLogoOut(Start.x, Start.y);
                int choise = Helpers.Helpers.MenuReader(adminView.adminProductViewPage, adminView.adminProductViewPageLocations,false);
                Helpers.AdminHelpers adminHelpers = new Helpers.AdminHelpers();


                switch (choise)
                {
                    case 0: // Add Product

                        UsingDb.DbAddProduct dbAddProduct = new UsingDb.DbAddProduct();
                        dbAddProduct.AddProduct(Start.x + 3, Start.y + 11); // läger till produkt

                        break;

                    case 1: // Ändra product

                        UsingDb.GetInfoDb getInfoDbEdit = new UsingDb.GetInfoDb();
                        int productIdEdit = adminHelpers.ChoseProduct(adminView.adminProductEdit); // all produkter
                        Models.Product productToChange = getInfoDbEdit.GetDbInfoOneObject(productIdEdit); // väljer 1 produkt



                        break;

                    case 2: // sätt produkt på sale


                        UsingDb.GetInfoDb getInfoDbSale = new UsingDb.GetInfoDb();
                        int productIdSale = adminHelpers.ChoseProduct(adminView.adminProductSale); // all produkter
                        Models.Product productOnSale = getInfoDbSale.GetDbInfoOneObject(productIdSale); // väljer 1 produkt
                        adminHelpers.ProductOnSale(productOnSale);
                        break;

                    case 3: // sätt produkt på sale

                        break;

                    case 4: // sätt produkt på sale

                        return;
                        
                }
            }

        }

    }
}
