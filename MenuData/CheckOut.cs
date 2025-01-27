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
            "Chose card",
            "Add card",
            "Back"

        };

        public int[,] cardOptionLocations =
        {
            {30,10},
            {45,10},
            {58,10},

        };

        public List<string> shipingOption = new List<string> // Defult
        {
            "Reguler",
            "Express",

        };

        public int[,] shipingOptionLocations =
        {
            {39,10},
            {51,10}

        };




    }
}

;