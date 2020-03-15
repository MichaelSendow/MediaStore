using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaStore
{
    internal class ShoppingBasket
    {
        private IDictionary<MediaStore.Product, uint> Products
        {
            get => default;
            set
            {
            }
        }

        public void AddProductToBasket()
        {
            throw new System.NotImplementedException();
        }

        public void SubtractProductFromBasket()
        {
            throw new System.NotImplementedException();
        }

        public void ClearBasket()
        {
            throw new System.NotImplementedException();
        }
    }
}