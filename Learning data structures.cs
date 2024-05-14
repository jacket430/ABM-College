using System;

class MainClass {
    public static void Main(string[] args)
    {
        List<string> cities = new List<string> { "Calgary", "Edmonton", "Airdrie" };

        foreach(string city in cities){
            Console.WriteLine(city);
        
        }
    }
}



using System;
using System.Collections;

class MainClass {
    public static void Main(string[] args)
    {
        ArrayList cities = new ArrayList();

        cities.Add("Calgary");
        cities.Add("Edmonton");
        cities.Add("Airdrie");

        foreach (string city in cities)
        {
            Console.WriteLine(city);
        }
    }
}

using System;
using System.Collections.Generic;

class MainClass {
    public static void Main(string[] args)
    {
        Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

        keyValuePairs.Add(001, "Calgary");
        keyValuePairs.Add(002, "Emonton");
        keyValuePairs.Add(003, "Airdrie");
        keyValuePairs.Add(004, "Calgary");
        keyValuePairs.Add(005, "Calgary");
        keyValuePairs.Add(006, "Airdrie");

        foreach (var pair in keyValuePairs)
        {
            Console.WriteLine("Key ID: {00}, Value: {1}", pair.Key, pair.Value);
        }
    }
}

