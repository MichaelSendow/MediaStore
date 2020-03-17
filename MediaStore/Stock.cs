using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MediaStore
{
    public class Stock
    {

        /// <summary>
        /// List of products in stock
        /// </summary>
        public IDictionary<uint, Product> Products
        {
            get; set;
        }

        public Stock()
        {
            Products = new Dictionary<uint, Product>();
        }

        public Stock(List<Product> products)
        {
            Products = new Dictionary<uint, Product>();
            if (products != null)
            {
                foreach (var product in products)
                    AddProduct(product);
            }
        }

        internal uint GetNextProductCode()
        {
            uint nextProductCode = 1;

            if (Products.Count != 0)
                nextProductCode = Products.Keys.Max() + 1;


            return nextProductCode;
        }

        internal void AddProduct(Product product)
        {
            try
            {
                Products.Add(product.ProductCode, product);
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        internal void DeleteProduct()
        {
            throw new System.NotImplementedException();
        }

        internal void AddQuantity()
        {
            throw new System.NotImplementedException();
        }

        internal void SubtractQuantity()
        {
            throw new System.NotImplementedException();
        }

        internal List<Product> ListProducts()
        {
            throw new System.NotImplementedException();
        }

        internal Product GetProduct()
        {
            throw new System.NotImplementedException();
        }
    }
}