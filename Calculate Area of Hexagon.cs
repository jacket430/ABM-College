using System;

class Program
{
        static void Main()
        {
            double sideLength = 12;
            double area = HexagonArea(sideLength);
            Console.WriteLine($"A hexagon with a side length of {sideLength} has an area of {area}");
        }

        static double HexagonArea(double side)
        {
            double area = (3 * Math.Sqrt(3) / 2) * Math.Pow(side, 2);
            return area;
        }
}