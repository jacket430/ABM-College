using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 3, 5, 7, 2, 8, -1, 4, 10, 12 };
        int max = array[0];
        int min = array[0];

        foreach (int num in array)
        {
            if (num > max)
            {
                max = num;
            }
            if (num < min)
            {
                min = num;
            }
        }

        Console.WriteLine($"Max value: {max}");
        Console.WriteLine($"Min value: {min}");
    }
}
