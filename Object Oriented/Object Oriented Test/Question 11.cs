using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Phone numbers for testing
        string[] testPhoneNumbers = { "+1 (654) 896-248", "+44 20 7946 0958", "+12345", "+122-456-7842", "+383727", "1234", "12387489", "-123974" };

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
        if (string.IsNullOrEmpty(phoneNumber) || phoneNumber[0] != '+')
        {
            return null;
        }

        // Clean up number
        string cleanedPhoneNumber = Regex.Replace(phoneNumber, @"[\s\-\(\)\.]", "");

        if (!Regex.IsMatch(cleanedPhoneNumber.Substring(1), @"^\d+$"))
        {
            return null;
        }

        return cleanedPhoneNumber;
    }
}
