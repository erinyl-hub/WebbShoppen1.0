using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.MenuData
{
    internal class LoggIn
    {
        public List<string> FrontPageOne = new List<string> // Defult
        {
            "Logg in",
            "Register",
            "Categories",
            "Search",
        };

        public int[,] FrontPageOneLocations =
        {
            {27 +22,11},
            {39+22,11},
            {52+22,11},
            {67+22,11},

        };


        public List<string> FrontPageTwo = new List<string> // Inloggad
        {
            "Logg in",
            "Register",
            "Categories",
            "Search",
        };

        public int[,] FrontPageTwoLocations =
        {
            {27 +22,11},
            {39+22,11},
            {52+22,11},
            {67+22,11},

        };

    }
}
