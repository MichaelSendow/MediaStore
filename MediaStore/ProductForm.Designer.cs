using System.Drawing;

namespace MediaStore
{
    partial class ProductForm
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
            this.FunctionButton = new System.Windows.Forms.Button();
            this.CxlButton = new System.Windows.Forms.Button();
            this.ProductCodeTextBox = new System.Windows.Forms.TextBox();
            this.ProductCodeLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.ReleaseYearLabel = new System.Windows.Forms.Label();
            this.ReleaseYearTextBox = new System.Windows.Forms.TextBox();
            this.PublisherLabel = new System.Windows.Forms.Label();
            this.PublisherTextBox = new System.Windows.Forms.TextBox();
            this.CreatorLabel = new System.Windows.Forms.Label();
            this.CreatorTextBox = new System.Windows.Forms.TextBox();
            this.FreeTextLabel = new System.Windows.Forms.Label();
            this.FreeTextBox = new System.Windows.Forms.TextBox();
            this.QtyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.QtyNumericLabel = new System.Windows.Forms.Label();
            this.IsActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.TypeListBox = new System.Windows.Forms.ListBox();
            this.TypeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.QtyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // FunctionButton
            // 
            this.FunctionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionButton.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FunctionButton.Location = new System.Drawing.Point(701, 458);
            this.FunctionButton.MaximumSize = new System.Drawing.Size(156, 75);
            this.FunctionButton.MinimumSize = new System.Drawing.Size(156, 75);
            this.FunctionButton.Name = "FunctionButton";
            this.FunctionButton.Size = new System.Drawing.Size(156, 75);
            this.FunctionButton.TabIndex = 12;
            this.FunctionButton.Text = "Function Button";
            this.FunctionButton.UseVisualStyleBackColor = true;
            this.FunctionButton.Click += new System.EventHandler(this.FunctionButton_Click);
            // 
            // CxlButton
            // 
            this.CxlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CxlButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CxlButton.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.CxlButton.Location = new System.Drawing.Point(12, 458);
            this.CxlButton.MaximumSize = new System.Drawing.Size(156, 75);
            this.CxlButton.MinimumSize = new System.Drawing.Size(156, 75);
            this.CxlButton.Name = "CxlButton";
            this.CxlButton.Size = new System.Drawing.Size(156, 75);
            this.CxlButton.TabIndex = 13;
            this.CxlButton.Text = "Cancel";
            this.CxlButton.UseVisualStyleBackColor = true;
            this.CxlButton.Click += new System.EventHandler(this.ProductCloseButton_Click);
            // 
            // ProductCodeTextBox
            // 
            this.ProductCodeTextBox.BackColor = System.Drawing.Color.White;
            this.ProductCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductCodeTextBox.Enabled = false;
            this.ProductCodeTextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.ProductCodeTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ProductCodeTextBox.Location = new System.Drawing.Point(12, 28);
            this.ProductCodeTextBox.Name = "ProductCodeTextBox";
            this.ProductCodeTextBox.ReadOnly = true;
            this.ProductCodeTextBox.Size = new System.Drawing.Size(303, 32);
            this.ProductCodeTextBox.TabIndex = 1;
            this.ProductCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProductCodeTextBox.WordWrap = false;
            // 
            // ProductCodeLabel
            // 
            this.ProductCodeLabel.AutoSize = true;
            this.ProductCodeLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductCodeLabel.Location = new System.Drawing.Point(12, 9);
            this.ProductCodeLabel.Name = "ProductCodeLabel";
            this.ProductCodeLabel.Size = new System.Drawing.Size(124, 18);
            this.ProductCodeLabel.TabIndex = 0;
            this.ProductCodeLabel.Text = "Product code";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 63);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(46, 18);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Title";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.BackColor = System.Drawing.Color.White;
            this.TitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleTextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.TitleTextBox.Location = new System.Drawing.Point(12, 84);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.ReadOnly = true;
            this.TitleTextBox.Size = new System.Drawing.Size(846, 32);
            this.TitleTextBox.TabIndex = 5;
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceLabel.Location = new System.Drawing.Point(499, 7);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(52, 18);
            this.PriceLabel.TabIndex = 0;
            this.PriceLabel.Text = "Price";
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.BackColor = System.Drawing.Color.White;
            this.PriceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PriceTextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.PriceTextBox.Location = new System.Drawing.Point(502, 28);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.ReadOnly = true;
            this.PriceTextBox.Size = new System.Drawing.Size(175, 32);
            this.PriceTextBox.TabIndex = 3;
            this.PriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityLabel.Location = new System.Drawing.Point(680, 7);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(83, 18);
            this.QuantityLabel.TabIndex = 0;
            this.QuantityLabel.Text = "Quantity";
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.BackColor = System.Drawing.Color.White;
            this.QuantityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuantityTextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.QuantityTextBox.Location = new System.Drawing.Point(683, 28);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.ReadOnly = true;
            this.QuantityTextBox.Size = new System.Drawing.Size(175, 32);
            this.QuantityTextBox.TabIndex = 4;
            this.QuantityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeLabel.Location = new System.Drawing.Point(318, 7);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(52, 18);
            this.TypeLabel.TabIndex = 0;
            this.TypeLabel.Text = "Type";
            // 
            // ReleaseYearLabel
            // 
            this.ReleaseYearLabel.AutoSize = true;
            this.ReleaseYearLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReleaseYearLabel.Location = new System.Drawing.Point(12, 119);
            this.ReleaseYearLabel.Name = "ReleaseYearLabel";
            this.ReleaseYearLabel.Size = new System.Drawing.Size(125, 18);
            this.ReleaseYearLabel.TabIndex = 0;
            this.ReleaseYearLabel.Text = "Release Year";
            // 
            // ReleaseYearTextBox
            // 
            this.ReleaseYearTextBox.BackColor = System.Drawing.Color.White;
            this.ReleaseYearTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReleaseYearTextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.ReleaseYearTextBox.Location = new System.Drawing.Point(12, 140);
            this.ReleaseYearTextBox.MaxLength = 10;
            this.ReleaseYearTextBox.Name = "ReleaseYearTextBox";
            this.ReleaseYearTextBox.ReadOnly = true;
            this.ReleaseYearTextBox.Size = new System.Drawing.Size(127, 32);
            this.ReleaseYearTextBox.TabIndex = 6;
            this.ReleaseYearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PublisherLabel
            // 
            this.PublisherLabel.AutoSize = true;
            this.PublisherLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PublisherLabel.Location = new System.Drawing.Point(463, 119);
            this.PublisherLabel.Name = "PublisherLabel";
            this.PublisherLabel.Size = new System.Drawing.Size(89, 18);
            this.PublisherLabel.TabIndex = 0;
            this.PublisherLabel.Text = "Publisher";
            // 
            // PublisherTextBox
            // 
            this.PublisherTextBox.BackColor = System.Drawing.Color.White;
            this.PublisherTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PublisherTextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.PublisherTextBox.Location = new System.Drawing.Point(463, 140);
            this.PublisherTextBox.Name = "PublisherTextBox";
            this.PublisherTextBox.ReadOnly = true;
            this.PublisherTextBox.Size = new System.Drawing.Size(395, 32);
            this.PublisherTextBox.TabIndex = 8;
            // 
            // CreatorLabel
            // 
            this.CreatorLabel.AutoSize = true;
            this.CreatorLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatorLabel.Location = new System.Drawing.Point(145, 119);
            this.CreatorLabel.Name = "CreatorLabel";
            this.CreatorLabel.Size = new System.Drawing.Size(76, 18);
            this.CreatorLabel.TabIndex = 0;
            this.CreatorLabel.Text = "Creator";
            // 
            // CreatorTextBox
            // 
            this.CreatorTextBox.BackColor = System.Drawing.Color.White;
            this.CreatorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CreatorTextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.CreatorTextBox.Location = new System.Drawing.Point(145, 140);
            this.CreatorTextBox.Name = "CreatorTextBox";
            this.CreatorTextBox.ReadOnly = true;
            this.CreatorTextBox.Size = new System.Drawing.Size(312, 32);
            this.CreatorTextBox.TabIndex = 7;
            // 
            // FreeTextLabel
            // 
            this.FreeTextLabel.AutoSize = true;
            this.FreeTextLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FreeTextLabel.Location = new System.Drawing.Point(12, 175);
            this.FreeTextLabel.Name = "FreeTextLabel";
            this.FreeTextLabel.Size = new System.Drawing.Size(113, 18);
            this.FreeTextLabel.TabIndex = 0;
            this.FreeTextLabel.Text = "Information";
            // 
            // FreeTextBox
            // 
            this.FreeTextBox.BackColor = System.Drawing.Color.White;
            this.FreeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FreeTextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.FreeTextBox.Location = new System.Drawing.Point(12, 196);
            this.FreeTextBox.Multiline = true;
            this.FreeTextBox.Name = "FreeTextBox";
            this.FreeTextBox.ReadOnly = true;
            this.FreeTextBox.Size = new System.Drawing.Size(846, 250);
            this.FreeTextBox.TabIndex = 9;
            // 
            // QtyNumericUpDown
            // 
            this.QtyNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.QtyNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QtyNumericUpDown.Font = new System.Drawing.Font("Verdana", 14F);
            this.QtyNumericUpDown.Location = new System.Drawing.Point(592, 490);
            this.QtyNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.QtyNumericUpDown.Name = "QtyNumericUpDown";
            this.QtyNumericUpDown.Size = new System.Drawing.Size(103, 42);
            this.QtyNumericUpDown.TabIndex = 11;
            this.QtyNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.QtyNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // QtyNumericLabel
            // 
            this.QtyNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.QtyNumericLabel.AutoSize = true;
            this.QtyNumericLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.QtyNumericLabel.Location = new System.Drawing.Point(587, 458);
            this.QtyNumericLabel.Name = "QtyNumericLabel";
            this.QtyNumericLabel.Size = new System.Drawing.Size(108, 25);
            this.QtyNumericLabel.TabIndex = 0;
            this.QtyNumericLabel.Text = "Quantity";
            this.QtyNumericLabel.Visible = false;
            // 
            // IsActiveCheckBox
            // 
            this.IsActiveCheckBox.AutoSize = true;
            this.IsActiveCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IsActiveCheckBox.Checked = true;
            this.IsActiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsActiveCheckBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.IsActiveCheckBox.Location = new System.Drawing.Point(175, 458);
            this.IsActiveCheckBox.Name = "IsActiveCheckBox";
            this.IsActiveCheckBox.Size = new System.Drawing.Size(108, 29);
            this.IsActiveCheckBox.TabIndex = 10;
            this.IsActiveCheckBox.Text = "Active";
            this.IsActiveCheckBox.UseVisualStyleBackColor = true;
            this.IsActiveCheckBox.CheckedChanged += new System.EventHandler(this.IsActiveCheckBox_CheckedChanged);
            // 
            // TypeListBox
            // 
            this.TypeListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TypeListBox.DisplayMember = "Product.ProductType";
            this.TypeListBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeListBox.FormattingEnabled = true;
            this.TypeListBox.ItemHeight = 25;
            this.TypeListBox.Items.AddRange(new object[] {
            "Book",
            "Movie",
            "Music"});
            this.TypeListBox.Location = new System.Drawing.Point(321, 28);
            this.TypeListBox.Name = "TypeListBox";
            this.TypeListBox.Size = new System.Drawing.Size(175, 27);
            this.TypeListBox.TabIndex = 0;
            this.TypeListBox.Visible = false;
            // 
            // TypeTextBox
            // 
            this.TypeTextBox.BackColor = System.Drawing.Color.White;
            this.TypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TypeTextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.TypeTextBox.Location = new System.Drawing.Point(321, 28);
            this.TypeTextBox.Name = "TypeTextBox";
            this.TypeTextBox.ReadOnly = true;
            this.TypeTextBox.Size = new System.Drawing.Size(175, 32);
            this.TypeTextBox.TabIndex = 2;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 544);
            this.Controls.Add(this.TypeTextBox);
            this.Controls.Add(this.TypeListBox);
            this.Controls.Add(this.IsActiveCheckBox);
            this.Controls.Add(this.QtyNumericUpDown);
            this.Controls.Add(this.QtyNumericLabel);
            this.Controls.Add(this.FreeTextLabel);
            this.Controls.Add(this.FreeTextBox);
            this.Controls.Add(this.ReleaseYearLabel);
            this.Controls.Add(this.ReleaseYearTextBox);
            this.Controls.Add(this.PublisherLabel);
            this.Controls.Add(this.PublisherTextBox);
            this.Controls.Add(this.CreatorLabel);
            this.Controls.Add(this.CreatorTextBox);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.QuantityTextBox);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.ProductCodeLabel);
            this.Controls.Add(this.ProductCodeTextBox);
            this.Controls.Add(this.CxlButton);
            this.Controls.Add(this.FunctionButton);
            this.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(891, 600);
            this.MinimumSize = new System.Drawing.Size(891, 600);
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product";
            ((System.ComponentModel.ISupportInitialize)(this.QtyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ProductCodeTextBox;
        private System.Windows.Forms.Label ProductCodeLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label ReleaseYearLabel;
        private System.Windows.Forms.TextBox ReleaseYearTextBox;
        private System.Windows.Forms.Label PublisherLabel;
        private System.Windows.Forms.TextBox PublisherTextBox;
        private System.Windows.Forms.Label CreatorLabel;
        private System.Windows.Forms.TextBox CreatorTextBox;
        private System.Windows.Forms.Label FreeTextLabel;
        private System.Windows.Forms.TextBox FreeTextBox;
        public System.Windows.Forms.Button FunctionButton;
        public System.Windows.Forms.Button CxlButton;
        private System.Windows.Forms.NumericUpDown QtyNumericUpDown;
        private System.Windows.Forms.Label QtyNumericLabel;
        private System.Windows.Forms.CheckBox IsActiveCheckBox;
        private System.Windows.Forms.ListBox TypeListBox;
        private System.Windows.Forms.TextBox TypeTextBox;
    }
}