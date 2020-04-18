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
        #region Constructors

        /// <summary>
        /// Klasskonstruktor. Öppnar ett formulär som visar alla försäljningar.
        /// </summary>
        /// <param name="stock">Varulager innehållande alla varor som finns representerade i sales</param>
        /// <param name="sales">Försäljningshistorik</param>
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
                        listViewItem.Name = listViewItem.Text;
                        listViewItem.SubItems.Add(receipt.ProductCode.ToString(CultureInfo.CurrentCulture));
                        listViewItem.SubItems.Add(stock.GetProduct(receipt.ProductCode).Title);
                        listViewItem.SubItems.Add(receipt.Quantity.ToString(CultureInfo.CurrentCulture));
                        listViewItem.SubItems.Add(receipt.Price.ToString(CultureInfo.CurrentCulture));

                        ReceiptsListView.Items.Add(listViewItem);
                    }
                }
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Centrerar dialogen över dess "parent" vid laddande av dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReceiptsDialog_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        #endregion Methods
    }
}
