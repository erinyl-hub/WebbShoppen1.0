using WebbShoppen1._0.AddToDb;
using WebbShoppen1._0.Models;
using WebbShoppen1._0.TheWheel;

namespace WebbShoppen1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {


            TheWheel.Start start = new TheWheel.Start();

            start.StartMenu();
            
            //Helpers.Helpers.MenuLogoOut(25,1);


            // Helpers.Helpers.LoggIn(28, 11);



            //AddToDb.DbAddCustomer dbAddCustomer = new AddToDb.DbAddCustomer(); // lägga till kund
            //dbAddCustomer.AddCustomer(60, 14);

            //AddToDb.DbAddManufacturer dbAddManufacturer = new AddToDb.DbAddManufacturer(); // lägga till manufacurer
            //dbAddManufacturer.AddManufacturer(64, 14);

            //AddToDb.DbAddProductCategory dbAddProductCategory = new DbAddProductCategory(); // lägg till kategori
            //dbAddProductCategory.AddProductCategory(64, 14);

            //AddToDb.DbAddSupplier dbAddSupplier = new AddToDb.DbAddSupplier(); // lägg till supplier
            //dbAddSupplier.AddSupplier(64, 14);

            //Helpers.AddProduct addProduct = new Helpers.AddProduct();  // lägga till produkt
            //addProduct.CreateProduct(27, 11);


            Console.ReadLine();


        }   
    }
}
