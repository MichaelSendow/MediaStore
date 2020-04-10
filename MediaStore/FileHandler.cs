using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MediaStore
{
    internal static class FileHandler
    {
        #region Methods

        internal static List<Receipt> LoadSales(string filePathName)
        {
            List<Receipt> receiptList = new List<Receipt>();

            using (StreamReader streamReader = new StreamReader(filePathName))
            {
                //Consume header
                if (streamReader.Peek() >= 0)
                {
                    _ = streamReader.ReadLine();
                }

                while (streamReader.Peek() >= 0)
                {
                    try
                    {
                        string receiptstring = streamReader.ReadLine();
                        if (receiptstring.Length > 0)
                        {
                            var fields = receiptstring.Split(';');
                            Receipt receipt = new Receipt
                            {
                                //ProductCode;Quantity;DateOfSale;ReceiptNumber;Price
                                ProductCode = uint.Parse(fields[0], CultureInfo.CurrentCulture),
                                Quantity = uint.Parse(fields[1], CultureInfo.CurrentCulture),
                                DateOfSale = fields[2],
                                ReceiptNumber = uint.Parse(fields[3], CultureInfo.CurrentCulture),
                                Price = decimal.Parse(fields[4],CultureInfo.CurrentCulture)

                            };
                            receiptList.Add(receipt);
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to load sales file", ex);
                    }
                }
                return receiptList;
            }
        }

        internal static List<Product> LoadStock(string filePathName)
        {
            List<Product> productList = new List<Product>();

            using (StreamReader streamReader = new StreamReader(filePathName))
            {
                //Consume header
                if (streamReader.Peek() >= 0)
                {
                    _ = streamReader.ReadLine();
                }

                while (streamReader.Peek() >= 0)
                {
                    try
                    {
                        string product = streamReader.ReadLine();
                        if (product.Length > 0)
                        {
                            var fields = product.Split(';');
                            Product prod = new Product
                            {
                                //ProductCode;Title;ProductType;Price;Quantity;ReleaseYear;Creator;Publisher;FreeText;Staus

                                ProductCode = uint.Parse(fields[0], CultureInfo.CurrentCulture),
                                Title = fields[1],
                                Type = (Product.ProductType)Enum.Parse(typeof(Product.ProductType), fields[2], true),
                                Price = decimal.Parse(fields[3], CultureInfo.CurrentCulture),
                                Quantity = uint.Parse(fields[4], CultureInfo.CurrentCulture),
                                ReleaseYear = uint.Parse(fields[5], CultureInfo.CurrentCulture),
                                Creator = fields[6],
                                Publisher = fields[7],
                                FreeText = fields[8],
                                Status = (Product.ProductStatus)Enum.Parse(typeof(Product.ProductStatus), fields[9], true)
                            };
                            productList.Add(prod);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to load product file", ex);
                    }
                }
                return productList;
            }
        }

        internal static void SaveSales(Sales sales, string filePathName)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filePathName, append: false))
                {
                    //Write header
                    streamWriter.WriteLine("ProductCode;Quantity;DateOfSale;ReceiptNumber;Price");
                    foreach (var receiptList in sales.Ledger.Values)
                    {
                        foreach (var receipt in receiptList)
                        {
                            streamWriter.WriteLine(receipt.ToString());
                        }

                    }
                    streamWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save sales file", ex);
            }
        }

        internal static void SaveStock(Stock stock, string filePathName)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filePathName, append: false))
                {
                    //Write header
                    streamWriter.WriteLine("ProductCode;Title;Type;Price;Quantity;ReleaseYear;Creator;Publisher;FreeText;Status");

                    foreach (var value in stock.Products.Values)
                    {
                        streamWriter.WriteLine(value.ToString());
                    }
                    streamWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save product file", ex);
            }
        }

        #endregion Methods
    }
}