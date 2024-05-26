using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // SSNs for testing
        string[] testSSNs = { "152-43-6156", "133 26 4234", "553754389", "61-335-6426", "abc-12-3456", "123-45-678", "123-45-67890" };

        foreach (string ssn in testSSNs)
        {
            string formattedSSN = FormatSSN(ssn);
            if (formattedSSN != null)
            {
                Console.WriteLine($"Valid: {formattedSSN}");
            }
            else
            {
                Console.WriteLine($"Invalid: {ssn}");
            }
        }
    }

    static string FormatSSN(string ssn)
    {
        // Clean
        string cleanedSSN = Regex.Replace(ssn, @"[^\d]", "");

        // Verify cleaning worked properly
        if (cleanedSSN.Length != 9)
        {
            return null;
        }

        // Format SSN
        return $"{cleanedSSN.Substring(0, 3)}-{cleanedSSN.Substring(3, 2)}-{cleanedSSN.Substring(5, 4)}";
    }
}
