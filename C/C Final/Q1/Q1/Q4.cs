using System;
using System.Collections.Generic;

namespace Q4
{
    public class PermSequence
    {
        public string GetPerm(int n,  int k)
        {
            List<int> nums = new List<int>();
            int[] facto = new int[n + 1];
            string output = "";

            facto[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                facto[i] = facto[i - 1] * i;
            }
            for (int i = 1; i <= n; i++)
            {
                nums.Add(i);
            }
            
            k--;
            
            for (int i = 1; i <= n; i++)
            {
                int index = k / facto[n - 1];
                output += nums[index];
                nums.RemoveAt(index);
                k -= index * facto[n - i];
            }
            return output;
        }
    }

    public class Q4
    {
        public static void Main(string[] args)
        {
            PermSequence ps = new PermSequence();

            Console.WriteLine("~~ Unique Permutations~~");
            Console.WriteLine("\nn = 3, k = 3:");
            Console.WriteLine(ps.GetPerm(3, 3));
            Console.WriteLine("\nn = 4, k = 9:");
            Console.WriteLine(ps.GetPerm(4, 9));
            Console.WriteLine("\nn = 3, k = 1:");
            Console.WriteLine(ps.GetPerm(3, 1));
            Console.WriteLine("\n~~ Complete! ~~");
        }
    }
}
