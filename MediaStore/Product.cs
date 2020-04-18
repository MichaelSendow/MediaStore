using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


namespace MediaStore
{
    public class Product
    {


        #region Properties

        /// <summary>
        /// Defaultfont för ett listviewitem
        /// </summary>
        public static Font DefaultFont
        {
            get
            {
                return new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
        }

        /// <summary>
        /// Defaultfont för en inaktiv produkt i ett listviewitem
        /// </summary>
        public static Font InactiveFont
        {
            get
            {
                return new Font("Verdana", 8F, FontStyle.Strikeout, GraphicsUnit.Point, ((byte)(0)));
            }
        }

        /// <summary>
        /// Sträng som innehåller författare eller dylikt
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Sträng som innehåller fritext om produkten, t.ex. ISBN nummer.
        /// </summary>
        public string FreeText { get; set; }

        /// <summary>
        /// Priset på produkten
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Produktnummer
        /// </summary>
        public uint ProductCode { get; set; }

        /// <summary>
        /// Sträng som innehåller utgivare.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Antal exemplar av produkten i lager
        /// </summary>
        public uint Quantity { get; set; }

        /// <summary>
        /// Produktens utgivningsår
        /// </summary>
        public uint ReleaseYear { get; set; }

        /// <summary>
        /// Statusen på produkten. T.ex om den är aktiv eller inte.
        /// </summary>
        public ProductStatus Status { get; set; }

        /// <summary>
        /// Produktens titel
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Vilken produktkategori, eller typ, produkten tillhör.
        /// </summary>
        public ProductType Type { get; set; }

        #endregion Properties

        #region Enums

        /// <summary>
        /// Vilka olika statusar en produkt kan ha.
        /// </summary>
        public enum ProductStatus
        {
            Active,
            InActive
        }

        /// <summary>
        /// Vilka olika produkttyper en produkt kan tillhöra
        /// </summary>
        public enum ProductType
        {
            Book,
            Music,
            Movie
        }

        #endregion Enums

        #region Constructors

        /// <summary>
        /// Klass konstruktor, tar in alla enskilda properites
        /// </summary>
        public Product(uint productCode, string title, ProductType type, decimal price, uint quantity = 0, string creator = "", string freeText = "", string publisher = "", uint releaseYear = 0, ProductStatus status = ProductStatus.Active)
        {
            ProductCode = productCode;
            Title = title;
            Type = type;
            Price = price;
            Quantity = quantity;
            Creator = creator;
            Publisher = publisher;
            ReleaseYear = releaseYear;
            FreeText = freeText;
            Status = status;
        }
        /// <summary>
        /// Konstruktor som skapar en ny produkt utifrån en annan produkt.
        /// </summary>
        /// <param name="prod"></param>
        public Product(Product prod)
        {
            if (prod != null)
            {
                ProductCode = prod.ProductCode;
                Title = prod.Title;
                Type = prod.Type;
                Price = prod.Price;
                Quantity = prod.Quantity;
                Creator = prod.Creator;
                Publisher = prod.Publisher;
                ReleaseYear = prod.ReleaseYear;
                FreeText = prod.FreeText;
                Status = prod.Status;
            }
        }

        public Product()
        {
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Skapar en ListViewItem från produkten av ProductCode, Title, Type, Price, Quantity, Status. Sätter font baserat på Status.
        /// </summary>
        /// <returns>Ett ListViewItem baserat på ProductCode, Title, Type, Price, Quantity, Status</returns>
        public ListViewItem GetProductListViewItem()
        {
            ListViewItem listViewItem = new ListViewItem(ProductCode.ToString(CultureInfo.CurrentCulture));
            listViewItem.Name = listViewItem.Text;
            listViewItem.SubItems.Add(Title);
            listViewItem.SubItems.Add(Type.ToString());
            listViewItem.SubItems.Add(Price.ToString("0.00", CultureInfo.CurrentCulture));
            listViewItem.SubItems.Add(Quantity.ToString(CultureInfo.CurrentCulture));
            listViewItem.Font = Status == ProductStatus.Active ? listViewItem.Font = DefaultFont : listViewItem.Font = InactiveFont;

            return listViewItem;
        }

        /// <summary>
        /// Skapar en sträng för kvittoutskrift
        /// </summary>
        /// <returns>Kvittosträngsrepresentationen av produkten</returns>
        public string ReceiptString()
        {
            string receiptString;

            if (Title.Length > 30)
            {
                receiptString = Title.Substring(0, 27).PadRight(30, '.');
            }
            else
            {
                receiptString = Title.PadRight(30);
            }
            receiptString = receiptString.PadRight(34);
            receiptString += Price.ToString("0.00", CultureInfo.CurrentCulture).PadRight(9);
            receiptString = receiptString.PadRight(47);
            receiptString += Quantity.ToString(CultureInfo.CurrentCulture).PadRight(6);
            receiptString = receiptString.PadRight(57);
            receiptString += (Quantity * Price).ToString("0.00", CultureInfo.CurrentCulture).PadLeft(13);

            return receiptString;
        }

        /// <summary>
        /// Skapar en ListViewItem från produkten av ProductCode, Title, Price, Quantity, Status. Sätter font baserat på Status.
        /// </summary>
        /// <returns>Ett ListViewItem baserat på ProductCode, Title, Price, Quantity, Status</returns>
        public ListViewItem ShoppingBasketGetProductListViewItem()
        {
            ListViewItem listViewItem = new ListViewItem(ProductCode.ToString(CultureInfo.CurrentCulture));
            listViewItem.Name = listViewItem.Text;
            listViewItem.SubItems.Add(Title);
            listViewItem.SubItems.Add(Price.ToString("0.00", CultureInfo.CurrentCulture));
            listViewItem.SubItems.Add(Quantity.ToString(CultureInfo.CurrentCulture));
            listViewItem.SubItems.Add((Price * Quantity).ToString(CultureInfo.CurrentCulture));
            listViewItem.Font = Status == ProductStatus.Active ? listViewItem.Font = DefaultFont : listViewItem.Font = InactiveFont;

            return listViewItem;
        }
        /// <summary>
        /// Skapar en ListViewItem från produkten av ProductCode och Title. Sätter font baserat på Status.
        /// </summary>
        /// <returns>Ett ListViewItem baserat på ProductCode och Title,</returns>
        public ListViewItem StatisticsGetProductListViewItem()
        {
            ListViewItem listViewItem = new ListViewItem(ProductCode.ToString(CultureInfo.CurrentCulture));
            listViewItem.Name = listViewItem.Text;
            listViewItem.SubItems.Add(Title);
            listViewItem.Font = Status == ProductStatus.Active ? listViewItem.Font = DefaultFont : listViewItem.Font = InactiveFont;

            return listViewItem;
        }

        /// <summary>
        /// Override av ToString(). Returnerar strängrepresentationen av produkten.
        /// </summary>
        /// <returns>Strängrepresentationen av produkten</returns>
        public override string ToString()
        {

            //ProductCode;Title;ProductType;Price;Quantity;ReleaseYear;Creator;Publisher;FreeText;Status
            string productAsString;
            productAsString = ProductCode.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += Title + ';';
            productAsString += Type.ToString() + ';';
            productAsString += Price.ToString("0.00", CultureInfo.CurrentCulture) + ';';
            productAsString += Quantity.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += ReleaseYear.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += Creator.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += Publisher.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += FreeText.ToString(CultureInfo.CurrentCulture) + ';';
            productAsString += Status.ToString();

            return productAsString;
        }

        /// <summary>
        /// Uppdaterar en produkt med nya värden
        /// </summary>
        /// <param name="title">Ny titel</param>
        /// <param name="type">Ny produkttyp</param>
        /// <param name="price">Nytt pris</param>
        /// <param name="quantity">Ny kvantitet</param>
        /// <param name="creator">Ny skapare</param>
        /// <param name="freeText">Ny fritext</param>
        /// <param name="publisher">Ny utgivare</param>
        /// <param name="releaseYear">Nytt utgivningsår</param>
        /// <param name="status">Ny produktstatus</param>
        public void UpdateProduct(string title, ProductType type, decimal price, uint quantity = 0, string creator = "", string freeText = "", string publisher = "", uint releaseYear = 0, ProductStatus status = ProductStatus.Active)
        {
            Title = title;
            Type = type;
            Price = price;
            Quantity = quantity;
            Creator = creator;
            Publisher = publisher;
            ReleaseYear = releaseYear;
            FreeText = freeText;
            Status = status;
        }

        #endregion Methods
    }
}