using System;

namespace Q3
{
    internal class Q3
    {
        public int LengthOfLastWord(string s)
        {
            s = s.Trim();
            string[] words = s.Split(' ');
            return words[words.Length - 1].Length;
        }

        public static void Main(string[] args)
        {
            Q3 q3 = new Q3();

            Console.WriteLine("~~ Last Word Length ~~");
            string input1 = "\nHello World";
            Console.WriteLine($"{input1}: {q3.LengthOfLastWord(input1)}");
            string input2 = "\n   fly me   to   the moon  ";
            Console.WriteLine($"{input2}: {q3.LengthOfLastWord(input2)}");
            string input3 = "\nluffy is still joyboy";
            Console.WriteLine($"{input3}: {q3.LengthOfLastWord(input3)}");
            Console.WriteLine("\n~~ Complete! ~~");
        }
    }
}
