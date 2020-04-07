using System.Globalization;

namespace MediaStore
{
    internal class Receipt
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

        #endregion Properties


        #region Constructors

        public Receipt(uint receiptNumber, uint productCode, string dateOfSale, uint quantity)
        {
            ReceiptNumber = receiptNumber;
            ProductCode = productCode;
            DateOfSale = dateOfSale;
            Quantity = quantity;
        }

        public Receipt(Receipt receipt)
        {
            ReceiptNumber = receipt.ReceiptNumber;
            ProductCode = receipt.ProductCode;
            DateOfSale = receipt.DateOfSale;
            Quantity = receipt.Quantity;
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
            receiptAsString += ReceiptNumber.ToString(CultureInfo.CurrentCulture);

            return receiptAsString;
        }

        #endregion Methods

    }
}