using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        double number = Convert.ToDouble(input);

        if (number % 2 == 0)
        {
            Console.WriteLine("Your number is even.");
        }
        else
        {
            Console.WriteLine("Your number is odd.");
        }
    }
}
