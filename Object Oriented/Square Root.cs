uusing System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Prime numbers from 1 to 100:");

        for (int number = 2; number <= 100; number++)
        {
            if (IsPrime(number))
            {
                Console.Write(number + " ");
            }
        }
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
