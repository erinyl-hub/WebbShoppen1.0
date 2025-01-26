using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Helpers;
using WebbShoppen1._0.TheWheel;

namespace WebbShoppen1._0.AddToDb
{
    internal class DbAddCustomer
    {

        public void AddCustomer(int x, int y)
        {
            Models.User user = CreateAcount(x,y);

            Console.Clear();
            Helpers.Helpers.MenuLogoOut(Start.x, Start.y);

            Models.UserInfo userInfo = CreatePersonalInfo(x,y, true);

            using (var dB = new Models.MyDbContext())
            {
                userInfo.User = user;
                dB.UserInfo.Add(userInfo);
                dB.SaveChanges();
            }
        }

        public Models.UserInfo AddNewAdress(int x, int y)
        {
            Models.UserInfo userInfo = CreatePersonalInfo(x + 36, y + 13, false);
            return userInfo;
        }



        private Models.User CreateAcount(int x, int y)
        {
            MenuData.AddCustomerAcount createCustomerAcount = new MenuData.AddCustomerAcount();
            var logginData = new Window("Enter personal data", x, y, createCustomerAcount.createLogginData);
            logginData.Draw(5, 0);

            string emailAdress = CreateEmailAdress(x, y);
            string password = CreatePassword(x + 3, y);

            Console.SetCursorPosition(x + 3, y + 8);
            string name = Console.ReadLine();

            Console.SetCursorPosition(x + 3, y + 10);
            string surname = Console.ReadLine();

            int yearBorn = RightYear(x + 3, y + 12);

            bool gender = RightGender(x + 3, y + 14);

            Models.User loggInInfo = new Models.User
                    (emailAdress, password, surname, surname, yearBorn, gender); 

            return loggInInfo;
        }


        private Models.UserInfo CreatePersonalInfo(int x, int y, bool mainAdress)
        {
            MenuData.AddCustomerAcount createCustomerAcount = new MenuData.AddCustomerAcount();
            var customerInfoMenu = new Window("Enter personal info", x, y, createCustomerAcount.createPersenolInfo);
            customerInfoMenu.Draw(8,0);

            Console.SetCursorPosition(x + 9, y + 1);
            string adress = Console.ReadLine();

            Console.SetCursorPosition(x + 13, y + 2);
            string postalCode = Console.ReadLine();

            Console.SetCursorPosition(x + 7, y + 3);
            string city = Console.ReadLine();

            Console.SetCursorPosition(x + 10, y + 4);
            string country = Console.ReadLine();

            Console.SetCursorPosition(x + 18, y + 5);
            string telephoneNumber = Console.ReadLine();

            Models.UserInfo customerInfo = new Models.UserInfo
                ( adress, postalCode, city, country, telephoneNumber, mainAdress);

            return customerInfo;
        }

        private string CreatePassword(int x, int y)
        {
            while (true)
            {
                Console.SetCursorPosition(x, y + 4);
                string password = Console.ReadLine();

                Console.SetCursorPosition(x, y + 6);
                string passwordAgain = Console.ReadLine();

                if (password == passwordAgain && password != "")
                {
                    Helpers.Helpers.clearMsg(x - 13, y + 15, 43, 4);
                    return password;
                }

                else
                {
                    MenuData.AddCustomerAcount passwordNotMatch = new MenuData.AddCustomerAcount();
                    var notMatch = new Window("", x + 1 , y + 15, passwordNotMatch.passwordNotMatch);
                    notMatch.Draw(0,1);

                    password = Helpers.Helpers.Replacer(password.Length);
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write(password);

                    passwordAgain = Helpers.Helpers.Replacer(passwordAgain.Length);
                    Console.SetCursorPosition(x, y + 6);
                    Console.Write(passwordAgain);
                }
            }
        }

        private int RightYear(int x, int y)
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
                        Helpers.Helpers.clearMsg(x - 5, y + 3, 37, 5);
                        return year;
                    }
                }

                MenuData.AddCustomerAcount yearWrongFormat = new MenuData.AddCustomerAcount();
                var notMatch = new Window("", x - 5, y + 3, yearWrongFormat.wrongYear);
                notMatch.Draw(0,1);
                Console.SetCursorPosition(x, y);
                Console.Write("          ");
            }
        }

        private bool RightGender(int x, int y)
        {
            while (true)
            {
                char gender = Console.ReadKey(true).KeyChar;
                if (gender == '1')
                {
                    Helpers.Helpers.clearMsg(x + 3, y, 25, 1);
                    Console.SetCursorPosition(x + 3, y);
                    Console.Write("Male");
                    Helpers.Helpers.clearMsg(x - 1, y + 7, 26, 7);
                    return false;
                }
                else if (gender == '2')
                {
                    Helpers.Helpers.clearMsg(x + 3, y, 25, 1);
                    Console.SetCursorPosition(x + 3, y);
                    Console.Write("Female");
                    Helpers.Helpers.clearMsg(x - 1, y + 7, 26, 7);
                    return true;
                }

                MenuData.AddCustomerAcount wrongGenderKey = new MenuData.AddCustomerAcount();
                var notMatch = new Window("", x , y + 1, wrongGenderKey.wrongGenderKey);
                notMatch.Draw(0,1);
            }
        }

        private string CreateEmailAdress(int x, int y)
        {
            while (true)
            {
                bool inUse = true;
                Console.SetCursorPosition(x + 3, y + 2);
                string emailAdress = Console.ReadLine();

                using (var dB = new Models.MyDbContext())
                {
                    foreach (var customer in dB.User) // skapa ett link istället?
                    {
                        if (customer.EmailAdress == emailAdress) { inUse = false; }
                    }
                }

                if (inUse == true && emailAdress != "")
                {
                    Helpers.Helpers.clearMsg(x - 13, y + 15, 44, 4);
                    return emailAdress;
                }

                MenuData.AddCustomerAcount emailInUse = new MenuData.AddCustomerAcount();
                var notMatch = new Window("", x + 1, y  + 15, emailInUse.emailInUse);
                notMatch.Draw(0,1);
                emailAdress = Helpers.Helpers.Replacer(emailAdress.Length);
                Console.SetCursorPosition(x + 3, y + 2);
                Console.Write(emailAdress);
            }

        }
    }
}
