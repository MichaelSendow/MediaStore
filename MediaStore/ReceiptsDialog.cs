using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaStore
{
    public partial class ReceiptsDialog : Form
    {
        public ReceiptsDialog(Stock stock, Sales sales)
        {
            InitializeComponent();
            ReceiptsListView.Items.Clear();


            if (stock != null && sales != null)
            {
                foreach (var receiptList in sales.Ledger.Values)
                {
                    foreach (var receipt in receiptList)
                    {
                        ListViewItem listViewItem = new ListViewItem(receipt.ReceiptNumber.ToString(CultureInfo.CurrentCulture));
                        listViewItem.SubItems.Add(receipt.ProductCode.ToString(CultureInfo.CurrentCulture));
                        listViewItem.SubItems.Add(stock.GetProduct(receipt.ProductCode).Title);
                        listViewItem.SubItems.Add(receipt.Quantity.ToString(CultureInfo.CurrentCulture));
                        listViewItem.SubItems.Add(receipt.Price.ToString(CultureInfo.CurrentCulture));

                        ReceiptsListView.Items.Add(listViewItem);
                    }

                }
            }


        }

        private void ReceiptsDialog_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
