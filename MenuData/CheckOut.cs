using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.MenuData
{
    internal class CheckOut
    {
        public List<string> checkOutAdress = new List<string> // Defult
        {
            "Adress",
            ">",
            "PostalCode",
            ">",
            "City",
            ">",
            "Country",
            ">",
            "Telephone Number",
            ">",
        };

        public List<string> checkOutAdressChoise = new List<string> // Defult
        {
            "Use existing adress",
            "Enter new adress",
         
        };

        public int[,] checkOutAdressChoiseLocations =
{
            {29,10},
            {53,10},
 
        };


    }
}

;