using System;
using System.Collections.Generic;
using System.Globalization;

namespace MediaStore
{
    /// <summary>
    /// Klass som implementerar ISearch-interfacet. Söker mha nyckelord efter att ha splittat upp söksträngen på semikolon
    /// </summary>
    public class SplitSearcher : ISearch
    {
        #region Enums

        public enum ProductField
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

        #endregion Enums

        #region Methods

        /// <summary>
        /// Sökfunktion för att söka i lager
        /// </summary>
        /// <param name="stock">Lagret att genomsöka</param>
        /// <param name="searchString">Sträng att söka efter i lager</param>
        /// <returns>Ett lager som matchar söksträngen</returns>
        public Stock Search(Stock stock, string searchString)
        {
            Stock MatchedStock;

            //Omsträngen är tom så returnerar vi allt.
            if (searchString.Length == 0)
            {
                MatchedStock = new Stock(stock);
            }
            else
            {
                //Annars skapa ett tomt lager
                MatchedStock = new Stock();

                //Dela upp söksträngen i substrings efte semikolon
                var subSearchStrings = searchString.Split(';');

                //Om vi inte har ett jämt antal substrings så kommer vi inte få några träffar och 
                //returnerar det tomma lagret
                if (subSearchStrings.Length % 2 == 0)
                {
                    //skapar upp 2 arrayer
                    //productFields innehåller alla fält
                    //searchTerms innhåller motsvarande sökterm
                    string[] productFields = new string[subSearchStrings.Length / 2];
                    string[] searchTerms = new string[subSearchStrings.Length / 2];

                    //Dela upp substrängarna till respektive array
                    for (int i = 0, a = 0; i < subSearchStrings.Length; i += 2, a++)
                    {
                        productFields[a] = subSearchStrings[i];
                        searchTerms[a] = subSearchStrings[i + 1];
                    }

                    bool isProductFields = true;

                    //Om inte alla termer i productsFields är nyckelord
                    //returneras det tomma lagret. Lite overhead 
                    foreach (string item in productFields)
                    {
                        isProductFields = isProductFields && Enum.TryParse<ProductField>(item, true, out _);
                        if (isProductFields == false)
                            break;
                    }

                    //Alla fält är nyckelord
                    if (isProductFields)
                    {
                        //För alla produkter i lagret
                        foreach (var item in stock.Products.Values)
                        {
                            bool totalMatch = true;

                            //För alla nyckelord i söksträngen
                            for (int i = 0; i < productFields.Length; i++)
                            {
                                //Kolla vad det är för nyckelord och jämför det mot produktens värde.
                                //Om något nyckelords värde inte matchar avbryt matchningen av resten av nyckelorden.
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
                                //Något av nyckelorden matchade inte.
                                if (!totalMatch)
                                {
                                    break;
                                }
                            }
                            //Om alla nyckelord matchat så lägg till produkten i MatchedStock.
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
            //Returnera det matchande lagret.
            return MatchedStock;
        }

        #endregion Methods
    }
}
