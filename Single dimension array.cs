using System;

class Program
{
    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5 };

        Console.Write("[ ");
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine("]");
    }
}
