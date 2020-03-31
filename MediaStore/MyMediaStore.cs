﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaStore
{
    public partial class MyMediaStore : Form
    {
        const string productsFileName = "products.csv";
        const string salesFileName = "sales.csv";

        private readonly Stock MyStock;
        private readonly ShoppingBasket MyShoppingBasket;
        private readonly Sales MySales;

        private readonly ListViewColumnSorter lvwColumnSorter;
        private readonly List<string> ReceiptList;



        public MyMediaStore()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            CashierStockListView.ListViewItemSorter = lvwColumnSorter;
            ShoppingBasketListView.ListViewItemSorter = lvwColumnSorter;
            MyShoppingBasket = new ShoppingBasket();
            ReceiptList = new List<string>();

            try
            {
                if (File.Exists(productsFileName))
                    MyStock = new Stock(productsFileName);
                else
                    MyStock = new Stock();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong loading products.\r\n\r\nError Message: {ex.Message}\r\n" +
                                    $"Inner Exception: {ex.InnerException.Message}\r\n{ex.InnerException.StackTrace}\r\n\r\n" +
                                    $"Please fix {productsFileName} and restart the program", $"LoadStock({productsFileName})", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExitWithoutSavingFile();
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
                MessageBox.Show($"Something went wrong loading sales info.\r\n\r\nError Message: {ex.Message}\r\n" +
                                    $"Inner Exception: {ex.InnerException.Message}\r\n{ex.InnerException.StackTrace}\r\n\r\n" +
                                    $"Please fix {salesFileName} and restart the program", $"LoadSales({salesFileName})", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExitWithoutSavingFile();
            }

            UpdateCashierStockListView();

            //Product product1 = new Product(MyStock.GetNextProductCode(), "Avatar: The Last Airbender, The Complete Collection", Product.ProductTypes.Movie, 297.20m, 0, "Michael Dante DiMartino & Bryan Konietzko", "De som praktiserar en av de fyra elementens krafter slåss mot varandra. De olika fraktionerna, Eld, Vatten, Jord och Luft, kämpar om herreväldet, och den som är ödesbestämd att få slut på striderna är Avataren. Tyvärr är Avataren en omogen pojkspoling på tolv år, som inte vill ha något ansvar alls. Längd: 1468 minute", "Twentieth Century Fox", "2017", false);
            //MyStock.AddProduct(product1);
            //MyStock.SaveStockToFile(productsFileName);



        }



        private void ExitWithoutSavingFile()
        {
            throw new NotImplementedException();
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

        /// <summary>
        /// Should add product to ShoppingBasket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashierStockListView_DoubleClick(object sender, EventArgs e)
        {

            uint productCode = uint.Parse(CashierStockListView.SelectedItems[0].Text, CultureInfo.CurrentCulture);

            using (ProductForm productForm = new ProductForm(MyStock.GetProduct(productCode), ProductForm.FormFunction.AddToBasket))
            {
                if (productForm.ShowDialog() == DialogResult.OK)
                {
                    uint qty = productForm.GetNumericSpinBoxValue();
                    MyShoppingBasket.AddProductToBasket(MyStock.GetProduct(productCode), qty);
                    MyStock.Products[productCode].Quantity -= qty;
                    UpdateShoppingBasketListView();
                    UpdateCashierStockListView();
                }
            }
        }

        private void ShoppingBasketListView_DoubleClick(object sender, EventArgs e)
        {
            uint productCode = uint.Parse(ShoppingBasketListView.SelectedItems[0].Text, CultureInfo.CurrentCulture);

            using (ProductForm productForm = new ProductForm(MyShoppingBasket.GetProduct(productCode), ProductForm.FormFunction.ShoppingList))
            {
                if (productForm.ShowDialog() == DialogResult.OK)
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

                    UpdateShoppingBasketListView();
                    UpdateCashierStockListView();
                }
            }
        }


        private void UpdateShoppingBasketListView()
        {

            ShoppingBasketListView.Items.Clear();
            decimal totalSum = 0;

            foreach (KeyValuePair<uint, Product> productValuePair in MyShoppingBasket.Products)
            {
                ListViewItem listViewItem = productValuePair.Value.ShoppingBasketGetProductListViewItem();
                ShoppingBasketListView.Items.Add(listViewItem);
                totalSum += (productValuePair.Value.Quantity * productValuePair.Value.Price);
            }

            TotalSum_Numbers.ForeColor = Color.Black;
            TotalSum_Numbers.Text = Math.Round(totalSum, 2).ToString(CultureInfo.CurrentCulture);

        }

        private void UpdateCashierStockListView()
        {
            CashierStockListView.Items.Clear();
            foreach (KeyValuePair<uint, Product> productValuePair in MyStock.Products)
            {
                if (productValuePair.Value.IsActive)
                {
                    CashierStockListView.Items.Add(productValuePair.Value.CashierGetProductListViewItem());
                }
            }

        }

        private void ShoppingBasketClearBasketButton_Click(object sender, EventArgs e)
        {
            ClearShoppingBasket();
            UpdateShoppingBasketListView();
            UpdateCashierStockListView();
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


                ShoppingBasketListView.Items.Clear();
                MyShoppingBasket.ClearBasket();
                TotalSum_Numbers.Text = "0";
            }
        }

        private void MyMediaStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MyShoppingBasket.Products.Count != 0)
            {
                ClearShoppingBasket();
            }

            //MyStock.SaveStockToFile(productsFileName);
            MySales.SaveSalesToFile(salesFileName);
        }


        private void ClearShoppingBasket()
        {
            ShoppingBasketListView.Items.Clear();

            foreach (var item in MyShoppingBasket.Products.Values)
            {
                MyStock.Products[item.ProductCode].Quantity += item.Quantity;
            }
            MyShoppingBasket.ClearBasket();
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
                    count++;// 0, 1,  2, 3

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

        private void CashierReturnItemsButton_Click(object sender, EventArgs e)
        {
            //All fields has text
            if (ReturnReceiptTextBox.Text.Length != 0 && ReturnProductTextBox.Text.Length != 0 && ReturnQtyTextBox.Text.Length != 0)
            {
                //All fields are validnumbers
                if (ValidateUINT(ReturnReceiptTextBox.Text) && ValidateUINT(ReturnProductTextBox.Text) && ValidateUINT(ReturnQtyTextBox.Text))
                {
                    uint receiptNumber = uint.Parse(ReturnReceiptTextBox.Text, CultureInfo.CurrentCulture);
                    uint productNumber = uint.Parse(ReturnProductTextBox.Text, CultureInfo.CurrentCulture);
                    uint quantity = uint.Parse(ReturnQtyTextBox.Text, CultureInfo.CurrentCulture);

                    try
                    {
                        MySales.Ledger[receiptNumber].
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    MySales.ReturnProduct(receiptNumber, productNumber, quantity);
                    MyStock.AddQuantity(productNumber, quantity);
                }


            }
        }

        /// <summary>
        /// Checks if a string is only numbers.
        /// </summary>
        /// <param name="TextBoxNumber"></param>
        /// <returns></returns>
        static bool ValidateUINT(string stringToValidate)
        {

            try
            {
                _ = uint.Parse(stringToValidate, CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }

}
