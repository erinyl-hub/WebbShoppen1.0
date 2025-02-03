using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WebbShoppen1._0.TheWheel;
using WebbShoppen1._0.Models;
using WebbShoppen1._0.MenuData;

namespace WebbShoppen1._0.AddToDb
{
    internal class Connectors
    {
        //static string connString = "data source=.\\SQLEXPRESS; initial catalog=WebbShoppen1.0; persist security info=True; Integrated Security=True; TrustServerCertificate=True;";
        static string connString = "Server=tcp:runedbase.database.windows.net,1433;Initial Catalog=RuneSys24;Persist Security Info=False;User ID=Rune;Password=*SystemTILL2026!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public void UpdateSale(Models.Product product)
        {
            string sql =
                "UPDATE [RuneSys24].[dbo].[Product] SET OnSale = @OnSale, DiscountAmount = @DiscountAmount WHERE Id = @Id";


            using (var connection = new SqlConnection(connString))
            {

                connection.Execute(sql, new { OnSale = product.OnSale, DiscountAmount = product.DiscountAmount, Id = product.Id });
            }

        }

        public void AddAdress(Models.UserInfo userInfo)
        {
            string sql =
                "INSERT INTO [RuneSys24].[dbo].[UserInfo]" +
                 "(" +
                 "[Adress]" +
                 ",[PostalCode]" +
                 ",[City]" +
                 ",[Country]" +
                 ",[TelephoneNumber]" +
                 ",[MainInfo]" +
                 ",[UserId]" +
                 ") " +
               " VALUES (@Adress, @PostalCode, @City , @Country , @TelephoneNumber , @MainInfo , @UserId )";


            using (var connection = new SqlConnection(connString))
            {

                connection.Execute(sql, new
                {
                    Adress = userInfo.Adress,
                    PostalCode = userInfo.PostalCode,
                    City = userInfo.City,
                    Country = userInfo.Country,
                    TelephoneNumber = userInfo.TelephoneNumber,
                    MainInfo = userInfo.MainInfo,
                    UserId = Start.user.UserId
                });
            }

        }

        public async Task<List<Models.CardInfo>> GetCardInfo(int id)
        {

            string sql =
                "SELECT * FROM [RuneSys24].[dbo].[CardInfo] WHERE UserId = @Id";

            using (var connection = new SqlConnection(connString))
            {
                var cardInfo = connection.Query<Models.CardInfo>(sql, new { Id = id }).ToList();
                return cardInfo;

                
            }
        }

        public List<Models.Product> GetProducts(int id)
        {

            string sql =
                "SELECT * FROM [RuneSys24].[dbo].[Product] WHERE ProductCategoryId = @Id";

            using (var connection = new SqlConnection(connString))
            {
                var products = connection.Query<Models.Product>(sql, new { Id = id }).ToList();
                return products;


            }
        }

        public async Task LowerProductDb(int id, int amount)
        {

            string sql =
                "UPDATE Product Set ProductInStock = ProductInStock - @Amount  WHERE Id = @Id";

            using (var connection = new SqlConnection(connString))
            {
                await connection.ExecuteAsync(sql, new { Id = id, Amount = amount });

            }
        }

        public List<Models.UserInfo> GetUserInfo(int id)
        {

            string sql =
                "SELECT * FROM [RuneSys24].[dbo].[UserInfo] WHERE UserId = @Id";

            using (var connection = new SqlConnection(connString))
            {
                var products = connection.Query<Models.UserInfo>(sql, new { Id = id }).ToList();
                return products;
            }
        }

        public void SetNewMainAdress(int newMainId, int userId)
        {

            string sql =
                "UPDATE [RuneSys24].[dbo].[UserInfo] SET MainInfo = 0 WHERE MainInfo = 1 AND UserId = @UserId " +
                "UPDATE [RuneSys24].[dbo].[UserInfo] SET MainInfo = 1 WHERE id = @NewMainId";

            using (var connection = new SqlConnection(connString))
            {
                connection.Execute(sql, new { NewMainId = newMainId, UserId = userId });

            }
        }

        public void ChagneAdress(int adressId, string adress, string postalCode, string city, string country, string telephoneNumber)
        {

            string sql =
                "  UPDATE [RuneSys24].[dbo].[UserInfo] SET " +
                "Adress = @Adress, PostalCode = @PostalCode, City = @City, Country = @Country,TelephoneNumber = @TelephoneNumber WHERE Id = @AdressId";
                

            using (var connection = new SqlConnection(connString))
            {
                connection.Execute
                    (sql, new { 
                        Adress = adress, 
                        PostalCode = postalCode, 
                        City = city, 
                        Country = country, 
                        TelephoneNumber = telephoneNumber, 
                        AdressId = adressId}
                    );

            }
        }

        public List<Models.Order> GetOrders(int id)
        {
            string sql =
                "SELECT * FROM [RuneSys24].[dbo].[Order] WHERE UserInfoId = @Id";

            using (var connection = new SqlConnection(connString))
            {
                var orders =  connection.Query<Models.Order>(sql, new { Id = id });
                return orders.ToList();
            }
        }



    }
}
