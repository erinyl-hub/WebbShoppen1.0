using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class Order
    {

        public Order() { }

        public Order
            (DateTime orderDate, DateTime arrivalDate, double totalCost, int productCount,
            bool orderArrived, bool orderUnderway, bool orderProcessing, int userInfoId) 
        {
            OrderDate = orderDate;
            ArrivalDate = arrivalDate;
            TotalCost = totalCost;
            ProductCount = productCount;
            OrderArrived = orderArrived;
            OrderProcessing = orderProcessing;
            UserInfoId = userInfoId;         
        }


        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public double TotalCost { get; set; }
        public int ProductCount { get; set; }
        public bool OrderArrived { get; set; }
        public bool OrderUnderway { get; set; }
        public bool OrderProcessing { get; set; }

        public int UserInfoId { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        
    }
}
