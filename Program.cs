using WebbShoppen1._0.Models;

namespace WebbShoppen1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //AddToDb.DbAddManufacturer.AddManufacturer();



            Helpers.AddProduct addProduct = new Helpers.AddProduct();
            addProduct.CreateProduct();


            Console.ReadLine();


        }   
    }
}
