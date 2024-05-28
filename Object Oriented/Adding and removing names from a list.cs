using System;
using System.Collections.Generic;

public class Program
{
	static void Main()
	{
		List<string> names = new List<string>();

		names.Add("Avery");
		names.Add("Basant");
		names.Add("Jon");
		names.Add("Nardos");
		names.Add("Shekinah");

		Console.WriteLine("Names on the list before removal:");
		foreach (string name in names)
		{
			Console.WriteLine(name);
		}
		Console.WriteLine("Total number of names: " + names.Count);
		Console.WriteLine();

		Console.WriteLine("Removing 2 names from list...");
		Console.WriteLine();
        names.RemoveAt(0);
		names.RemoveAt(0);

		Console.WriteLine("Names on the list after removal:");
		foreach (string name in names)
		{
			Console.WriteLine(name);
		}
		Console.WriteLine("Total number of names: " + names.Count);

		Console.WriteLine();
		Console.WriteLine("Updating names...");
		Console.WriteLine();

		names[0] = "Walter White";
		names[1] = "Jesse Pinkman";
		names[2] = "Saul Goodman";

        Console.WriteLine("Names on the list after renaming:");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}
