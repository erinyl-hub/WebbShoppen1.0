using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace WebbShoppen1._0.UsingDb
{
    internal class Connectors
    {
        static string connString = "data source=.\\SQLEXPRESS; initial catalog=WebbShoppen1.0; persist security info=True; Integrated Security=True; TrustServerCertificate=True;";


        public static List<Models.Product> CitiesOut()
        {
            string sql = "SELECT TOP (1000) [Id]\r\n      ,[ProductName]\r\n      ,[Description]\r\n      ,[ProductPrice]\r\n      ,[ProductInStock]\r\n      ,[ReorderLevel]\r\n      ,[OutgoingProduct]\r\n      ,[OnSale]\r\n      ,[DiscountAmount]\r\n      ,[ManufacturerId]\r\n      ,[SupplierId]\r\n      ,[ProductCategoryId]\r\n  FROM [WebbShoppen1.0].[dbo].[Products]";
            List<Models.Product> cities = new List<Models.Product>();

            using (var connection = new SqlConnection(connString))
            {
                cities = connection.Query<Models.Product>(sql).ToList();
            }
            return cities;
        }

    }
}
