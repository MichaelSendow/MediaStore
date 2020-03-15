using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaStore
{
    internal class Stock
    {
        /// <summary>
        /// Product, Quantity
        /// </summary>
        private IDictionary<MediaStore.Product, uint> Products
        {
            get => default;
            set
            {
            }
        }

        internal void AddProduct()
        {
            throw new System.NotImplementedException();
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