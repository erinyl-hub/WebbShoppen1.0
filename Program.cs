namespace WebbShoppen1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Helpers.AddProductCategory productCategory = new Helpers.AddProductCategory();

            productCategory.CreateProductCategory();

            Console.ReadLine();


        }
    }
}
