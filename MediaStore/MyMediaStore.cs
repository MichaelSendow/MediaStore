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

        #endregion Fields

        #region Constructors

        public MyMediaStore()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            CashierListView1.ListViewItemSorter = lvwColumnSorter;
            ShoppingBasketListView1.ListViewItemSorter = lvwColumnSorter;
            StockListView1.ListViewItemSorter = lvwColumnSorter;
            MyShoppingBasket = new ShoppingBasket();
            ReceiptList = new List<string>();

            //Product product1 = new Product(MyStock.GetNextProductCode(), "Avatar: The Last Airbender, The Complete Collection", Product.ProductTypes.Movie, 297.20m, 0, "Michael Dante DiMartino & Bryan Konietzko", "De som praktiserar en av de fyra elementens krafter slåss mot varandra. De olika fraktionerna, Eld, Vatten, Jord och Luft, kämpar om herreväldet, och den som är ödesbestämd att få slut på striderna är Avataren. Tyvärr är Avataren en omogen pojkspoling på tolv år, som inte vill ha något ansvar alls. Längd: 1468 minute", "Twentieth Century Fox", "2017", false);
            //MyStock.AddProduct(product1);
            //MyStock.SaveStockToFile(productsFileName);
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

            UpdateStockListView();
            UpdateCashierStockListView();
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
            if (ReturnReceiptTextBox.TextLength != 0 && ReturnProductTextBox.TextLength != 0 && ReturnQtyTextBox.TextLength != 0)
            {
                //All fields are validnumbers
                if (ValidateUINT(ReturnReceiptTextBox.Text) && ValidateUINT(ReturnProductTextBox.Text) && ValidateUINT(ReturnQtyTextBox.Text))
                {
                    uint receiptNumber = uint.Parse(ReturnReceiptTextBox.Text, CultureInfo.CurrentCulture);
                    uint productCode = uint.Parse(ReturnProductTextBox.Text, CultureInfo.CurrentCulture);
                    uint quantityToReturn = uint.Parse(ReturnQtyTextBox.Text, CultureInfo.CurrentCulture);

                    if (quantityToReturn <= 0)
                    {
                        MessageBox.Show("Return quantity must be 1 or larger");
                        return;
                    }

                    if (MySales.ReturnProduct(receiptNumber, productCode, quantityToReturn))
                    {
                        MyStock.AddQuantity(productCode, quantityToReturn);
                        UpdateStockListView();
                        ReturnReceiptTextBox.Text = "";
                        ReturnProductTextBox.Text = "";
                        ReturnQtyTextBox.Text = "";
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
            if (uint.TryParse(QuantityTextBox.Text, out uint _))
            {
                if (uint.Parse(QuantityTextBox.Text, CultureInfo.CurrentCulture) == 0)
                {
                    SaveUpdatedProductFromStockTab();
                    UpdateListViews();
                    SaveFiles();
                }
                else if (IsActiveCheckBox.Checked == false && uint.Parse(QuantityTextBox.Text, CultureInfo.CurrentCulture) > 0)
                {
                    DialogResult dlgr = MessageBox.Show($"The product still has quantity in stock.\r\nAre you sure the product should be inactive?", "Quantity is not zero", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (dlgr == DialogResult.Yes)
                    {
                        SaveUpdatedProductFromStockTab();
                        UpdateListViews();
                        SaveFiles();
                    }
                    else
                    {
                        this.IsActiveCheckBox.CheckedChanged -= new EventHandler(this.IsActiveCheckBox_CheckedChanged);
                        IsActiveCheckBox.Checked = true;
                        this.IsActiveCheckBox.CheckedChanged += new EventHandler(this.IsActiveCheckBox_CheckedChanged);
                    }
                }
                else
                {
                    SaveUpdatedProductFromStockTab();
                    UpdateListViews();
                    SaveFiles();
                }
            }
        }

        private void MyMediaStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MyShoppingBasket.Products.Count != 0)
            {
                DialogResult dlgr = MessageBox.Show("The Shopping Basket is not empty. \r\nComplete sale before qutting?", "Complete sale?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (dlgr == DialogResult.Yes)
                {
                    e.Cancel = true;
                    MainTabControl.SelectedTab = CashierTabPage;
                    CashierTabPage.Focus();

                    return;
                }
                else if (dlgr == DialogResult.No)
                {
                    ClearShoppingBasket();
                }
            }

            if (UnsavedChanges())
            {
                DialogResult dlgr = MessageBox.Show("You have unsaved changes in the Stock-tab. Do you want to save changes before quitting?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (dlgr == DialogResult.Yes)
                {
                    e.Cancel = true;
                    MainTabControl.SelectedTab = StockTabPage;
                    StockTabPage.Focus();
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

        private void ShoppingBasketCheckOutButton_Click(object sender, EventArgs e)
        {
            if (MyShoppingBasket.Products.Count != 0)
            {
                uint receiptNumber = MySales.GetNextReceiptNumber();

                //Prints to default printer.
                if (CashierPrintReceiptsCheckBox.CheckState == CheckState.Checked)
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
                    ReceiptList.Add("Total sum: " + TotalSum_Numbers.Text.PadLeft(70));

                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }

                //Add new receipt
                foreach (var product in MyShoppingBasket.Products.Values)
                {
                    MySales.AddReceipt(new Receipt(receiptNumber, product.ProductCode, DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture), product.Quantity));
                }

                ShoppingBasketListView1.Items.Clear();
                MyShoppingBasket.ClearBasket();
                TotalSum_Numbers.Text = "0";
            }

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
            //Dirty way of showing the receipts.
            System.Diagnostics.Process.Start($"{salesFileName}");
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

        private void StockListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectListViewItem();
        }

        private void StockSaveUpdatedProductButton_Click(object sender, EventArgs e)
        {
            SaveUpdatedProductFromStockTab();
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

        private void SaveUpdatedProductFromStockTab()
        {
            if (ValidateFieldsInStockTab())
            {
                uint productCode = uint.Parse(ProductCodeTextBox.Text, CultureInfo.CurrentCulture);
                Product updatedProduct = MyStock.GetProduct(productCode);

                if (IsActiveCheckBox.Checked == true)
                {
                    updatedProduct.UpdateProduct(TitleTextBox.Text,
                    (Product.ProductType)Enum.Parse(typeof(Product.ProductType), TypeListBox.Text, true),
                    decimal.Parse(PriceTextBox.Text, CultureInfo.CurrentCulture),
                    uint.Parse(QuantityTextBox.Text, CultureInfo.CurrentCulture),
                    CreatorTextBox.Text, FreeTextBox.Text,
                    PublisherTextBox.Text,
                    uint.Parse(ReleaseYearTextBox.Text, CultureInfo.CurrentCulture),
                    Product.ProductStatus.Active);
                }
                else
                {
                    updatedProduct.UpdateProduct(TitleTextBox.Text,
                    (Product.ProductType)Enum.Parse(typeof(Product.ProductType), TypeListBox.Text, true),
                    decimal.Parse(PriceTextBox.Text, CultureInfo.CurrentCulture),
                    uint.Parse(QuantityTextBox.Text, CultureInfo.CurrentCulture),
                    CreatorTextBox.Text, FreeTextBox.Text,
                    PublisherTextBox.Text,
                    uint.Parse(ReleaseYearTextBox.Text, CultureInfo.CurrentCulture),
                    Product.ProductStatus.InActive);
                }

            }
            else
            {
                MessageBox.Show("Some fields are not correctly formated. Newlines or ';' are not allowed.", "Unsupported format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectListViewItem()
        {
            if (StockListView1.SelectedItems.Count == 0)
            {
                return;
            }
            else if (ProductCodeTextBox.TextLength != 0)
            {
                if (UnsavedChanges())
                {
                    DialogResult dlgr = MessageBox.Show("You have unsaved changes. \r\nDo you want to save changes before changing product?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (dlgr == DialogResult.Yes)
                    {
                        SaveUpdatedProductFromStockTab();
                        UpdateStockListView();
                        SaveFiles();
                        return;
                    }
                    else
                    {
                        UpdateStockListView();
                    }
                }
            }

            uint productCode = uint.Parse(StockListView1.Items[StockListView1.SelectedIndices[0]].Text, CultureInfo.CurrentCulture);

            Product selectedProduct = MyStock.GetProduct(productCode);

            ProductCodeTextBox.Text = selectedProduct.ProductCode.ToString(CultureInfo.CurrentCulture);
            TypeListBox.Text = selectedProduct.Type.ToString();
            PriceTextBox.Text = selectedProduct.Price.ToString(CultureInfo.CurrentCulture);
            QuantityTextBox.Text = selectedProduct.Quantity.ToString(CultureInfo.CurrentCulture);
            TitleTextBox.Text = selectedProduct.Title;
            ReleaseYearTextBox.Text = selectedProduct.ReleaseYear.ToString(CultureInfo.CurrentCulture);
            CreatorTextBox.Text = selectedProduct.Creator;
            PublisherTextBox.Text = selectedProduct.Publisher;
            FreeTextBox.Text = selectedProduct.FreeText;
            if (selectedProduct.Status != Product.ProductStatus.Active)
            {
                IsActiveCheckBox.CheckedChanged -= new EventHandler(this.IsActiveCheckBox_CheckedChanged);
                IsActiveCheckBox.Checked = false;
                IsActiveCheckBox.CheckedChanged += new EventHandler(this.IsActiveCheckBox_CheckedChanged);
            }
            else
            {
                IsActiveCheckBox.Checked = true;
            }
        }

        private bool UnsavedChanges()
        {
            if (ProductCodeTextBox.TextLength != 0)
            {
                Product oldProduct = MyStock.GetProduct(uint.Parse(ProductCodeTextBox.Text, CultureInfo.CurrentCulture));

                if (
                    TypeListBox.Text != oldProduct.Type.ToString() ||
                    PriceTextBox.Text != oldProduct.Price.ToString(CultureInfo.CurrentCulture) ||
                    QuantityTextBox.Text != oldProduct.Quantity.ToString(CultureInfo.CurrentCulture) ||
                    TitleTextBox.Text != oldProduct.Title ||
                    ReleaseYearTextBox.Text != oldProduct.ReleaseYear.ToString(CultureInfo.CurrentCulture) ||
                    CreatorTextBox.Text != oldProduct.Creator ||
                    PublisherTextBox.Text != oldProduct.Publisher ||
                    FreeTextBox.Text != oldProduct.FreeText
                    )

                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void UpdateCashierStockListView()
        {

            Stock stock;

            CashierListView1.Items.Clear();

            if (CashierSearchTextBox.TextLength == 0)
            {
                stock = MyStock;
            }
            else if (CashierSearchTextBox.Text.Contains(';'))
            {
                SplitSearcher splitSearcher = new SplitSearcher();
                stock = splitSearcher.Search(MyStock, CashierSearchTextBox.Text);
            }
            else
            {
                WildSearch wildSearcher = new WildSearch();

                stock = wildSearcher.Search(MyStock, CashierSearchTextBox.Text);
            }

            foreach (KeyValuePair<uint, Product> productValuePair in stock.Products)
            {
                if (CashierShowAllProductsCheckBox.CheckState == CheckState.Unchecked)
                {
                    if (productValuePair.Value.Status == Product.ProductStatus.Active)
                    {
                        CashierListView1.Items.Add(productValuePair.Value.GetProductListViewItem());
                    }
                }
                else
                {
                    if (productValuePair.Value.Status == Product.ProductStatus.Active)
                    {
                        CashierListView1.Items.Add(productValuePair.Value.GetProductListViewItem());
                    }
                    else
                    {
                        CashierListView1.Items.Add(productValuePair.Value.GetProductListViewItem(new Font("Verdana", 8F, FontStyle.Strikeout, GraphicsUnit.Point, ((byte)(0)))));
                    }
                }
            }
        }

        private void UpdateListViews()
        {
            UpdateShoppingBasketListView();
            UpdateStockListView();
            UpdateCashierStockListView();
        }

        private void UpdateShoppingBasketListView()
        {
            ShoppingBasketListView1.Items.Clear();
            decimal totalSum = 0;

            foreach (KeyValuePair<uint, Product> productValuePair in MyShoppingBasket.Products)
            {
                ListViewItem listViewItem = productValuePair.Value.ShoppingBasketGetProductListViewItem();
                ShoppingBasketListView1.Items.Add(listViewItem);
                totalSum += (productValuePair.Value.Quantity * productValuePair.Value.Price);
            }

            TotalSum_Numbers.ForeColor = Color.Black;
            TotalSum_Numbers.Text = Math.Round(totalSum, 2).ToString(CultureInfo.CurrentCulture);
        }

        private void UpdateStockListView()
        {
            Stock stock;

            StockListView1.Items.Clear();

            if (StockSearchTextBox.TextLength == 0)
            {
                stock = MyStock;
            }
            else if (StockSearchTextBox.Text.Contains(';'))
            {
                SplitSearcher splitSearcher = new SplitSearcher();
                stock = splitSearcher.Search(MyStock, StockSearchTextBox.Text);
            }
            else
            {
                WildSearch wildSearcher = new WildSearch();

                stock = wildSearcher.Search(MyStock, StockSearchTextBox.Text);
            }

            foreach (KeyValuePair<uint, Product> productValuePair in stock.Products)
            {
                if (StockShowAllProductsCheckBox.CheckState == CheckState.Unchecked)
                {
                    if (productValuePair.Value.Status == Product.ProductStatus.Active)
                    {
                        StockListView1.Items.Add(productValuePair.Value.GetProductListViewItem());
                    }
                }
                else
                {
                    if (productValuePair.Value.Status == Product.ProductStatus.Active)
                    {
                        StockListView1.Items.Add(productValuePair.Value.GetProductListViewItem());
                    }
                    else
                    {
                        StockListView1.Items.Add(productValuePair.Value.GetProductListViewItem(new Font("Verdana", 8F, FontStyle.Strikeout, GraphicsUnit.Point, ((byte)(0)))));
                    }
                }

            }

        }

        private bool ValidateFieldsInStockTab()
        {
            if (
                Product.ProductType.TryParse(TypeListBox.Text, true, out Product.ProductType _) &&
                decimal.TryParse(PriceTextBox.Text, out decimal _) &&
                uint.TryParse(QuantityTextBox.Text, out uint _) &&
                uint.TryParse(ReleaseYearTextBox.Text, out uint _) &&
                TitleTextBox.Text.Contains(Environment.NewLine) == false && TitleTextBox.Text.Contains(";") == false &&
                CreatorTextBox.Text.Contains(Environment.NewLine) == false && CreatorTextBox.Text.Contains(";") == false &&
                PublisherTextBox.Text.Contains(Environment.NewLine) == false && PublisherTextBox.Text.Contains(";") == false &&
                FreeTextBox.Text.Contains(Environment.NewLine) == false && FreeTextBox.Text.Contains(";") == false
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


    }
}