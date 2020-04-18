using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaStore
{
    public class Stock
    {

        #region Properties

        /// <summary>
        /// Dictionary som innehåller alla varor i lagret. Key = ProductCode, Value = Product
        /// </summary>
        /// 
        public IDictionary<uint, Product> Products
        {
            get; set;
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Konstruktor som skapar ett tomt lager.
        /// </summary>
        public Stock()
        {
            Products = new Dictionary<uint, Product>();
        }

        /// <summary>
        /// Konstruktor som skapar en kopia av ett existerande lager.
        /// </summary>
        /// <param name="stock"></param>
        public Stock(Stock stock)
        {
            if (stock != null)
            {
                Products = new Dictionary<uint, Product>(stock.Products);
            }
            else
            {
                Products = new Dictionary<uint, Product>();
            }

        }

        /// <summary>
        /// Konstruktor som skapar ett lager utifrån inläsning av fil
        /// </summary>
        /// <param name="filePathName">Sökväg till fil innehållande varulager</param>
        public Stock(string filePathName)
        {
            Products = new Dictionary<uint, Product>();

            List<Product> products = FileHandler.LoadStock(filePathName);
            if (products != null)
            {
                foreach (var product in products)
                    AddProduct(product);
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Lägger till en produkt till varulagret
        /// </summary>
        /// <param name="product">Produkten att lägga till</param>
        internal void AddProduct(Product product)
        {
            try
            {
                Products.Add(product.ProductCode, product);
            }
            catch (Exception ex)
            {

                throw new Exception($"Product with product code: {product.ProductCode} already exists.", ex);
            }
        }

        /// <summary>
        /// Ökar kvantitet på produkt i lager.
        /// </summary>
        /// <param name="productCode">Produktkod</param>
        /// <param name="quantity">Antal att öka lagret med</param>
        internal void AddQuantity(uint productCode, uint quantity)
        {
            if (Products.ContainsKey(productCode))
            {
                Products[productCode].Quantity += quantity;
            }
        }

        /// <summary>
        /// Metod för att få fram ett ledigt produktnummer.
        /// </summary>
        /// <returns>Nytt unikt produktnummer</returns>
        internal uint GetNextProductCode()
        {
            uint nextProductCode = 1;

            if (Products.Count != 0)
                nextProductCode = Products.Keys.Max() + 1;

            return nextProductCode;
        }

        /// <summary>
        /// Hämtar en produkt från lagret
        /// </summary>
        /// <param name="productCode">Produktens produktnummer</param>
        /// <returns></returns>
        internal Product GetProduct(uint productCode)
        {
            if (Products.TryGetValue(productCode, out Product product))
                return product;
            else
            {
                throw new Exception("Product does not exist");
            }
        }

        //internal List<Product> GetProductList()
        //{
        //    List<Product> productsList = new List<Product>();
        //    foreach (var product in Products.Values)
        //    {
        //        productsList.Add(product);
        //    }
        //    return productsList;
        //}

        /// <summary>
        /// Sparar varulagret till fil
        /// </summary>
        /// <param name="filePathName">Sökväg till fil innehållande varulager</param>
        internal void SaveStockToFile(string filePathName)
        {
            FileHandler.SaveStock(this, filePathName);
        }


        //internal void SubtractQuantity(uint productCode, uint quantity)
        //{
        //    if (Products.ContainsKey(productCode))
        //    {
        //        Products[productCode].Quantity -= quantity;
        //    }
        //}

        #endregion Methods
    }
}