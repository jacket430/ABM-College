using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number 1: ");
        string input1 = Console.ReadLine();
        double number1 = Convert.ToDouble(input1); // Converting to double for fractions

        Console.WriteLine("Enter number 2: ");
        string input2 = Console.ReadLine();
        double number2 = Convert.ToDouble(input2);

        double sum = number1 + number2;
        Console.WriteLine($"Sum: {sum}");

        double difference = Math.Abs(number1 - number2); // Used Math.Abs to prevent negatives from displaying
        Console.WriteLine($"Difference: {difference}");

        double product = number1 * number2;
        Console.WriteLine($"Product: {product}");

        double quotient = number1 / number2;
        Console.Write($"Quotient: {quotient}");
    }
}