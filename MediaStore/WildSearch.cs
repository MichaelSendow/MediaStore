using System.Collections.Generic;
using System.Globalization;

namespace MediaStore
{
    public class WildSearch : ISearch
    {
        #region Methods

        public Stock Search(Stock stock, string searchString)
        {
            Stock MatchedStock;
            if (searchString.Length == 0)
            {
                MatchedStock = new Stock(stock);
            }
            else
            {
                MatchedStock = new Stock();

                foreach (KeyValuePair<uint, Product> productValuePair in stock.Products)
                {
                    if (productValuePair.Value.ToString().Replace(";", " ").ToLower(CultureInfo.CurrentCulture).Contains(searchString.ToLower(CultureInfo.CurrentCulture)))
                    {
                        if (MatchedStock.Products.ContainsKey(productValuePair.Key) == false)
                        {
                            MatchedStock.Products.Add(productValuePair);
                        }
                    }
                }
            }

            return MatchedStock;

        }

        #endregion Methods
    }
}