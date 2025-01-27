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

        };

        public int[,] FrontPageOneLocations =
        {
            {39,10},
            {51,10},


        };


        public List<string> FrontPageTwo = new List<string> // User
        {
            "Profile",
            "Categories",
            "Search",
            "Cart"
        };

        public int[,] FrontPageTwoLocations =
        {
            {28,10},
            {40,10},
            {55,10},
            {66,10},

        };

        public List<string> FrontPageTree = new List<string> // Admin
        {
            "Profile",
            "Admin",
            "Categories", 
            "Search",

        };

        public int[,] FrontPageTreeLocations =
        {
            {28,10},
            {40,10},
            {50,10},
            {65,10},

        };

    }
}
