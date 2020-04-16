using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MediaStore
{
    public static class Statistics
    {

        public enum Mode { AllTime, Year, Month }

        public static List<ListViewItem> Top10(Stock stock, List<Receipt> receiptList, Product.ProductType type, bool showOnlyActive, Mode mode)
        {

            List<ListViewItem> listViewItems = new List<ListViewItem>();

            //Get all receipts for producttype
            if (receiptList != null && stock != null)
            {
                var receiptQuery =
                    from rec in receiptList
                    join prod in stock.Products.Values on rec.ProductCode equals prod.ProductCode
                    where (showOnlyActive ? (prod.Status == Product.ProductStatus.Active && prod.Type == type) : prod.Type == type) &&
                    (mode == Mode.AllTime ? 1 == 1 : (mode == Mode.Year ? DateTime.Parse(rec.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat).Year == DateTime.Today.Year :
                    (mode == Mode.Month ? DateTime.Parse(rec.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat).Month == DateTime.Today.Month : 1 == 1)))
                    group rec by rec.ProductCode into receiptGroup
                    select receiptGroup;


                List<KeyValuePair<uint, uint>> statList = new List<KeyValuePair<uint, uint>>();
                foreach (var receiptGroup in receiptQuery)
                {
                    uint sumqty = 0;
                    uint code = 0;
                    foreach (var receipt in receiptGroup)
                    {
                        code = receipt.ProductCode;
                        sumqty += receipt.Quantity;
                    }
                    statList.Add(new KeyValuePair<uint, uint>(code, sumqty));
                    statList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
                }
                int i = 1;
                foreach (var item in statList)
                {
                    ListViewItem lvi = new ListViewItem(i.ToString(CultureInfo.CurrentCulture));
                    lvi.Name = lvi.Text;
                    lvi.SubItems.Add(item.Key.ToString(CultureInfo.CurrentCulture));
                    lvi.SubItems.Add(stock.GetProduct(item.Key).Title);
                    lvi.SubItems.Add(item.Value.ToString(CultureInfo.CurrentCulture));
                    lvi.Font = stock.GetProduct(item.Key).Status == Product.ProductStatus.Active ? Product.DefaultFont : Product.InactiveFont;
                    listViewItems.Add(lvi);
                    i++;
                }

            }

            return listViewItems;
        }

        public enum SaleStat
        {
            AllTime = 0,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12,
            Yearly = 13
        }

        public static string TotalSalesStatistics(Stock stock, List<Receipt> receiptList, DateTime dateTime)
        {
            decimal grossAmout = 0;
            decimal yearGross = 0;
            if (receiptList != null && stock != null)
            {
                foreach (var receipt in receiptList)
                {
                    grossAmout += receipt.Quantity * receipt.Price;

                    if (DateTime.Parse(receipt.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat).Year == dateTime.Year)
                    {
                        yearGross += receipt.Quantity * receipt.Price;
                    }
                }

            }
            return grossAmout.ToString("0.00",CultureInfo.CurrentCulture) + " / " + yearGross.ToString("0.00", CultureInfo.CurrentCulture);
        }

        public static Dictionary<SaleStat, KeyValuePair<uint, decimal>> SalesStatistics(uint productCode, DateTime dateTime, Stock stock, List<Receipt> receiptList)
        {
            Dictionary<SaleStat, KeyValuePair<uint, decimal>> salesDictionary = new Dictionary<SaleStat, KeyValuePair<uint, decimal>>();
            if (receiptList != null && stock != null)
            {
                var receiptQuery_AllTime =
                    from rec in receiptList
                    where rec.ProductCode == productCode
                    select rec;

                var receiptQuery_Year =
                    from rec in receiptList
                    where rec.ProductCode == productCode && DateTime.Parse(rec.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat).Year == dateTime.Year
                    select rec;


                var values = (SaleStat[])Enum.GetValues(typeof(SaleStat));

                foreach (var item in values)
                {
                    if (item != SaleStat.AllTime && item != SaleStat.Yearly)
                        salesDictionary.Add(item, MonthlySales(receiptQuery_Year, item));
                }

                uint qty = 0;
                decimal grossAmout = 0;
                foreach (var item in receiptQuery_AllTime)
                {
                    qty += item.Quantity;
                    grossAmout += item.Quantity * item.Price;
                }
                salesDictionary.Add(SaleStat.AllTime, new KeyValuePair<uint, decimal>(qty, grossAmout));


                qty = 0;
                grossAmout = 0;
                foreach (var item in receiptQuery_Year)
                {
                    qty += item.Quantity;
                    grossAmout += item.Quantity * item.Price;
                }
                salesDictionary.Add(SaleStat.Yearly, new KeyValuePair<uint, decimal>(qty, grossAmout));

            }

            return salesDictionary;
        }

        private static KeyValuePair<uint, decimal> MonthlySales(IEnumerable<Receipt> receipts, SaleStat key)
        {
            var query =
                from receipt in receipts
                where DateTime.Parse(receipt.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat).Month == (int)key
                select receipt;

            uint qty = 0;
            decimal grossAmout = 0;
            foreach (var item in query)
            {
                qty += item.Quantity;
                grossAmout += item.Quantity * item.Price;
            }
            return new KeyValuePair<uint, decimal>(qty, grossAmout);

        }


    }


}