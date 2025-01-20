using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Helpers;

namespace WebbShoppen1._0.Models
{
    internal class ProductCategory : IHasInfo
    {
        public ProductCategory() { }

        public ProductCategory(string categoryName, string description) 
        { 
            CategoryName = categoryName;
            Description = description;
        }


        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? ProductCategoryCount { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
