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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.CashierTabPage = new System.Windows.Forms.TabPage();
            this.ShoppingBasketPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CashierSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CashierSplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CashierSearchLabel = new System.Windows.Forms.Label();
            this.Stock_ListView = new System.Windows.Forms.ListView();
            this.ColumnHeader_ProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader_ProductType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader_Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader_Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PrintReceiptsCheckBox = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.StockTabPage = new System.Windows.Forms.TabPage();
            this.StatisticsTabPage = new System.Windows.Forms.TabPage();
            this.MainTabControl.SuspendLayout();
            this.CashierTabPage.SuspendLayout();
            this.ShoppingBasketPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierSplitContainer1)).BeginInit();
            this.CashierSplitContainer1.Panel1.SuspendLayout();
            this.CashierSplitContainer1.Panel2.SuspendLayout();
            this.CashierSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierSplitContainer2)).BeginInit();
            this.CashierSplitContainer2.Panel1.SuspendLayout();
            this.CashierSplitContainer2.Panel2.SuspendLayout();
            this.CashierSplitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.CashierTabPage);
            this.MainTabControl.Controls.Add(this.StockTabPage);
            this.MainTabControl.Controls.Add(this.StatisticsTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1463, 968);
            this.MainTabControl.TabIndex = 0;
            // 
            // CashierTabPage
            // 
            this.CashierTabPage.Controls.Add(this.ShoppingBasketPanel);
            this.CashierTabPage.Controls.Add(this.CashierSplitContainer1);
            this.CashierTabPage.Location = new System.Drawing.Point(4, 29);
            this.CashierTabPage.Name = "CashierTabPage";
            this.CashierTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CashierTabPage.Size = new System.Drawing.Size(1455, 935);
            this.CashierTabPage.TabIndex = 0;
            this.CashierTabPage.Text = "Cashier";
            this.CashierTabPage.UseVisualStyleBackColor = true;
            // 
            // ShoppingBasketPanel
            // 
            this.ShoppingBasketPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShoppingBasketPanel.Controls.Add(this.button2);
            this.ShoppingBasketPanel.Controls.Add(this.button1);
            this.ShoppingBasketPanel.Controls.Add(this.label1);
            this.ShoppingBasketPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShoppingBasketPanel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShoppingBasketPanel.Location = new System.Drawing.Point(935, 3);
            this.ShoppingBasketPanel.Name = "ShoppingBasketPanel";
            this.ShoppingBasketPanel.Size = new System.Drawing.Size(517, 929);
            this.ShoppingBasketPanel.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(3, 839);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 83);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "Clear Basket";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(382, 839);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 83);
            this.button1.TabIndex = 1;
            this.button1.Text = "Check out";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shopping Basket";
            // 
            // CashierSplitContainer1
            // 
            this.CashierSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CashierSplitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.CashierSplitContainer1.Location = new System.Drawing.Point(3, 3);
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
            this.CashierSplitContainer1.Panel2.Controls.Add(this.PrintReceiptsCheckBox);
            this.CashierSplitContainer1.Panel2.Controls.Add(this.button3);
            this.CashierSplitContainer1.Panel2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierSplitContainer1.Size = new System.Drawing.Size(929, 929);
            this.CashierSplitContainer1.SplitterDistance = 827;
            this.CashierSplitContainer1.TabIndex = 0;
            // 
            // CashierSplitContainer2
            // 
            this.CashierSplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CashierSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CashierSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.CashierSplitContainer2.Name = "CashierSplitContainer2";
            this.CashierSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // CashierSplitContainer2.Panel1
            // 
            this.CashierSplitContainer2.Panel1.Controls.Add(this.CashierSearchLabel);
            // 
            // CashierSplitContainer2.Panel2
            // 
            this.CashierSplitContainer2.Panel2.Controls.Add(this.Stock_ListView);
            this.CashierSplitContainer2.Size = new System.Drawing.Size(929, 827);
            this.CashierSplitContainer2.SplitterDistance = 55;
            this.CashierSplitContainer2.TabIndex = 2;
            // 
            // CashierSearchLabel
            // 
            this.CashierSearchLabel.AutoSize = true;
            this.CashierSearchLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierSearchLabel.Location = new System.Drawing.Point(3, 4);
            this.CashierSearchLabel.Name = "CashierSearchLabel";
            this.CashierSearchLabel.Size = new System.Drawing.Size(113, 34);
            this.CashierSearchLabel.TabIndex = 0;
            this.CashierSearchLabel.Text = "Search";
            // 
            // Stock_ListView
            // 
            this.Stock_ListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Stock_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader_ProductCode,
            this.ColumnHeader_Title,
            this.ColumnHeader_ProductType,
            this.ColumnHeader_Price,
            this.ColumnHeader_Qty});
            this.Stock_ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Stock_ListView.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stock_ListView.FullRowSelect = true;
            this.Stock_ListView.HideSelection = false;
            this.Stock_ListView.Location = new System.Drawing.Point(0, 0);
            this.Stock_ListView.MultiSelect = false;
            this.Stock_ListView.Name = "Stock_ListView";
            this.Stock_ListView.Size = new System.Drawing.Size(927, 766);
            this.Stock_ListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.Stock_ListView.TabIndex = 1;
            this.Stock_ListView.UseCompatibleStateImageBehavior = false;
            this.Stock_ListView.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader_ProductCode
            // 
            this.ColumnHeader_ProductCode.Text = "Product code";
            this.ColumnHeader_ProductCode.Width = 149;
            // 
            // ColumnHeader_Title
            // 
            this.ColumnHeader_Title.Text = "Title";
            this.ColumnHeader_Title.Width = 380;
            // 
            // ColumnHeader_ProductType
            // 
            this.ColumnHeader_ProductType.Text = "Type";
            this.ColumnHeader_ProductType.Width = 120;
            // 
            // ColumnHeader_Price
            // 
            this.ColumnHeader_Price.Text = "Price";
            this.ColumnHeader_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader_Price.Width = 80;
            // 
            // ColumnHeader_Qty
            // 
            this.ColumnHeader_Qty.Text = "Quantity";
            this.ColumnHeader_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader_Qty.Width = 104;
            // 
            // PrintReceiptsCheckBox
            // 
            this.PrintReceiptsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintReceiptsCheckBox.AutoSize = true;
            this.PrintReceiptsCheckBox.Location = new System.Drawing.Point(781, 69);
            this.PrintReceiptsCheckBox.Name = "PrintReceiptsCheckBox";
            this.PrintReceiptsCheckBox.Size = new System.Drawing.Size(143, 22);
            this.PrintReceiptsCheckBox.TabIndex = 1;
            this.PrintReceiptsCheckBox.Text = "Print receipts";
            this.PrintReceiptsCheckBox.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(3, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 83);
            this.button3.TabIndex = 0;
            this.button3.Text = "Return items";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // StockTabPage
            // 
            this.StockTabPage.Location = new System.Drawing.Point(4, 29);
            this.StockTabPage.Name = "StockTabPage";
            this.StockTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StockTabPage.Size = new System.Drawing.Size(1455, 935);
            this.StockTabPage.TabIndex = 1;
            this.StockTabPage.Text = "Stock";
            this.StockTabPage.UseVisualStyleBackColor = true;
            // 
            // StatisticsTabPage
            // 
            this.StatisticsTabPage.Location = new System.Drawing.Point(4, 29);
            this.StatisticsTabPage.Name = "StatisticsTabPage";
            this.StatisticsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StatisticsTabPage.Size = new System.Drawing.Size(1455, 935);
            this.StatisticsTabPage.TabIndex = 2;
            this.StatisticsTabPage.Text = "Statistics";
            this.StatisticsTabPage.UseVisualStyleBackColor = true;
            // 
            // MyMediaStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 968);
            this.Controls.Add(this.MainTabControl);
            this.Name = "MyMediaStore";
            this.Text = "My Media Store";
            this.MainTabControl.ResumeLayout(false);
            this.CashierTabPage.ResumeLayout(false);
            this.ShoppingBasketPanel.ResumeLayout(false);
            this.ShoppingBasketPanel.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage CashierTabPage;
        private System.Windows.Forms.TabPage StockTabPage;
        private System.Windows.Forms.TabPage StatisticsTabPage;
        private System.Windows.Forms.SplitContainer CashierSplitContainer1;
        private System.Windows.Forms.Panel ShoppingBasketPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CashierSearchLabel;
        private System.Windows.Forms.ListView Stock_ListView;
        private System.Windows.Forms.ColumnHeader ColumnHeader_ProductCode;
        private System.Windows.Forms.ColumnHeader ColumnHeader_Title;
        private System.Windows.Forms.ColumnHeader ColumnHeader_ProductType;
        private System.Windows.Forms.ColumnHeader ColumnHeader_Price;
        private System.Windows.Forms.ColumnHeader ColumnHeader_Qty;
        private System.Windows.Forms.SplitContainer CashierSplitContainer2;
        private System.Windows.Forms.CheckBox PrintReceiptsCheckBox;
        private System.Windows.Forms.Button button3;
    }
}

