using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaStore
{
    public class SplitSearcher : ISearch
    {
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

                var splits = searchString.Split(';');

                foreach (var split in splits)
                {
                    switch ((ProductField)Enum.Parse(typeof(ProductField), split, true))
                    {
                        case ProductField.ProductCode:
                            foreach (KeyValuePair<uint, Product> productValuePair in stock.Products)
                            {
                                if (productValuePair.Value.ToString().Replace(";", "").ToLower(CultureInfo.CurrentCulture).Contains(searchString.ToLower(CultureInfo.CurrentCulture)))
                                {
                                    if (MatchedStock.Products.ContainsKey(productValuePair.Key) == false)
                                    {
                                        MatchedStock.Products.Add(productValuePair);
                                    }
                                }
                            }


                            break;
                        case ProductField.Title:
                            break;
                        case ProductField.Type:
                            break;
                        case ProductField.Price:
                            break;
                        case ProductField.Quantity:
                            break;
                        case ProductField.ReleaseYear:
                            break;
                        case ProductField.Creator:
                            break;
                        case ProductField.Publisher:
                            break;
                        case ProductField.FreeText:
                            break;
                        case ProductField.Status:
                            break;
                        default:
                            break;
                    }
                }

                foreach (KeyValuePair<uint, Product> productValuePair in stock.Products)
                {
                    if (productValuePair.Value.ToString().Replace(";", "").ToLower(CultureInfo.CurrentCulture).Contains(searchString.ToLower(CultureInfo.CurrentCulture)))
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

        enum ProductField
        {
            ProductCode, 
            Title, 
            Type, 
            Price, 
            Quantity, 
            ReleaseYear, 
            Creator, 
            Publisher, 
            FreeText, 
            Status
        }
    }
}
