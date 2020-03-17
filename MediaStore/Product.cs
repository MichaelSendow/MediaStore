using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MediaStore
{
    public class Product
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Product(uint productCode, string title, ProductTypes productType, float price, uint quantity = 0, string creator = "", string freeText = "", string publisher = "", string releaseYear = "")
        {
            ProductCode = productCode;
            Title = title;
            ProductType = productType;
            Price = price;
            Quantity = quantity;
            Creator = creator;
            Publisher = publisher;
            ReleaseYear = releaseYear;
            FreeText = freeText;
        }

        //public Product(uint productCode, string title, ProductTypes productType, float price, uint quantity = 0)
        //{
        //    ProductCode = productCode;
        //    Title = title;
        //    ProductType = productType;
        //    Price = price;
        //    Quantity = quantity;
        //    Creator = "";
        //    Publisher = "";
        //    ReleaseYear = "";
        //    FreeText = "";
        //}

        /// <summary>
        /// Name of the product
        /// </summary>
        public string Title
        {
            get; set;
        }

        /// <summary>
        /// Price of the product
        /// </summary>
        public float Price
        {
            get; set;
        }

        /// <summary>
        /// The product code
        /// </summary>
        public uint ProductCode
        {
            get; set;
        }

        /// <summary>
        /// Date of release
        /// </summary>
        public string ReleaseYear
        {
            get; set;
        }

        /// <summary>
        /// Author, Artist, Director
        /// </summary>
        public string Creator
        {
            get; set;
        }
        /// <summary>
        /// Type of product (Book, Music or Movie)
        /// </summary>
        public ProductTypes ProductType
        {
            get; set;
        }

        /// <summary>
        /// Name of publisher or record label
        /// </summary>
        public string Publisher
        {
            get; set;
        }

        /// <summary>
        /// Free text field
        /// </summary>
        public string FreeText
        {
            get; set;
        }

        /// <summary>
        /// Quantity
        /// </summary>
        public uint Quantity
        {
            get; set;
        }

        /// <summary>
        /// Book, Music, Movie
        /// </summary>
        public enum ProductTypes
        {
            Book,
            Music,
            Movie
        }
    }
}