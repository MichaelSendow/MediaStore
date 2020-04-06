using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace MediaStore
{
    internal class ShoppingBasket
    {
        #region Properties

        public IDictionary<uint, Product> Products
        {
            get; set;
        }

        #endregion Properties

        #region Constructors

        public ShoppingBasket()
        {
            Products = new Dictionary<uint, Product>();
        }

        #endregion Constructors

        #region Methods

        public void AddProductToBasket(Product product, uint qty)
        {

            if (Products.ContainsKey(product.ProductCode))
            {
                Products[product.ProductCode].Quantity += qty;
            }
            else
            {
                
                Products.Add(product.ProductCode, new Product(product));
                Products[product.ProductCode].Quantity = qty;
            }
        }
               
        public void ClearBasket()
        {
            Products.Clear();
        }

        internal Product GetProduct(uint productCode)
        {
            if (Products.TryGetValue(productCode, out Product product))
                return product;
            else
            {
                throw new Exception("Product does not exist");
            }
        }

        #endregion Methods

    }
}