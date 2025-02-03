using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class LogInRegistry
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int UserId { get; set; }
        public DateTime LoggedInTime { get; set; } = DateTime.Now;
        public string UserType { get; set; }

    }
}
