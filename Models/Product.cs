using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class Product
    {
        public Product() { }

        public Product
            (string productName, string description, double productPrice,
            int? reorderLevel, bool outgoingProduct, bool onSale, double? discountAmount,
            int supplierId, int productCategoryId) 
        {
            ProductName = productName;
            Description = description;
            ProductPrice = productPrice;
            ReorderLevel = reorderLevel;
            OutgoingProduct = outgoingProduct;
            OnSale = onSale;
            DiscountAmount = discountAmount;

            SupplierId = supplierId;
            ProductCategoryId = productCategoryId;
        }


        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public double ProductPrice { get; set; }
        public int ProductInStock { get; set; }
        public int? ReorderLevel { get; set; }
        public bool OutgoingProduct { get; set; }
        public bool OnSale { get; set; }
        public double? DiscountAmount { get; set; }

        public int SupplierId { get; set; }
        public int ProductCategoryId { get; set; }

        public virtual OrderDetail OrderDetails { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Supplier Supplier { get; set; }


    }
}
