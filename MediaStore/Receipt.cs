using System.Globalization;

namespace MediaStore
{
    public class Receipt
    {
        #region Properties

        /// <summary>
        /// Date of sale
        /// </summary>
        public string DateOfSale { get; set; }

        /// <summary>
        /// The product being sold
        /// </summary>
        public uint ProductCode { get; set; }
        /// <summary>
        /// Number of items
        /// </summary>
        public uint Quantity { get; set; }

        /// <summary>
        /// Number of items
        /// </summary>
        public uint ReceiptNumber { get; set; }

        public decimal Price { get; set; }

        #endregion Properties


        #region Constructors

        public Receipt(uint receiptNumber, uint productCode, string dateOfSale, uint quantity, decimal price)
        {
            ReceiptNumber = receiptNumber;
            ProductCode = productCode;
            DateOfSale = dateOfSale;
            Quantity = quantity;
            Price = price;
        }

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

        public Receipt()
        {

        }

        #endregion Constructors

        #region Methods

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