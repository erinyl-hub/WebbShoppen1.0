using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class PaymentInfo
    {

        public int Id { get; set; }
        public bool Invoice { get; set; }
        public int BillingAdress { get; set; }
        public bool Installment { get; set; }
        public int MountCount { get; set; }
        public bool Card { get; set; }

        public int? CardInfoId { get; set; }
        //public int? UserInfoId { get; set; }
        public int OrderId { get; set; }

        //public virtual UserInfo UserInfo { get; set; }
        public virtual CardInfo? CardInfo { get; set; }
        public virtual Order Order { get; set; }

    }
}
