using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MediaStore
{
    public partial class MyMediaStore : Form
    {
        #region Fields

        private const string productsFileName = "products.csv";
        private const string salesFileName = "sales.csv";

        private readonly ListViewColumnSorter lvwColumnSorter;
        private readonly ShoppingBasket MyShoppingBasket;
        private readonly List<string> ReceiptList;
        private Sales MySales;
        private Stock MyStock;
        private ReceiptsDialog receiptDialog;
        private bool UnsavedChanges = false;

        #endregion Fields

        #region Constructors

        public MyMediaStore()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            CashierListView1.ListViewItemSorter = lvwColumnSorter;
            ShoppingBasketListView1.ListViewItemSorter = lvwColumnSorter;
            StockListView1.ListViewItemSorter = lvwColumnSorter;
            StatListView_Sales.ListViewItemSorter = lvwColumnSorter;
            MyShoppingBasket = new ShoppingBasket();
            ReceiptList = new List<string>();
            StatDateTimePicker_Year.Value = DateTime.Now;
        }

        private void MyMediaStore_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(productsFileName))
                    MyStock = new Stock(productsFileName);
                else
                    MyStock = new Stock();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong loading products.\r\n\r\nError Message: {ex.Message}\r\n\r\n" +
                                    $"Please fix {productsFileName} and restart the program", $"LoadStock({productsFileName})", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ExitWithoutSavingFile();
                return;
            }

            try
            {
                if (File.Exists(salesFileName))
                    MySales = new Sales(salesFileName);
                else
                    MySales = new Sales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong loading sales info.\r\n\r\nError Message: {ex.Message}\r\n\r\n" +
                                    $"Please fix {salesFileName} and restart the program", $"LoadSales({salesFileName})", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ExitWithoutSavingFile();
                return;
            }

            StatSetLabels();
            UpdateListViews();
        }

        #endregion Constructors

        #region EventMethods

        private void AddNewProductButton_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product
            {
                ProductCode = MyStock.GetNextProductCode()
            };
            MyStock.AddProduct(newProduct);

            using (ProductForm productForm = new ProductForm(newProduct, ProductForm.FormFunction.NewProduct))
            {
                productForm.ShowDialog();

                if (productForm.FunctionSucceeded)
                {
                    UpdateListViews();
                }
                else
                {
                    MyStock.Products.Remove(newProduct.ProductCode);
                }
            }
        }

        private void CashierReturnItemsButton_Click(object sender, EventArgs e)
        {
            //All fields has text
            if (CashierTextBox_ReturnReceipt.TextLength != 0 && CashierTextBox_ReturnProduct.TextLength != 0 && CashierTextBox_ReturnQuantity.TextLength != 0)
            {
                //All fields are validnumbers
                if (ValidateUINT(CashierTextBox_ReturnReceipt.Text) && ValidateUINT(CashierTextBox_ReturnProduct.Text) && ValidateUINT(CashierTextBox_ReturnQuantity.Text))
                {
                    uint receiptNumber = uint.Parse(CashierTextBox_ReturnReceipt.Text, CultureInfo.CurrentCulture);
                    uint productCode = uint.Parse(CashierTextBox_ReturnProduct.Text, CultureInfo.CurrentCulture);
                    uint quantityToReturn = uint.Parse(CashierTextBox_ReturnQuantity.Text, CultureInfo.CurrentCulture);

                    if (quantityToReturn <= 0)
                    {
                        MessageBox.Show("Return quantity must be 1 or larger");
                        return;
                    }

                    if (MySales.ReturnProduct(receiptNumber, productCode, quantityToReturn))
                    {
                        MyStock.AddQuantity(productCode, quantityToReturn);
                        UpdateStockListView();
                        CashierTextBox_ReturnReceipt.Text = "";
                        CashierTextBox_ReturnProduct.Text = "";
                        CashierTextBox_ReturnQuantity.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("All fields must contain numbers");
                }
            }
            else
            {
                MessageBox.Show("All fields must contain numbers");
            }
        }

        private void CashierSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateCashierStockListView();
        }

        private void CashierShowAllProductsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCashierStockListView();
        }

        /// <summary>
        /// Should add product to ShoppingBasket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashierStockListView_DoubleClick(object sender, EventArgs e)
        {
            uint productCode = uint.Parse(CashierListView1.SelectedItems[0].Text, CultureInfo.CurrentCulture);

            using (ProductForm productForm = new ProductForm(MyStock.GetProduct(productCode), ProductForm.FormFunction.AddToBasket, MyStock.Products[productCode].Quantity))
            {
                productForm.ShowDialog();
                if (productForm.FunctionSucceeded)
                {
                    uint qty = productForm.GetNumericSpinBoxValue();
                    MyShoppingBasket.AddProductToBasket(MyStock.GetProduct(productCode), qty);
                    MyStock.Products[productCode].Quantity -= qty;
                    UpdateListViews();
                }
            }
        }

        private void IsActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (uint.TryParse(StockTextBox_Quantity.Text, out uint _))
            {
                if (uint.Parse(StockTextBox_Quantity.Text, CultureInfo.CurrentCulture) == 0)
                {
                    //SaveUpdatedProductFromStockTab();
                    //UpdateListViews();
                    //SaveFiles();

                    Product product = MyStock.GetProduct(uint.Parse(StockTextBox_ProductCode.Text, CultureInfo.CurrentCulture));
                    product.Status = StockCheckBox_Active.Checked ? Product.ProductStatus.Active : Product.ProductStatus.InActive;
                    UnsavedChanges = true;

                }
                else if (StockCheckBox_Active.Checked == false && uint.Parse(StockTextBox_Quantity.Text, CultureInfo.CurrentCulture) > 0)
                {
                    DialogResult dlgr = MessageBox.Show($"The product still has quantity in stock.\r\nAre you sure the product should be inactive?", "Quantity is not zero", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (dlgr == DialogResult.Yes)
                    {
                        //SaveUpdatedProductFromStockTab();
                        //UpdateListViews();
                        //SaveFiles();

                        Product product = MyStock.GetProduct(uint.Parse(StockTextBox_ProductCode.Text, CultureInfo.CurrentCulture));
                        product.Status = StockCheckBox_Active.Checked ? Product.ProductStatus.Active : Product.ProductStatus.InActive;
                        UnsavedChanges = true;
                    }
                    else
                    {
                        this.StockCheckBox_Active.CheckedChanged -= new EventHandler(this.IsActiveCheckBox_CheckedChanged);
                        StockCheckBox_Active.Checked = true;
                        this.StockCheckBox_Active.CheckedChanged += new EventHandler(this.IsActiveCheckBox_CheckedChanged);
                    }
                }
                else
                {
                    //SaveUpdatedProductFromStockTab();
                    //UpdateListViews();
                    //SaveFiles();
                    Product product = MyStock.GetProduct(uint.Parse(StockTextBox_ProductCode.Text, CultureInfo.CurrentCulture));
                    product.Status = StockCheckBox_Active.Checked ? Product.ProductStatus.Active : Product.ProductStatus.InActive;
                    UnsavedChanges = true;
                }
            }

        }

        private void MyMediaStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MyShoppingBasket.Products.Count != 0)
            {
                DialogResult dlgr = MessageBox.Show("The Shopping Basket is not empty. \r\nReview basket before qutting?", "Uncompleted sale", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (dlgr == DialogResult.Yes)
                {
                    e.Cancel = true;
                    MainTabControl.SelectTab(CashierTabPage);
                    return;
                }
                else if (dlgr == DialogResult.No)
                {
                    ClearShoppingBasket();
                }
            }

            if (UnsavedChanges)
            {
                DialogResult dlgr = MessageBox.Show("You have unsaved changes in the Stock-tab. Do you want to review changes before quitting?", "Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (dlgr == DialogResult.Yes)
                {
                    e.Cancel = true;
                    MainTabControl.SelectTab(StockTabPage);
                    return;
                }
                else if (dlgr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            SaveFiles();
        }

        //Printing Text File in C#
        //https://www.c-sharpcorner.com/article/printing-text-file-in-C-Sharp/
        //2020-03-29
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            float linesPerPage = 0;
            float yPos;
            int count = 0;

            //Read margins from PrintPageEventArgs
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;

            using (Font Consolas10 = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))))
            {
                //Calculate the lines per page on the basis of the height of the page and the height of the font
                linesPerPage = e.MarginBounds.Height / Consolas10.GetHeight(graphics);

                while (count < linesPerPage && count < ReceiptList.Count)
                {
                    //Calculate the starting position
                    yPos = topMargin + (count * Consolas10.GetHeight(graphics));
                    //Draw text
                    using (StringFormat stringFormat = new StringFormat())
                    {
                        graphics.DrawString(ReceiptList[count], Consolas10, Brushes.Black, leftMargin, yPos, stringFormat);
                    }

                    //Move to next line
                    count++;
                }
            }

            //If PrintPageEventArgs has more pages to print
            if (count < ReceiptList.Count)
            {
                ReceiptList.RemoveRange(0, count);
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        private void SelectStatListViewItem()
        {
            if (StatListView_Sales.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                uint productCode = uint.Parse(StatListView_Sales.Items[StatListView_Sales.SelectedIndices[0]].Text, CultureInfo.CurrentCulture);
                Dictionary<Statistics.SaleStat, KeyValuePair<uint, decimal>> keyValuePairs = Statistics.SalesStatistics(productCode, StatDateTimePicker_Year.Value, MyStock, MySales.ReceiptsAsList());
                UpdateStatisticsTabPage(keyValuePairs);
            }
        }

        private void ShoppingBasketCheckOutButton_Click(object sender, EventArgs e)
        {
            if (MyShoppingBasket.Products.Count != 0)
            {
                uint receiptNumber = MySales.GetNextReceiptNumber();

                //Prints to default printer.
                if (CashierCheckBox_PrintReceipts.CheckState == CheckState.Checked)
                {
                    ReceiptList.Clear();
                    ReceiptList.Add($"Receipt {DateTime.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)}");
                    ReceiptList.Add($"Receiptnumber: {receiptNumber.ToString(CultureInfo.CurrentCulture)}");
                    ReceiptList.Add("");
                    ReceiptList.Add("#          Title                             Price        Qty               Total");
                    ReceiptList.Add("".PadRight(81, '-'));

                    foreach (var item in MyShoppingBasket.Products.Values)
                    {
                        ReceiptList.Add(item.ProductCode.ToString(CultureInfo.CurrentCulture).PadRight(11) + item.ReceiptString());
                    }
                    ReceiptList.Add("".PadRight(81, '-'));
                    ReceiptList.Add("Total sum: " + ShoppingBasketTextBox_TotalSum.Text.PadLeft(70));

                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }

                //Add new receipt
                foreach (var product in MyShoppingBasket.Products.Values)
                {
                    MySales.AddReceipt(new Receipt(receiptNumber, product.ProductCode, DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture), product.Quantity, product.Price));
                }

                ShoppingBasketListView1.Items.Clear();
                MyShoppingBasket.ClearBasket();
                ShoppingBasketTextBox_TotalSum.Text = "0";
            }
            MessageBox.Show("Sale completed", "Sold", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SaveFiles();
        }

        private void ShoppingBasketClearBasketButton_Click(object sender, EventArgs e)
        {
            ClearShoppingBasket();
            UpdateListViews();
            SaveFiles();
        }

        private void ShoppingBasketListView_DoubleClick(object sender, EventArgs e)
        {
            uint productCode = uint.Parse(ShoppingBasketListView1.SelectedItems[0].Text, CultureInfo.CurrentCulture);

            using (ProductForm productForm = new ProductForm(MyShoppingBasket.GetProduct(productCode), ProductForm.FormFunction.ShoppingList, MyStock.Products[productCode].Quantity))
            {
                productForm.ShowDialog();
                if (productForm.FunctionSucceeded)
                {
                    uint qty = productForm.GetNumericSpinBoxValue();
                    uint originalQty = MyShoppingBasket.GetProduct(productCode).Quantity;

                    if (qty == 0)
                    {
                        MyShoppingBasket.Products.Remove(productCode);
                        MyStock.Products[productCode].Quantity += originalQty;
                    }
                    else
                    {
                        MyShoppingBasket.Products[productCode].Quantity = qty;
                        MyStock.Products[productCode].Quantity += originalQty - qty;
                    }

                    UpdateListViews();
                }
            }
        }

        private void ShowReceiptsButton_Click(object sender, EventArgs e)
        {
            if (receiptDialog != null)
            {
                receiptDialog.Dispose();
            }

            receiptDialog = new ReceiptsDialog(MyStock, MySales);
            receiptDialog.Show();
        }

        /// How to sort a ListView control by a column in Visual C#
        /// https://support.microsoft.com/en-us/help/319401/how-to-sort-a-listview-control-by-a-column-in-visual-c
        /// 2020-03-21
        private void SortListViewOnColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (e.Column >= 1 && e.Column <= 2)
            {
                lvwColumnSorter.TextSort = true;
            }
            else
            {
                lvwColumnSorter.TextSort = false;
            }

            ((ListView)sender).Sort();
        }

        private void StatButton_AllTime_Click(object sender, EventArgs e)
        {
            Top10(Product.ProductType.Book, Top10ListView_Books, Top10BooksCheckBox, Statistics.Mode.AllTime);
            Top10(Product.ProductType.Movie, Top10ListView_Movies, Top10MoviesCheckBox, Statistics.Mode.AllTime);
            Top10(Product.ProductType.Music, Top10ListView_Music, Top10MusicCheckBox, Statistics.Mode.AllTime);
        }

        private void StatButton_Month_Click(object sender, EventArgs e)
        {
            Top10(Product.ProductType.Book, Top10ListView_Books, Top10BooksCheckBox, Statistics.Mode.Month);
            Top10(Product.ProductType.Movie, Top10ListView_Movies, Top10MoviesCheckBox, Statistics.Mode.Month);
            Top10(Product.ProductType.Music, Top10ListView_Music, Top10MusicCheckBox, Statistics.Mode.Month);
        }

        private void StatButton_Year_Click(object sender, EventArgs e)
        {
            Top10(Product.ProductType.Book, Top10ListView_Books, Top10BooksCheckBox, Statistics.Mode.Year);
            Top10(Product.ProductType.Movie, Top10ListView_Movies, Top10MoviesCheckBox, Statistics.Mode.Year);
            Top10(Product.ProductType.Music, Top10ListView_Music, Top10MusicCheckBox, Statistics.Mode.Year);
        }

        private void StatCheckBox_ShowAll_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStatListView();
        }

        private void StatDateTimePicker_Year_ValueChanged(object sender, EventArgs e)
        {
            StatLabel_Yearly.Text = "Total " + StatDateTimePicker_Year.Value.ToString("yyyy", CultureInfo.CurrentCulture);
            StatListView_Sales_SelectedIndexChanged(sender, e);
        }

        private void StatListView_Sales_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectStatListViewItem();
        }
        private void StatTextBox_Search_TextChanged(object sender, EventArgs e)
        {
            UpdateStatListView();
        }

        private void StockListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectStockListViewItem();
        }

        private void StockSaveUpdatedProductButton_Click(object sender, EventArgs e)
        {
            if (SaveUpdatedProductFromStockTab())
                UpdateListViews();
        }

        private void StockSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateStockListView();
        }

        private void StockShowAllProductsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStockListView();
        }


        #endregion EventMethods

        #region Methods

        /// <summary>
        /// Checks if a string is only numbers.
        /// </summary>
        /// <param name="TextBoxNumber"></param>
        /// <returns></returns>
        private static bool ValidateUINT(string stringToValidate)
        {
            return uint.TryParse(stringToValidate, out uint _);
        }

        private void ClearShoppingBasket()
        {
            ShoppingBasketListView1.Items.Clear();

            foreach (var item in MyShoppingBasket.Products.Values)
            {
                MyStock.Products[item.ProductCode].Quantity += item.Quantity;
            }
            MyShoppingBasket.ClearBasket();
        }

        private void ExitWithoutSavingFile()
        {
            this.FormClosing -= new FormClosingEventHandler(this.MyMediaStore_FormClosing);
            this.Close();
        }

        private void SaveFiles()
        {
            MyStock.SaveStockToFile(productsFileName);
            MySales.SaveSalesToFile(salesFileName);
        }

        private bool SaveUpdatedProductFromStockTab()
        {
            if (StockTextBox_ProductCode.TextLength != 0)
            {
                if (ValidateFieldsInStockTab())
                {
                    uint productCode = uint.Parse(StockTextBox_ProductCode.Text, CultureInfo.CurrentCulture);
                    Product updatedProduct = MyStock.GetProduct(productCode);

                    if (StockCheckBox_Active.Checked == true)
                    {
                        updatedProduct.UpdateProduct(StockTextBox_Title.Text,
                        (Product.ProductType)Enum.Parse(typeof(Product.ProductType), StockListBox_Type.Text, true),
                        decimal.Parse(StockTextBox_Price.Text, CultureInfo.CurrentCulture),
                        uint.Parse(StockTextBox_Quantity.Text, CultureInfo.CurrentCulture),
                        StockTextBox_Creator.Text, StockTextBox_FreeText.Text,
                        StockTextBox_Publisher.Text,
                        uint.Parse(StockTextBox_ReleaseYear.Text, CultureInfo.CurrentCulture),
                        Product.ProductStatus.Active);
                        UnsavedChanges = false;
                        StockSplitContainer1.Panel2.BackColor = Color.Transparent;
                    }
                    else
                    {
                        updatedProduct.UpdateProduct(StockTextBox_Title.Text,
                        (Product.ProductType)Enum.Parse(typeof(Product.ProductType), StockListBox_Type.Text, true),
                        decimal.Parse(StockTextBox_Price.Text, CultureInfo.CurrentCulture),
                        uint.Parse(StockTextBox_Quantity.Text, CultureInfo.CurrentCulture),
                        StockTextBox_Creator.Text, StockTextBox_FreeText.Text,
                        StockTextBox_Publisher.Text,
                        uint.Parse(StockTextBox_ReleaseYear.Text, CultureInfo.CurrentCulture),
                        Product.ProductStatus.InActive);
                        UnsavedChanges = false;
                        StockSplitContainer1.Panel2.BackColor = Color.Transparent;
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Some fields are not correctly formated.\r\nFor instance no newlines or ';' are allowed in text fields.", "Unsupported format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void SelectStockListViewItem()
        {
            uint productCode;

            if (StockListView1.SelectedItems.Count == 0)
            {
                return;
            }
            else if (StockTextBox_ProductCode.TextLength != 0)
            {
                productCode = uint.Parse(StockListView1.Items[StockListView1.SelectedIndices[0]].Text, CultureInfo.CurrentCulture);

                if (UnsavedChanges)
                {
                    DialogResult dlgr = MessageBox.Show("You have unsaved changes. \r\nDo you want to save changes before changing product?", "Save changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (dlgr == DialogResult.Yes)
                    {
                        if (SaveUpdatedProductFromStockTab())
                        {
                            UpdateStockListView();
                            SaveFiles();
                            UnsavedChanges = false;
                            StockSplitContainer1.Panel2.BackColor = Color.Transparent;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (dlgr == DialogResult.No)
                    {
                        UnsavedChanges = false;
                        StockSplitContainer1.Panel2.BackColor = Color.Transparent;
                    }
                    else
                    {
                        return;
                    }
                }

                UpdateStockBoxes(productCode);
            }
            else
            {
                productCode = uint.Parse(StockListView1.Items[StockListView1.SelectedIndices[0]].Text, CultureInfo.CurrentCulture);
                UpdateStockBoxes(productCode);
            }
        }

        private void UpdateStockBoxes(uint productCode)
        {
            Product selectedProduct = MyStock.GetProduct(productCode);

            Unload_StockTextBox_EventHandler();

            StockTextBox_ProductCode.Text = selectedProduct.ProductCode.ToString(CultureInfo.CurrentCulture);
            StockListBox_Type.Text = selectedProduct.Type.ToString();
            StockTextBox_Price.Text = selectedProduct.Price.ToString(CultureInfo.CurrentCulture);
            StockTextBox_Quantity.Text = selectedProduct.Quantity.ToString(CultureInfo.CurrentCulture);
            StockTextBox_Title.Text = selectedProduct.Title;
            StockTextBox_ReleaseYear.Text = selectedProduct.ReleaseYear.ToString(CultureInfo.CurrentCulture);
            StockTextBox_Creator.Text = selectedProduct.Creator;
            StockTextBox_Publisher.Text = selectedProduct.Publisher;
            StockTextBox_FreeText.Text = selectedProduct.FreeText;
            StockCheckBox_Active.Checked = selectedProduct.Status == Product.ProductStatus.Active ? true : false;

            Load_StockTextBox_EventHandler();
        }

        private void StatSetLabels()
        {
            StatLabel_January.Text = new DateTime(2010, 1, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_February.Text = new DateTime(2010, 2, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_March.Text = new DateTime(2010, 3, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_April.Text = new DateTime(2010, 4, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_May.Text = new DateTime(2010, 5, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_June.Text = new DateTime(2010, 6, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_July.Text = new DateTime(2010, 7, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_August.Text = new DateTime(2010, 8, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_September.Text = new DateTime(2010, 9, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_October.Text = new DateTime(2010, 10, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_November.Text = new DateTime(2010, 11, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
            StatLabel_December.Text = new DateTime(2010, 12, 1).ToString("MMM", CultureInfo.CurrentCulture).ToUpper(CultureInfo.CurrentCulture);
        }

        private void Top10(Product.ProductType productType, ListView listView, CheckBox checkBox, Statistics.Mode mode)
        {
            List<Receipt> receipts = MySales.ReceiptsAsList();
            listView.Items.Clear();
            List<ListViewItem> listViewItems = checkBox.Checked ? Statistics.Top10(MyStock, receipts, productType, showOnlyActive: false, mode) : Statistics.Top10(MyStock, receipts, productType, showOnlyActive: true, mode);

            for (int i = 0; i < listViewItems.Count && i < 10; i++)
            {
                listView.Items.Add(listViewItems[i]);
            }
        }

        private void UpdateCashierStockListView()
        {

            Stock stock;

            CashierListView1.Items.Clear();

            if (CashierTextBox_Search.TextLength == 0)
            {
                stock = MyStock;
            }
            else if (CashierTextBox_Search.Text.Contains(';'))
            {
                SplitSearcher splitSearcher = new SplitSearcher();
                stock = splitSearcher.Search(MyStock, CashierTextBox_Search.Text);
            }
            else
            {
                WildSearch wildSearcher = new WildSearch();

                stock = wildSearcher.Search(MyStock, CashierTextBox_Search.Text);
            }

            foreach (KeyValuePair<uint, Product> productValuePair in stock.Products)
            {
                if (CashierCheckBox_ShowAllProducts.CheckState == CheckState.Unchecked)
                {
                    if (productValuePair.Value.Status == Product.ProductStatus.Active)
                    {
                        CashierListView1.Items.Add(productValuePair.Value.GetProductListViewItem());
                    }
                }
                else
                {
                    CashierListView1.Items.Add(productValuePair.Value.GetProductListViewItem());
                }
            }
        }

        private void UpdateListViews()
        {
            UpdateShoppingBasketListView();
            UpdateStockListView();
            UpdateCashierStockListView();
            UpdateStatListView();
        }

        private void UpdateShoppingBasketListView()
        {
            ShoppingBasketListView1.Items.Clear();
            decimal totalSum = 0;

            foreach (KeyValuePair<uint, Product> productValuePair in MyShoppingBasket.Products)
            {
                ShoppingBasketListView1.Items.Add(productValuePair.Value.ShoppingBasketGetProductListViewItem());
                totalSum += (productValuePair.Value.Quantity * productValuePair.Value.Price);
            }

            ShoppingBasketTextBox_TotalSum.ForeColor = Color.Black;
            ShoppingBasketTextBox_TotalSum.Text = Math.Round(totalSum, 2).ToString(CultureInfo.CurrentCulture);
        }

        private void UpdateStatisticsTabPage(Dictionary<Statistics.SaleStat, KeyValuePair<uint, decimal>> keyValuePairs)
        {
            StatLabel_AllTime_QTY.Text = keyValuePairs[Statistics.SaleStat.AllTime].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_January_QTY.Text = keyValuePairs[Statistics.SaleStat.January].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_February_QTY.Text = keyValuePairs[Statistics.SaleStat.February].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_March_QTY.Text = keyValuePairs[Statistics.SaleStat.March].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_April_QTY.Text = keyValuePairs[Statistics.SaleStat.April].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_May_QTY.Text = keyValuePairs[Statistics.SaleStat.May].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_June_QTY.Text = keyValuePairs[Statistics.SaleStat.June].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_July_QTY.Text = keyValuePairs[Statistics.SaleStat.July].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_August_QTY.Text = keyValuePairs[Statistics.SaleStat.August].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_September_QTY.Text = keyValuePairs[Statistics.SaleStat.September].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_October_QTY.Text = keyValuePairs[Statistics.SaleStat.October].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_November_QTY.Text = keyValuePairs[Statistics.SaleStat.November].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_December_QTY.Text = keyValuePairs[Statistics.SaleStat.December].Key.ToString(CultureInfo.CurrentCulture);
            StatLabel_Yearly_QTY.Text = keyValuePairs[Statistics.SaleStat.Yearly].Key.ToString(CultureInfo.CurrentCulture);

            StatLabel_AllTime_Gross.Text = keyValuePairs[Statistics.SaleStat.AllTime].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_January_Gross.Text = keyValuePairs[Statistics.SaleStat.January].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_February_Gross.Text = keyValuePairs[Statistics.SaleStat.February].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_March_Gross.Text = keyValuePairs[Statistics.SaleStat.March].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_April_Gross.Text = keyValuePairs[Statistics.SaleStat.April].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_May_Gross.Text = keyValuePairs[Statistics.SaleStat.May].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_June_Gross.Text = keyValuePairs[Statistics.SaleStat.June].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_July_Gross.Text = keyValuePairs[Statistics.SaleStat.July].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_August_Gross.Text = keyValuePairs[Statistics.SaleStat.August].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_September_Gross.Text = keyValuePairs[Statistics.SaleStat.September].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_October_Gross.Text = keyValuePairs[Statistics.SaleStat.October].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_November_Gross.Text = keyValuePairs[Statistics.SaleStat.November].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_December_Gross.Text = keyValuePairs[Statistics.SaleStat.December].Value.ToString(CultureInfo.CurrentCulture);
            StatLabel_Yearly_Gross.Text = keyValuePairs[Statistics.SaleStat.Yearly].Value.ToString(CultureInfo.CurrentCulture);

            StatLabel_TotalSales_TOT.Text = Statistics.TotalSalesStatistics(MyStock, MySales.ReceiptsAsList());


        }

        private void UpdateStatListView()
        {

            Stock stock;

            StatListView_Sales.Items.Clear();

            if (StatTextBox_Search.TextLength == 0)
            {
                stock = MyStock;
            }
            else if (StatTextBox_Search.Text.Contains(';'))
            {
                SplitSearcher splitSearcher = new SplitSearcher();
                stock = splitSearcher.Search(MyStock, StatTextBox_Search.Text);
            }
            else
            {
                WildSearch wildSearcher = new WildSearch();

                stock = wildSearcher.Search(MyStock, StatTextBox_Search.Text);
            }

            foreach (KeyValuePair<uint, Product> productValuePair in stock.Products)
            {
                if (StatCheckBox_ShowAll.CheckState == CheckState.Unchecked)
                {
                    if (productValuePair.Value.Status == Product.ProductStatus.Active)
                    {
                        StatListView_Sales.Items.Add(productValuePair.Value.StatisticsGetProductListViewItem());
                    }
                }
                else
                {
                    StatListView_Sales.Items.Add(productValuePair.Value.StatisticsGetProductListViewItem());
                }
            }

        }

        private void UpdateStockListView()
        {
            Stock stock;

            StockListView1.Items.Clear();

            if (StockTextBox_Search.TextLength == 0)
            {
                stock = MyStock;
            }
            else if (StockTextBox_Search.Text.Contains(';'))
            {
                SplitSearcher splitSearcher = new SplitSearcher();
                stock = splitSearcher.Search(MyStock, StockTextBox_Search.Text);
            }
            else
            {
                WildSearch wildSearcher = new WildSearch();

                stock = wildSearcher.Search(MyStock, StockTextBox_Search.Text);
            }

            foreach (KeyValuePair<uint, Product> productValuePair in stock.Products)
            {
                if (StockCheckBox_ShowAllProducts.CheckState == CheckState.Unchecked)
                {
                    if (productValuePair.Value.Status == Product.ProductStatus.Active)
                    {
                        StockListView1.Items.Add(productValuePair.Value.GetProductListViewItem());
                    }
                }
                else
                {
                    StockListView1.Items.Add(productValuePair.Value.GetProductListViewItem());
                }
            }
        }

        /// <summary>
        /// Checks if all fields are correctly formated.
        /// </summary>
        /// <returns>True if all fields are correctly formated.</returns>
        private bool ValidateFieldsInStockTab()
        {
            if (
                Product.ProductType.TryParse(StockListBox_Type.Text, true, out Product.ProductType _) &&
                decimal.TryParse(StockTextBox_Price.Text, out decimal _) &&
                uint.TryParse(StockTextBox_Quantity.Text, out uint _) &&
                uint.TryParse(StockTextBox_ReleaseYear.Text, out uint _) &&
                StockTextBox_Title.Text.Contains(Environment.NewLine) == false && StockTextBox_Title.Text.Contains(";") == false &&
                StockTextBox_Creator.Text.Contains(Environment.NewLine) == false && StockTextBox_Creator.Text.Contains(";") == false &&
                StockTextBox_Publisher.Text.Contains(Environment.NewLine) == false && StockTextBox_Publisher.Text.Contains(";") == false &&
                StockTextBox_FreeText.Text.Contains(Environment.NewLine) == false && StockTextBox_FreeText.Text.Contains(";") == false
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Methods

        private void StockTextBox_TextChanged(object sender, EventArgs e)
        {
            if (StockTextBox_ProductCode.TextLength != 0)
            {
                UnsavedChanges = true;
                StockSplitContainer1.Panel2.BackColor = Color.MistyRose;
            }
        }

        private void Unload_StockTextBox_EventHandler()
        {
            StockTextBox_Price.TextChanged -= new EventHandler(this.StockTextBox_TextChanged);
            StockListBox_Type.SelectedValueChanged -= new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_FreeText.TextChanged -= new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_ReleaseYear.TextChanged -= new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_Publisher.TextChanged -= new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_Creator.TextChanged -= new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_Quantity.TextChanged -= new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_Price.TextChanged -= new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_Title.TextChanged -= new EventHandler(this.StockTextBox_TextChanged);
            StockCheckBox_Active.CheckedChanged -= new EventHandler(this.IsActiveCheckBox_CheckedChanged);
        }

        private void Load_StockTextBox_EventHandler()
        {
            StockTextBox_Price.TextChanged += new EventHandler(this.StockTextBox_TextChanged);
            StockListBox_Type.SelectedValueChanged += new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_FreeText.TextChanged += new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_ReleaseYear.TextChanged += new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_Publisher.TextChanged += new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_Creator.TextChanged += new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_Quantity.TextChanged += new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_Price.TextChanged += new EventHandler(this.StockTextBox_TextChanged);
            StockTextBox_Title.TextChanged += new EventHandler(this.StockTextBox_TextChanged);
            StockCheckBox_Active.CheckedChanged += new EventHandler(this.IsActiveCheckBox_CheckedChanged);
        }

        private void MainTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (UnsavedChanges)
            {
                DialogResult dlgr = MessageBox.Show("You have unsaved changes. \r\nDo you want to save changes before leaving?", "Save changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (dlgr == DialogResult.Yes)
                {
                    if (SaveUpdatedProductFromStockTab())
                    {
                        UpdateStockListView();
                        SaveFiles();
                        UnsavedChanges = false;
                        StockSplitContainer1.Panel2.BackColor = Color.Transparent;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else if (dlgr == DialogResult.No)
                {
                    UpdateStockBoxes(uint.Parse(StockTextBox_ProductCode.Text, CultureInfo.CurrentCulture));
                    UnsavedChanges = false;
                    StockSplitContainer1.Panel2.BackColor = Color.Transparent;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}