using System;
using System.Collections.Generic;

namespace MediaStore
{
    internal class ShoppingBasket
    {
        #region Properties

        /// <summary>
        /// Dictionary som håller produkter. 
        /// </summary>
        public IDictionary<uint, Product> Products { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Konstruktor som skapar en tom varukorg
        /// </summary>
        public ShoppingBasket()
        {
            Products = new Dictionary<uint, Product>();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Lägger till en produkt i varukorgen med Quantity = qty
        /// </summary>
        /// <param name="product">Produkt att lägga till</param>
        /// <param name="qty">Antal exemplar av produkten</param>
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

        /// <summary>
        /// Tömmer varukorgen på produkter
        /// </summary>
        public void ClearBasket()
        {
            Products.Clear();
        }

        /// <summary>
        /// Hämtar produkt från varukorgen.
        /// </summary>
        /// <param name="productCode">Produktnummer för varan som ska hämtas</param>
        /// <returns>Produkt från varukorgen</returns>
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