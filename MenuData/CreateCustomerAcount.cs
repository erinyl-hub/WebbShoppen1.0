using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.MenuData
{
    internal class CreateCustomerAcount
    {
        public List<string> createLogginData = new List<string> {
            "Enter emailadress",
            ">",
            "Enter password",
            ">",
            "Confirm password",
            ">"
        };

        public List<string> createPersenolInfo = new List<string> {
            "Name: ",
            "Surname: ",
            "Year born: ",
            "Gender: (1) Male | (2) Female",
            "Adress: ",
            "Postalcode: ",
            "City: ",
            "Country: ",
            "Telephonenumber: " 
        };

        public List<string> passwordNotMatch = new List<string> {
            "Password did not match",
            "      Try again",
            
        };

        public List<string> wrongYear = new List<string> {
            " Year was not in the right format",
            "          Try again",
            "        Example: 2024"

        };

        public List<string> wrongGenderKey = new List<string> {
            "    Input was wrong   ",
            "       Try again",
            "        Press",
            "      1 for male",
            "     2 for female"

        };

        public List<string> emailInUse = new List<string> {
            "The email adress is in use",
            "       Try again"

        };



    }
}
