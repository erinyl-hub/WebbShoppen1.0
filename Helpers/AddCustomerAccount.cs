using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebbShoppen1._0.MenuData;

namespace WebbShoppen1._0.Helpers
{
    internal class AddCustomerAccount
    {
        public Models.Customer CreateAcount()
        {

            int x = 40;
            int y = 10;

            MenuData.AddCustomerAcount createCustomerAcount = new MenuData.AddCustomerAcount();
            var logginData = new Window("Enter loggin data", x, y, createCustomerAcount.createLogginData);
            logginData.Draw(5);


            string emailAdress = CreateEmailAdress(x, y);
            string password = CreatePassword(x + 3, y);

            Console.Clear();
            var customerInfo = new Window("Enter personal info", x, y, createCustomerAcount.createPersenolInfo);
            customerInfo.Draw(8);

            Console.SetCursorPosition(x + 7, y + 1);
            string name = Console.ReadLine();

            Console.SetCursorPosition(x + 10, y + 2);
            string surname = Console.ReadLine();

            int yearBorn = RightYear(x + 12, y + 3);

            bool gender = RightGender(x + 6, y + 4);

            Console.SetCursorPosition(x + 9, y + 5);
            string adress = Console.ReadLine();

            Console.SetCursorPosition(x + 13, y + 6);
            string postalCode = Console.ReadLine();

            Console.SetCursorPosition(x + 7, y + 7);
            string city = Console.ReadLine();

            Console.SetCursorPosition(x + 10, y + 8);
            string country = Console.ReadLine();

            Console.SetCursorPosition(x + 18, y + 9);
            string telephoneNumber = Console.ReadLine();

            Models.Customer customer = new Models.Customer
                (emailAdress,password,name,surname,yearBorn,gender,adress,postalCode,city,country,telephoneNumber);

            return customer;
        }

        public string CreatePassword(int x, int y)
        {
            while (true)
            {
                Console.SetCursorPosition(x, y + 4);
                string password = Console.ReadLine();



                Console.SetCursorPosition(x, y + 6);
                string passwordAgain = Console.ReadLine();

                if (password == passwordAgain && password != "")
                {
                    return password;
                }

                else
                {
                    MenuData.AddCustomerAcount passwordNotMatch = new MenuData.AddCustomerAcount();
                    var notMatch = new Window("", x - 1, y + 8, passwordNotMatch.passwordNotMatch);
                    notMatch.Draw(0);

                    password = Helpers.Replacer(password.Length);
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write(password);

                    passwordAgain = Helpers.Replacer(passwordAgain.Length);
                    Console.SetCursorPosition(x, y + 6);
                    Console.Write(passwordAgain);
                }
            }
        }

        public int RightYear(int x, int y)
        {
            int year;

            while (true)
            {
                Console.SetCursorPosition(x, y);

                if (int.TryParse(Console.ReadLine(), out year))
                {
                    string rightFormat = Convert.ToString(year);

                    if (rightFormat.Length == 4)
                    {
                        Helpers.clearMsg(x - 13, y + 8, 37, 5);
                        return year;
                    }
                }

                MenuData.AddCustomerAcount yearWrongFormat = new MenuData.AddCustomerAcount();
                var notMatch = new Window("", x - 13, y + 8, yearWrongFormat.wrongYear);
                notMatch.Draw(0);
                Console.SetCursorPosition(x, y);
                Console.Write("          ");
            }
        }

        public bool RightGender(int x, int y)
        {
            while (true)
            {
                char gender = Console.ReadKey(true).KeyChar;
                if (gender == '1')
                {
                    Helpers.clearMsg(x + 3, y, 25, 1);
                    Console.SetCursorPosition(x + 3, y);
                    Console.Write("Male");
                    Helpers.clearMsg(x - 1, y + 7, 26, 7);
                    return false;
                }
                else if (gender == '2')
                {
                    Helpers.clearMsg(x + 3, y, 25, 1);
                    Console.SetCursorPosition(x + 3, y);
                    Console.Write("Female");
                    Helpers.clearMsg(x - 1, y + 7, 26, 7);
                    return true;
                }

                MenuData.AddCustomerAcount wrongGenderKey = new MenuData.AddCustomerAcount();
                var notMatch = new Window("", x - 1, y + 7, wrongGenderKey.wrongGenderKey);
                notMatch.Draw(0);
            }
        }

        public string CreateEmailAdress(int x, int y)
        {
            while (true)
            {
                bool inUse = true;
                Console.SetCursorPosition(x + 3, y + 2);
                string emailAdress = Console.ReadLine();

                using (var dB = new Models.MyDbContext())
                {
                    foreach (var customer in dB.Customers)
                    {
                        if(customer.EmailAdress == emailAdress) {inUse = false;}
                    }          
                }

                if(inUse == true && emailAdress != "")
                {
                    Helpers.clearMsg(x - 13, y + 8, 43, 4);
                    return emailAdress;
                }

                MenuData.AddCustomerAcount emailInUse = new MenuData.AddCustomerAcount();
                var notMatch = new Window("", x, y + 8, emailInUse.emailInUse);
                notMatch.Draw(0);
                emailAdress = Helpers.Replacer(emailAdress.Length);
                Console.SetCursorPosition(x + 3, y + 2);
                Console.Write(emailAdress);
            }

        }
    }
}
