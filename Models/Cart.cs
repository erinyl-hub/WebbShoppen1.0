using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class Cart
    {
        public int? UserId { get; set; } = null;
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int Amount { get; set; } = 0;
        public double UnitPrice { get; set; }
        public double Discount { get; set; } = 0;
        public double FinalPrice => Math.Round(UnitPrice - Discount,2);
        public double TotalPriceProducts => Amount * FinalPrice;

        public static List<Cart> TheCart { get; set; }
        public static int? CartCount => TheCart?.Count;


    }
}
