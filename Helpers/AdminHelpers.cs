using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Helpers
{
    internal class AdminHelpers
    {
        public  static void ChoseProduct()
        {
            AdminHelpers adminHelpers = new AdminHelpers();
            List<Models.ProductUse> productList = adminHelpers.GetProductList();

            int rowCount;

            Helpers.NavigeraOchVälj(productList, 20, 5);



        }

        public List<Models.ProductUse> GetProductList()
        {
            UsingDb.GetInfoDb getInfoDb = new UsingDb.GetInfoDb();
            var allProducts = getInfoDb.GetDbInfo<Models.Product>();

            List<Models.ProductUse> productList = new List<Models.ProductUse>();

            for (int i = 0; i < allProducts.Count; i++) 
            {
                Models.ProductUse productUse = new Models.ProductUse 
                {Id = allProducts[i].Id, Name = allProducts[i].ProductName, IdInList = i};
                productList.Add(productUse);
            
            }



            return productList;


        }



    }
}
