using System;

class Program
{
    static void Main()
    {
        int[,] array = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Console.Write("[");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j]);
                if (j < array.GetLength(1) - 1)
                {
                    Console.Write(" ");
                }
            }
            if (i < array.GetLength(0) - 1)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine("]");
    }
}
