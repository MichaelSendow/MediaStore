using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MediaStore
{
    public static class Statistics
    {
        public static List<ListViewItem> Top10AllTime(Stock stock, List<Receipt> receiptList, Product.ProductType type, bool showOnlyActive)
        {

            List<ListViewItem> listViewItems = new List<ListViewItem>();

            //Get all receipts for producttype
            if (receiptList != null && stock != null)
            {
                var receiptQuery =
                    from rec in receiptList
                    join prod in stock.Products.Values on rec.ProductCode equals prod.ProductCode
                    where showOnlyActive ? (prod.Status == Product.ProductStatus.Active && prod.Type == type) : prod.Type == type
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
                foreach (var item in statList)
                {
                    ListViewItem lvi = new ListViewItem(item.Key.ToString(CultureInfo.CurrentCulture));
                    lvi.SubItems.Add(stock.GetProduct(item.Key).Title);
                    lvi.SubItems.Add(item.Value.ToString(CultureInfo.CurrentCulture));
                    lvi.Font = stock.GetProduct(item.Key).Status == Product.ProductStatus.Active ? Product.DefaultFont : Product.InactiveFont;
                    listViewItems.Add(lvi);
                }

            }

            return listViewItems;
        }

        public static List<KeyValuePair<uint, decimal>> SaleStat(List<Receipt> receipts, DateTime dateTime)
        {
            List<KeyValuePair<uint, decimal>> keyValuePairs = null;

            return keyValuePairs;
        }

    }
}