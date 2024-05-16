using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Dictionary<string, List<string>> People = new Dictionary<string, List<string>>();

        People["Instructor 1"] = new List<string> { "Avery", "Jon", "Nardos", "Shekinah" };
        People["Instructor 2"] = new List<string> { "Avery", "Jon", "Nardos", "Shekinah" };

        foreach (KeyValuePair<string, List<string>> entry in People)
        {
            string instructor = entry.Key;
            List<string> students = entry.Value;

            Console.WriteLine(instructor + " has these students:");
            foreach (string student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }
    }
}
