using System;
using System.Collections.Generic;

namespace Q1
{
    public class Program
    {
        public static IList<IList<int>> UniquePermutations(int[] nums)
        {
            IList<IList<int>> permutations = new List<IList<int>>();
            Array.Sort(nums);
            Perm(permutations, nums, new bool[nums.Length], new List<int>());
            return permutations;
        }

        private static void Perm(IList<IList<int>> permutations, int[] nums, bool[] dupe, List<int> current)
        {
            if (current.Count == nums.Length)
            {
                permutations.Add(new List<int>(current));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1] && !dupe[i - 1])
                {
                    continue;
                }

                if (!dupe[i])
                {
                    dupe[i] = true;
                    current.Add(nums[i]);
                    Perm(permutations, nums, dupe, current);
                    current.RemoveAt(current.Count - 1);
                    dupe[i] = false;
                }
            }
        }
        public static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            IList<IList<int>> result = UniquePermutations(nums);

            Console.WriteLine("~~ Unique Permutation Generator ~~\n");

            foreach (var permutation in result)
            {
                Console.WriteLine(string.Join(",", permutation));
            }

            Console.WriteLine("\n~~ Complete! ~~");
        }
    }
}
