using System;

public class Program
{
    public static void Main()
    {
        int numberOfLines = 6;

        for (int i = 1; i <= numberOfLines; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}
