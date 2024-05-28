using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Prime numbers from 1 to 100:");
        for (int i = 1; i <= 100; i++)
        {
            if (IsPrime(i))
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine();

        Console.WriteLine("Prime numbers from 700 to 800:");
        for (int i = 700; i <= 800; i++)
        {
            if (IsPrime(i))
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine();
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}
