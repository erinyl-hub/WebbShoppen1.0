using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.MenuData
{
    internal class FrontMenu
    {
        public List<string> FrontPageOne = new List<string> // Defult
        {
            "Logg in",
            "Register",
            "Categories",
            "Search",
            "Cart",
        };

        public int[,] FrontPageOneLocations =
        {
            {22,10},
            {34,10},
            {47,10},
            {62,10},
            {73,10},

        };


        public List<string> FrontPageTwo = new List<string> // Inloggad
        {
            "Profile",
            "Categories",
            "Search",
            "Cart"
        };

        public int[,] FrontPageTwoLocations =
        {
            {31,11},
            {43,11},
            {58,11},
            {69,11},

        };

        public List<string> FrontPageTree = new List<string> // Inloggad
        {
            "Profile",
            "Admin",
            "Categories", 
            "Search",

        };

        public int[,] FrontPageTreeLocations =
        {
            {30,11},
            {42,11},
            {52,11},
            {67,11},

        };

    }
}
