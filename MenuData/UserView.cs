using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.MenuData
{
    internal class UserView
    {
        public List<string> userFrontPage = new List<string> // User
        {
            "Profile",
            "Categories",
            "Search",
            "Cart",
            "Logg out"
        };

        public int[,] userFrontPageLocation =
        {
            {20,10},
            {32,10},
            {47,10},
            {58,10},
            {69,10},

        };



    }
}
