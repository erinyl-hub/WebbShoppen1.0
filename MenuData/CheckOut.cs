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

        public List<string> paymentOptions = new List<string> // Defult
        {
            "Card",
            "Invoice",
            "Installment"

        };

        public int[,] paymentOptionsLocations =
        {
            {32,13},
            {41,13},
            {53,13},

        };

        public List<string> cardOption = new List<string> // Defult
        {
            "Choose card",
            "Add card",
            

        };

        public int[,] cardOptionLocations =
        {
            {36,10},
            {51,10},


        };

        public List<string> shipingOption = new List<string> // Defult
        {
            "Reguler 25$",
            "Express 50$",

        };

        public int[,] shipingOptionLocations =
        {
            {35,10},
            {51,10}

        };

        public List<string> confirmOrder = new List<string> // Defult
        {
            "Confirm Order",
            "Cancel",

        };

        public int[,] confirmOrderLocations =
        {
            {35,10},
            {53,10}

        };




    }
}

;