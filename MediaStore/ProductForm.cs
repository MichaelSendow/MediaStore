using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaStore
{
    public partial class ProductForm : Form
    {
        public FormFunction ProductFormFunction { get; set; }

        private Product FormsProduct;

        public enum FormFunction
        {
            AddToBasket,
            UpdateProduct,
            SubtractFromBasket,
            Close,
            ShoppingList,
            None
        }


        public ProductForm()
        {
            InitializeComponent();
            ProductFormFunction = FormFunction.None;
            FormsProduct = new Product();
        }

        public ProductForm(Product product, FormFunction formFunction)
        {
            InitializeComponent();

            FormsProduct = new Product(product);

            switch (formFunction)
            {
                case FormFunction.AddToBasket:
                    AddToBasketForm();
                    break;
                case FormFunction.UpdateProduct:
                    break;
                case FormFunction.SubtractFromBasket:
                    break;
                case FormFunction.Close:
                    break;
                case FormFunction.None:
                    break;
                case FormFunction.ShoppingList:
                    ShoppingList();
                    break;
                default:
                    break;
            }


            ProductFormFunction = formFunction;
        }

        private void ShoppingList()
        {
            PopulateForm();


            QtyNumericLabel.Text = "New QTY";
            QtyNumericLabel.Visible = true;

            QtyNumericUpDown.Minimum = 0;
            QtyNumericUpDown.Maximum = FormsProduct.Quantity;
            QtyNumericUpDown.Visible = true;

            FunctionButton.Text = "Update Quantity";
        }

        private void AddToBasketForm()
        {
            if (FormsProduct != null)
            {
                PopulateForm();

                if (FormsProduct.Quantity == 0)
                    FunctionButton.Enabled = false;


                QtyNumericLabel.Text = "QTY";
                QtyNumericLabel.Visible = true;

                QtyNumericUpDown.Maximum = FormsProduct.Quantity;
                QtyNumericUpDown.Visible = true;

                FunctionButton.Text = "Add to Basket";
            }
        }
        private void PopulateForm()
        {
            ProductCodeTextBox.Text = FormsProduct.ProductCode.ToString(CultureInfo.CurrentCulture);
            TypeTextBox.Text = FormsProduct.ProductType.ToString();
            PriceTextBox.Text = FormsProduct.Price.ToString(CultureInfo.CurrentCulture);
            QuantityTextBox.Text = FormsProduct.Quantity.ToString(CultureInfo.CurrentCulture);
            TitleTextBox.Text = FormsProduct.Title;
            ReleaseYearTextBox.Text = FormsProduct.ReleaseYear;
            CreatorTextBox.Text = FormsProduct.Creator;
            PublisherTextBox.Text = FormsProduct.Publisher;
            FreeTextBox.Text = FormsProduct.FreeText;
        }

        public uint GetNumericSpinBoxValue()
        {
            if (QtyNumericUpDown.Value > FormsProduct.Quantity)
            {
                return FormsProduct.Quantity;
            }
            else
            {
                return (uint)QtyNumericUpDown.Value;
            }
        }

        private void FunctionButton_Click(object sender, EventArgs e)
        {
            ProductFormFunction = FormFunction.AddToBasket;
            this.Hide();
        }

        private void ProductCloseButton_Click(object sender, EventArgs e)
        {
            ProductFormFunction = FormFunction.Close;
            this.Hide();
        }
    }
}
