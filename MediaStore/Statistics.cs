using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MediaStore
{
    /// <summary>
    /// Statisk klass för att generera statisitk från ett lager och försäljningshistorik
    /// </summary>
    public static class Statistics
    {

        #region Enums

        public enum Mode { AllTime, Year, Month }

        public enum SaleStat
        {
            AllTime = 0,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12,
            Yearly = 13
        }

        #endregion Enums

        #region Methods

        /// <summary>
        /// Beräknar försäljningsstatistik för en produkt i ett lager.
        /// </summary>
        /// <param name="productCode">Varans produktnummer</param>
        /// <param name="dateTime">Vilket år statistiken ska tas fram för</param>
        /// <param name="stock">Lagret varan finns i</param>
        /// <param name="receiptList">Fösäljningshistorik</param>
        /// <returns>Returnerar ett dictionary med statistik över alla perioder innehållandes antal sålda varor och värdet</returns>
        public static Dictionary<SaleStat, KeyValuePair<uint, decimal>> SalesStatistics(uint productCode, DateTime dateTime, Stock stock, List<Receipt> receiptList)
        {
            //Dictionary<SaleStat Period, KeyValuePair<uint qty, decimal grossamount>> pseudo vad jag har tänkt mig att dictionaryt ska representera
            Dictionary<SaleStat, KeyValuePair<uint, decimal>> salesDictionary = new Dictionary<SaleStat, KeyValuePair<uint, decimal>>();
            if (receiptList != null && stock != null)
            {
                //Alla kvitton som matchar produktnummer
                var receiptQuery_AllTime =
                    from rec in receiptList
                    where rec.ProductCode == productCode
                    select rec;

                //Alla kvitton som matchar produktnummer och är från angivet år.
                var receiptQuery_Year =
                    from rec in receiptList
                    where rec.ProductCode == productCode && DateTime.Parse(rec.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat).Year == dateTime.Year
                    select rec;

                //Få ut alla SaleStat enums till en array
                var values = (SaleStat[])Enum.GetValues(typeof(SaleStat));

                foreach (var item in values)
                {
                    //För de Enums som inte är AllTime eller Yearly, hämta försäljningsstatistik för given månad.
                    //och spara i dictionary.
                    if (item != SaleStat.AllTime && item != SaleStat.Yearly)
                        salesDictionary.Add(item, MonthlySales(receiptQuery_Year, item));
                 
                }

                uint qty = 0;
                decimal grossAmout = 0;
                //Addera all volym och räkna fram totalt försäljningsvärde för produkten någonsin
                foreach (var item in receiptQuery_AllTime)
                {
                    qty += item.Quantity;
                    grossAmout += item.Quantity * item.Price;
                }
                salesDictionary.Add(SaleStat.AllTime, new KeyValuePair<uint, decimal>(qty, grossAmout));


                qty = 0;
                grossAmout = 0;
                //Addera all volym och räkna fram totalt försäljningsvärde för produkten för angivet år.
                foreach (var item in receiptQuery_Year)
                {
                    qty += item.Quantity;
                    grossAmout += item.Quantity * item.Price;
                }
                salesDictionary.Add(SaleStat.Yearly, new KeyValuePair<uint, decimal>(qty, grossAmout));

            }

            //skicka tillbaka hela dictionaryt
            return salesDictionary;
        }

        /// <summary>
        /// Metod för att bygga upp en lista av ListViewItems för att visa tio-i-topp information
        /// </summary>
        /// <param name="stock">Varulager</param>
        /// <param name="receiptList">Lista på alla kvitton</param>
        /// <param name="type">Produkttyp</param>
        /// <param name="showOnlyActive">Ska listan enbart visa aktiva instrument</param>
        /// <param name="mode">Vilken typ av list ska produceras: AllTime, för i år, eller för denna månad. (AllTime, Year, Month) </param>
        /// <returns>Tio-I-Top lista av ListViewItem</returns>
        public static List<ListViewItem> Top10(Stock stock, List<Receipt> receiptList, Product.ProductType type, bool showOnlyActive, Mode mode)
        {

            List<ListViewItem> listViewItems = new List<ListViewItem>();

            //Get all receipts for producttype
            if (receiptList != null && stock != null)
            {
                //Alla kvitton för angiven produkttyp, aktiva eller alla produkter och för vilken typ av lista (mode)
                //grupperade per produkt.
                var receiptQuery =
                    from rec in receiptList
                    join prod in stock.Products.Values on rec.ProductCode equals prod.ProductCode
                    where (showOnlyActive ? (prod.Status == Product.ProductStatus.Active && prod.Type == type) : prod.Type == type) &&
                    (mode == Mode.Month ? DateTime.Parse(rec.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat).Month == DateTime.Today.Month :
                    (mode == Mode.Year ? DateTime.Parse(rec.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat).Year == DateTime.Today.Year : DateTime.Parse(rec.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat) >= DateTime.MinValue))
                    group rec by rec.ProductCode into receiptGroup
                    select receiptGroup;


                //Produktnummer, antal
                List<KeyValuePair<uint, uint>> statList = new List<KeyValuePair<uint, uint>>();

                //För varje produkt
                foreach (var receiptGroup in receiptQuery)
                {
                    uint sumqty = 0;
                    uint code = 0;
                    //Gå igenom varje kvitto
                    foreach (var receipt in receiptGroup)
                    {
                        code = receipt.ProductCode;
                        sumqty += receipt.Quantity;
                    }
                    //Addera produkt, totalt antal sålda till listan
                    statList.Add(new KeyValuePair<uint, uint>(code, sumqty));
                    //Sortera listan
                    statList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
                }

                int i = 1;
                //Bygg upp listan av ListViewItems
                //Rank, Produktnummer, Titel, TotalSåldVolym
                foreach (var item in statList)
                {
                    ListViewItem lvi = new ListViewItem(i.ToString(CultureInfo.CurrentCulture));
                    lvi.Name = lvi.Text;
                    lvi.SubItems.Add(item.Key.ToString(CultureInfo.CurrentCulture));
                    lvi.SubItems.Add(stock.GetProduct(item.Key).Title);
                    lvi.SubItems.Add(item.Value.ToString(CultureInfo.CurrentCulture));
                    //Sätt font baserad på Status
                    lvi.Font = stock.GetProduct(item.Key).Status == Product.ProductStatus.Active ? Product.DefaultFont : Product.InactiveFont;
                    //Lägg till i listan över ListViewItems
                    listViewItems.Add(lvi);
                    i++;
                }

            }
            //Skicka upp listan
            return listViewItems;
        }

        /// <summary>
        /// Metod som returnerar en textsträng som visar totalförsäljning och årligförsäljning av hela lagret.
        /// </summary>
        /// <param name="stock">Varulager</param>
        /// <param name="receiptList">Alla enskilda kvitton</param>
        /// <param name="dateTime">Vilket år ska beräknas</param>
        /// <returns>Textsträng: [Totalförsäljning] / [Årligförsäljning]</returns>
        public static string TotalSalesStatistics(Stock stock, List<Receipt> receiptList, DateTime dateTime)
        {
            decimal grossAmout = 0;
            decimal yearGross = 0;
            if (receiptList != null && stock != null)
            {
                foreach (var receipt in receiptList)
                {
                    grossAmout += receipt.Quantity * receipt.Price;

                    if (DateTime.Parse(receipt.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat).Year == dateTime.Year)
                    {
                        yearGross += receipt.Quantity * receipt.Price;
                    }
                }
            }
            //Formatera strängen så den ser bra ut i en label
            return grossAmout.ToString("0.00", CultureInfo.CurrentCulture) + " / " + yearGross.ToString("0.00", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Sammanställer månatlig försäljningsstatistik
        /// </summary>
        /// <param name="receipts">Kvitton för en produkt</param>
        /// <param name="key">Vilken månad som ska sammanställas</param>
        /// <returns>KeyValuePair&lt;uint QTY, decimal GrossAmount&gt;</returns>
        private static KeyValuePair<uint, decimal> MonthlySales(IEnumerable<Receipt> receipts, SaleStat key)
        {
            var query =
                from receipt in receipts
                where DateTime.Parse(receipt.DateOfSale, CultureInfo.CurrentCulture.DateTimeFormat).Month == (int)key
                select receipt;

            uint qty = 0;
            decimal grossAmout = 0;
            foreach (var item in query)
            {
                qty += item.Quantity;
                grossAmout += item.Quantity * item.Price;
            }
            return new KeyValuePair<uint, decimal>(qty, grossAmout);
        }

        #endregion Methods


    }


}