using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WebbShoppen1._0.TheWheel;

namespace WebbShoppen1._0.AddToDb
{
    internal class Connectors
    {
        static string connString = "data source=.\\SQLEXPRESS; initial catalog=WebbShoppen1.0; persist security info=True; Integrated Security=True; TrustServerCertificate=True;";


        public void UpdateSale(Models.Product product)
        {
            string sql =
                "UPDATE [WebbShoppen1.0].[dbo].[Product] SET OnSale = @OnSale, DiscountAmount = @DiscountAmount WHERE Id = @Id";


            using (var connection = new SqlConnection(connString))
            {
                
                connection.Execute(sql, new { OnSale = product.OnSale, DiscountAmount = product.DiscountAmount, Id = product.Id });
            }

        }

        public void AddAdress(Models.UserInfo userInfo)
        {
            string sql =
                "INSERT INTO [WebbShoppen1.0].[dbo].[UserInfo]" +
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

    }
}
