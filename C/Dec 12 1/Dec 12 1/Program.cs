using System;
using System.Collections.Generic;
using System.Linq;

namespace Dec_12_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var friends = new List<Friend>
            {
                new Friend { FirstName = "Avery", Age = 27 },
                new Friend { FirstName = "Tommy", Age = 24 },
                new Friend { FirstName = "Tina", Age = 19 },
                new Friend { FirstName = "Tommy", Age = 24 },
                new Friend { FirstName = "Tina", Age = 19 },
                new Friend { FirstName = "Tommy", Age = 24 },
                new Friend { FirstName = "Tommy", Age = 24 },
                new Friend { FirstName = "Misty", Age = 67 }
            };

            var over30 = friends.Where(friend => friend.Age <= 30).ToList();

            Console.WriteLine("Under 30:");
            foreach (var friend in over30)
            {
                Console.WriteLine($"{friend.FirstName} - {friend.Age}");
            }

            Console.WriteLine("\nBy year of birth:");
            var sortedByBirthYear = friends.OrderBy(friend => CalculateYearOfBirth(friend.Age)).ToList();
            foreach (var friend in sortedByBirthYear)
            {
                Console.WriteLine($"{friend.FirstName} - Year of Birth: {CalculateYearOfBirth(friend.Age)}");
            }

            Console.WriteLine("\nUnique Friends:");
            var uniqueFriends = friends
                .GroupBy(friend => new { friend.FirstName, friend.Age })
                .Where(group => group.Count() == 1)
                .Select(group => group.First());

            foreach (var friend in uniqueFriends)
            {
                Console.WriteLine($"{friend.FirstName} - {friend.Age}");
            }
        }

        public static int CalculateYearOfBirth(int age)
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - age;
        }
    }

    public class Friend
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
}
