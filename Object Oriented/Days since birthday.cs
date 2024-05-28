using System;

class Program
{
    static void Main()
    {
        DateTime myBirthday = new DateTime(1997, 2, 1);

        DateTime today = DateTime.Today;
        TimeSpan age = today - myBirthday;
        int daysSinceMyBirthday = age.Days;

        DayOfWeek dayofWeek = myBirthday.DayOfWeek;

        Console.WriteLine($"My birthday was {myBirthday.ToString("MMMM d, yyyy")}");
        Console.WriteLine($"It has been {daysSinceMyBirthday} days since I was born");
        Console.WriteLine($"It was on a {dayofWeek}");
    }
}