using System;
using System.Collections.Generic;

namespace Q5
{
    public class BracketGen
    {
        public IList<string> GenBrackets(int n)
        {
            List<string> result = new List<string>();
            BracketCheck(result, "", 0, 0, n);
            return result;
        }

        public void BracketCheck(List<string> output, string current, int open, int close, int max)
        {
            if (current.Length == max * 2)
            {
                output.Add(current);
                return;
            }
            if (open < max)
            {
                BracketCheck(output, current + "(", open + 1, close, max);
            }
            if (close < open)
            {
                BracketCheck(output, current + ")", open, close + 1, max);
            }
        }
    }

    public class Q5
    {
        public static void Main(string[] args)
        {
            BracketGen bg = new BracketGen();

            Console.WriteLine("~~ Bracket Generator ~~");
            Console.WriteLine("\nn = 3:");
            Console.WriteLine(string.Join(", ", bg.GenBrackets(3)));
            Console.WriteLine("\nn = 1:");
            Console.WriteLine(string.Join(", ", bg.GenBrackets(1)));
            Console.WriteLine("\n~~ Complete! ~~");
        }
    }
}
