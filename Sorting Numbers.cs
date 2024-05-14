using System;
using System.Linq;

public class Sorting
{
    public static void Main(string[] args)
    {
        int[] numbers = {3, 5, 2, 8, 12, 89, 38, 52, 6, 33, 82, 25, 79, 318, 15, 72, 10, 1, 45};

        Array.Sort(numbers);
        
        int smallestNumber = numbers.Min();
        int largestNumber = numbers.Max();
        
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        double mean = (double)sum / numbers.Length;

        Console.WriteLine("Smallest number: " + smallestNumber);
        Console.WriteLine("Largest number: " + largestNumber);
        Console.WriteLine("Mean of array: " + mean);

        Console.WriteLine("Sorted array in ascending order:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();

        Array.Reverse(numbers);

        Console.WriteLine("Sorted array in descending order:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
    }
}