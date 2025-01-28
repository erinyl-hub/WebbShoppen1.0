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
             "Supplier Id",
            ">",
            "Category Id",
            ">",

        };

        public List<string> wrongFormatWindow = new List<string>
        {
            "Worng format",
            " Try again",

        };

        public List<string> wrongId = new List<string>
        {
            "ID does not exist",
            "    Try again",

        };

    }
}
