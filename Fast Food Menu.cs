using System;
using System.Collections.Generic;

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
        List<PriceProductPair> priceProductList = InitializeMenu();

        bool startNewOrder = true;
        while (startNewOrder)
        {
            StartOrder(priceProductList);

            Console.WriteLine("Would you like to start a new order? (y/Y for yes):");
            string response = Console.ReadLine();
            startNewOrder = response.Equals("y", "Y");
        }
    }

    static List<PriceProductPair> InitializeMenu()
    {
        return new List<PriceProductPair>()
        {
            new PriceProductPair(10.46, "Burger"),
            new PriceProductPair(12.99, "Chicken Nuggets"),
            new PriceProductPair(2.30, "Fountain Drink"),
            new PriceProductPair(15.53, "Double Burger")
        };
    }

    static void StartOrder(List<PriceProductPair> priceProductList)
    {
        PrintMenu(priceProductList);

        Console.WriteLine("Enter the item numbers separated by spaces:");
        string input = Console.ReadLine();
        string[] inputArray = input.Split(' ');

        double totalPrice = CalculateTotalPrice(inputArray, priceProductList);

        PrintTotalPrice(totalPrice);
    }

    static void PrintMenu(List<PriceProductPair> priceProductList)
    {
        Console.WriteLine("Menu:");
        Console.WriteLine(new string('-', 30));

        for (int i = 0; i < priceProductList.Count; i++)
        {
            var item = priceProductList[i];
            Console.WriteLine($"{i + 1}. {item.ProductName}: ${item.ItemPrice:F2}");
        }
    }

    static double CalculateTotalPrice(string[] inputArray, List<PriceProductPair> priceProductList)
    {
        double totalPrice = 0.0;

        foreach (string itemNumber in inputArray)
        {
            int index = int.Parse(itemNumber) - 1;
            totalPrice += priceProductList[index].ItemPrice;
        }

        return totalPrice;
    }

    static void PrintTotalPrice(double totalPrice)
    {
        double gst = totalPrice * 0.05;
        double finalPrice = totalPrice + gst;

        Console.WriteLine();
        Console.WriteLine($"Total Price: ${totalPrice:F2}");
        Console.WriteLine($"GST (5%): ${gst:F2}");
        Console.WriteLine($"Final Price: ${finalPrice:F2}");
    }
}
