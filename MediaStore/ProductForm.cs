using System;
using System.Globalization;
using System.Windows.Forms;

namespace MediaStore
{
    public partial class ProductForm : Form
    {
        #region Fields

        private readonly Product FormsProduct;
        private readonly uint StockMaxQty;

        #endregion Fields

        #region Properties

        public FormFunction Function { get; set; }
        public bool FunctionSucceeded { get; set; }

        #endregion Properties

        #region Enums

        public enum FormFunction
        {
            AddToBasket,
            ShoppingList,
            NewProduct,
            Cancel,
            None
        }

        #endregion Enums

        #region Constructors

        public ProductForm()
        {
            InitializeComponent();
            Function = FormFunction.None;
            FormsProduct = new Product();
            FunctionSucceeded = false;
        }

        public ProductForm(Product product, FormFunction formFunction, uint maxQty = 1000000)
        {
            InitializeComponent();

            StockMaxQty = maxQty;
            Function = formFunction;

            switch (formFunction)
            {
                case FormFunction.AddToBasket:
                    FormsProduct = new Product(product);
                    AddToBasketForm();
                    break;

                case FormFunction.NewProduct:
                    FormsProduct = product;
                    NewProduct();
                    break;

                case FormFunction.ShoppingList:
                    FormsProduct = new Product(product);
                    ShoppingList();
                    break;

                default:
                    break;
            }
        }

        #endregion Constructors

        #region EventMethods

        private void FunctionButton_Click(object sender, EventArgs e)
        {
            if (Function == FormFunction.NewProduct)
            {
                if (ValidateFields())
                {
                    if (IsActiveCheckBox.Checked == true)
                    {
                        FormsProduct.UpdateProduct(TitleTextBox.Text,
                        (Product.ProductType)Enum.Parse(typeof(Product.ProductType), TypeListBox.Text, true),
                        decimal.Parse(PriceTextBox.Text, CultureInfo.CurrentCulture),
                        uint.Parse(QuantityTextBox.Text, CultureInfo.CurrentCulture),
                        CreatorTextBox.Text, FreeTextBox.Text,
                        PublisherTextBox.Text,
                        uint.Parse(ReleaseYearTextBox.Text, CultureInfo.CurrentCulture),
                        Product.ProductStatus.Active);
                        FunctionSucceeded = true;
                        this.Hide();
                    }
                    else
                    {
                        FormsProduct.UpdateProduct(TitleTextBox.Text,
                        (Product.ProductType)Enum.Parse(typeof(Product.ProductType), TypeListBox.Text, true),
                        decimal.Parse(PriceTextBox.Text, CultureInfo.CurrentCulture),
                        uint.Parse(QuantityTextBox.Text, CultureInfo.CurrentCulture),
                        CreatorTextBox.Text, FreeTextBox.Text,
                        PublisherTextBox.Text,
                        uint.Parse(ReleaseYearTextBox.Text, CultureInfo.CurrentCulture),
                        Product.ProductStatus.InActive);
                        FunctionSucceeded = true;
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Some fields are incorrect.", "Incorrect fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                FunctionSucceeded = true;
                this.Hide();
            }
        }

        private void IsActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsActiveCheckBox.Checked == true)
            {
                FormsProduct.Status = Product.ProductStatus.Active;
            }
            else
            {
                FormsProduct.Status = Product.ProductStatus.InActive;
            }
        }

        private void ProductCloseButton_Click(object sender, EventArgs e)
        {
            FunctionSucceeded = false;
            this.Hide();
        }

        #endregion EventMethods

        #region Methods

        public uint GetNumericSpinBoxValue()
        {
            return (uint)QtyNumericUpDown.Value;
        }

        private void AddToBasketForm()
        {
            if (FormsProduct != null)
            {
                PopulateForm();

                if (FormsProduct.Quantity == 0 || FormsProduct.Status == Product.ProductStatus.InActive)
                    FunctionButton.Enabled = false;

                IsActiveCheckBox.Enabled = false;
                IsActiveCheckBox.Visible = false;

                QtyNumericLabel.Text = "QTY";
                QtyNumericLabel.Visible = true;

                QtyNumericUpDown.Maximum = StockMaxQty;
                QtyNumericUpDown.Minimum = 1;
                QtyNumericUpDown.Visible = true;

                FunctionButton.Text = "Add to Basket";
            }
        }

        private void NewProduct()
        {
            if (FormsProduct != null)
            {
                IsActiveCheckBox.Enabled = true;
                IsActiveCheckBox.Visible = true;

                QtyNumericLabel.Visible = false;
                QtyNumericUpDown.Enabled = false;
                QtyNumericUpDown.Visible = false;

                TypeListBox.Enabled = true;
                TypeListBox.Visible = true;
                TypeListBox.SelectedItem = "Book";

                ProductCodeTextBox.Text = FormsProduct.ProductCode.ToString(CultureInfo.CurrentCulture);
                PriceTextBox.ReadOnly = false;
                QuantityTextBox.ReadOnly = false;
                TitleTextBox.ReadOnly = false;
                ReleaseYearTextBox.ReadOnly = false;
                CreatorTextBox.ReadOnly = false;
                PublisherTextBox.ReadOnly = false;
                FreeTextBox.ReadOnly = false;
                TypeTextBox.Visible = false;
                TypeTextBox.Enabled = false;

                FunctionButton.Text = "Add to Stock";
            }
        }

        private void PopulateForm()
        {
            ProductCodeTextBox.Text = FormsProduct.ProductCode.ToString(CultureInfo.CurrentCulture);
            TypeListBox.SelectedItem = FormsProduct.Type.ToString();
            TypeTextBox.Text = FormsProduct.Type.ToString();
            PriceTextBox.Text = FormsProduct.Price.ToString(CultureInfo.CurrentCulture);
            QuantityTextBox.Text = FormsProduct.Quantity.ToString(CultureInfo.CurrentCulture);
            TitleTextBox.Text = FormsProduct.Title;
            ReleaseYearTextBox.Text = FormsProduct.ReleaseYear.ToString(CultureInfo.CurrentCulture);
            CreatorTextBox.Text = FormsProduct.Creator;
            PublisherTextBox.Text = FormsProduct.Publisher;
            FreeTextBox.Text = FormsProduct.FreeText;

            if (FormsProduct.Status != Product.ProductStatus.Active)
            {
                IsActiveCheckBox.Checked = false;
            }
        }

        private void ShoppingList()
        {
            PopulateForm();

            IsActiveCheckBox.Enabled = false;
            IsActiveCheckBox.Visible = false;

            QtyNumericLabel.Text = "New QTY";
            QtyNumericLabel.Visible = true;

            QtyNumericUpDown.Minimum = 0;
            QtyNumericUpDown.Maximum = StockMaxQty + FormsProduct.Quantity;

            QtyNumericUpDown.Visible = true;

            FunctionButton.Text = "Update Quantity";
        }

        private bool ValidateFields()
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