using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MediaStore
{
    public class Product
    {

        /// <summary>
        /// The product code
        /// </summary>
        public uint ProductCode { get; set; }

        /// <summary>
        /// The title of the product
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Type of product (Book, Music or Movie)
        /// </summary>
        public ProductTypes ProductType { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity of product
        /// </summary>
        public uint Quantity { get; set; }

        /// <summary>
        /// Date of release
        /// </summary>
        public string ReleaseYear { get; set; }

        /// <summary>
        /// Author, Artist, Director
        /// </summary>
        public string Creator { get; set; }


        /// <summary>
        /// Name of publisher or record label
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Free text field
        /// </summary>
        public string FreeText { get; set; }

        /// <summary>
        /// Free text field
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Enumerator [Book, Music, Movie]
        /// </summary>
        public enum ProductTypes
        {
            Book,
            Music,
            Movie
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        public Product(uint productCode, string title, ProductTypes productType, decimal price, uint quantity = 0, string creator = "", string freeText = "", string publisher = "", string releaseYear = "", bool isActive = true)
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
            IsActive = isActive;
        }

        public Product(Product prod)
        {
            if (prod != null)
            {
                ProductCode = prod.ProductCode;
                Title = prod.Title;
                ProductType = prod.ProductType;
                Price = prod.Price;
                Quantity = prod.Quantity;
                Creator = prod.Creator;
                Publisher = prod.Publisher;
                ReleaseYear = prod.ReleaseYear;
                FreeText = prod.FreeText;
                IsActive = prod.IsActive;
            }
        }

        public Product()
        {

        }


        public ListViewItem CashierGetProductListViewItem(Font font = null)
        {
            ListViewItem listViewItem = new ListViewItem(ProductCode.ToString(CultureInfo.CurrentCulture));
            listViewItem.SubItems.Add(Title);
            listViewItem.SubItems.Add(ProductType.ToString());
            listViewItem.SubItems.Add(Price.ToString("0.00", CultureInfo.CurrentCulture));
            listViewItem.SubItems.Add(Quantity.ToString(CultureInfo.CurrentCulture));
            if (font == null)
            {
                listViewItem.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                listViewItem.Font = font;
            }

            return listViewItem;
        }

        public ListViewItem ShoppingBasketGetProductListViewItem(Font font = null)
        {
            ListViewItem listViewItem = new ListViewItem(ProductCode.ToString(CultureInfo.CurrentCulture));
            listViewItem.SubItems.Add(Title);
            listViewItem.SubItems.Add(Price.ToString("0.00", CultureInfo.CurrentCulture));
            listViewItem.SubItems.Add(Quantity.ToString(CultureInfo.CurrentCulture));
            listViewItem.SubItems.Add((Price * Quantity).ToString(CultureInfo.CurrentCulture));
            if (font == null)
            {
                listViewItem.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                listViewItem.Font = font;
            }

            return listViewItem;
        }

        public string ReceiptString()
        {
            string receiptString;

            if (Title.Length > 30)
            {
                receiptString = Title.Substring(0, 27).PadRight(30, '.');
            }
            else
            {
                receiptString = Title.PadRight(30);
            }
            receiptString = receiptString.PadRight(34);
            receiptString += Price.ToString("0.00", CultureInfo.CurrentCulture).PadRight(9);
            receiptString = receiptString.PadRight(47);
            receiptString += Quantity.ToString(CultureInfo.CurrentCulture).PadRight(6);
            receiptString = receiptString.PadRight(57);
            receiptString += (Quantity * Price).ToString("0.00", CultureInfo.CurrentCulture).PadLeft(13);



            return receiptString;
        }


        public override string ToString()
        {

            //ProductCode;Title;ProductType;Price;Quantity;ReleaseYear;Creator;Publisher;FreeText;IsActive
            string productAsString;
            productAsString = ProductCode.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += Title + ';';
            productAsString += ProductType.ToString() + ';';
            productAsString += Price.ToString("0.00", CultureInfo.CurrentCulture) + ';';
            productAsString += Quantity.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += ReleaseYear.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += Creator.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += Publisher.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += FreeText.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += IsActive.ToString(CultureInfo.CurrentCulture);


            return productAsString;
        }
    }
}