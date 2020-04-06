using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaStore
{
    internal class Sales
    {
        #region Properties

        public IDictionary<uint, List<Receipt>> Ledger { get; set; }

        #endregion Properties

        #region Constructors

        public Sales()
        {
            Ledger = new Dictionary<uint, List<Receipt>>();
        }

        public Sales(List<Receipt> receipts)
        {
            Ledger = new Dictionary<uint, List<Receipt>>();
            if (receipts != null)
            {
                foreach (var receipt in receipts)
                {
                    AddReceipt(receipt);

                }
            }
        }

        public Sales(string filePathName)
        {

            Ledger = new Dictionary<uint, List<Receipt>>();

            List<Receipt> receipts = FileHandler.LoadSales(filePathName);

            if (receipts != null)
            {
                foreach (var receipt in receipts)
                {
                    AddReceipt(receipt);

                }
            }

        }

        #endregion Constructors

        #region Methods

        internal void AddReceipt(Receipt receipt)
        {
            if (Ledger.ContainsKey(receipt.ReceiptNumber))
            {
                Ledger[receipt.ReceiptNumber].Add(new Receipt(receipt));
            }
            else
            {
                Ledger.Add(receipt.ReceiptNumber, new List<Receipt> { new Receipt(receipt) });
            }
        }

        internal uint GetNextReceiptNumber()
        {
            uint nextProductCode = 1;

            if (Ledger.Count != 0)
                nextProductCode = Ledger.Keys.Max() + 1;


            return nextProductCode;
        }

        internal bool ReturnProduct(uint receiptNumber, uint productCode, uint QtyToReturn)
        {
            if (Ledger.TryGetValue(receiptNumber, out List<Receipt> receiptList))
            {
                foreach (var item in receiptList)
                {
                    //found the product in receipt
                    if (item.ProductCode == productCode)
                    {
                        //Quantity checks out
                        if (item.Quantity >= QtyToReturn)
                        {
                            if (item.Quantity == QtyToReturn)
                            {
                                receiptList.Remove(item);
                            }
                            else
                            {
                                item.Quantity -= QtyToReturn;
                            }

                            MessageBox.Show("Return processed successfully!", "Return processed", MessageBoxButtons.OK);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show($"Return quantity can't be larger than {item.Quantity}", "Return quantity to big", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
                MessageBox.Show($"No such product in receipt: {receiptNumber}", "No such product", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                MessageBox.Show($"Unable to find receipt: {receiptNumber}", "Receipt not found", MessageBoxButtons.OK);
                return false;
            }
        }

        internal void SaveSalesToFile(string filePathName)
        {
            FileHandler.SaveSales(this, filePathName);
        }

        #endregion Methods

    }
}