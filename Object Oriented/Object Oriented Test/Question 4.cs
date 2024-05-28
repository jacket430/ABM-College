using System;

class Program
{
    static void Main(string[] args)
    {
        int firstNumber = 0;
        int secondNumber = 1; // Storing the first 2 numbers to use for the rest of the calculations

        Console.WriteLine("Printing sequence...");
        Console.WriteLine(firstNumber);
        Console.WriteLine(secondNumber);
        for (int i = 2; i < 10; i++)
        {
            int nextNumber = firstNumber + secondNumber;
            Console.WriteLine(nextNumber);

            firstNumber = secondNumber;
            secondNumber = nextNumber; // Updating numbers for recalculation
        }
        Console.WriteLine("Printing complete.");
    }
}
