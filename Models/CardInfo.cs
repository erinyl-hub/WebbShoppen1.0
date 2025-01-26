using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class CardInfo
    {
        public int Id { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string CardDate { get; set; }
        public int CardCVV { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<PaymentInfo> OrderDetails { get; set; } = new List<PaymentInfo>();
        public virtual User User { get; set; }
    }
}
