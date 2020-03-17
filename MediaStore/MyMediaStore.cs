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
    public partial class MyMediaStore : Form
    {
        private readonly Stock MyStock = new Stock();






        public MyMediaStore()
        {
            InitializeComponent();


            Product product1 = new Product(MyStock.GetNextProductCode(), "Konstens alla regler", Product.ProductTypes.Book, 540.23F, 10, "Meeep Moop", "Jaha", "OK", "1989");
            MyStock.AddProduct(product1);
            Product product2 = new Product(MyStock.GetNextProductCode(), "Lala land", Product.ProductTypes.Movie, 540.23F);
            MyStock.AddProduct(product2);

            foreach (var productValuePair in MyStock.Products)
            {
                Stock_ListView.Items.Add(GetProductListViewItem(productValuePair));
            }

        }

        private ListViewItem GetProductListViewItem(KeyValuePair<uint, Product> keyValuePair, Font font = null)
        {
            ListViewItem listViewItem = new ListViewItem(keyValuePair.Key.ToString(CultureInfo.CurrentCulture));
            listViewItem.SubItems.Add(keyValuePair.Value.Title);
            listViewItem.SubItems.Add(keyValuePair.Value.ProductType.ToString());
            listViewItem.SubItems.Add(keyValuePair.Value.Price.ToString(CultureInfo.CurrentCulture));
            listViewItem.SubItems.Add(keyValuePair.Value.Quantity.ToString(CultureInfo.CurrentCulture));
            if (font == null)
            {
                listViewItem.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                listViewItem.Font = font;
            }

            return listViewItem;
        }
    }

}
