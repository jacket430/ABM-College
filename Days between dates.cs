using System;

class Program
{
    static void Main()
    {
        DateTime firstDate = new DateTime(2023, 1, 1); // <--- Year, Month, Day
        DateTime secondDate = new DateTime(2022, 1, 2);

        TimeSpan difference = firstDate - secondDate;
        int daysBetween = Math.Abs(difference.Days);

        Console.WriteLine($"{daysBetween} days");
    }
}
