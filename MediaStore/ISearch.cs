namespace MediaStore
{
    public interface ISearch
    {
        #region Methods

        /// <summary>
        /// Sökfunktion för att söka i lager
        /// </summary>
        /// <param name="stock">Lagret att genomsöka</param>
        /// <param name="searchString">Sträng att söka efter i lager</param>
        /// <returns>Ett lager som matchar söksträngen</returns>
        Stock Search(Stock stock, string searchString);

        #endregion Methods
    }
}