using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.TheWheel;

namespace WebbShoppen1._0.Helpers
{
    internal class SearchHelpers
    {
        public List<Models.Product> SearchEngine(List<Models.Product> productList, string searchWord)
        {
            var searchResult = productList
                    .Where(product => product.ProductName.Contains(searchWord, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            return searchResult;
        }


        public async Task TheSearcher()
        {
            AddToDb.GetInfoDb getInfoDb = new AddToDb.GetInfoDb();
            var productList = getInfoDb.GetDbInfoAsync<Models.Product>();
            List<string> searchBox = new List<string>() { ">" };


            Console.Clear();
            Helpers.MenuLogoOut(Start.x, Start.y);
            Window window = new Window("Search", TheWheel.Start.x + 40, TheWheel.Start.y + 11, searchBox);
            window.Draw(15, 0);
            Console.SetCursorPosition(TheWheel.Start.x + 43, TheWheel.Start.y + 12);
            string searchWord = Console.ReadLine();

            SearchHelpers searchHelpers = new SearchHelpers();
            List<Models.Product> searchResult = searchHelpers.SearchEngine(await productList, searchWord);


            if (searchResult.Count > 0)
            {
                ProductCategoryHelpers categoryHelpers = new ProductCategoryHelpers();
                List<string> searchResultMsg = new List<string>()
                {   "           [SearchResult]",
                "Press enter on product to add to cart",
                "           Esc to return" };
                categoryHelpers.ChoseProduct(searchResult, Start.x + 15, Start.y + 17, searchResultMsg, 20);
            }

            else 
            {
                Console.Clear();
                Helpers.MenuLogoOut(Start.x, Start.y);
                List<string> noResultMsg = new List<string>() 
                {"No results was found", "Press key to continue..." };
                Window noResult = new Window("", Start.x + 38, Start.y + 11, noResultMsg);
                noResult.Draw(5, 0);
                Console.ReadKey(true);

            }

        }

    }






}
