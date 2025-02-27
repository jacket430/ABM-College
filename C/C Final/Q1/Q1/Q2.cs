using System;

namespace Q2
{
    public class Power
    {
        public double PCalc(double x, int n)
        {
            if (n == 0)
                return 1;

            long N = n;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }

            double result = 1;
            double workingTotal = x;

            while (N > 0)
            {
                if ((N % 2) == 1)
                {
                    result *= workingTotal;
                }
                workingTotal *= workingTotal;
                N /= 2;
            }
            return result;
        }
    }

    public class Q2
    {
        public static void Main(string[] args)
        {
            Power pcalc = new Power();

            Console.WriteLine("~~ Power Calculator ~~\n");
            Console.WriteLine("2.00000, 10: ");
            Console.WriteLine(pcalc.PCalc(2.00000, 10));
            Console.WriteLine("\n2.10000, 3: ");
            Console.WriteLine(pcalc.PCalc(2.10000, 3));
            Console.WriteLine("\n2.00000, -2: ");
            Console.WriteLine(pcalc.PCalc(2.00000, -2));
            Console.WriteLine("\n~~ Complete! ~~");
        }

    }
}
