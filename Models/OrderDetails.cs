using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class OrderDetail
    {
        public OrderDetail() { }

        public OrderDetail(double unitPrice, int quantity, double? discount, int productId, int orderId) 
        {
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
            ProductId = productId;
            OrderId = orderId;
        }


        public int Id { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double? Discount { get; set; }

        public int ProductId { get; set; }
        public int OrderId { get; set; }


        public virtual Order Order { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
