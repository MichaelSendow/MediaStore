using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaStore
{
    internal class Product
    {
        /// <summary>
        /// Constructor
        /// </summary>
        internal Product(uint _ProductCode, string _Title, float _Price)
        {
            ProductCode = _ProductCode;
            Title = _Title;
            Price = _Price;
        }
        /// <summary>
        /// Name of the product
        /// </summary>
        private string Title
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Price of the product
        /// </summary>
        private float Price
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// The product code
        /// </summary>
        private uint ProductCode
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Date of release
        /// </summary>
        private string ReleaseYear
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Author, Artist, Director
        /// </summary>
        private string Creator
        {
            get => default;
            set
            {
            }
        }
        /// <summary>
        /// Type of product (Book, Music or Movie)
        /// </summary>
        private ProductTypes ProductType
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Name of publisher or record label
        /// </summary>
        private string Publisher
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Free text field
        /// </summary>
        private string FreeText
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Modify a product
        /// </summary>
        internal void ModifyProduct()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Book, Music, Movie
        /// </summary>
        private enum ProductTypes
        {
            Book = 0,
            Music = 1,
            Movie = 2
        }
    }
}