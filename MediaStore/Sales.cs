using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaStore
{
    internal class Sales
    {
        public IDictionary<uint, List<Receipt>> Ledger { get; set; }

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

        internal void ReturnProduct(uint receiptNumber, uint productCode, uint QtyToReturn)
        {
            if (Ledger.ContainsKey(receiptNumber))
            {


            //    if (Ledger[receiptNumber].Quantity >= QtyToReturn)
            //    {
            //        Ledger[receiptNumber].Quantity -= QtyToReturn;
            //        if (Ledger[receiptNumber].Quantity == 0)
            //        {
            //            Ledger.Remove(receiptNumber);
            //        }
            //    }
            //    else
            //    {
            //        throw new Exception($"Can't return bigger quantity than: {Ledger[receiptNumber].Quantity.ToString(CultureInfo.CurrentCulture)}");
            //    }

            //}
            //else
            //{
            //    throw new Exception($"Can't find receipt: {receiptNumber.ToString(CultureInfo.CurrentCulture)}");
            }
        }

        internal uint GetNextReceiptNumber()
        {
            uint nextProductCode = 1;

            if (Ledger.Count != 0)
                nextProductCode = Ledger.Keys.Max() + 1;


            return nextProductCode;
        }


        internal void SaveSalesToFile(string filePathName)
        {
            FileHandler.SaveSales(this, filePathName);
        }

        internal void DeleteProduct()
        {
            throw new System.NotImplementedException();
        }
    }
}