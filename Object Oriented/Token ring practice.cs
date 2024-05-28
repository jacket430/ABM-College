using System;
using System.Collections.Generic;

public class Computer
{
    public string Name { get; set; }

    public Computer(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, int> tokenRing = new Dictionary<string, int>
        {
            { "Computer1", 1 },
            { "Computer2", 0 },
            { "Computer3", 0 },
            { "Computer4", 0 },
            { "Computer5", 0 },
            { "Computer6", 0 },
            { "Computer7", 0 },
            { "Computer8", 0 },
            { "Computer9", 0 },
            { "Computer10", 0 }
        };

        Console.WriteLine("Computer1 has the token.");
        Console.WriteLine("Releasing and passing the token.");
        Console.WriteLine();

        for (int i = 2; i <= tokenRing.Count; i++)
        {
            PassToken(tokenRing, i);
            Console.WriteLine($"Computer{i} has the token.");
            Console.WriteLine("Releasing and passing the token.");
            Console.WriteLine();
        }
    }

    static void PassToken(Dictionary<string, int> tokenRing, int computerNumber)
    {
        var keys = new List<string>(tokenRing.Keys);

        foreach (var key in keys)
        {
            tokenRing[key] = 0;
        }

        string computerKey = $"Computer{computerNumber}";
        if (tokenRing.ContainsKey(computerKey))
        {
            tokenRing[computerKey] = 1;
        }
    }
}
