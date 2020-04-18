using System.Globalization;

namespace MediaStore
{
    public class Receipt
    {
        #region Properties

        /// <summary>
        /// Försäljningsdatum
        /// </summary>
        public string DateOfSale { get; set; }

        /// <summary>
        /// Produktnummer av såld vara
        /// </summary>
        public uint ProductCode { get; set; }
        /// <summary>
        /// Antal sålda varor
        /// </summary>
        public uint Quantity { get; set; }

        /// <summary>
        /// Kvittonummer
        /// </summary>
        public uint ReceiptNumber { get; set; }

        /// <summary>
        /// Priset på en vara vid försäljningstillfället.
        /// </summary>
        public decimal Price { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Klasskonstruktor. Skapar ett nytt kvitto bestående av inparametrarna.
        /// </summary>
        /// <param name="receiptNumber">Kvittonummer</param>
        /// <param name="productCode">Produktnummer av såld vara</param>
        /// <param name="dateOfSale">Försäljningsdatum</param>
        /// <param name="quantity">Antal sålda exemplar</param>
        /// <param name="price">Priset per såld vara</param>
        public Receipt(uint receiptNumber, uint productCode, string dateOfSale, uint quantity, decimal price)
        {
            ReceiptNumber = receiptNumber;
            ProductCode = productCode;
            DateOfSale = dateOfSale;
            Quantity = quantity;
            Price = price;
        }

        /// <summary>
        /// Klasskonstrukotr. Skapar ett nytt kvitto utifrån ett annat kvitto.
        /// </summary>
        /// <param name="receipt">Kvitto att kopiera data i från</param>
        public Receipt(Receipt receipt)
        {
            if (receipt != null)
            {
                ReceiptNumber = receipt.ReceiptNumber;
                ProductCode = receipt.ProductCode;
                DateOfSale = receipt.DateOfSale;
                Quantity = receipt.Quantity;
                Price = receipt.Price;
            }
        }

        /// <summary>
        /// Klasskonstruktor. Skapar ett tomt kvitto.
        /// </summary>
        public Receipt()
        {
        }
        

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Hjälpmetod för att representera ett kvitto som en textsträng.
        /// </summary>
        /// <returns>Strängrepresentationen av ett kvitto.</returns>
        public override string ToString()
        {
            string receiptAsString;
            receiptAsString = ProductCode.ToString(CultureInfo.CurrentCulture) + ';';
            receiptAsString += Quantity.ToString(CultureInfo.CurrentCulture) + ';';
            receiptAsString += DateOfSale + ';';
            receiptAsString += ReceiptNumber.ToString(CultureInfo.CurrentCulture) +';';
            receiptAsString += Price.ToString(CultureInfo.CurrentCulture);

            return receiptAsString;
        }

        #endregion Methods

    }
}