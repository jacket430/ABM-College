using System;
using System.Collections.Generic;
using System.Linq;
public class PriceProductPair
{
    public double ItemPrice { get; set; }
    public string ProductName { get; set; }

    public PriceProductPair(double itemPrice, string productName)
    {
        ItemPrice = itemPrice;
        ProductName = productName;
    }
}
class Program
{
    static void Main()
    {
        List<PriceProductPair> PriceProduct = new List<PriceProductPair>()
        {
            new PriceProductPair(10.46, "Burger"),
            new PriceProductPair(12.99, "Chicken Nuggets"),
            new PriceProductPair(2.30, "Fountain Drink"),
            new PriceProductPair(15.53, "Double Burger"),
            new PriceProductPair(10.99, "McChicken"),
            new PriceProductPair(2.99, "Apple Slices"),
            new PriceProductPair(9.12, "Mystery Meat"),
            new PriceProductPair(2.00, "The Orb")
        };

        PrintMenu(PriceProduct);
    }

    static void PrintMenu(List<PriceProductPair> priceProductList)
    {
        Console.WriteLine("Menu:");
        Console.WriteLine(new string('-', 30));

        foreach (var item in priceProductList)
        {
            Console.WriteLine(item.ProductName + item.ItemPrice);
        }
    }
}