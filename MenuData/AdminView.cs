using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.MenuData
{
    internal class AdminView // fixa så att man som admin kan lägga till en produkt, kan sätta produkt på sale, samt vissa på inlogg sida
    {

        public List<string> adminPageDefult = new List<string> // Admin
        {
            "Profile",
            "Admin",
            "Categories",
            "Search",

        };

        public int[,] adminPageDefultLocations =
        {
            {28,10},
            {40,10},
            {50,10},
            {65,10},

        };

        public List<string> adminPage = new List<string> // Defult
        {
            "View Product",

        };

        public int[,] adminPageLocations =
        {
            {22,10},
            //{34,10},
            //{47,10},
            //{62,10},
            //{73,10},

        };

        public List<string> adminProductViewPage = new List<string>
        {
            "Add Product",
            "Edit",
            "Sale",
            //"View Product",

        };

        public int[,] adminProductViewPageLocations =
        {
            {22,10},
            {34,10},
            {47,10},
            //{62,10},
            //{73,10},

        };

        public List<string> adminProductSale = new List<string>
        {
            "Chose product to put on sale",
           

        };

        public List<string> adminProductEdit = new List<string>
        {
            "   Chose product to edit   ",


        };

        public List<string> adminProductSaleValue = new List<string>
        {
            "Enter sale value: ",


        };








    }
}
