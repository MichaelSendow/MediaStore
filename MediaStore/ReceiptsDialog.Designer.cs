namespace MediaStore
{
    partial class ReceiptsDialog
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
            this.ReceiptsListView = new System.Windows.Forms.ListView();
            this.Receipt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ReceiptsListView
            // 
            this.ReceiptsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Receipt,
            this.ProductNumber,
            this.Title,
            this.Quantity,
            this.Price});
            this.ReceiptsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReceiptsListView.Font = new System.Drawing.Font("Verdana", 8F);
            this.ReceiptsListView.HideSelection = false;
            this.ReceiptsListView.Location = new System.Drawing.Point(0, 0);
            this.ReceiptsListView.Name = "ReceiptsListView";
            this.ReceiptsListView.Size = new System.Drawing.Size(844, 374);
            this.ReceiptsListView.TabIndex = 0;
            this.ReceiptsListView.UseCompatibleStateImageBehavior = false;
            this.ReceiptsListView.View = System.Windows.Forms.View.Details;
            // 
            // Receipt
            // 
            this.Receipt.Text = "Receipt #";
            this.Receipt.Width = 98;
            // 
            // ProductNumber
            // 
            this.ProductNumber.Text = "Product #";
            this.ProductNumber.Width = 99;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 454;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Qty";
            // 
            // Price
            // 
            this.Price.Text = "Price per unit";
            this.Price.Width = 124;
            // 
            // ReceiptsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 374);
            this.Controls.Add(this.ReceiptsListView);
            this.Name = "ReceiptsDialog";
            this.Text = "Receipts";
            this.Load += new System.EventHandler(this.ReceiptsDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ReceiptsListView;
        private System.Windows.Forms.ColumnHeader Receipt;
        private System.Windows.Forms.ColumnHeader ProductNumber;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Price;
    }
}