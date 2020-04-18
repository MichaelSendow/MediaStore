using System.Collections.Generic;
using System.Globalization;

namespace MediaStore
{
    /// <summary>
    /// Klass som implementerar ISearch-interfacet. Fritextsöker igenom ett lager.
    /// </summary>
    public class WildSearch : ISearch
    {
        #region Methods

        /// <summary>
        /// Fritextsökning av en Product
        /// </summary>
        /// <param name="stock">Lager som har alla produkter som ska genomsökas.</param>
        /// <param name="searchString">Söksträng som ska matchas mot produkter i lagret.</param>
        /// <returns>Ett nytt lager som bara innehåller matchade produkter.</returns>
        public Stock Search(Stock stock, string searchString)
        {
            Stock MatchedStock;

            //Om söksträngen är tom matchar vi allt.
            if (searchString.Length == 0)
            {
                MatchedStock = new Stock(stock);
            }
            else
            {
                //Annars skapar vi ett tomt lager som vi lägger in de matchade produkterna i.
                MatchedStock = new Stock();
                
                //För varje produkt i orginallagret
                foreach (KeyValuePair<uint, Product> productValuePair in stock.Products)
                {
                    //Om strängrepresentationen av produkten innehåller söksträngen
                    if (productValuePair.Value.ToString().Replace(";", " ").ToLower(CultureInfo.CurrentCulture).Contains(searchString.ToLower(CultureInfo.CurrentCulture)))
                    {
                        //Hängslen
                        if (MatchedStock.Products.ContainsKey(productValuePair.Key) == false)
                        {
                            //Lägger vi till den i det matchade lagret.
                            MatchedStock.Products.Add(productValuePair);
                        }
                    }
                }
            }

            //Skicka tillbaka det matchade lagret.
            return MatchedStock;

        }

        #endregion Methods
    }
}