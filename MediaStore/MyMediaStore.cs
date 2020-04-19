using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MediaStore
{
    /// <summary>
    /// Simple media store
    /// </summary>
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

        /// <summary>
        /// Konstruktor för MyMediaStore
        /// </summary>
        public MyMediaStore()
        {
            InitializeComponent();

            //Skapa ny kolumnsorterare och bind den till alla listviews
            lvwColumnSorter = new ListViewColumnSorter();
            CashierListView1.ListViewItemSorter = lvwColumnSorter;
            ShoppingBasketListView1.ListViewItemSorter = lvwColumnSorter;
            StockListView1.ListViewItemSorter = lvwColumnSorter;
            StatListView_Sales.ListViewItemSorter = lvwColumnSorter;
            //Skapar en ny tom varukorg
            MyShoppingBasket = new ShoppingBasket();
            //Förbereder för kvittoutskrifter
            ReceiptList = new List<string>();
            //Sätter värde på Numeric-up-down i Statistics-tabben till dagens datum
            StatDateTimePicker_Year.Value = DateTime.Now;
            //Kopplar på eventhanteraren för kontrollen.
            this.StatDateTimePicker_Year.ValueChanged += new System.EventHandler(this.StatDateTimePicker_Year_ValueChanged);
        }

        /// <summary>
        /// När formuläret laddas laddar denna metod in produktfilen och kvittofilen. Uppdaterar alla ListViews och sätter lite startvärden för statistiksidan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyMediaStore_Load(object sender, EventArgs e)
        {
            //Ladda produktfil om sådan finns. Annars skapa ett tomt lager.
            //Stänger ned programmet om inläsning misslyckas.
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

            //Ladda kvittofil om sådan finns. Annars skapas en tom bokföring.
            //Stänger ned programmet om inläsning misslyckas.
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

            //Sätter några labels i Statistic-tabben
            StatSetLabels();
            //Uppdatera alla listviews med produkter.
            UpdateListViews();

            //Sätt label och räkna ut statisitk för Statistics-tabben
            StatLabel_TotalSales.Text = "All Sales / All Sales " + StatDateTimePicker_Year.Value.ToString("yyyy", CultureInfo.CurrentCulture);
            StatLabel_TotalSales_TOT.Text = Statistics.TotalSalesStatistics(MyStock, MySales.ReceiptsAsList(), StatDateTimePicker_Year.Value);
        }

        #endregion Constructors

        #region EventMethods
        /// <summary>
        /// Öppna en dialog för att lägga till ny produkt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Returnerar produkter till lagret
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashierReturnItemsButton_Click(object sender, EventArgs e)
        {
            //Kontrollerar att alla fält är ifyllda
            if (CashierTextBox_ReturnReceipt.TextLength != 0 && CashierTextBox_ReturnProduct.TextLength != 0 && CashierTextBox_ReturnQuantity.TextLength != 0)
            {
                //Kontrollerar att all text går att konvertera till typen uint
                if (
                    uint.TryParse(CashierTextBox_ReturnReceipt.Text, out uint receiptNumber) &&
                    uint.TryParse(CashierTextBox_ReturnProduct.Text, out uint productCode) &&
                    uint.TryParse(CashierTextBox_ReturnQuantity.Text, out uint quantityToReturn)
                    )
                {
                    //Konverterar texten i fälten till uint
                    //receiptNumber = uint.Parse(CashierTextBox_ReturnReceipt.Text, CultureInfo.CurrentCulture);
                    //productCode = uint.Parse(CashierTextBox_ReturnProduct.Text, CultureInfo.CurrentCulture);
                    //quantityToReturn = uint.Parse(CashierTextBox_ReturnQuantity.Text, CultureInfo.CurrentCulture);

                    if (quantityToReturn <= 0)
                    {
                        MessageBox.Show("Return quantity must be 1 or larger");
                        return;
                    }

                    //Om siffrorna stämmer så returneras varan till lagret och kvittot uppdateras.
                    if (MySales.ReturnProduct(receiptNumber, productCode, quantityToReturn))
                    {
                        MyStock.AddQuantity(productCode, quantityToReturn);
                        UpdateListViews();
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

        /// <summary>
        /// Sökfunktion i Cashier-fliken 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashierSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateCashierStockListView();
        }

        /// <summary>
        /// Visa/dölj inaktiva produkter i Cashier-fliken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashierShowAllProductsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCashierStockListView();
        }

        /// <summary>
        /// Öppnar en dialog för att köpa en produkt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashierStockListView_DoubleClick(object sender, EventArgs e)
        {
            uint productCode = uint.Parse(CashierListView1.SelectedItems[0].Text, CultureInfo.CurrentCulture);

            //Så att dispose kallas korrekt på det nya formuläret.
            using (ProductForm productForm = new ProductForm(MyStock.GetProduct(productCode), ProductForm.FormFunction.AddToBasket, MyStock.Products[productCode].Quantity))
            {
                productForm.ShowDialog();
                if (productForm.FunctionSucceeded)
                {
                    uint qty = productForm.GetNumericSpinBoxValue();
                    //Lägg till varan i korgen
                    MyShoppingBasket.AddProductToBasket(MyStock.GetProduct(productCode), qty);
                    //Räkna ned lagret med lika många exemplar som flyttades till korgen.
                    MyStock.Products[productCode].Quantity -= qty;
                    UpdateListViews();
                }
            }
        }

        /// <summary>
        /// Kallas på när man byter flik. Kontroll för att fråga om man vill spara ändringar på en produkt om sådan finns i Stock-fliken. Ändrar tillbaka bakgrundsfärgen vid YES/NO. Cancel gör inget.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Kallas på när man stänger programmet. Kontrollerar att varukorgen är tom och att inga ändringar finns att spara. Om allt är som det ska så sparas produktfil och kvittofil.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Utskriftsfunktion, modifierad för att läsa från en Lista av strängar istället för från en streamreader.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Skapar upp kvitto för att printa samt ett kvitto för bokföringen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShoppingBasketCheckOutButton_Click(object sender, EventArgs e)
        {
            if (MyShoppingBasket.Products.Count != 0)
            {
                uint receiptNumber = MySales.GetNextReceiptNumber();

                //Printar till standardskrivare om checkbox är ikryssad
                if (CashierCheckBox_PrintReceipts.CheckState == CheckState.Checked)
                {
                    ReceiptList.Clear();
                    ReceiptList.Add($"Receipt {DateTime.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture)}");
                    ReceiptList.Add($"Receipt number: {receiptNumber.ToString(CultureInfo.CurrentCulture)}");
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

                //Lägger till kvitto till bokföringen.
                foreach (var product in MyShoppingBasket.Products.Values)
                {
                    MySales.AddReceipt(new Receipt(receiptNumber, product.ProductCode, DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture), product.Quantity, product.Price));
                }

                //Töm listview, varukorg och sätt om TotalSum till 0
                ShoppingBasketListView1.Items.Clear();
                MyShoppingBasket.ClearBasket();
                ShoppingBasketTextBox_TotalSum.Text = "0";
            }
            //Bara så att användaren får lite feedback på att försäljning gått igenom
            MessageBox.Show("Sale completed", "Sold", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SaveFiles();
        }
        /// <summary>
        ///Tömmer varukorgen och återbördar exemplaren till lagret
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShoppingBasketClearBasketButton_Click(object sender, EventArgs e)
        {
            ClearShoppingBasket();
            UpdateListViews();
            SaveFiles();
        }
        /// <summary>
        /// Öppnar dialog som ger användaren möjlighet att ändra antalet varor kunden vill köpa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShoppingBasketListView_DoubleClick(object sender, EventArgs e)
        {
            uint productCode = uint.Parse(ShoppingBasketListView1.SelectedItems[0].Text, CultureInfo.CurrentCulture);

            //Ny dialog 
            using (ProductForm productForm = new ProductForm(MyShoppingBasket.GetProduct(productCode), ProductForm.FormFunction.ShoppingList, MyStock.Products[productCode].Quantity))
            {
                productForm.ShowDialog();
                if (productForm.FunctionSucceeded)
                {
                    //Om allt går bra läs tillbaka den nya kvantiteten
                    uint qty = productForm.GetNumericSpinBoxValue();
                    uint originalQty = MyShoppingBasket.GetProduct(productCode).Quantity;

                    if (qty == 0)
                    {
                        //Om qty == 0 så returnera allt till lagret
                        MyShoppingBasket.Products.Remove(productCode);
                        MyStock.Products[productCode].Quantity += originalQty;
                    }
                    else
                    {
                        //Annars justera lager och varukorg
                        MyShoppingBasket.Products[productCode].Quantity = qty;
                        MyStock.Products[productCode].Quantity += originalQty - qty;
                    }
                    //Uppdatera listviews för att återspegla ändringen i lagerstatus
                    UpdateListViews();
                }
            }
        }

        /// <summary>
        /// Öppnar ett enkelt formulär för att lista alla kvitton i bokföringen. Underlättar vid demonstrationssyfte.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowReceiptsButton_Click(object sender, EventArgs e)
        {
            if (receiptDialog != null)
            {
                receiptDialog.Dispose();
            }

            receiptDialog = new ReceiptsDialog(MyStock, MySales);
            receiptDialog.Show();
        }

        // How to sort a ListView control by a column in Visual C#
        // https://support.microsoft.com/en-us/help/319401/how-to-sort-a-listview-control-by-a-column-in-visual-c
        // 2020-03-21
        // 
        /// <summary>
        /// Sorterar listview via kolumnklick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            //Hårdkodat för mina listviews. Sätter textsortering eller numerisksortering.
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

        /// <summary>
        /// Visa/dölj inaktiva produkter i Statistics-fliken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatCheckBox_ShowAll_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStatListView();
        }

        /// <summary>
        /// Uppdaterar formuläret för att återspegla valt år i datetime-väljaren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatDateTimePicker_Year_ValueChanged(object sender, EventArgs e)
        {
            StatLabel_Yearly.Text = "Total " + StatDateTimePicker_Year.Value.ToString("yyyy", CultureInfo.CurrentCulture);
            StatLabel_TotalSales.Text = "All Sales / All Sales " + StatDateTimePicker_Year.Value.ToString("yyyy", CultureInfo.CurrentCulture);
            StatLabel_TotalSales_TOT.Text = Statistics.TotalSalesStatistics(MyStock, MySales.ReceiptsAsList(), StatDateTimePicker_Year.Value);
            StatListView_Sales_SelectedIndexChanged(sender, e);
        }

        /// <summary>
        /// Kallas på vid val av produkt i listan över produkter i Statistic-fliken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatListView_Sales_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectStatListViewItem();
        }

        /// <summary>
        /// Sökfunktion i Statistics-fliken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatTextBox_Search_TextChanged(object sender, EventArgs e)
        {
            UpdateStatListView();
        }

        /// <summary>
        /// Checkbox i Stock-fliken för att ändra en produkts status mellan aktiv och ej aktiv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stock_IsActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Kontrollera att QTY fältet är korrekt
            if (uint.TryParse(StockTextBox_Quantity.Text, out uint _))
            {
                //Om QTY är 0 behövs ingen extra kontroll
                if (uint.Parse(StockTextBox_Quantity.Text, CultureInfo.CurrentCulture) == 0)
                {
                    //Hämta produkt
                    Product product = MyStock.GetProduct(uint.Parse(StockTextBox_ProductCode.Text, CultureInfo.CurrentCulture));
                    //Om checkbox är checked sätt till aktiv annars till inaktiv
                    product.Status = StockCheckBox_Active.Checked ? Product.ProductStatus.Active : Product.ProductStatus.InActive;
                    //Uppdatera att osparade ändringar finns
                    UnsavedChanges = true;
                    StockSplitContainer1.Panel2.BackColor = Color.MistyRose;

                }
                //Om produkten finns i lager och är aktiv så behöver vi frånga om man är säker på vad man håller på med.
                else if (StockCheckBox_Active.Checked == false && uint.Parse(StockTextBox_Quantity.Text, CultureInfo.CurrentCulture) > 0)
                {
                    DialogResult dlgr = MessageBox.Show($"The product still has quantity in stock.\r\nAre you sure the product should be inactive?", "Quantity is not zero", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (dlgr == DialogResult.Yes)
                    {
                        Product product = MyStock.GetProduct(uint.Parse(StockTextBox_ProductCode.Text, CultureInfo.CurrentCulture));
                        product.Status = StockCheckBox_Active.Checked ? Product.ProductStatus.Active : Product.ProductStatus.InActive;
                        UnsavedChanges = true;
                        StockSplitContainer1.Panel2.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        //Om man inte vill sätta om till inaktiv behöver vi temporärt stoppa eventhanteraren för att inte hamna i en loop när vi sätter tillbaka checkboxen.
                        this.StockCheckBox_Active.CheckedChanged -= new EventHandler(this.Stock_IsActiveCheckBox_CheckedChanged);
                        StockCheckBox_Active.Checked = true;
                        this.StockCheckBox_Active.CheckedChanged += new EventHandler(this.Stock_IsActiveCheckBox_CheckedChanged);
                    }
                }
                // För att aktivera en produkt behöver vi inga kontroller.
                else
                {
                    Product product = MyStock.GetProduct(uint.Parse(StockTextBox_ProductCode.Text, CultureInfo.CurrentCulture));
                    product.Status = StockCheckBox_Active.Checked ? Product.ProductStatus.Active : Product.ProductStatus.InActive;
                    UnsavedChanges = true;
                    StockSplitContainer1.Panel2.BackColor = Color.MistyRose;
                }
            }
        }

        /// <summary>
        /// Kallas på vid val av produkt i listan över produkter i Stock-fliken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectStockListViewItem();
        }

        /// <summary>
        /// Uppdaterar vald produkt i Stock-fliken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockSaveUpdatedProductButton_Click(object sender, EventArgs e)
        {
            if (SaveUpdatedProductFromStockTab())
                UpdateListViews();
        }

        /// <summary>
        /// Sökfunktion i Stock-fliken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateStockListView();
        }

        /// <summary>
        /// Visa/dölj inaktiva produkter i Stock-fliken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockShowAllProductsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStockListView();
        }

        /// <summary>
        /// Om ett värde ändras i en produkt på Stock-fliken så sätter vi UnsavedChanges till true och ändrar bakgrundsfärg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockTextBox_TextChanged(object sender, EventArgs e)
        {
            if (StockTextBox_ProductCode.TextLength != 0)
            {
                UnsavedChanges = true;
                StockSplitContainer1.Panel2.BackColor = Color.MistyRose;
            }
        }

        /// <summary>
        /// Uppdaterar tio-i-topplistorna med all försäljning någonsin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Top10Button_AllTime_Click(object sender, EventArgs e)
        {
            Top10Button_AllTime.BackColor = Color.LightSkyBlue;
            Top10Button_Month.BackColor = Color.Transparent;
            Top10Button_Year.BackColor = Color.Transparent;

            Top10(Product.ProductType.Book, Top10ListView_Books, Top10BooksCheckBox, Statistics.Mode.AllTime);
            Top10(Product.ProductType.Movie, Top10ListView_Movies, Top10MoviesCheckBox, Statistics.Mode.AllTime);
            Top10(Product.ProductType.Music, Top10ListView_Music, Top10MusicCheckBox, Statistics.Mode.AllTime);
        }

        /// <summary>
        /// Uppdaterar tio-i-topplistorna med all försäljning för innevarande månad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Top10Button_Month_Click(object sender, EventArgs e)
        {
            Top10Button_AllTime.BackColor = Color.Transparent;
            Top10Button_Month.BackColor = Color.LightSkyBlue;
            Top10Button_Year.BackColor = Color.Transparent;

            Top10(Product.ProductType.Book, Top10ListView_Books, Top10BooksCheckBox, Statistics.Mode.Month);
            Top10(Product.ProductType.Movie, Top10ListView_Movies, Top10MoviesCheckBox, Statistics.Mode.Month);
            Top10(Product.ProductType.Music, Top10ListView_Music, Top10MusicCheckBox, Statistics.Mode.Month);
        }

        /// <summary>
        /// Uppdaterar tio-i-topplistorna med all försäljning för i år
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Top10Button_Year_Click(object sender, EventArgs e)
        {
            Top10Button_AllTime.BackColor = Color.Transparent;
            Top10Button_Month.BackColor = Color.Transparent;
            Top10Button_Year.BackColor = Color.LightSkyBlue;

            Top10(Product.ProductType.Book, Top10ListView_Books, Top10BooksCheckBox, Statistics.Mode.Year);
            Top10(Product.ProductType.Movie, Top10ListView_Movies, Top10MoviesCheckBox, Statistics.Mode.Year);
            Top10(Product.ProductType.Music, Top10ListView_Music, Top10MusicCheckBox, Statistics.Mode.Year);
        }
        #endregion EventMethods

        #region Methods

        /// <summary>
        /// Hjälpmetod för att tömma varukorg
        /// </summary>
        private void ClearShoppingBasket()
        {
            ShoppingBasketListView1.Items.Clear();

            foreach (var item in MyShoppingBasket.Products.Values)
            {
                MyStock.Products[item.ProductCode].Quantity += item.Quantity;
            }
            MyShoppingBasket.ClearBasket();
        }

        /// <summary>
        /// Hjälpmetod för att stänga ned programmet utan att spara filer
        /// </summary>
        private void ExitWithoutSavingFile()
        {
            //Koppla loss eventhanteraren för FormClosing() och stäng ned!
            this.FormClosing -= new FormClosingEventHandler(this.MyMediaStore_FormClosing);
            this.Close();
        }

        /// <summary>
        /// Hjälpmetod för att koppla på eventhanteraren för TextChanged i Stock-fliken
        /// </summary>
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
            StockCheckBox_Active.CheckedChanged += new EventHandler(this.Stock_IsActiveCheckBox_CheckedChanged);
        }

        /// <summary>
        /// Hjälpmetod för att spara produktfil och kvittofil
        /// </summary>
        private void SaveFiles()
        {
            MyStock.SaveStockToFile(productsFileName);
            MySales.SaveSalesToFile(salesFileName);
        }

        /// <summary>
        /// Hjälpmetod för att spara förändrad produkt i Stock-fliken
        /// </summary>
        /// <returns>True om produkten gick att spara till lagret.</returns>
        private bool SaveUpdatedProductFromStockTab()
        {
            //En produkt är "uppritad" i formuläret
            if (StockTextBox_ProductCode.TextLength != 0)
            {
                //Kontrollera att alla fält är korrekt formaterade
                if (ValidateFieldsInStockTab())
                {
                    //Hämta produktkoden
                    uint productCode = uint.Parse(StockTextBox_ProductCode.Text, CultureInfo.CurrentCulture);
                    //Hämta produkten
                    Product updatedProduct = MyStock.GetProduct(productCode);

                    //Uppdatera produkten
                    updatedProduct.UpdateProduct(StockTextBox_Title.Text,
                    (Product.ProductType)Enum.Parse(typeof(Product.ProductType), StockListBox_Type.Text, true),
                    decimal.Parse(StockTextBox_Price.Text, CultureInfo.CurrentCulture),
                    uint.Parse(StockTextBox_Quantity.Text, CultureInfo.CurrentCulture),
                    StockTextBox_Creator.Text, StockTextBox_FreeText.Text,
                    StockTextBox_Publisher.Text,
                    uint.Parse(StockTextBox_ReleaseYear.Text, CultureInfo.CurrentCulture),
                    StockCheckBox_Active.Checked ? Product.ProductStatus.Active : Product.ProductStatus.InActive);
                    //Sätt UnsavedChanges till false och ändra tillbaka bakgrundsfärgen
                    UnsavedChanges = false;
                    StockSplitContainer1.Panel2.BackColor = Color.Transparent;

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

        /// <summary>
        /// Hjälpmetod vid val av produkt i Statistics-fliken
        /// </summary>
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
        /// <summary>
        /// Hjälpmetod vid val av produkt i Stock-fliken
        /// </summary>
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

        /// <summary>
        /// Hjälpmetod för att sätta rätt text på labels i Statistics-fliken
        /// </summary>
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

        /// <summary>
        /// Hjälpmetod för att bygga upp tio-i-topplistor
        /// </summary>
        /// <param name="productType">Vilken produkttyp som listan ska framställas för</param>
        /// <param name="listView">Vilken listview som ska uppdateras</param>
        /// <param name="checkBox">Visa alla produkter eller bara aktiva</param>
        /// <param name="mode">Vilken tio-i-topp vill man ta fram: AllTime, Year, eller Month</param>
        private void Top10(Product.ProductType productType, ListView listView, CheckBox checkBox, Statistics.Mode mode)
        {
            List<Receipt> receipts = MySales.ReceiptsAsList();
            listView.Items.Clear();
            List<ListViewItem> listViewItems = Statistics.Top10(MyStock, receipts, productType, checkBox.Checked ? false : true, mode);

            for (int i = 0; i < listViewItems.Count && i < 10; i++)
            {
                listView.Items.Add(listViewItems[i]);
            }
        }

        /// <summary>
        /// Hjälpmetod för att koppla loss eventhanteraren för TextChanged i Stock-fliken
        /// </summary>
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
            StockCheckBox_Active.CheckedChanged -= new EventHandler(this.Stock_IsActiveCheckBox_CheckedChanged);
        }

        /// <summary>
        /// Hjälpmetod för att uppdatera listview i Cashier-fliken
        /// </summary>
        private void UpdateCashierStockListView()
        {

            Stock stock;
            //Töm listan på items
            CashierListView1.Items.Clear();

            //Kolla om sökraden är tom 
            if (CashierTextBox_Search.TextLength == 0)
            {
                //isf är stock = vårt lager
                stock = MyStock;
            }
            //Annars kollar vi om nyckelord har används i sökrutan och kör en splitSearcher
            else if (CashierTextBox_Search.Text.Contains(';'))
            {
                SplitSearcher splitSearcher = new SplitSearcher();
                //splitSearcher returnerar ett lager med enbart de produkter som uppfyller sökkriterierna
                stock = splitSearcher.Search(MyStock, CashierTextBox_Search.Text);
            }
            //Om inga nyckelord används så kör vi en WildSearch som är en fritextsökning över alla fält
            else
            {
                WildSearch wildSearcher = new WildSearch();
                //WildSearch returnerar ett lager med enbart de produkter som uppfyller sökkriterierna
                stock = wildSearcher.Search(MyStock, CashierTextBox_Search.Text);
            }

            //Nu har vi ett lager vi kan visa upp i en listview

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

        /// <summary>
        /// Uppdaterar alla listviews
        /// </summary>
        private void UpdateListViews()
        {
            UpdateShoppingBasketListView();
            UpdateStockListView();
            UpdateCashierStockListView();
            UpdateStatListView();
        }

        /// <summary>
        /// Hjälpmetod för att uppdatera varukorgens listview
        /// </summary>
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

        /// <summary>
        /// Hjälpmetod för att rita upp Statistics-fliken
        /// </summary>
        /// <param name="keyValuePairs">Dictionary innehållande kombination av säljinfotyp och ett keyvaluepair med QTY,GrossAmount </param>
        private void UpdateStatisticsTabPage(Dictionary<Statistics.SaleStat, KeyValuePair<uint, decimal>> keyValuePairs)
        {
            //Sätter alla labels
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

            //Sätter special labeln som visar totalförsäljning för det valda året.
            StatLabel_TotalSales_TOT.Text = Statistics.TotalSalesStatistics(MyStock, MySales.ReceiptsAsList(), StatDateTimePicker_Year.Value);
        }

        /// <summary>
        /// Hjälpmetod för att uppdatera listview i Statistics-fliken
        /// </summary>
        private void UpdateStatListView()
        {
            //Samma logik som i UpdateCashierStockListView()

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

        /// <summary>
        /// Hjälpmetod för att rita upp en produkt i Stock-fliken
        /// </summary>
        /// <param name="productCode">Produktnummer på den valda produkten</param>
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

        /// <summary>
        /// Hjälpmetod för att uppdatera listview i Stock-fliken
        /// </summary>
        private void UpdateStockListView()
        {
            //Samma logik som i UpdateCashierStockListView()

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
        /// Kontrollerar att alla fält för en produkt i Stock-fliken är korrekt formaterade.
        /// </summary>
        /// <returns>True om alla fält är korrekt formaterade</returns>
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


    }
}