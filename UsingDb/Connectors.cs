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


        public void UpdateSale(Models.Product product)
        {
            string sql =
                "UPDATE [WebbShoppen1.0].[dbo].[Product] SET OnSale = @OnSale, DiscountAmount = @DiscountAmount WHERE Id = @Id";


            using (var connection = new SqlConnection(connString))
            {
                
                connection.Execute(sql, new { OnSale = product.OnSale, DiscountAmount = product.DiscountAmount, Id = product.Id });
            }

        }

    }
}
