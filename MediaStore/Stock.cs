using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace MediaStore
{
    public class Stock
    {

        #region Properties

        /// <summary>
        /// List of products in stock. Key = ProductCode, Value = Product
        /// </summary>
        /// 
        public IDictionary<uint, Product> Products
        {
            get; set;
        }

        #endregion Properties

        #region Constructors

        public Stock()
        {
            Products = new Dictionary<uint, Product>();
        }

        public Stock(Stock stock)
        {
            if (stock !=null)
            {
                Products = new Dictionary<uint, Product>(stock.Products);
            }
            else
            {
                Products = new Dictionary<uint, Product>();
            }
            
        }

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

        internal void AddQuantity(uint productCode, uint quantity)
        {
            if (Products.ContainsKey(productCode))
            {
                Products[productCode].Quantity += quantity;
            }
        }

        //internal void DeleteProduct(uint productCode)
        //{
        //    if (Products.ContainsKey(productCode))
        //    {
        //        Products.Remove(productCode);
        //    }
        //}

        internal uint GetNextProductCode()
        {
            uint nextProductCode = 1;

            if (Products.Count != 0)
                nextProductCode = Products.Keys.Max() + 1;


            return nextProductCode;
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

        //internal List<Product> GetProductList()
        //{
        //    List<Product> productsList = new List<Product>();
        //    foreach (var product in Products.Values)
        //    {
        //        productsList.Add(product);
        //    }
        //    return productsList;
        //}

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