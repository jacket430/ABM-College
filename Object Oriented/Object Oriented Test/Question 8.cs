using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Add postal codes here for testing
        string[] testPostalCodes = { "AAA 111", "x99 8aa", "t2r-3d9", "T3K0R3", "A1A1A1", "90210" };

        foreach (string postalCode in testPostalCodes)
        {
            string formattedPostalCode = ValidateAndFormatPostalCode(postalCode);
            if (formattedPostalCode != null)
            {
                Console.WriteLine($"Valid: {formattedPostalCode}");
            }
            else
            {
                Console.WriteLine($"Invalid: {postalCode}");
            }
        }
    }

    static string ValidateAndFormatPostalCode(string postalCode)
    {
        // Strips extra characters
        string cleanedPostalCode = Regex.Replace(postalCode.ToUpper(), @"[^A-Z0-9]", ""); 

        if (cleanedPostalCode.Length == 6 &&
            char.IsLetter(cleanedPostalCode[0]) &&
            char.IsDigit(cleanedPostalCode[1]) &&
            char.IsLetter(cleanedPostalCode[2]) &&
            char.IsDigit(cleanedPostalCode[3]) &&
            char.IsLetter(cleanedPostalCode[4]) &&
            char.IsDigit(cleanedPostalCode[5]))
        {
            return $"{cleanedPostalCode.Substring(0, 3)} {cleanedPostalCode.Substring(3, 3)}";
        }

        return null;
    }
}
