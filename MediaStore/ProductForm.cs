using System;
using System.Globalization;
using System.Windows.Forms;

namespace MediaStore
{
    public partial class ProductForm : Form
    {
        #region Fields

        /// <summary>
        /// Den produkt som visas i formuläret.
        /// </summary>
        private readonly Product FormsProduct;

        /// <summary>
        /// Maxvolym produkten kan ha i vissa lägen.
        /// </summary>
        private readonly uint StockMaxQty;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Vilken funktion formuläret ska fylla
        /// </summary>
        public FormFunction Function { get; set; }

        /// <summary>
        /// Predikat för att visa om funktionen lyckats eller ej
        /// </summary>
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

        /// <summary>
        /// Klasskonstruktor. Skapar formulär i enlighet med vald funktion
        /// </summary>
        /// <param name="product">Vilken produkt som ska visas i formuläret</param>
        /// <param name="formFunction">Vilken funktion formuläret ska anta.</param>
        /// <param name="maxQty">Maxantal av en produkt</param>
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

        /// <summary>
        /// Om formulärfunktionen är NewProduct försöker vi spara produkten till FormsProduct och döljer formuläret. 
        /// Vid annan funktion döljs formuläret.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    MessageBox.Show("Some fields are incorrect. \r\nPrice, Quantity, Title, and Release year are mandatory.", "Incorrect fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                FunctionSucceeded = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Om checkboxen i formuläret ändras sätter vi status på produkten till motsvarande
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FormsProduct.Status = IsActiveCheckBox.Checked == true ? Product.ProductStatus.Active : Product.ProductStatus.InActive;
        }

        /// <summary>
        /// Om close-knappen klickas istället för Function-knappen sätts FunctionSucceeded = false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductCloseButton_Click(object sender, EventArgs e)
        {
            FunctionSucceeded = false;
            this.Hide();
        }

        #endregion EventMethods

        #region Methods

        /// <summary>
        /// Hjälpmetod som läser av kvantitetsväljaren
        /// </summary>
        /// <returns></returns>
        public uint GetNumericSpinBoxValue()
        {
            return (uint)QtyNumericUpDown.Value;
        }

        /// <summary>
        /// Hjälpmetod som initierar formuläret om funktionen är AddToBasket
        /// </summary>
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

        /// <summary>
        /// Hjälpmetod som initierar formuläret om funktionen är NewProduct
        /// </summary>
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
                PriceTextBox.Text = "0";
                QuantityTextBox.ReadOnly = false;
                QuantityTextBox.Text = "0";
                TitleTextBox.ReadOnly = false;
                ReleaseYearTextBox.ReadOnly = false;
                ReleaseYearTextBox.Text = DateTime.Today.ToString("yyyy", CultureInfo.CurrentCulture);
                CreatorTextBox.ReadOnly = false;
                PublisherTextBox.ReadOnly = false;
                FreeTextBox.ReadOnly = false;
                TypeTextBox.Visible = false;
                TypeTextBox.Enabled = false;

                FunctionButton.Text = "Add to Stock";
            }
        }

        /// <summary>
        /// Hjälpmetod som populerer alla kontroller i forumläret utifrån dess produkt
        /// </summary>
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

            IsActiveCheckBox.Checked = FormsProduct.Status == Product.ProductStatus.Active ? true : false;

        }

        /// <summary>
        /// Hjälpmetod som initierar formuläret om funktionen är ShoppingList
        /// </summary>
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

        /// <summary>
        /// Hjälpfunktion som stämmer av att alla kontrollers värden i formuläret är giltigt formaterade
        /// </summary>
        /// <returns>True om alla kontroller är giltigt ifyllda</returns>
        private bool ValidateFields()
        {
            if (
                Product.ProductType.TryParse(TypeListBox.Text, true, out Product.ProductType _) &&
                decimal.TryParse(PriceTextBox.Text, out decimal _) &&
                uint.TryParse(QuantityTextBox.Text, out uint _) &&
                uint.TryParse(ReleaseYearTextBox.Text, out uint _) &&
                TitleTextBox.Text.Contains(Environment.NewLine) == false && TitleTextBox.Text.Contains(";") == false && TitleTextBox.Text.Trim().Length != 0 &&
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