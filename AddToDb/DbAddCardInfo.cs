using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Models;
using WebbShoppen1._0.TheWheel;

namespace WebbShoppen1._0.AddToDb
{
    internal class DbAddCardInfo
    {
        public static void AddCardInfo()
        {
            Models.CardInfo cardInfo = CreateCardInfo(Start.x + 35, Start.y + 13);

            using (var dB = new MyDbContext())
            {
                dB.Add(cardInfo);

                dB.SaveChanges();
            }

        }


        private static Models.CardInfo CreateCardInfo(int x, int y)
        {
            
            Console.Clear();
            Helpers.Helpers.MenuLogoOut(Start.x, Start.y);

            List<string> cardInfoMenu = new List<string>() 
            {
                "Card type",
                ">",
                "Card number",
                ">",
                "Card date",
                ">",
                "Card CVV",
                ">"
            };

            Helpers.Window window = new Helpers.Window("Card Info", x, y, cardInfoMenu);
            window.Draw(15,0);

            string cardType = Helpers.Helpers.NotEmpty(x + 3 , y + 2, x + 4, y + 10);
            string cardNumber = Helpers.Helpers.NotEmpty(x + 3, y + 4, x + 4, y + 10);
            string cardDate = Helpers.Helpers.NotEmpty(x + 3, y + 6, x + 4, y + 10);
            string cardCVV = Helpers.Helpers.NotEmpty(x + 3, y + 8, x + 4, y + 10);

            Models.CardInfo cardInfo = new Models.CardInfo() 
            {
                CardType = cardType,
                CardNumber = cardNumber,
                CardDate = cardDate,
                CardCVV = cardCVV,
                UserId = Start.user.UserId
            };

            return cardInfo;


        }
    }
}
