using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

                var subSearchStrings = searchString.Split(';');

                if (subSearchStrings.Length % 2 == 0)
                {
                    //(ProductField)Enum.Parse(typeof(ProductField), split, true)

                    string[] productFields = new string[subSearchStrings.Length / 2];
                    string[] searchTerms = new string[subSearchStrings.Length / 2];

                    for (int i = 0, a = 0; i < subSearchStrings.Length; i += 2, a++)
                    {
                        productFields[a] = subSearchStrings[i];
                        searchTerms[a] = subSearchStrings[i + 1];
                    }

                    bool isProductFields = true;
                    List<ProductField> listOfFields = new List<ProductField>();
                    foreach (var item in productFields)
                    {
                        isProductFields = isProductFields && Enum.TryParse<ProductField>(item, true, out _);
                        if (isProductFields)
                            listOfFields.Add((ProductField)Enum.Parse(typeof(ProductField), item, true));
                    }

                    if (isProductFields)
                    {





                        foreach (var item in stock.Products.Values)
                        {
                            bool totalMatch = true;

                            for (int i = 0; i < productFields.Length; i++)
                            {
                                switch ((ProductField)Enum.Parse(typeof(ProductField), productFields[i], true))
                                {
                                    case ProductField.ProductCode:
                                        if (uint.TryParse(searchTerms[i], out uint productCode))
                                        {
                                            if (item.ProductCode != productCode)
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        else
                                        {
                                            totalMatch = false;
                                        }
                                        break;
                                    case ProductField.Title:
                                        if (item.Title.ToLower(CultureInfo.CurrentCulture).Contains(searchTerms[i].ToLower(CultureInfo.CurrentCulture)) == false)
                                        {
                                            totalMatch = false;
                                        }
                                        break;
                                    case ProductField.Type:
                                        if (Enum.TryParse<Product.ProductType>(searchTerms[i], true, out Product.ProductType type))
                                        {
                                            if (item.Type != type)
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        else
                                        {
                                            totalMatch = false;
                                        }
                                        break;
                                    case ProductField.Price:
                                        if (searchTerms[i].StartsWith("<"))
                                        {
                                            if (decimal.TryParse(searchTerms[i].Substring(1), out decimal price))
                                            {
                                                if (item.Price > price)
                                                {
                                                    totalMatch = false;
                                                }
                                            }
                                            else
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        else if (searchTerms[i].StartsWith(">"))
                                        {
                                            if (decimal.TryParse(searchTerms[i].Substring(1), out decimal price))
                                            {
                                                if (item.Price < price)
                                                {
                                                    totalMatch = false;
                                                }
                                            }
                                            else
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        else
                                        {
                                            if (decimal.TryParse(searchTerms[i], out decimal price))
                                            {
                                                if (item.Price != price)
                                                {
                                                    totalMatch = false;
                                                }
                                            }
                                            else
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        break;
                                    case ProductField.Quantity:
                                        if (searchTerms[i].StartsWith("<"))
                                        {
                                            if (uint.TryParse(searchTerms[i].Substring(1), out uint Quantity))
                                            {
                                                if (item.Quantity > Quantity)
                                                {
                                                    totalMatch = false;
                                                }
                                            }
                                            else
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        else if (searchTerms[i].StartsWith(">"))
                                        {
                                            if (uint.TryParse(searchTerms[i].Substring(1), out uint Quantity))
                                            {
                                                if (item.Quantity < Quantity)
                                                {
                                                    totalMatch = false;
                                                }
                                            }
                                            else
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        else
                                        {
                                            if (uint.TryParse(searchTerms[i], out uint Quantity))
                                            {
                                                if (item.Quantity != Quantity)
                                                {
                                                    totalMatch = false;
                                                }
                                            }
                                            else
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        break;
                                    case ProductField.ReleaseYear:
                                        if (searchTerms[i].StartsWith("<"))
                                        {
                                            if (uint.TryParse(searchTerms[i].Substring(1), out uint ReleaseYear))
                                            {
                                                if (item.ReleaseYear > ReleaseYear)
                                                {
                                                    totalMatch = false;
                                                }
                                            }
                                            else
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        else if (searchTerms[i].StartsWith(">"))
                                        {
                                            if (uint.TryParse(searchTerms[i].Substring(1), out uint ReleaseYear))
                                            {
                                                if (item.ReleaseYear < ReleaseYear)
                                                {
                                                    totalMatch = false;
                                                }
                                            }
                                            else
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        else
                                        {
                                            if (uint.TryParse(searchTerms[i], out uint ReleaseYear))
                                            {
                                                if (item.ReleaseYear != ReleaseYear)
                                                {
                                                    totalMatch = false;
                                                }
                                            }
                                            else
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        break;
                                    case ProductField.Creator:
                                        if (item.Creator.ToLower(CultureInfo.CurrentCulture).Contains(searchTerms[i].ToLower(CultureInfo.CurrentCulture)) == false)
                                        {
                                            totalMatch = false;
                                        }
                                        break;
                                    case ProductField.Publisher:
                                        if (item.Publisher.ToLower(CultureInfo.CurrentCulture).Contains(searchTerms[i].ToLower(CultureInfo.CurrentCulture)) == false)
                                        {
                                            totalMatch = false;
                                        }
                                        break;
                                    case ProductField.FreeText:
                                        if (item.FreeText.ToLower(CultureInfo.CurrentCulture).Contains(searchTerms[i].ToLower(CultureInfo.CurrentCulture)) == false)
                                        {
                                            totalMatch = false;
                                        }
                                        break;
                                    case ProductField.Status:
                                        if (Enum.TryParse<Product.ProductStatus>(searchTerms[i], true, out Product.ProductStatus status))
                                        {
                                            if (item.Status != status)
                                            {
                                                totalMatch = false;
                                            }
                                        }
                                        else
                                        {
                                            totalMatch = false;
                                        }
                                        break;
                                    default:
                                        totalMatch = false;
                                        break;
                                }
                            }
                            if (totalMatch)
                            {
                                if (MatchedStock.Products.ContainsKey(item.ProductCode) == false)
                                {
                                    MatchedStock.Products.Add(item.ProductCode, new Product(item));
                                }
                            }
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
