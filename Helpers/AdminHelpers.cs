using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.TheWheel;
using WebbShoppen1._0.UsingDb;

namespace WebbShoppen1._0.Helpers
{
    internal class AdminHelpers
    {
        public int ChoseProduct(List<string> msg)
        {
            AdminHelpers adminHelpers = new AdminHelpers();
            GetInfoDb getInfoDb = new GetInfoDb();
            List<Models.Product> productList = getInfoDb.GetDbInfo<Models.Product>();

            int productId = Helpers.ChoseObject(productList, TheWheel.Start.x + 17, TheWheel.Start.y + 15, msg);

            return productId;
        }

        public void EditProduct(int productId) // skriva link här?
        {
            //Namn,Desc, price, stock, outgoing



        }


        public void ProductOnSale(Models.Product product)
        {
            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);

            if (product.OnSale == false)
            {
                MenuData.AdminView adminView = new MenuData.AdminView();
                Window window = new Window("", Start.x + 35, Start.y + 13, adminView.adminProductSaleValue);
                window.Draw(25,1);
                double discount = Helpers.checkFormat<double>(Start.x + 54, Start.y + 14, Start.x - 30, Start.y + 1);

                product.OnSale = true;
                product.DiscountAmount = discount;
            }

            else
            {
                product.OnSale = false;
                product.DiscountAmount = 0;
            }

            UsingDb.Connectors connectors = new UsingDb.Connectors();
            connectors.UpdateSale(product);


        }

    }
}
