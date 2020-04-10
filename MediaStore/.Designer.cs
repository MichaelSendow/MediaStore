namespace MediaStore
{
    partial class MyMediaStore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                receiptDialog.Dispose();
            }
            base.Dispose(disposing);
            
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMediaStore));
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.CashierTabPage = new System.Windows.Forms.TabPage();
            this.CashierTabSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CashierSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CashierSplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CashierTextBox_Search = new System.Windows.Forms.TextBox();
            this.CashierLabel_Search = new System.Windows.Forms.Label();
            this.CashierListView1 = new System.Windows.Forms.ListView();
            this.CashierListViewColumnHeader_ProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CashierListViewColumnHeader_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CashierListViewColumnHeader_ProductType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CashierListViewColumnHeader_Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CashierListViewColumnHeader_Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CashierButton_ShowReceipts = new System.Windows.Forms.Button();
            this.CashierCheckBox_ShowAllProducts = new System.Windows.Forms.CheckBox();
            this.CashierTextBox_ReturnQuantity = new System.Windows.Forms.TextBox();
            this.CashierLabel_ReturnQuantity = new System.Windows.Forms.Label();
            this.CashierTextBox_ReturnProduct = new System.Windows.Forms.TextBox();
            this.CashierLabel_ReturnProduct = new System.Windows.Forms.Label();
            this.CashierTextBox_ReturnReceipt = new System.Windows.Forms.TextBox();
            this.CashierLabel_ReturnReceipt = new System.Windows.Forms.Label();
            this.CashierCheckBox_PrintReceipts = new System.Windows.Forms.CheckBox();
            this.CashierButton_ReturnItems = new System.Windows.Forms.Button();
            this.ShoppingBasketSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ShoppingBasketSplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CashierShoppingBasketLabel = new System.Windows.Forms.Label();
            this.ShoppingBasketTextBox_TotalSum = new System.Windows.Forms.TextBox();
            this.ShoppingBasketLabel_TotalSum = new System.Windows.Forms.Label();
            this.ShoppingBasketListView1 = new System.Windows.Forms.ListView();
            this.ShoppingBasketColumnHeader_ProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShoppingBasketColumnHeader_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShoppingBasketColumnHeader_Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShoppingBasketColumnHeader_Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShoppingBasketColumnHeader_TotalSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShoppingBasketButton_ClearBasket = new System.Windows.Forms.Button();
            this.ShoppingBasketButton_CheckOut = new System.Windows.Forms.Button();
            this.StockTabPage = new System.Windows.Forms.TabPage();
            this.StockSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.StockCheckBox_ShowAllProducts = new System.Windows.Forms.CheckBox();
            this.StockButton_AddNewProduct = new System.Windows.Forms.Button();
            this.StockSplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.StockSearchPanel1 = new System.Windows.Forms.Panel();
            this.StockTextBox_Search = new System.Windows.Forms.TextBox();
            this.StockLabel_Search = new System.Windows.Forms.Label();
            this.StockListView1 = new System.Windows.Forms.ListView();
            this.StockColumnHeader1_ProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StockColumnHeader2_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StockColumnHeader3_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StockColumnHeader4_Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StockColumnHeader5_Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StockListBox_Type = new System.Windows.Forms.ListBox();
            this.StockButton_Update = new System.Windows.Forms.Button();
            this.StockCheckBox_Active = new System.Windows.Forms.CheckBox();
            this.StockLabel_FreeText = new System.Windows.Forms.Label();
            this.StockTextBox_FreeText = new System.Windows.Forms.TextBox();
            this.StockLabel_ReleaseYear = new System.Windows.Forms.Label();
            this.StockTextBox_ReleaseYear = new System.Windows.Forms.TextBox();
            this.StockLabel_Publisher = new System.Windows.Forms.Label();
            this.StockTextBox_Publisher = new System.Windows.Forms.TextBox();
            this.StockLabel_Creator = new System.Windows.Forms.Label();
            this.StockTextBox_Creator = new System.Windows.Forms.TextBox();
            this.StockLabel_Type = new System.Windows.Forms.Label();
            this.StockLabel_Quantity = new System.Windows.Forms.Label();
            this.StockTextBox_Quantity = new System.Windows.Forms.TextBox();
            this.StockLabel_Price = new System.Windows.Forms.Label();
            this.StockTextBox_Price = new System.Windows.Forms.TextBox();
            this.StockLabel_Title = new System.Windows.Forms.Label();
            this.StockTextBox_Title = new System.Windows.Forms.TextBox();
            this.StockLabel_ProductCode = new System.Windows.Forms.Label();
            this.StockTextBox_ProductCode = new System.Windows.Forms.TextBox();
            this.StatisticsTabPage = new System.Windows.Forms.TabPage();
            this.StatSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.StatTableLayoutPanel1_Sales = new System.Windows.Forms.TableLayoutPanel();
            this.StatListView_Sales = new System.Windows.Forms.ListView();
            this.StatColumnHeader1_ProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatColumnHeader2_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatTextBox_Search = new System.Windows.Forms.TextBox();
            this.StatPanel_Controls = new System.Windows.Forms.Panel();
            this.StatCheckBox_ShowAll = new System.Windows.Forms.CheckBox();
            this.StatSplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.StatTableLayoutPanel_Charts = new System.Windows.Forms.TableLayoutPanel();
            this.StatButton_Month = new System.Windows.Forms.Button();
            this.StatButton_Year = new System.Windows.Forms.Button();
            this.StatPanel_Music = new System.Windows.Forms.Panel();
            this.StatLabel_Music = new System.Windows.Forms.Label();
            this.StatPanel_Movies = new System.Windows.Forms.Panel();
            this.StatLabel_Movies = new System.Windows.Forms.Label();
            this.StatPanel_Books = new System.Windows.Forms.Panel();
            this.StatLabel_Books = new System.Windows.Forms.Label();
            this.StatButton_AllTime = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.StatListView_Books = new System.Windows.Forms.ListView();
            this.StatBooksColumnHeader1_Pn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatBooksColumnHeader2_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatListView_Movies = new System.Windows.Forms.ListView();
            this.StatMoviesColumnHeader1_Pn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatMoviesColumnHeader2_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatListView_Music = new System.Windows.Forms.ListView();
            this.StatMusicColumnHeader1_Pn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatMusicColumnHeader2_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatDateTimePicker_Year = new System.Windows.Forms.DateTimePicker();
            this.StatTableLayoutPanel2_Sales = new System.Windows.Forms.TableLayoutPanel();
            this.StatPanel_Sales = new System.Windows.Forms.Panel();
            this.StatPanel_Dates = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StatLabel_AllTime = new System.Windows.Forms.Label();
            this.StatLabel_Quantity = new System.Windows.Forms.Label();
            this.StatLabel_GrossAmount = new System.Windows.Forms.Label();
            this.StatLabel_January = new System.Windows.Forms.Label();
            this.StatLabel_Februari = new System.Windows.Forms.Label();
            this.StatLabel_Mars = new System.Windows.Forms.Label();
            this.StatLabel_April = new System.Windows.Forms.Label();
            this.StatLabel_May = new System.Windows.Forms.Label();
            this.StatLabel_June = new System.Windows.Forms.Label();
            this.StatLabel_Juli = new System.Windows.Forms.Label();
            this.StatLabel_August = new System.Windows.Forms.Label();
            this.StatLabel_September = new System.Windows.Forms.Label();
            this.StatLabel_October = new System.Windows.Forms.Label();
            this.StatLabel_November = new System.Windows.Forms.Label();
            this.StatLabel_December = new System.Windows.Forms.Label();
            this.StatLabel_Yearly = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.CashierTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierTabSplitContainer)).BeginInit();
            this.CashierTabSplitContainer.Panel1.SuspendLayout();
            this.CashierTabSplitContainer.Panel2.SuspendLayout();
            this.CashierTabSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierSplitContainer1)).BeginInit();
            this.CashierSplitContainer1.Panel1.SuspendLayout();
            this.CashierSplitContainer1.Panel2.SuspendLayout();
            this.CashierSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierSplitContainer2)).BeginInit();
            this.CashierSplitContainer2.Panel1.SuspendLayout();
            this.CashierSplitContainer2.Panel2.SuspendLayout();
            this.CashierSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShoppingBasketSplitContainer1)).BeginInit();
            this.ShoppingBasketSplitContainer1.Panel1.SuspendLayout();
            this.ShoppingBasketSplitContainer1.Panel2.SuspendLayout();
            this.ShoppingBasketSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShoppingBasketSplitContainer2)).BeginInit();
            this.ShoppingBasketSplitContainer2.Panel1.SuspendLayout();
            this.ShoppingBasketSplitContainer2.Panel2.SuspendLayout();
            this.ShoppingBasketSplitContainer2.SuspendLayout();
            this.StockTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockSplitContainer1)).BeginInit();
            this.StockSplitContainer1.Panel1.SuspendLayout();
            this.StockSplitContainer1.Panel2.SuspendLayout();
            this.StockSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockSplitContainer2)).BeginInit();
            this.StockSplitContainer2.Panel1.SuspendLayout();
            this.StockSplitContainer2.Panel2.SuspendLayout();
            this.StockSplitContainer2.SuspendLayout();
            this.StockSearchPanel1.SuspendLayout();
            this.StatisticsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatSplitContainer1)).BeginInit();
            this.StatSplitContainer1.Panel1.SuspendLayout();
            this.StatSplitContainer1.Panel2.SuspendLayout();
            this.StatSplitContainer1.SuspendLayout();
            this.StatTableLayoutPanel1_Sales.SuspendLayout();
            this.StatPanel_Controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatSplitContainer2)).BeginInit();
            this.StatSplitContainer2.Panel1.SuspendLayout();
            this.StatSplitContainer2.Panel2.SuspendLayout();
            this.StatSplitContainer2.SuspendLayout();
            this.StatTableLayoutPanel_Charts.SuspendLayout();
            this.StatPanel_Music.SuspendLayout();
            this.StatPanel_Movies.SuspendLayout();
            this.StatPanel_Books.SuspendLayout();
            this.StatTableLayoutPanel2_Sales.SuspendLayout();
            this.StatPanel_Sales.SuspendLayout();
            this.StatPanel_Dates.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.CashierTabPage);
            this.MainTabControl.Controls.Add(this.StockTabPage);
            this.MainTabControl.Controls.Add(this.StatisticsTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1650, 865);
            this.MainTabControl.TabIndex = 0;
            // 
            // CashierTabPage
            // 
            this.CashierTabPage.Controls.Add(this.CashierTabSplitContainer);
            this.CashierTabPage.Location = new System.Drawing.Point(4, 38);
            this.CashierTabPage.Name = "CashierTabPage";
            this.CashierTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CashierTabPage.Size = new System.Drawing.Size(1642, 823);
            this.CashierTabPage.TabIndex = 0;
            this.CashierTabPage.Text = "Cashier";
            this.CashierTabPage.UseVisualStyleBackColor = true;
            // 
            // CashierTabSplitContainer
            // 
            this.CashierTabSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CashierTabSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.CashierTabSplitContainer.Name = "CashierTabSplitContainer";
            // 
            // CashierTabSplitContainer.Panel1
            // 
            this.CashierTabSplitContainer.Panel1.Controls.Add(this.CashierSplitContainer1);
            // 
            // CashierTabSplitContainer.Panel2
            // 
            this.CashierTabSplitContainer.Panel2.Controls.Add(this.ShoppingBasketSplitContainer1);
            this.CashierTabSplitContainer.Size = new System.Drawing.Size(1636, 817);
            this.CashierTabSplitContainer.SplitterDistance = 863;
            this.CashierTabSplitContainer.TabIndex = 0;
            this.CashierTabSplitContainer.TabStop = false;
            // 
            // CashierSplitContainer1
            // 
            this.CashierSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CashierSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CashierSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.CashierSplitContainer1.IsSplitterFixed = true;
            this.CashierSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.CashierSplitContainer1.Name = "CashierSplitContainer1";
            this.CashierSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // CashierSplitContainer1.Panel1
            // 
            this.CashierSplitContainer1.Panel1.Controls.Add(this.CashierSplitContainer2);
            this.CashierSplitContainer1.Panel1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // CashierSplitContainer1.Panel2
            // 
            this.CashierSplitContainer1.Panel2.Controls.Add(this.CashierButton_ShowReceipts);
            this.CashierSplitContainer1.Panel2.Controls.Add(this.CashierCheckBox_ShowAllProducts);
            this.CashierSplitContainer1.Panel2.Controls.Add(this.CashierTextBox_ReturnQuantity);
            this.CashierSplitContainer1.Panel2.Controls.Add(this.CashierLabel_ReturnQuantity);
            this.CashierSplitContainer1.Panel2.Controls.Add(this.CashierTextBox_ReturnProduct);
            this.CashierSplitContainer1.Panel2.Controls.Add(this.CashierLabel_ReturnProduct);
            this.CashierSplitContainer1.Panel2.Controls.Add(this.CashierTextBox_ReturnReceipt);
            this.CashierSplitContainer1.Panel2.Controls.Add(this.CashierLabel_ReturnReceipt);
            this.CashierSplitContainer1.Panel2.Controls.Add(this.CashierCheckBox_PrintReceipts);
            this.CashierSplitContainer1.Panel2.Controls.Add(this.CashierButton_ReturnItems);
            this.CashierSplitContainer1.Panel2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierSplitContainer1.Size = new System.Drawing.Size(863, 817);
            this.CashierSplitContainer1.SplitterDistance = 718;
            this.CashierSplitContainer1.TabIndex = 0;
            this.CashierSplitContainer1.TabStop = false;
            // 
            // CashierSplitContainer2
            // 
            this.CashierSplitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CashierSplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.CashierSplitContainer2.IsSplitterFixed = true;
            this.CashierSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.CashierSplitContainer2.Name = "CashierSplitContainer2";
            this.CashierSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // CashierSplitContainer2.Panel1
            // 
            this.CashierSplitContainer2.Panel1.Controls.Add(this.CashierTextBox_Search);
            this.CashierSplitContainer2.Panel1.Controls.Add(this.CashierLabel_Search);
            // 
            // CashierSplitContainer2.Panel2
            // 
            this.CashierSplitContainer2.Panel2.Controls.Add(this.CashierListView1);
            this.CashierSplitContainer2.Size = new System.Drawing.Size(857, 713);
            this.CashierSplitContainer2.SplitterDistance = 54;
            this.CashierSplitContainer2.TabIndex = 2;
            this.CashierSplitContainer2.TabStop = false;
            // 
            // CashierTextBox_Search
            // 
            this.CashierTextBox_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CashierTextBox_Search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CashierTextBox_Search.Font = new System.Drawing.Font("Verdana", 10F);
            this.CashierTextBox_Search.Location = new System.Drawing.Point(122, 9);
            this.CashierTextBox_Search.Name = "CashierTextBox_Search";
            this.CashierTextBox_Search.Size = new System.Drawing.Size(732, 32);
            this.CashierTextBox_Search.TabIndex = 1;
            this.CashierTextBox_Search.TextChanged += new System.EventHandler(this.CashierSearchTextBox_TextChanged);
            // 
            // CashierLabel_Search
            // 
            this.CashierLabel_Search.AutoSize = true;
            this.CashierLabel_Search.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierLabel_Search.Location = new System.Drawing.Point(3, 4);
            this.CashierLabel_Search.Name = "CashierLabel_Search";
            this.CashierLabel_Search.Size = new System.Drawing.Size(113, 34);
            this.CashierLabel_Search.TabIndex = 0;
            this.CashierLabel_Search.Text = "Search";
            // 
            // CashierListView1
            // 
            this.CashierListView1.BackColor = System.Drawing.SystemColors.Window;
            this.CashierListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CashierListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CashierListViewColumnHeader_ProductCode,
            this.CashierListViewColumnHeader_Title,
            this.CashierListViewColumnHeader_ProductType,
            this.CashierListViewColumnHeader_Price,
            this.CashierListViewColumnHeader_Qty});
            this.CashierListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CashierListView1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierListView1.FullRowSelect = true;
            this.CashierListView1.HideSelection = false;
            this.CashierListView1.Location = new System.Drawing.Point(0, 0);
            this.CashierListView1.MultiSelect = false;
            this.CashierListView1.Name = "CashierListView1";
            this.CashierListView1.Size = new System.Drawing.Size(857, 655);
            this.CashierListView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.CashierListView1.TabIndex = 2;
            this.CashierListView1.UseCompatibleStateImageBehavior = false;
            this.CashierListView1.View = System.Windows.Forms.View.Details;
            this.CashierListView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortListViewOnColumnClick);
            this.CashierListView1.DoubleClick += new System.EventHandler(this.CashierStockListView_DoubleClick);
            // 
            // CashierListViewColumnHeader_ProductCode
            // 
            this.CashierListViewColumnHeader_ProductCode.Text = "Product code";
            this.CashierListViewColumnHeader_ProductCode.Width = 131;
            // 
            // CashierListViewColumnHeader_Title
            // 
            this.CashierListViewColumnHeader_Title.Text = "Title";
            this.CashierListViewColumnHeader_Title.Width = 373;
            // 
            // CashierListViewColumnHeader_ProductType
            // 
            this.CashierListViewColumnHeader_ProductType.Text = "Type";
            this.CashierListViewColumnHeader_ProductType.Width = 120;
            // 
            // CashierListViewColumnHeader_Price
            // 
            this.CashierListViewColumnHeader_Price.Text = "Price";
            this.CashierListViewColumnHeader_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CashierListViewColumnHeader_Price.Width = 80;
            // 
            // CashierListViewColumnHeader_Qty
            // 
            this.CashierListViewColumnHeader_Qty.Text = "Quantity";
            this.CashierListViewColumnHeader_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CashierListViewColumnHeader_Qty.Width = 114;
            // 
            // CashierButton_ShowReceipts
            // 
            this.CashierButton_ShowReceipts.Location = new System.Drawing.Point(587, 64);
            this.CashierButton_ShowReceipts.Name = "CashierButton_ShowReceipts";
            this.CashierButton_ShowReceipts.Size = new System.Drawing.Size(86, 28);
            this.CashierButton_ShowReceipts.TabIndex = 0;
            this.CashierButton_ShowReceipts.TabStop = false;
            this.CashierButton_ShowReceipts.Text = "Receipts";
            this.CashierButton_ShowReceipts.UseVisualStyleBackColor = true;
            this.CashierButton_ShowReceipts.Click += new System.EventHandler(this.ShowReceiptsButton_Click);
            // 
            // CashierCheckBox_ShowAllProducts
            // 
            this.CashierCheckBox_ShowAllProducts.AutoSize = true;
            this.CashierCheckBox_ShowAllProducts.Location = new System.Drawing.Point(679, 5);
            this.CashierCheckBox_ShowAllProducts.Name = "CashierCheckBox_ShowAllProducts";
            this.CashierCheckBox_ShowAllProducts.Size = new System.Drawing.Size(179, 22);
            this.CashierCheckBox_ShowAllProducts.TabIndex = 5;
            this.CashierCheckBox_ShowAllProducts.Text = "Show all products";
            this.CashierCheckBox_ShowAllProducts.UseVisualStyleBackColor = true;
            this.CashierCheckBox_ShowAllProducts.CheckedChanged += new System.EventHandler(this.CashierShowAllProductsCheckBox_CheckedChanged);
            // 
            // CashierTextBox_ReturnQuantity
            // 
            this.CashierTextBox_ReturnQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CashierTextBox_ReturnQuantity.Location = new System.Drawing.Point(425, 29);
            this.CashierTextBox_ReturnQuantity.Name = "CashierTextBox_ReturnQuantity";
            this.CashierTextBox_ReturnQuantity.Size = new System.Drawing.Size(138, 27);
            this.CashierTextBox_ReturnQuantity.TabIndex = 9;
            // 
            // CashierLabel_ReturnQuantity
            // 
            this.CashierLabel_ReturnQuantity.AutoSize = true;
            this.CashierLabel_ReturnQuantity.Location = new System.Drawing.Point(425, 5);
            this.CashierLabel_ReturnQuantity.Name = "CashierLabel_ReturnQuantity";
            this.CashierLabel_ReturnQuantity.Size = new System.Drawing.Size(79, 18);
            this.CashierLabel_ReturnQuantity.TabIndex = 6;
            this.CashierLabel_ReturnQuantity.Text = "Quantity";
            // 
            // CashierTextBox_ReturnProduct
            // 
            this.CashierTextBox_ReturnProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CashierTextBox_ReturnProduct.Location = new System.Drawing.Point(281, 29);
            this.CashierTextBox_ReturnProduct.Name = "CashierTextBox_ReturnProduct";
            this.CashierTextBox_ReturnProduct.Size = new System.Drawing.Size(138, 27);
            this.CashierTextBox_ReturnProduct.TabIndex = 8;
            // 
            // CashierLabel_ReturnProduct
            // 
            this.CashierLabel_ReturnProduct.AutoSize = true;
            this.CashierLabel_ReturnProduct.Location = new System.Drawing.Point(281, 5);
            this.CashierLabel_ReturnProduct.Name = "CashierLabel_ReturnProduct";
            this.CashierLabel_ReturnProduct.Size = new System.Drawing.Size(136, 18);
            this.CashierLabel_ReturnProduct.TabIndex = 4;
            this.CashierLabel_ReturnProduct.Text = "Product number";
            // 
            // CashierTextBox_ReturnReceipt
            // 
            this.CashierTextBox_ReturnReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CashierTextBox_ReturnReceipt.Location = new System.Drawing.Point(137, 29);
            this.CashierTextBox_ReturnReceipt.Name = "CashierTextBox_ReturnReceipt";
            this.CashierTextBox_ReturnReceipt.Size = new System.Drawing.Size(138, 27);
            this.CashierTextBox_ReturnReceipt.TabIndex = 7;
            // 
            // CashierLabel_ReturnReceipt
            // 
            this.CashierLabel_ReturnReceipt.AutoSize = true;
            this.CashierLabel_ReturnReceipt.Location = new System.Drawing.Point(137, 5);
            this.CashierLabel_ReturnReceipt.Name = "CashierLabel_ReturnReceipt";
            this.CashierLabel_ReturnReceipt.Size = new System.Drawing.Size(136, 18);
            this.CashierLabel_ReturnReceipt.TabIndex = 2;
            this.CashierLabel_ReturnReceipt.Text = "Receipt number";
            // 
            // CashierCheckBox_PrintReceipts
            // 
            this.CashierCheckBox_PrintReceipts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CashierCheckBox_PrintReceipts.AutoSize = true;
            this.CashierCheckBox_PrintReceipts.Location = new System.Drawing.Point(679, 69);
            this.CashierCheckBox_PrintReceipts.Name = "CashierCheckBox_PrintReceipts";
            this.CashierCheckBox_PrintReceipts.Size = new System.Drawing.Size(143, 22);
            this.CashierCheckBox_PrintReceipts.TabIndex = 6;
            this.CashierCheckBox_PrintReceipts.Text = "Print receipts";
            this.CashierCheckBox_PrintReceipts.UseVisualStyleBackColor = true;
            // 
            // CashierButton_ReturnItems
            // 
            this.CashierButton_ReturnItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CashierButton_ReturnItems.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.CashierButton_ReturnItems.Location = new System.Drawing.Point(3, 5);
            this.CashierButton_ReturnItems.Name = "CashierButton_ReturnItems";
            this.CashierButton_ReturnItems.Size = new System.Drawing.Size(128, 83);
            this.CashierButton_ReturnItems.TabIndex = 10;
            this.CashierButton_ReturnItems.Text = "Return items";
            this.CashierButton_ReturnItems.UseVisualStyleBackColor = true;
            this.CashierButton_ReturnItems.Click += new System.EventHandler(this.CashierReturnItemsButton_Click);
            // 
            // ShoppingBasketSplitContainer1
            // 
            this.ShoppingBasketSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShoppingBasketSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShoppingBasketSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ShoppingBasketSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.ShoppingBasketSplitContainer1.Name = "ShoppingBasketSplitContainer1";
            this.ShoppingBasketSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ShoppingBasketSplitContainer1.Panel1
            // 
            this.ShoppingBasketSplitContainer1.Panel1.Controls.Add(this.ShoppingBasketSplitContainer2);
            // 
            // ShoppingBasketSplitContainer1.Panel2
            // 
            this.ShoppingBasketSplitContainer1.Panel2.Controls.Add(this.ShoppingBasketButton_ClearBasket);
            this.ShoppingBasketSplitContainer1.Panel2.Controls.Add(this.ShoppingBasketButton_CheckOut);
            this.ShoppingBasketSplitContainer1.Size = new System.Drawing.Size(769, 817);
            this.ShoppingBasketSplitContainer1.SplitterDistance = 718;
            this.ShoppingBasketSplitContainer1.TabIndex = 0;
            this.ShoppingBasketSplitContainer1.TabStop = false;
            // 
            // ShoppingBasketSplitContainer2
            // 
            this.ShoppingBasketSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShoppingBasketSplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ShoppingBasketSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.ShoppingBasketSplitContainer2.Name = "ShoppingBasketSplitContainer2";
            this.ShoppingBasketSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ShoppingBasketSplitContainer2.Panel1
            // 
            this.ShoppingBasketSplitContainer2.Panel1.Controls.Add(this.CashierShoppingBasketLabel);
            // 
            // ShoppingBasketSplitContainer2.Panel2
            // 
            this.ShoppingBasketSplitContainer2.Panel2.Controls.Add(this.ShoppingBasketTextBox_TotalSum);
            this.ShoppingBasketSplitContainer2.Panel2.Controls.Add(this.ShoppingBasketLabel_TotalSum);
            this.ShoppingBasketSplitContainer2.Panel2.Controls.Add(this.ShoppingBasketListView1);
            this.ShoppingBasketSplitContainer2.Size = new System.Drawing.Size(767, 716);
            this.ShoppingBasketSplitContainer2.SplitterDistance = 53;
            this.ShoppingBasketSplitContainer2.TabIndex = 0;
            this.ShoppingBasketSplitContainer2.TabStop = false;
            // 
            // CashierShoppingBasketLabel
            // 
            this.CashierShoppingBasketLabel.AutoSize = true;
            this.CashierShoppingBasketLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierShoppingBasketLabel.Location = new System.Drawing.Point(3, 4);
            this.CashierShoppingBasketLabel.Name = "CashierShoppingBasketLabel";
            this.CashierShoppingBasketLabel.Size = new System.Drawing.Size(253, 34);
            this.CashierShoppingBasketLabel.TabIndex = 0;
            this.CashierShoppingBasketLabel.Text = "Shopping Basket";
            // 
            // ShoppingBasketTextBox_TotalSum
            // 
            this.ShoppingBasketTextBox_TotalSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShoppingBasketTextBox_TotalSum.BackColor = System.Drawing.Color.White;
            this.ShoppingBasketTextBox_TotalSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ShoppingBasketTextBox_TotalSum.Font = new System.Drawing.Font("Verdana", 14F);
            this.ShoppingBasketTextBox_TotalSum.ForeColor = System.Drawing.Color.Black;
            this.ShoppingBasketTextBox_TotalSum.Location = new System.Drawing.Point(178, 622);
            this.ShoppingBasketTextBox_TotalSum.Name = "ShoppingBasketTextBox_TotalSum";
            this.ShoppingBasketTextBox_TotalSum.ReadOnly = true;
            this.ShoppingBasketTextBox_TotalSum.Size = new System.Drawing.Size(587, 35);
            this.ShoppingBasketTextBox_TotalSum.TabIndex = 3;
            this.ShoppingBasketTextBox_TotalSum.TabStop = false;
            this.ShoppingBasketTextBox_TotalSum.Text = "0";
            this.ShoppingBasketTextBox_TotalSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ShoppingBasketTextBox_TotalSum.WordWrap = false;
            // 
            // ShoppingBasketLabel_TotalSum
            // 
            this.ShoppingBasketLabel_TotalSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShoppingBasketLabel_TotalSum.AutoSize = true;
            this.ShoppingBasketLabel_TotalSum.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShoppingBasketLabel_TotalSum.Location = new System.Drawing.Point(2, 622);
            this.ShoppingBasketLabel_TotalSum.Name = "ShoppingBasketLabel_TotalSum";
            this.ShoppingBasketLabel_TotalSum.Size = new System.Drawing.Size(170, 34);
            this.ShoppingBasketLabel_TotalSum.TabIndex = 0;
            this.ShoppingBasketLabel_TotalSum.Text = "Total Sum:";
            // 
            // ShoppingBasketListView1
            // 
            this.ShoppingBasketListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShoppingBasketListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ShoppingBasketListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ShoppingBasketColumnHeader_ProductCode,
            this.ShoppingBasketColumnHeader_Title,
            this.ShoppingBasketColumnHeader_Price,
            this.ShoppingBasketColumnHeader_Quantity,
            this.ShoppingBasketColumnHeader_TotalSum});
            this.ShoppingBasketListView1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShoppingBasketListView1.FullRowSelect = true;
            this.ShoppingBasketListView1.HideSelection = false;
            this.ShoppingBasketListView1.Location = new System.Drawing.Point(0, 0);
            this.ShoppingBasketListView1.Name = "ShoppingBasketListView1";
            this.ShoppingBasketListView1.Size = new System.Drawing.Size(767, 619);
            this.ShoppingBasketListView1.TabIndex = 3;
            this.ShoppingBasketListView1.UseCompatibleStateImageBehavior = false;
            this.ShoppingBasketListView1.View = System.Windows.Forms.View.Details;
            this.ShoppingBasketListView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortListViewOnColumnClick);
            this.ShoppingBasketListView1.DoubleClick += new System.EventHandler(this.ShoppingBasketListView_DoubleClick);
            // 
            // ShoppingBasketColumnHeader_ProductCode
            // 
            this.ShoppingBasketColumnHeader_ProductCode.Text = "ProductCode";
            this.ShoppingBasketColumnHeader_ProductCode.Width = 136;
            // 
            // ShoppingBasketColumnHeader_Title
            // 
            this.ShoppingBasketColumnHeader_Title.Text = "Title";
            this.ShoppingBasketColumnHeader_Title.Width = 220;
            // 
            // ShoppingBasketColumnHeader_Price
            // 
            this.ShoppingBasketColumnHeader_Price.Text = "Price";
            this.ShoppingBasketColumnHeader_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ShoppingBasketColumnHeader_Price.Width = 101;
            // 
            // ShoppingBasketColumnHeader_Quantity
            // 
            this.ShoppingBasketColumnHeader_Quantity.Text = "Quantity";
            this.ShoppingBasketColumnHeader_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ShoppingBasketColumnHeader_Quantity.Width = 130;
            // 
            // ShoppingBasketColumnHeader_TotalSum
            // 
            this.ShoppingBasketColumnHeader_TotalSum.Text = "Sum";
            this.ShoppingBasketColumnHeader_TotalSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ShoppingBasketColumnHeader_TotalSum.Width = 86;
            // 
            // ShoppingBasketButton_ClearBasket
            // 
            this.ShoppingBasketButton_ClearBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShoppingBasketButton_ClearBasket.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.ShoppingBasketButton_ClearBasket.Location = new System.Drawing.Point(3, 5);
            this.ShoppingBasketButton_ClearBasket.Name = "ShoppingBasketButton_ClearBasket";
            this.ShoppingBasketButton_ClearBasket.Size = new System.Drawing.Size(128, 83);
            this.ShoppingBasketButton_ClearBasket.TabIndex = 0;
            this.ShoppingBasketButton_ClearBasket.TabStop = false;
            this.ShoppingBasketButton_ClearBasket.Text = "Clear Basket";
            this.ShoppingBasketButton_ClearBasket.UseVisualStyleBackColor = true;
            this.ShoppingBasketButton_ClearBasket.Click += new System.EventHandler(this.ShoppingBasketClearBasketButton_Click);
            // 
            // ShoppingBasketButton_CheckOut
            // 
            this.ShoppingBasketButton_CheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShoppingBasketButton_CheckOut.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShoppingBasketButton_CheckOut.Location = new System.Drawing.Point(635, 5);
            this.ShoppingBasketButton_CheckOut.Name = "ShoppingBasketButton_CheckOut";
            this.ShoppingBasketButton_CheckOut.Size = new System.Drawing.Size(128, 83);
            this.ShoppingBasketButton_CheckOut.TabIndex = 4;
            this.ShoppingBasketButton_CheckOut.Text = "Check out";
            this.ShoppingBasketButton_CheckOut.UseVisualStyleBackColor = true;
            this.ShoppingBasketButton_CheckOut.Click += new System.EventHandler(this.ShoppingBasketCheckOutButton_Click);
            // 
            // StockTabPage
            // 
            this.StockTabPage.Controls.Add(this.StockSplitContainer1);
            this.StockTabPage.Location = new System.Drawing.Point(4, 38);
            this.StockTabPage.Name = "StockTabPage";
            this.StockTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StockTabPage.Size = new System.Drawing.Size(1642, 823);
            this.StockTabPage.TabIndex = 1;
            this.StockTabPage.Text = "Stock";
            this.StockTabPage.UseVisualStyleBackColor = true;
            // 
            // StockSplitContainer1
            // 
            this.StockSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.StockSplitContainer1.IsSplitterFixed = true;
            this.StockSplitContainer1.Location = new System.Drawing.Point(3, 3);
            this.StockSplitContainer1.Name = "StockSplitContainer1";
            // 
            // StockSplitContainer1.Panel1
            // 
            this.StockSplitContainer1.Panel1.Controls.Add(this.StockCheckBox_ShowAllProducts);
            this.StockSplitContainer1.Panel1.Controls.Add(this.StockButton_AddNewProduct);
            // 
            // StockSplitContainer1.Panel2
            // 
            this.StockSplitContainer1.Panel2.AutoScroll = true;
            this.StockSplitContainer1.Panel2.Controls.Add(this.StockSplitContainer2);
            this.StockSplitContainer1.Size = new System.Drawing.Size(1636, 817);
            this.StockSplitContainer1.SplitterDistance = 136;
            this.StockSplitContainer1.TabIndex = 0;
            this.StockSplitContainer1.TabStop = false;
            // 
            // StockCheckBox_ShowAllProducts
            // 
            this.StockCheckBox_ShowAllProducts.AutoSize = true;
            this.StockCheckBox_ShowAllProducts.Checked = true;
            this.StockCheckBox_ShowAllProducts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StockCheckBox_ShowAllProducts.Font = new System.Drawing.Font("Verdana", 8F);
            this.StockCheckBox_ShowAllProducts.Location = new System.Drawing.Point(4, 771);
            this.StockCheckBox_ShowAllProducts.Name = "StockCheckBox_ShowAllProducts";
            this.StockCheckBox_ShowAllProducts.Size = new System.Drawing.Size(109, 40);
            this.StockCheckBox_ShowAllProducts.TabIndex = 0;
            this.StockCheckBox_ShowAllProducts.TabStop = false;
            this.StockCheckBox_ShowAllProducts.Text = "Show all \r\nproducts";
            this.StockCheckBox_ShowAllProducts.UseVisualStyleBackColor = true;
            this.StockCheckBox_ShowAllProducts.CheckedChanged += new System.EventHandler(this.StockShowAllProductsCheckBox_CheckedChanged);
            // 
            // StockButton_AddNewProduct
            // 
            this.StockButton_AddNewProduct.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.StockButton_AddNewProduct.Location = new System.Drawing.Point(3, 3);
            this.StockButton_AddNewProduct.Name = "StockButton_AddNewProduct";
            this.StockButton_AddNewProduct.Size = new System.Drawing.Size(128, 83);
            this.StockButton_AddNewProduct.TabIndex = 0;
            this.StockButton_AddNewProduct.TabStop = false;
            this.StockButton_AddNewProduct.Text = "Add New Product";
            this.StockButton_AddNewProduct.UseVisualStyleBackColor = true;
            this.StockButton_AddNewProduct.Click += new System.EventHandler(this.AddNewProductButton_Click);
            // 
            // StockSplitContainer2
            // 
            this.StockSplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.StockSplitContainer2.Name = "StockSplitContainer2";
            // 
            // StockSplitContainer2.Panel1
            // 
            this.StockSplitContainer2.Panel1.Controls.Add(this.StockSearchPanel1);
            this.StockSplitContainer2.Panel1.Controls.Add(this.StockListView1);
            // 
            // StockSplitContainer2.Panel2
            // 
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockListBox_Type);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockButton_Update);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockCheckBox_Active);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockLabel_FreeText);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockTextBox_FreeText);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockLabel_ReleaseYear);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockTextBox_ReleaseYear);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockLabel_Publisher);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockTextBox_Publisher);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockLabel_Creator);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockTextBox_Creator);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockLabel_Type);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockLabel_Quantity);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockTextBox_Quantity);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockLabel_Price);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockTextBox_Price);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockLabel_Title);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockTextBox_Title);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockLabel_ProductCode);
            this.StockSplitContainer2.Panel2.Controls.Add(this.StockTextBox_ProductCode);
            this.StockSplitContainer2.Size = new System.Drawing.Size(1496, 817);
            this.StockSplitContainer2.SplitterDistance = 857;
            this.StockSplitContainer2.TabIndex = 0;
            this.StockSplitContainer2.TabStop = false;
            // 
            // StockSearchPanel1
            // 
            this.StockSearchPanel1.Controls.Add(this.StockTextBox_Search);
            this.StockSearchPanel1.Controls.Add(this.StockLabel_Search);
            this.StockSearchPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.StockSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.StockSearchPanel1.Name = "StockSearchPanel1";
            this.StockSearchPanel1.Size = new System.Drawing.Size(855, 54);
            this.StockSearchPanel1.TabIndex = 0;
            // 
            // StockTextBox_Search
            // 
            this.StockTextBox_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StockTextBox_Search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockTextBox_Search.Font = new System.Drawing.Font("Verdana", 10F);
            this.StockTextBox_Search.Location = new System.Drawing.Point(122, 8);
            this.StockTextBox_Search.Name = "StockTextBox_Search";
            this.StockTextBox_Search.Size = new System.Drawing.Size(723, 32);
            this.StockTextBox_Search.TabIndex = 1;
            this.StockTextBox_Search.TextChanged += new System.EventHandler(this.StockSearchTextBox_TextChanged);
            // 
            // StockLabel_Search
            // 
            this.StockLabel_Search.AutoSize = true;
            this.StockLabel_Search.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel_Search.Location = new System.Drawing.Point(3, 3);
            this.StockLabel_Search.Name = "StockLabel_Search";
            this.StockLabel_Search.Size = new System.Drawing.Size(113, 34);
            this.StockLabel_Search.TabIndex = 0;
            this.StockLabel_Search.Text = "Search";
            // 
            // StockListView1
            // 
            this.StockListView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StockListView1.BackColor = System.Drawing.SystemColors.Window;
            this.StockListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StockListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StockColumnHeader1_ProductCode,
            this.StockColumnHeader2_Title,
            this.StockColumnHeader3_Type,
            this.StockColumnHeader4_Price,
            this.StockColumnHeader5_Quantity});
            this.StockListView1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockListView1.FullRowSelect = true;
            this.StockListView1.HideSelection = false;
            this.StockListView1.Location = new System.Drawing.Point(0, 57);
            this.StockListView1.MultiSelect = false;
            this.StockListView1.Name = "StockListView1";
            this.StockListView1.Size = new System.Drawing.Size(855, 758);
            this.StockListView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.StockListView1.TabIndex = 2;
            this.StockListView1.UseCompatibleStateImageBehavior = false;
            this.StockListView1.View = System.Windows.Forms.View.Details;
            this.StockListView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortListViewOnColumnClick);
            this.StockListView1.SelectedIndexChanged += new System.EventHandler(this.StockListView1_SelectedIndexChanged);
            // 
            // StockColumnHeader1_ProductCode
            // 
            this.StockColumnHeader1_ProductCode.Text = "Product code";
            this.StockColumnHeader1_ProductCode.Width = 131;
            // 
            // StockColumnHeader2_Title
            // 
            this.StockColumnHeader2_Title.Text = "Title";
            this.StockColumnHeader2_Title.Width = 373;
            // 
            // StockColumnHeader3_Type
            // 
            this.StockColumnHeader3_Type.Text = "Type";
            this.StockColumnHeader3_Type.Width = 120;
            // 
            // StockColumnHeader4_Price
            // 
            this.StockColumnHeader4_Price.Text = "Price";
            this.StockColumnHeader4_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StockColumnHeader4_Price.Width = 80;
            // 
            // StockColumnHeader5_Quantity
            // 
            this.StockColumnHeader5_Quantity.Text = "Quantity";
            this.StockColumnHeader5_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StockColumnHeader5_Quantity.Width = 114;
            // 
            // StockListBox_Type
            // 
            this.StockListBox_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockListBox_Type.DisplayMember = "Product.ProductType";
            this.StockListBox_Type.Font = new System.Drawing.Font("Verdana", 10F);
            this.StockListBox_Type.FormattingEnabled = true;
            this.StockListBox_Type.ItemHeight = 25;
            this.StockListBox_Type.Items.AddRange(new object[] {
            "Book",
            "Movie",
            "Music"});
            this.StockListBox_Type.Location = new System.Drawing.Point(454, 137);
            this.StockListBox_Type.Name = "StockListBox_Type";
            this.StockListBox_Type.Size = new System.Drawing.Size(175, 27);
            this.StockListBox_Type.TabIndex = 8;
            // 
            // StockButton_Update
            // 
            this.StockButton_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StockButton_Update.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.StockButton_Update.Location = new System.Drawing.Point(503, 728);
            this.StockButton_Update.Name = "StockButton_Update";
            this.StockButton_Update.Size = new System.Drawing.Size(128, 83);
            this.StockButton_Update.TabIndex = 13;
            this.StockButton_Update.Text = "Update";
            this.StockButton_Update.UseVisualStyleBackColor = true;
            this.StockButton_Update.Click += new System.EventHandler(this.StockSaveUpdatedProductButton_Click);
            // 
            // StockCheckBox_Active
            // 
            this.StockCheckBox_Active.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StockCheckBox_Active.AutoSize = true;
            this.StockCheckBox_Active.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StockCheckBox_Active.Checked = true;
            this.StockCheckBox_Active.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StockCheckBox_Active.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.StockCheckBox_Active.Location = new System.Drawing.Point(3, 782);
            this.StockCheckBox_Active.Name = "StockCheckBox_Active";
            this.StockCheckBox_Active.Size = new System.Drawing.Size(108, 29);
            this.StockCheckBox_Active.TabIndex = 12;
            this.StockCheckBox_Active.Text = "Active";
            this.StockCheckBox_Active.UseVisualStyleBackColor = true;
            this.StockCheckBox_Active.CheckedChanged += new System.EventHandler(this.IsActiveCheckBox_CheckedChanged);
            // 
            // StockLabel_FreeText
            // 
            this.StockLabel_FreeText.AutoSize = true;
            this.StockLabel_FreeText.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel_FreeText.Location = new System.Drawing.Point(0, 225);
            this.StockLabel_FreeText.Name = "StockLabel_FreeText";
            this.StockLabel_FreeText.Size = new System.Drawing.Size(113, 18);
            this.StockLabel_FreeText.TabIndex = 42;
            this.StockLabel_FreeText.Text = "Information";
            // 
            // StockTextBox_FreeText
            // 
            this.StockTextBox_FreeText.BackColor = System.Drawing.Color.White;
            this.StockTextBox_FreeText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockTextBox_FreeText.Font = new System.Drawing.Font("Verdana", 10F);
            this.StockTextBox_FreeText.Location = new System.Drawing.Point(3, 246);
            this.StockTextBox_FreeText.Multiline = true;
            this.StockTextBox_FreeText.Name = "StockTextBox_FreeText";
            this.StockTextBox_FreeText.Size = new System.Drawing.Size(626, 250);
            this.StockTextBox_FreeText.TabIndex = 11;
            // 
            // StockLabel_ReleaseYear
            // 
            this.StockLabel_ReleaseYear.AutoSize = true;
            this.StockLabel_ReleaseYear.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel_ReleaseYear.Location = new System.Drawing.Point(0, 169);
            this.StockLabel_ReleaseYear.Name = "StockLabel_ReleaseYear";
            this.StockLabel_ReleaseYear.Size = new System.Drawing.Size(125, 18);
            this.StockLabel_ReleaseYear.TabIndex = 40;
            this.StockLabel_ReleaseYear.Text = "Release Year";
            // 
            // StockTextBox_ReleaseYear
            // 
            this.StockTextBox_ReleaseYear.BackColor = System.Drawing.Color.White;
            this.StockTextBox_ReleaseYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockTextBox_ReleaseYear.Font = new System.Drawing.Font("Verdana", 10F);
            this.StockTextBox_ReleaseYear.Location = new System.Drawing.Point(3, 190);
            this.StockTextBox_ReleaseYear.MaxLength = 10;
            this.StockTextBox_ReleaseYear.Name = "StockTextBox_ReleaseYear";
            this.StockTextBox_ReleaseYear.Size = new System.Drawing.Size(127, 32);
            this.StockTextBox_ReleaseYear.TabIndex = 9;
            this.StockTextBox_ReleaseYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // StockLabel_Publisher
            // 
            this.StockLabel_Publisher.AutoSize = true;
            this.StockLabel_Publisher.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel_Publisher.Location = new System.Drawing.Point(0, 113);
            this.StockLabel_Publisher.Name = "StockLabel_Publisher";
            this.StockLabel_Publisher.Size = new System.Drawing.Size(89, 18);
            this.StockLabel_Publisher.TabIndex = 38;
            this.StockLabel_Publisher.Text = "Publisher";
            // 
            // StockTextBox_Publisher
            // 
            this.StockTextBox_Publisher.BackColor = System.Drawing.Color.White;
            this.StockTextBox_Publisher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockTextBox_Publisher.Font = new System.Drawing.Font("Verdana", 10F);
            this.StockTextBox_Publisher.Location = new System.Drawing.Point(3, 134);
            this.StockTextBox_Publisher.Name = "StockTextBox_Publisher";
            this.StockTextBox_Publisher.Size = new System.Drawing.Size(445, 32);
            this.StockTextBox_Publisher.TabIndex = 7;
            // 
            // StockLabel_Creator
            // 
            this.StockLabel_Creator.AutoSize = true;
            this.StockLabel_Creator.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel_Creator.Location = new System.Drawing.Point(133, 169);
            this.StockLabel_Creator.Name = "StockLabel_Creator";
            this.StockLabel_Creator.Size = new System.Drawing.Size(76, 18);
            this.StockLabel_Creator.TabIndex = 36;
            this.StockLabel_Creator.Text = "Creator";
            // 
            // StockTextBox_Creator
            // 
            this.StockTextBox_Creator.BackColor = System.Drawing.Color.White;
            this.StockTextBox_Creator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockTextBox_Creator.Font = new System.Drawing.Font("Verdana", 10F);
            this.StockTextBox_Creator.Location = new System.Drawing.Point(136, 190);
            this.StockTextBox_Creator.Name = "StockTextBox_Creator";
            this.StockTextBox_Creator.Size = new System.Drawing.Size(493, 32);
            this.StockTextBox_Creator.TabIndex = 10;
            // 
            // StockLabel_Type
            // 
            this.StockLabel_Type.AutoSize = true;
            this.StockLabel_Type.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel_Type.Location = new System.Drawing.Point(451, 113);
            this.StockLabel_Type.Name = "StockLabel_Type";
            this.StockLabel_Type.Size = new System.Drawing.Size(52, 18);
            this.StockLabel_Type.TabIndex = 34;
            this.StockLabel_Type.Text = "Type";
            // 
            // StockLabel_Quantity
            // 
            this.StockLabel_Quantity.AutoSize = true;
            this.StockLabel_Quantity.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel_Quantity.Location = new System.Drawing.Point(496, 1);
            this.StockLabel_Quantity.Name = "StockLabel_Quantity";
            this.StockLabel_Quantity.Size = new System.Drawing.Size(83, 18);
            this.StockLabel_Quantity.TabIndex = 32;
            this.StockLabel_Quantity.Text = "Quantity";
            // 
            // StockTextBox_Quantity
            // 
            this.StockTextBox_Quantity.BackColor = System.Drawing.Color.White;
            this.StockTextBox_Quantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockTextBox_Quantity.Font = new System.Drawing.Font("Verdana", 10F);
            this.StockTextBox_Quantity.Location = new System.Drawing.Point(493, 22);
            this.StockTextBox_Quantity.Name = "StockTextBox_Quantity";
            this.StockTextBox_Quantity.Size = new System.Drawing.Size(136, 32);
            this.StockTextBox_Quantity.TabIndex = 5;
            this.StockTextBox_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // StockLabel_Price
            // 
            this.StockLabel_Price.AutoSize = true;
            this.StockLabel_Price.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel_Price.Location = new System.Drawing.Point(309, 1);
            this.StockLabel_Price.Name = "StockLabel_Price";
            this.StockLabel_Price.Size = new System.Drawing.Size(52, 18);
            this.StockLabel_Price.TabIndex = 30;
            this.StockLabel_Price.Text = "Price";
            // 
            // StockTextBox_Price
            // 
            this.StockTextBox_Price.BackColor = System.Drawing.Color.White;
            this.StockTextBox_Price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockTextBox_Price.Font = new System.Drawing.Font("Verdana", 10F);
            this.StockTextBox_Price.Location = new System.Drawing.Point(312, 22);
            this.StockTextBox_Price.Name = "StockTextBox_Price";
            this.StockTextBox_Price.Size = new System.Drawing.Size(175, 32);
            this.StockTextBox_Price.TabIndex = 4;
            this.StockTextBox_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // StockLabel_Title
            // 
            this.StockLabel_Title.AutoSize = true;
            this.StockLabel_Title.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel_Title.Location = new System.Drawing.Point(0, 57);
            this.StockLabel_Title.Name = "StockLabel_Title";
            this.StockLabel_Title.Size = new System.Drawing.Size(46, 18);
            this.StockLabel_Title.TabIndex = 28;
            this.StockLabel_Title.Text = "Title";
            // 
            // StockTextBox_Title
            // 
            this.StockTextBox_Title.BackColor = System.Drawing.Color.White;
            this.StockTextBox_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockTextBox_Title.Font = new System.Drawing.Font("Verdana", 10F);
            this.StockTextBox_Title.Location = new System.Drawing.Point(3, 78);
            this.StockTextBox_Title.Name = "StockTextBox_Title";
            this.StockTextBox_Title.Size = new System.Drawing.Size(626, 32);
            this.StockTextBox_Title.TabIndex = 6;
            // 
            // StockLabel_ProductCode
            // 
            this.StockLabel_ProductCode.AutoSize = true;
            this.StockLabel_ProductCode.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel_ProductCode.Location = new System.Drawing.Point(6, 1);
            this.StockLabel_ProductCode.Name = "StockLabel_ProductCode";
            this.StockLabel_ProductCode.Size = new System.Drawing.Size(124, 18);
            this.StockLabel_ProductCode.TabIndex = 26;
            this.StockLabel_ProductCode.Text = "Product code";
            // 
            // StockTextBox_ProductCode
            // 
            this.StockTextBox_ProductCode.BackColor = System.Drawing.Color.White;
            this.StockTextBox_ProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockTextBox_ProductCode.Enabled = false;
            this.StockTextBox_ProductCode.Font = new System.Drawing.Font("Verdana", 10F);
            this.StockTextBox_ProductCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.StockTextBox_ProductCode.Location = new System.Drawing.Point(3, 22);
            this.StockTextBox_ProductCode.Name = "StockTextBox_ProductCode";
            this.StockTextBox_ProductCode.ReadOnly = true;
            this.StockTextBox_ProductCode.Size = new System.Drawing.Size(303, 32);
            this.StockTextBox_ProductCode.TabIndex = 3;
            this.StockTextBox_ProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StockTextBox_ProductCode.WordWrap = false;
            // 
            // StatisticsTabPage
            // 
            this.StatisticsTabPage.Controls.Add(this.StatSplitContainer1);
            this.StatisticsTabPage.Location = new System.Drawing.Point(4, 38);
            this.StatisticsTabPage.Name = "StatisticsTabPage";
            this.StatisticsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StatisticsTabPage.Size = new System.Drawing.Size(1642, 823);
            this.StatisticsTabPage.TabIndex = 2;
            this.StatisticsTabPage.Text = "Statistics";
            this.StatisticsTabPage.UseVisualStyleBackColor = true;
            // 
            // StatSplitContainer1
            // 
            this.StatSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatSplitContainer1.Location = new System.Drawing.Point(3, 3);
            this.StatSplitContainer1.Name = "StatSplitContainer1";
            // 
            // StatSplitContainer1.Panel1
            // 
            this.StatSplitContainer1.Panel1.Controls.Add(this.StatTableLayoutPanel1_Sales);
            // 
            // StatSplitContainer1.Panel2
            // 
            this.StatSplitContainer1.Panel2.Controls.Add(this.StatSplitContainer2);
            this.StatSplitContainer1.Size = new System.Drawing.Size(1636, 817);
            this.StatSplitContainer1.SplitterDistance = 398;
            this.StatSplitContainer1.TabIndex = 0;
            // 
            // StatTableLayoutPanel1_Sales
            // 
            this.StatTableLayoutPanel1_Sales.ColumnCount = 1;
            this.StatTableLayoutPanel1_Sales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatTableLayoutPanel1_Sales.Controls.Add(this.StatListView_Sales, 0, 1);
            this.StatTableLayoutPanel1_Sales.Controls.Add(this.StatTextBox_Search, 0, 0);
            this.StatTableLayoutPanel1_Sales.Controls.Add(this.StatPanel_Controls, 0, 2);
            this.StatTableLayoutPanel1_Sales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatTableLayoutPanel1_Sales.Location = new System.Drawing.Point(0, 0);
            this.StatTableLayoutPanel1_Sales.Name = "StatTableLayoutPanel1_Sales";
            this.StatTableLayoutPanel1_Sales.RowCount = 3;
            this.StatTableLayoutPanel1_Sales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.StatTableLayoutPanel1_Sales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatTableLayoutPanel1_Sales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.StatTableLayoutPanel1_Sales.Size = new System.Drawing.Size(396, 815);
            this.StatTableLayoutPanel1_Sales.TabIndex = 0;
            // 
            // StatListView_Sales
            // 
            this.StatListView_Sales.BackColor = System.Drawing.SystemColors.Window;
            this.StatListView_Sales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatListView_Sales.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StatColumnHeader1_ProductCode,
            this.StatColumnHeader2_Title});
            this.StatListView_Sales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatListView_Sales.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatListView_Sales.FullRowSelect = true;
            this.StatListView_Sales.HideSelection = false;
            this.StatListView_Sales.Location = new System.Drawing.Point(3, 48);
            this.StatListView_Sales.MultiSelect = false;
            this.StatListView_Sales.Name = "StatListView_Sales";
            this.StatListView_Sales.Size = new System.Drawing.Size(390, 719);
            this.StatListView_Sales.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.StatListView_Sales.TabIndex = 2;
            this.StatListView_Sales.UseCompatibleStateImageBehavior = false;
            this.StatListView_Sales.View = System.Windows.Forms.View.Details;
            this.StatListView_Sales.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortListViewOnColumnClick);
            // 
            // StatColumnHeader1_ProductCode
            // 
            this.StatColumnHeader1_ProductCode.Text = "#";
            this.StatColumnHeader1_ProductCode.Width = 38;
            // 
            // StatColumnHeader2_Title
            // 
            this.StatColumnHeader2_Title.Text = "Title";
            this.StatColumnHeader2_Title.Width = 352;
            // 
            // StatTextBox_Search
            // 
            this.StatTextBox_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatTextBox_Search.Location = new System.Drawing.Point(3, 3);
            this.StatTextBox_Search.Name = "StatTextBox_Search";
            this.StatTextBox_Search.Size = new System.Drawing.Size(390, 37);
            this.StatTextBox_Search.TabIndex = 1;
            this.StatTextBox_Search.TextChanged += new System.EventHandler(this.StatTextBox_Search_TextChanged);
            // 
            // StatPanel_Controls
            // 
            this.StatPanel_Controls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatPanel_Controls.Controls.Add(this.StatCheckBox_ShowAll);
            this.StatPanel_Controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatPanel_Controls.Location = new System.Drawing.Point(3, 773);
            this.StatPanel_Controls.Name = "StatPanel_Controls";
            this.StatPanel_Controls.Size = new System.Drawing.Size(390, 39);
            this.StatPanel_Controls.TabIndex = 3;
            // 
            // StatCheckBox_ShowAll
            // 
            this.StatCheckBox_ShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatCheckBox_ShowAll.AutoSize = true;
            this.StatCheckBox_ShowAll.Font = new System.Drawing.Font("Verdana", 8F);
            this.StatCheckBox_ShowAll.Location = new System.Drawing.Point(3, 5);
            this.StatCheckBox_ShowAll.Name = "StatCheckBox_ShowAll";
            this.StatCheckBox_ShowAll.Size = new System.Drawing.Size(179, 22);
            this.StatCheckBox_ShowAll.TabIndex = 2;
            this.StatCheckBox_ShowAll.Text = "Show all products";
            this.StatCheckBox_ShowAll.UseVisualStyleBackColor = true;
            this.StatCheckBox_ShowAll.CheckedChanged += new System.EventHandler(this.StatCheckBox_ShowAll_CheckedChanged);
            // 
            // StatSplitContainer2
            // 
            this.StatSplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.StatSplitContainer2.Name = "StatSplitContainer2";
            // 
            // StatSplitContainer2.Panel1
            // 
            this.StatSplitContainer2.Panel1.Controls.Add(this.StatTableLayoutPanel2_Sales);
            // 
            // StatSplitContainer2.Panel2
            // 
            this.StatSplitContainer2.Panel2.Controls.Add(this.StatTableLayoutPanel_Charts);
            this.StatSplitContainer2.Size = new System.Drawing.Size(1234, 817);
            this.StatSplitContainer2.SplitterDistance = 348;
            this.StatSplitContainer2.TabIndex = 0;
            // 
            // StatTableLayoutPanel_Charts
            // 
            this.StatTableLayoutPanel_Charts.ColumnCount = 3;
            this.StatTableLayoutPanel_Charts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.StatTableLayoutPanel_Charts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.StatTableLayoutPanel_Charts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.StatTableLayoutPanel_Charts.Controls.Add(this.StatButton_Month, 2, 1);
            this.StatTableLayoutPanel_Charts.Controls.Add(this.StatButton_Year, 1, 1);
            this.StatTableLayoutPanel_Charts.Controls.Add(this.StatPanel_Music, 2, 0);
            this.StatTableLayoutPanel_Charts.Controls.Add(this.StatPanel_Movies, 1, 0);
            this.StatTableLayoutPanel_Charts.Controls.Add(this.StatPanel_Books, 0, 0);
            this.StatTableLayoutPanel_Charts.Controls.Add(this.StatButton_AllTime, 0, 1);
            this.StatTableLayoutPanel_Charts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatTableLayoutPanel_Charts.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.StatTableLayoutPanel_Charts.Location = new System.Drawing.Point(0, 0);
            this.StatTableLayoutPanel_Charts.Name = "StatTableLayoutPanel_Charts";
            this.StatTableLayoutPanel_Charts.RowCount = 2;
            this.StatTableLayoutPanel_Charts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatTableLayoutPanel_Charts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.StatTableLayoutPanel_Charts.Size = new System.Drawing.Size(880, 815);
            this.StatTableLayoutPanel_Charts.TabIndex = 0;
            // 
            // StatButton_Month
            // 
            this.StatButton_Month.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatButton_Month.Location = new System.Drawing.Point(589, 773);
            this.StatButton_Month.Name = "StatButton_Month";
            this.StatButton_Month.Size = new System.Drawing.Size(288, 39);
            this.StatButton_Month.TabIndex = 7;
            this.StatButton_Month.Text = "This Month";
            this.StatButton_Month.UseVisualStyleBackColor = true;
            // 
            // StatButton_Year
            // 
            this.StatButton_Year.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatButton_Year.Location = new System.Drawing.Point(296, 773);
            this.StatButton_Year.Name = "StatButton_Year";
            this.StatButton_Year.Size = new System.Drawing.Size(287, 39);
            this.StatButton_Year.TabIndex = 6;
            this.StatButton_Year.Text = "This Year";
            this.StatButton_Year.UseVisualStyleBackColor = true;
            // 
            // StatPanel_Music
            // 
            this.StatPanel_Music.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatPanel_Music.Controls.Add(this.StatListView_Music);
            this.StatPanel_Music.Controls.Add(this.StatLabel_Music);
            this.StatPanel_Music.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatPanel_Music.Location = new System.Drawing.Point(589, 3);
            this.StatPanel_Music.Name = "StatPanel_Music";
            this.StatPanel_Music.Size = new System.Drawing.Size(288, 764);
            this.StatPanel_Music.TabIndex = 0;
            // 
            // StatLabel_Music
            // 
            this.StatLabel_Music.AutoSize = true;
            this.StatLabel_Music.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatLabel_Music.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatLabel_Music.Location = new System.Drawing.Point(0, 0);
            this.StatLabel_Music.Name = "StatLabel_Music";
            this.StatLabel_Music.Size = new System.Drawing.Size(96, 34);
            this.StatLabel_Music.TabIndex = 0;
            this.StatLabel_Music.Text = "Music";
            // 
            // StatPanel_Movies
            // 
            this.StatPanel_Movies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatPanel_Movies.Controls.Add(this.StatListView_Movies);
            this.StatPanel_Movies.Controls.Add(this.StatLabel_Movies);
            this.StatPanel_Movies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatPanel_Movies.Location = new System.Drawing.Point(296, 3);
            this.StatPanel_Movies.Name = "StatPanel_Movies";
            this.StatPanel_Movies.Size = new System.Drawing.Size(287, 764);
            this.StatPanel_Movies.TabIndex = 0;
            // 
            // StatLabel_Movies
            // 
            this.StatLabel_Movies.AutoSize = true;
            this.StatLabel_Movies.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatLabel_Movies.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatLabel_Movies.Location = new System.Drawing.Point(0, 0);
            this.StatLabel_Movies.Name = "StatLabel_Movies";
            this.StatLabel_Movies.Size = new System.Drawing.Size(114, 34);
            this.StatLabel_Movies.TabIndex = 0;
            this.StatLabel_Movies.Text = "Movies";
            // 
            // StatPanel_Books
            // 
            this.StatPanel_Books.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatPanel_Books.Controls.Add(this.StatListView_Books);
            this.StatPanel_Books.Controls.Add(this.StatLabel_Books);
            this.StatPanel_Books.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatPanel_Books.Location = new System.Drawing.Point(3, 3);
            this.StatPanel_Books.Name = "StatPanel_Books";
            this.StatPanel_Books.Size = new System.Drawing.Size(287, 764);
            this.StatPanel_Books.TabIndex = 0;
            // 
            // StatLabel_Books
            // 
            this.StatLabel_Books.AutoSize = true;
            this.StatLabel_Books.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatLabel_Books.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatLabel_Books.Location = new System.Drawing.Point(0, 0);
            this.StatLabel_Books.Name = "StatLabel_Books";
            this.StatLabel_Books.Size = new System.Drawing.Size(100, 34);
            this.StatLabel_Books.TabIndex = 0;
            this.StatLabel_Books.Text = "Books";
            // 
            // StatButton_AllTime
            // 
            this.StatButton_AllTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatButton_AllTime.Location = new System.Drawing.Point(3, 773);
            this.StatButton_AllTime.Name = "StatButton_AllTime";
            this.StatButton_AllTime.Size = new System.Drawing.Size(287, 39);
            this.StatButton_AllTime.TabIndex = 5;
            this.StatButton_AllTime.Text = "All Time";
            this.StatButton_AllTime.UseVisualStyleBackColor = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(778, 744);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage);
            // 
            // StatListView_Books
            // 
            this.StatListView_Books.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatListView_Books.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatListView_Books.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StatBooksColumnHeader1_Pn,
            this.StatBooksColumnHeader2_Title});
            this.StatListView_Books.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatListView_Books.HideSelection = false;
            this.StatListView_Books.Location = new System.Drawing.Point(0, 37);
            this.StatListView_Books.Name = "StatListView_Books";
            this.StatListView_Books.Size = new System.Drawing.Size(285, 725);
            this.StatListView_Books.TabIndex = 1;
            this.StatListView_Books.UseCompatibleStateImageBehavior = false;
            this.StatListView_Books.View = System.Windows.Forms.View.Details;
            // 
            // StatBooksColumnHeader1_Pn
            // 
            this.StatBooksColumnHeader1_Pn.Text = "#";
            this.StatBooksColumnHeader1_Pn.Width = 38;
            // 
            // StatBooksColumnHeader2_Title
            // 
            this.StatBooksColumnHeader2_Title.Text = "Title";
            this.StatBooksColumnHeader2_Title.Width = 227;
            // 
            // StatListView_Movies
            // 
            this.StatListView_Movies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatListView_Movies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatListView_Movies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StatMoviesColumnHeader1_Pn,
            this.StatMoviesColumnHeader2_Title});
            this.StatListView_Movies.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatListView_Movies.HideSelection = false;
            this.StatListView_Movies.Location = new System.Drawing.Point(0, 37);
            this.StatListView_Movies.Name = "StatListView_Movies";
            this.StatListView_Movies.Size = new System.Drawing.Size(285, 725);
            this.StatListView_Movies.TabIndex = 2;
            this.StatListView_Movies.UseCompatibleStateImageBehavior = false;
            this.StatListView_Movies.View = System.Windows.Forms.View.Details;
            // 
            // StatMoviesColumnHeader1_Pn
            // 
            this.StatMoviesColumnHeader1_Pn.Text = "#";
            this.StatMoviesColumnHeader1_Pn.Width = 38;
            // 
            // StatMoviesColumnHeader2_Title
            // 
            this.StatMoviesColumnHeader2_Title.Text = "Title";
            this.StatMoviesColumnHeader2_Title.Width = 227;
            // 
            // StatListView_Music
            // 
            this.StatListView_Music.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatListView_Music.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatListView_Music.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StatMusicColumnHeader1_Pn,
            this.StatMusicColumnHeader2_Title});
            this.StatListView_Music.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatListView_Music.HideSelection = false;
            this.StatListView_Music.Location = new System.Drawing.Point(0, 37);
            this.StatListView_Music.Name = "StatListView_Music";
            this.StatListView_Music.Size = new System.Drawing.Size(285, 725);
            this.StatListView_Music.TabIndex = 3;
            this.StatListView_Music.UseCompatibleStateImageBehavior = false;
            this.StatListView_Music.View = System.Windows.Forms.View.Details;
            // 
            // StatMusicColumnHeader1_Pn
            // 
            this.StatMusicColumnHeader1_Pn.Text = "#";
            this.StatMusicColumnHeader1_Pn.Width = 38;
            // 
            // StatMusicColumnHeader2_Title
            // 
            this.StatMusicColumnHeader2_Title.Text = "Title";
            this.StatMusicColumnHeader2_Title.Width = 227;
            // 
            // StatDateTimePicker_Year
            // 
            this.StatDateTimePicker_Year.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatDateTimePicker_Year.CalendarFont = new System.Drawing.Font("Verdana", 8F);
            this.StatDateTimePicker_Year.CustomFormat = "yyyy";
            this.StatDateTimePicker_Year.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatDateTimePicker_Year.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StatDateTimePicker_Year.Location = new System.Drawing.Point(3, 5);
            this.StatDateTimePicker_Year.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.StatDateTimePicker_Year.Name = "StatDateTimePicker_Year";
            this.StatDateTimePicker_Year.ShowUpDown = true;
            this.StatDateTimePicker_Year.Size = new System.Drawing.Size(94, 29);
            this.StatDateTimePicker_Year.TabIndex = 3;
            this.StatDateTimePicker_Year.ValueChanged += new System.EventHandler(this.StatDateTimePicker_Year_ValueChanged);
            // 
            // StatTableLayoutPanel2_Sales
            // 
            this.StatTableLayoutPanel2_Sales.ColumnCount = 1;
            this.StatTableLayoutPanel2_Sales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatTableLayoutPanel2_Sales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StatTableLayoutPanel2_Sales.Controls.Add(this.StatPanel_Sales, 0, 0);
            this.StatTableLayoutPanel2_Sales.Controls.Add(this.StatPanel_Dates, 0, 1);
            this.StatTableLayoutPanel2_Sales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatTableLayoutPanel2_Sales.Location = new System.Drawing.Point(0, 0);
            this.StatTableLayoutPanel2_Sales.Name = "StatTableLayoutPanel2_Sales";
            this.StatTableLayoutPanel2_Sales.RowCount = 2;
            this.StatTableLayoutPanel2_Sales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatTableLayoutPanel2_Sales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.StatTableLayoutPanel2_Sales.Size = new System.Drawing.Size(346, 815);
            this.StatTableLayoutPanel2_Sales.TabIndex = 5;
            // 
            // StatPanel_Sales
            // 
            this.StatPanel_Sales.Controls.Add(this.tableLayoutPanel1);
            this.StatPanel_Sales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatPanel_Sales.Location = new System.Drawing.Point(3, 3);
            this.StatPanel_Sales.Name = "StatPanel_Sales";
            this.StatPanel_Sales.Size = new System.Drawing.Size(340, 764);
            this.StatPanel_Sales.TabIndex = 0;
            // 
            // StatPanel_Dates
            // 
            this.StatPanel_Dates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatPanel_Dates.Controls.Add(this.StatDateTimePicker_Year);
            this.StatPanel_Dates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatPanel_Dates.Location = new System.Drawing.Point(3, 773);
            this.StatPanel_Dates.Name = "StatPanel_Dates";
            this.StatPanel_Dates.Size = new System.Drawing.Size(340, 39);
            this.StatPanel_Dates.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_AllTime, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_Quantity, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_GrossAmount, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_January, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_Februari, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_Mars, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_April, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_May, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_June, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_Juli, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_August, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_September, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_October, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_November, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_December, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.StatLabel_Yearly, 0, 14);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 764);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // StatLabel_AllTime
            // 
            this.StatLabel_AllTime.AutoSize = true;
            this.StatLabel_AllTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_AllTime.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_AllTime.Location = new System.Drawing.Point(4, 51);
            this.StatLabel_AllTime.Name = "StatLabel_AllTime";
            this.StatLabel_AllTime.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_AllTime.TabIndex = 0;
            this.StatLabel_AllTime.Text = "All Time";
            this.StatLabel_AllTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_Quantity
            // 
            this.StatLabel_Quantity.AutoSize = true;
            this.StatLabel_Quantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_Quantity.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_Quantity.Location = new System.Drawing.Point(113, 1);
            this.StatLabel_Quantity.Name = "StatLabel_Quantity";
            this.StatLabel_Quantity.Size = new System.Drawing.Size(83, 49);
            this.StatLabel_Quantity.TabIndex = 1;
            this.StatLabel_Quantity.Text = "Quantity";
            this.StatLabel_Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatLabel_GrossAmount
            // 
            this.StatLabel_GrossAmount.AutoSize = true;
            this.StatLabel_GrossAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_GrossAmount.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_GrossAmount.Location = new System.Drawing.Point(203, 1);
            this.StatLabel_GrossAmount.Name = "StatLabel_GrossAmount";
            this.StatLabel_GrossAmount.Size = new System.Drawing.Size(133, 49);
            this.StatLabel_GrossAmount.TabIndex = 2;
            this.StatLabel_GrossAmount.Text = "Gross Amount";
            this.StatLabel_GrossAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatLabel_January
            // 
            this.StatLabel_January.AutoSize = true;
            this.StatLabel_January.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_January.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_January.Location = new System.Drawing.Point(4, 101);
            this.StatLabel_January.Name = "StatLabel_January";
            this.StatLabel_January.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_January.TabIndex = 3;
            this.StatLabel_January.Text = "Jan";
            this.StatLabel_January.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_Februari
            // 
            this.StatLabel_Februari.AutoSize = true;
            this.StatLabel_Februari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_Februari.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_Februari.Location = new System.Drawing.Point(4, 151);
            this.StatLabel_Februari.Name = "StatLabel_Februari";
            this.StatLabel_Februari.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_Februari.TabIndex = 4;
            this.StatLabel_Februari.Text = "Feb";
            this.StatLabel_Februari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_Mars
            // 
            this.StatLabel_Mars.AutoSize = true;
            this.StatLabel_Mars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_Mars.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_Mars.Location = new System.Drawing.Point(4, 201);
            this.StatLabel_Mars.Name = "StatLabel_Mars";
            this.StatLabel_Mars.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_Mars.TabIndex = 5;
            this.StatLabel_Mars.Text = "Mar";
            this.StatLabel_Mars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_April
            // 
            this.StatLabel_April.AutoSize = true;
            this.StatLabel_April.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_April.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_April.Location = new System.Drawing.Point(4, 251);
            this.StatLabel_April.Name = "StatLabel_April";
            this.StatLabel_April.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_April.TabIndex = 6;
            this.StatLabel_April.Text = "Apr";
            this.StatLabel_April.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_May
            // 
            this.StatLabel_May.AutoSize = true;
            this.StatLabel_May.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_May.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_May.Location = new System.Drawing.Point(4, 301);
            this.StatLabel_May.Name = "StatLabel_May";
            this.StatLabel_May.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_May.TabIndex = 7;
            this.StatLabel_May.Text = "May";
            this.StatLabel_May.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_June
            // 
            this.StatLabel_June.AutoSize = true;
            this.StatLabel_June.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_June.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_June.Location = new System.Drawing.Point(4, 351);
            this.StatLabel_June.Name = "StatLabel_June";
            this.StatLabel_June.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_June.TabIndex = 8;
            this.StatLabel_June.Text = "Jun";
            this.StatLabel_June.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_Juli
            // 
            this.StatLabel_Juli.AutoSize = true;
            this.StatLabel_Juli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_Juli.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_Juli.Location = new System.Drawing.Point(4, 401);
            this.StatLabel_Juli.Name = "StatLabel_Juli";
            this.StatLabel_Juli.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_Juli.TabIndex = 9;
            this.StatLabel_Juli.Text = "Jul";
            this.StatLabel_Juli.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_August
            // 
            this.StatLabel_August.AutoSize = true;
            this.StatLabel_August.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_August.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_August.Location = new System.Drawing.Point(4, 451);
            this.StatLabel_August.Name = "StatLabel_August";
            this.StatLabel_August.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_August.TabIndex = 10;
            this.StatLabel_August.Text = "Aug";
            this.StatLabel_August.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_September
            // 
            this.StatLabel_September.AutoSize = true;
            this.StatLabel_September.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_September.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_September.Location = new System.Drawing.Point(4, 501);
            this.StatLabel_September.Name = "StatLabel_September";
            this.StatLabel_September.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_September.TabIndex = 11;
            this.StatLabel_September.Text = "Sep";
            this.StatLabel_September.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_October
            // 
            this.StatLabel_October.AutoSize = true;
            this.StatLabel_October.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_October.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_October.Location = new System.Drawing.Point(4, 551);
            this.StatLabel_October.Name = "StatLabel_October";
            this.StatLabel_October.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_October.TabIndex = 12;
            this.StatLabel_October.Text = "Oct";
            this.StatLabel_October.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_November
            // 
            this.StatLabel_November.AutoSize = true;
            this.StatLabel_November.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_November.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_November.Location = new System.Drawing.Point(4, 601);
            this.StatLabel_November.Name = "StatLabel_November";
            this.StatLabel_November.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_November.TabIndex = 13;
            this.StatLabel_November.Text = "Nov";
            this.StatLabel_November.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_December
            // 
            this.StatLabel_December.AutoSize = true;
            this.StatLabel_December.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_December.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_December.Location = new System.Drawing.Point(4, 651);
            this.StatLabel_December.Name = "StatLabel_December";
            this.StatLabel_December.Size = new System.Drawing.Size(102, 49);
            this.StatLabel_December.TabIndex = 14;
            this.StatLabel_December.Text = "Dec";
            this.StatLabel_December.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_Yearly
            // 
            this.StatLabel_Yearly.AutoSize = true;
            this.StatLabel_Yearly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatLabel_Yearly.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.StatLabel_Yearly.Location = new System.Drawing.Point(4, 701);
            this.StatLabel_Yearly.Name = "StatLabel_Yearly";
            this.StatLabel_Yearly.Size = new System.Drawing.Size(102, 62);
            this.StatLabel_Yearly.TabIndex = 15;
            this.StatLabel_Yearly.Text = "Total 2020";
            this.StatLabel_Yearly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MyMediaStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1650, 865);
            this.Controls.Add(this.MainTabControl);
            this.Name = "MyMediaStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Media Store";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyMediaStore_FormClosing);
            this.Load += new System.EventHandler(this.MyMediaStore_Load);
            this.MainTabControl.ResumeLayout(false);
            this.CashierTabPage.ResumeLayout(false);
            this.CashierTabSplitContainer.Panel1.ResumeLayout(false);
            this.CashierTabSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CashierTabSplitContainer)).EndInit();
            this.CashierTabSplitContainer.ResumeLayout(false);
            this.CashierSplitContainer1.Panel1.ResumeLayout(false);
            this.CashierSplitContainer1.Panel2.ResumeLayout(false);
            this.CashierSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierSplitContainer1)).EndInit();
            this.CashierSplitContainer1.ResumeLayout(false);
            this.CashierSplitContainer2.Panel1.ResumeLayout(false);
            this.CashierSplitContainer2.Panel1.PerformLayout();
            this.CashierSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CashierSplitContainer2)).EndInit();
            this.CashierSplitContainer2.ResumeLayout(false);
            this.ShoppingBasketSplitContainer1.Panel1.ResumeLayout(false);
            this.ShoppingBasketSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShoppingBasketSplitContainer1)).EndInit();
            this.ShoppingBasketSplitContainer1.ResumeLayout(false);
            this.ShoppingBasketSplitContainer2.Panel1.ResumeLayout(false);
            this.ShoppingBasketSplitContainer2.Panel1.PerformLayout();
            this.ShoppingBasketSplitContainer2.Panel2.ResumeLayout(false);
            this.ShoppingBasketSplitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShoppingBasketSplitContainer2)).EndInit();
            this.ShoppingBasketSplitContainer2.ResumeLayout(false);
            this.StockTabPage.ResumeLayout(false);
            this.StockSplitContainer1.Panel1.ResumeLayout(false);
            this.StockSplitContainer1.Panel1.PerformLayout();
            this.StockSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StockSplitContainer1)).EndInit();
            this.StockSplitContainer1.ResumeLayout(false);
            this.StockSplitContainer2.Panel1.ResumeLayout(false);
            this.StockSplitContainer2.Panel2.ResumeLayout(false);
            this.StockSplitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockSplitContainer2)).EndInit();
            this.StockSplitContainer2.ResumeLayout(false);
            this.StockSearchPanel1.ResumeLayout(false);
            this.StockSearchPanel1.PerformLayout();
            this.StatisticsTabPage.ResumeLayout(false);
            this.StatSplitContainer1.Panel1.ResumeLayout(false);
            this.StatSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatSplitContainer1)).EndInit();
            this.StatSplitContainer1.ResumeLayout(false);
            this.StatTableLayoutPanel1_Sales.ResumeLayout(false);
            this.StatTableLayoutPanel1_Sales.PerformLayout();
            this.StatPanel_Controls.ResumeLayout(false);
            this.StatPanel_Controls.PerformLayout();
            this.StatSplitContainer2.Panel1.ResumeLayout(false);
            this.StatSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatSplitContainer2)).EndInit();
            this.StatSplitContainer2.ResumeLayout(false);
            this.StatTableLayoutPanel_Charts.ResumeLayout(false);
            this.StatPanel_Music.ResumeLayout(false);
            this.StatPanel_Music.PerformLayout();
            this.StatPanel_Movies.ResumeLayout(false);
            this.StatPanel_Movies.PerformLayout();
            this.StatPanel_Books.ResumeLayout(false);
            this.StatPanel_Books.PerformLayout();
            this.StatTableLayoutPanel2_Sales.ResumeLayout(false);
            this.StatPanel_Sales.ResumeLayout(false);
            this.StatPanel_Dates.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage CashierTabPage;
        private System.Windows.Forms.TabPage StockTabPage;
        private System.Windows.Forms.TabPage StatisticsTabPage;
        private System.Windows.Forms.SplitContainer CashierSplitContainer1;
        private System.Windows.Forms.Label CashierLabel_Search;
        private System.Windows.Forms.ListView CashierListView1;
        private System.Windows.Forms.ColumnHeader CashierListViewColumnHeader_ProductCode;
        private System.Windows.Forms.ColumnHeader CashierListViewColumnHeader_Title;
        private System.Windows.Forms.ColumnHeader CashierListViewColumnHeader_ProductType;
        private System.Windows.Forms.ColumnHeader CashierListViewColumnHeader_Price;
        private System.Windows.Forms.ColumnHeader CashierListViewColumnHeader_Qty;
        private System.Windows.Forms.SplitContainer CashierSplitContainer2;
        private System.Windows.Forms.CheckBox CashierCheckBox_PrintReceipts;
        private System.Windows.Forms.Button CashierButton_ReturnItems;
        private System.Windows.Forms.TextBox CashierTextBox_Search;
        private System.Windows.Forms.SplitContainer CashierTabSplitContainer;
        private System.Windows.Forms.SplitContainer ShoppingBasketSplitContainer1;
        private System.Windows.Forms.SplitContainer ShoppingBasketSplitContainer2;
        private System.Windows.Forms.Label CashierShoppingBasketLabel;
        private System.Windows.Forms.Label ShoppingBasketLabel_TotalSum;
        private System.Windows.Forms.ListView ShoppingBasketListView1;
        private System.Windows.Forms.ColumnHeader ShoppingBasketColumnHeader_ProductCode;
        private System.Windows.Forms.ColumnHeader ShoppingBasketColumnHeader_Title;
        private System.Windows.Forms.ColumnHeader ShoppingBasketColumnHeader_Price;
        private System.Windows.Forms.ColumnHeader ShoppingBasketColumnHeader_Quantity;
        private System.Windows.Forms.ColumnHeader ShoppingBasketColumnHeader_TotalSum;
        private System.Windows.Forms.Button ShoppingBasketButton_ClearBasket;
        private System.Windows.Forms.Button ShoppingBasketButton_CheckOut;
        private System.Windows.Forms.TextBox ShoppingBasketTextBox_TotalSum;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox CashierTextBox_ReturnQuantity;
        private System.Windows.Forms.Label CashierLabel_ReturnQuantity;
        private System.Windows.Forms.TextBox CashierTextBox_ReturnProduct;
        private System.Windows.Forms.Label CashierLabel_ReturnProduct;
        private System.Windows.Forms.TextBox CashierTextBox_ReturnReceipt;
        private System.Windows.Forms.Label CashierLabel_ReturnReceipt;
        private System.Windows.Forms.CheckBox CashierCheckBox_ShowAllProducts;
        private System.Windows.Forms.Button StockButton_AddNewProduct;
        private System.Windows.Forms.ListView StockListView1;
        private System.Windows.Forms.ColumnHeader StockColumnHeader1_ProductCode;
        private System.Windows.Forms.ColumnHeader StockColumnHeader2_Title;
        private System.Windows.Forms.ColumnHeader StockColumnHeader3_Type;
        private System.Windows.Forms.ColumnHeader StockColumnHeader4_Price;
        private System.Windows.Forms.ColumnHeader StockColumnHeader5_Quantity;
        private System.Windows.Forms.SplitContainer StockSplitContainer1;
        private System.Windows.Forms.SplitContainer StockSplitContainer2;
        private System.Windows.Forms.Button StockButton_Update;
        private System.Windows.Forms.CheckBox StockCheckBox_Active;
        private System.Windows.Forms.Label StockLabel_FreeText;
        private System.Windows.Forms.TextBox StockTextBox_FreeText;
        private System.Windows.Forms.Label StockLabel_ReleaseYear;
        private System.Windows.Forms.TextBox StockTextBox_ReleaseYear;
        private System.Windows.Forms.Label StockLabel_Publisher;
        private System.Windows.Forms.TextBox StockTextBox_Publisher;
        private System.Windows.Forms.Label StockLabel_Creator;
        private System.Windows.Forms.TextBox StockTextBox_Creator;
        private System.Windows.Forms.Label StockLabel_Type;
        private System.Windows.Forms.Label StockLabel_Quantity;
        private System.Windows.Forms.TextBox StockTextBox_Quantity;
        private System.Windows.Forms.Label StockLabel_Price;
        private System.Windows.Forms.TextBox StockTextBox_Price;
        private System.Windows.Forms.Label StockLabel_Title;
        private System.Windows.Forms.TextBox StockTextBox_Title;
        private System.Windows.Forms.Label StockLabel_ProductCode;
        private System.Windows.Forms.TextBox StockTextBox_ProductCode;
        private System.Windows.Forms.CheckBox StockCheckBox_ShowAllProducts;
        private System.Windows.Forms.ListBox StockListBox_Type;
        private System.Windows.Forms.Button CashierButton_ShowReceipts;
        private System.Windows.Forms.Panel StockSearchPanel1;
        private System.Windows.Forms.TextBox StockTextBox_Search;
        private System.Windows.Forms.Label StockLabel_Search;
        private System.Windows.Forms.SplitContainer StatSplitContainer1;
        private System.Windows.Forms.SplitContainer StatSplitContainer2;
        private System.Windows.Forms.TableLayoutPanel StatTableLayoutPanel_Charts;
        private System.Windows.Forms.Panel StatPanel_Music;
        private System.Windows.Forms.Panel StatPanel_Movies;
        private System.Windows.Forms.Panel StatPanel_Books;
        private System.Windows.Forms.Label StatLabel_Music;
        private System.Windows.Forms.Label StatLabel_Movies;
        private System.Windows.Forms.Label StatLabel_Books;
        private System.Windows.Forms.Button StatButton_Month;
        private System.Windows.Forms.Button StatButton_Year;
        private System.Windows.Forms.Button StatButton_AllTime;
        private System.Windows.Forms.TableLayoutPanel StatTableLayoutPanel1_Sales;
        private System.Windows.Forms.ListView StatListView_Sales;
        private System.Windows.Forms.ColumnHeader StatColumnHeader1_ProductCode;
        private System.Windows.Forms.ColumnHeader StatColumnHeader2_Title;
        private System.Windows.Forms.TextBox StatTextBox_Search;
        private System.Windows.Forms.Panel StatPanel_Controls;
        private System.Windows.Forms.CheckBox StatCheckBox_ShowAll;
        private System.Windows.Forms.ListView StatListView_Books;
        private System.Windows.Forms.ColumnHeader StatBooksColumnHeader1_Pn;
        private System.Windows.Forms.DateTimePicker StatDateTimePicker_Year;
        private System.Windows.Forms.ListView StatListView_Music;
        private System.Windows.Forms.ColumnHeader StatMusicColumnHeader1_Pn;
        private System.Windows.Forms.ColumnHeader StatMusicColumnHeader2_Title;
        private System.Windows.Forms.ListView StatListView_Movies;
        private System.Windows.Forms.ColumnHeader StatMoviesColumnHeader1_Pn;
        private System.Windows.Forms.ColumnHeader StatMoviesColumnHeader2_Title;
        private System.Windows.Forms.ColumnHeader StatBooksColumnHeader2_Title;
        private System.Windows.Forms.TableLayoutPanel StatTableLayoutPanel2_Sales;
        private System.Windows.Forms.Panel StatPanel_Sales;
        private System.Windows.Forms.Panel StatPanel_Dates;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label StatLabel_AllTime;
        private System.Windows.Forms.Label StatLabel_Quantity;
        private System.Windows.Forms.Label StatLabel_GrossAmount;
        private System.Windows.Forms.Label StatLabel_January;
        private System.Windows.Forms.Label StatLabel_Februari;
        private System.Windows.Forms.Label StatLabel_Mars;
        private System.Windows.Forms.Label StatLabel_April;
        private System.Windows.Forms.Label StatLabel_May;
        private System.Windows.Forms.Label StatLabel_June;
        private System.Windows.Forms.Label StatLabel_Juli;
        private System.Windows.Forms.Label StatLabel_August;
        private System.Windows.Forms.Label StatLabel_September;
        private System.Windows.Forms.Label StatLabel_October;
        private System.Windows.Forms.Label StatLabel_November;
        private System.Windows.Forms.Label StatLabel_December;
        private System.Windows.Forms.Label StatLabel_Yearly;
    }
}

