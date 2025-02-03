using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WebbShoppen1._0.AddToDb
{
    internal class Connection
    {
        private static MongoClient GetClient()
        {
            string connectionString = "mongodb+srv://eriknylund:SystemTILL2026!@ecluster.7zit7.mongodb.net/?retryWrites=true&w=majority&appName=ECluster";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            //settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls13};

            var client = new MongoClient(settings);

            return client;
        }   

        public static IMongoCollection<Models.LogInRegistry> RegisterLoggIn()
        {
            var client = GetClient();

            var database = client.GetDatabase("LoggInData");

            var personCollection = database.GetCollection<Models.LogInRegistry>("Users");

            return personCollection;
        }



    }
}
