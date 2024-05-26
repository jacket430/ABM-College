using System;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public void DisplayCarInfo()
    {
        Console.WriteLine($"{Year} {Make} {Model}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car myCar = new Car("Ford", "Focus", 2005);

        myCar.DisplayCarInfo();
    }
}
