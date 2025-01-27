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

        public OrderDetail(int quantity, int productId, int orderId) 
        {
            Quantity = quantity;
            ProductId = productId;
            OrderId = orderId;

        }


        public int Id { get; set; }
        public int Quantity { get; set; }
 

        public int ProductId { get; set; }
        public int OrderId { get; set; }


        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
