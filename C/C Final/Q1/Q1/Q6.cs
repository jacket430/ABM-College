using System;
using System.Collections.Generic;

namespace Q6
{
    internal class Q6
    {
        public int Min(IList<IList<int>> triangle)
        {
            if (triangle == null ||  triangle.Count == 0) return 0;
            int[] dpar = new int[triangle.Count];
            for (int i = 0; i < triangle[triangle.Count - 1].Count; i++)
            {
                dpar[i] = triangle[triangle.Count - 1][i];
            }
            for (int row = triangle.Count - 2;  row >= 0; row--)
            {
                for (int col = 0; col < triangle[row].Count; col++)
                {
                    dpar[col] = triangle[row][col] + Math.Min(dpar[col], dpar[col + 1]);
                }
            }
            return dpar[0];
        }
        public static void Main(string[] args)
        {
            Q6 q6 = new Q6();

            IList<IList<int>> triangle1 = new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 3, 4 },
                new List<int> { 6, 5, 7 },
                new List<int> { 4, 1, 8, 3 }
            };
            Console.WriteLine("~~ Triangle Path ~~\n");
            Console.WriteLine("{1}, {3, 4}, {6, 5, 7}, {4, 1, 8, 3}: ");
            Console.WriteLine(q6.Min(triangle1));

            IList<IList<int>> triangle2 = new List<IList<int>>
            {
                new List<int> { -10 }
            };
            Console.WriteLine("\n{-10}: ");
            Console.WriteLine(q6.Min(triangle2));
            Console.WriteLine("\n~~ Complete! ~~");
        }
    }
}
