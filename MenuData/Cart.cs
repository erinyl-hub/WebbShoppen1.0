using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.MenuData
{
    internal class Cart
    {
        public List<string> inCart = new List<string> // User
        {
            "Edit cart",
            "Check out",
            "Back",

        };

        public int[,] inCartLocation =
        {
            {31,10},
            {45,10},
            {59,10},


        };


    }
}
