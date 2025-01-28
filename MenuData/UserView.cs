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

        public List<string> userProfilePage = new List<string> // User
        {
            "Adress Info",
            "Orders",
            "Card Info",
            "Back",

        };

        public int[,] userProfilePageLocation =
        {
            {25,10},
            {41,10},
            {52,10},
            {66,10},

        };

        public List<string> userProfileAdressPage = new List<string> // User
        {
            "Change main adress",
            "Add new adress",
            "Change",
            "Back",

        };

        public int[,] userProfileAdressLocation =
        {
            {21,10},
            {44,10},
            {63,10},
            {74,10},

        };



    }
}
