using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.MenuData
{
    internal class AddProduct
    {
        public List<string> addProductMenu = new List<string>
        { 
            "Name",
            ">",
            "Description",
            ">",
            "Unit price",
            ">",
            "Units in stock",
            ">",
            "Manufacturer Id",
            ">",
             "Supplier Id",
            ">",
            "Product Category Id",
            ">",

        };

        public List<string> wrongFormatWindow = new List<string>
        {
            "You have enterd the worng format",
            "          Try again",

        };

        public List<string> wrongId = new List<string>
        {
            "Id does not exist",
            "    Try again",

        };

    }
}
