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

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.Order = order; // kopplar ihop
                }

                paymentInfo.Order = order; // kopplar ihop

                dB.Order.Add(order);

                dB.OrderDetail.AddRange(orderDetails);

                dB.PaymentInfos.Add(paymentInfo);

                dB.SaveChanges();
            }
        }


    }
}
