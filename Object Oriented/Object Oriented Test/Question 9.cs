using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Phone numbers for testing
        string[] testPhoneNumbers = { "1654896248", "(403) 240-4032", "12345", "122-456-7842", "383727", "133.780.7822", "5182749275", "28842282918" };

        foreach (string phoneNumber in testPhoneNumbers)
        {
            string formattedPhoneNumber = FormatPhoneNumber(phoneNumber);
            if (formattedPhoneNumber != null)
            {
                Console.WriteLine($"Valid: {formattedPhoneNumber}");
            }
            else
            {
                Console.WriteLine($"Invalid: {phoneNumber}");
            }
        }
    }

    static string FormatPhoneNumber(string phoneNumber)
    {
        // Strips extra characters
        string cleanedPhoneNumber = Regex.Replace(phoneNumber, @"[^\d]", "");

        if (cleanedPhoneNumber.Length == 10)
        {
            return $"({cleanedPhoneNumber.Substring(0, 3)}) {cleanedPhoneNumber.Substring(3, 3)}-{cleanedPhoneNumber.Substring(6, 4)}";
        }

        return null;
    }
}
