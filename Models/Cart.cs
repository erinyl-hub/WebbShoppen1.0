using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.TheWheel;
using WebbShoppen1._0.AddToDb;

namespace WebbShoppen1._0.Models
{
    internal class Cart
    {
        // public int? UserId { get; set; } = null; // ev om man inte är inloggad?
        public int ProductId { get; set; } = 0;
        public string ProductName { get; set; } = "";
        public int Amount { get; set; } = 0;
        public double UnitPrice { get; set; } = 0;
        public double Discount { get; set; } = 0;
        public double FinalPrice => Math.Round(UnitPrice - Discount, 2);
        public double TotalPriceProducts => Amount * FinalPrice;

        public static List<Cart> TheCart = new List<Cart>();
        public static int CartCount => TheCart?.Count ?? 0;



        public void AddToCartFromMenuSingel(int ProductId, Cart cartProduct)
        {

            AddToDb.GetInfoDb getInfoDb = new AddToDb.GetInfoDb();
            Models.Product product = getInfoDb.GetDbInfoOneObject<Product>(ProductId);


                foreach (var goods in TheCart)
                {
                    if (goods.ProductId == product.Id)
                    {
                        goods.Amount++;
                        return;
                    }

                }
            

            cartProduct.ProductId = product.Id;
            cartProduct.ProductName = product.ProductName;
            cartProduct.UnitPrice = product.ProductPrice;
            cartProduct.Discount = product.DiscountAmount ?? 0;
            cartProduct.Amount = 1;
            
            TheCart.Add(cartProduct);


        }


    }
}
