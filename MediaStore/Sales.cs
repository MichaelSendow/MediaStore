using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediaStore
{
    public class Sales
    {
        #region Properties

        /// <summary>
        /// Dictionary som innehåller alla kvitton. Key = Kvittonummer, Value = lista på kvitton tillhörande kvittonummret
        /// </summary>
        public IDictionary<uint, List<Receipt>> Ledger { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Skapar en tom huvudbok utan försäljningshistorik
        /// </summary>
        public Sales()
        {
            Ledger = new Dictionary<uint, List<Receipt>>();
        }

        //public Sales(List<Receipt> receipts)
        //{
        //    Ledger = new Dictionary<uint, List<Receipt>>();
        //    if (receipts != null)
        //    {
        //        foreach (var receipt in receipts)
        //        {
        //            AddReceipt(receipt);

        //        }
        //    }
        //}

        /// <summary>
        /// Läser in försäljningshistorik från fil
        /// </summary>
        /// <param name="filePathName">SÖkväg till fil innehållande försäljningshistorik</param>
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

        /// <summary>
        /// Lägger till nytt kvitto till försäljningshistoriken
        /// </summary>
        /// <param name="receipt"></param>
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

        /// <summary>
        /// Metod för att få fram ett ledigt kvittonummer.
        /// </summary>
        /// <returns>Nytt unikt kvittonummer</returns>
        internal uint GetNextReceiptNumber()
        {
            uint nextProductCode = 1;

            if (Ledger.Count != 0)
                nextProductCode = Ledger.Keys.Max() + 1;


            return nextProductCode;
        }

        /// <summary>
        /// Makulerar en försäljning. Kvittonummer, produkt och kvantitet måste finnas i historiken.
        /// </summary>
        /// <param name="receiptNumber">Kvittonummer</param>
        /// <param name="productCode">Produkten som ska returneras på kvittot</param>
        /// <param name="QtyToReturn">Antalet exemplar av produkten som ska returneras</param>
        /// <returns>True om kvittot finns, produkten finns på kvittot och antalet inte överskrider det som finns på kvittot.</returns>
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

        /// <summary>
        /// Sparar försäljningshistorik till fil
        /// </summary>
        /// <param name="filePathName">Sökväg till fil innehållande försäljningshistorik</param>
        internal void SaveSalesToFile(string filePathName)
        {
            FileHandler.SaveSales(this, filePathName);
        }

        /// <summary>
        /// Plattar ut dictionary listorna till en lista innehållandes alla enskilda kvitton
        /// </summary>
        /// <returns>Platt lista av alla kvitton</returns>
        internal List<Receipt> ReceiptsAsList()
        {
            List<Receipt> receipts = new List<Receipt>();
            foreach (var ListOfReceipts in Ledger.Values)
            {
                foreach (var receipt in ListOfReceipts)
                {
                    receipts.Add(receipt);
                }
            }

            return receipts;
        }

        #endregion Methods

    }
}