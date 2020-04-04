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

        private readonly Product FormsProduct;

        public enum FormFunction
        {
            AddToBasket,
            ShoppingList,
            NewProduct,
            None,
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
                case FormFunction.NewProduct:
                    NewProduct();
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

            IsActiveCheckBox.Enabled = false;
            IsActiveCheckBox.Visible = false;

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

                if (FormsProduct.Quantity == 0 || FormsProduct.Status == Product.ProductStatus.InActive)
                    FunctionButton.Enabled = false;

                IsActiveCheckBox.Enabled = false;
                IsActiveCheckBox.Visible = false;

                QtyNumericLabel.Text = "QTY";
                QtyNumericLabel.Visible = true;

                QtyNumericUpDown.Maximum = FormsProduct.Quantity;
                QtyNumericUpDown.Visible = true;

                FunctionButton.Text = "Add to Basket";
            }
        }

        private void NewProduct()
        {
            if (FormsProduct != null)
            {
                IsActiveCheckBox.Enabled = false;
                IsActiveCheckBox.Visible = false;

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
            this.Hide();
        }

        private void ProductCloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void IsActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsActiveCheckBox.Checked == true)
            {
                FormsProduct.Status = Product.ProductStatus.Active;
            }
            else
            {

            }
            FormsProduct.Status = Product.ProductStatus.InActive;
        }
    }
}
