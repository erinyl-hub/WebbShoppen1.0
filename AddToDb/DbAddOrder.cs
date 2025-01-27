using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Models;

namespace WebbShoppen1._0.AddToDb
{
    internal class DbAddOrder
    {

        public void AddOrder(Models.Order order, List<Models.OrderDetail> orderDetails, Models.PaymentInfo paymentInfo)
        {

            using (var dB = new Models.MyDbContext())
            {
                // Koppla varje OrderDetail i listan till Order
                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.Order = order;
                }

                // Koppla PaymentInfo till Order
                paymentInfo.Order = order;

                // Lägg till Order (huvudobjektet)
                dB.Order.Add(order);

                // Lägg till alla OrderDetails i databaskontexten
                dB.OrderDetail.AddRange(orderDetails);

                // Lägg till PaymentInfo i databaskontexten
                dB.PaymentInfos.Add(paymentInfo);

                // Spara alla ändringar i databasen
                dB.SaveChanges();
            }
        }

    }
}
