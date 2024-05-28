using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Strings containing dates for testing
        string[] testStrings = {
            "The date is 12/05/2023.",
            "Meeting scheduled for 25/12/2022.",
            "99/99/9999.",
            "Another date: 01/01/2020.",
            "String without date test",
            "Date: 31/12/2024 end of year."
        };

        foreach (string str in testStrings)
        {
            string extractedDate = ExtractAndFormatDate(str);
            if (extractedDate != null)
            {
                Console.WriteLine($"Validated date: {extractedDate}");
            }
            else
            {
                Console.WriteLine($"Invalid date: {str}");
            }
        }
    }

    static string ExtractAndFormatDate(string input)
    {
        string pattern = @"\b\d{2}/\d{2}/\d{4}\b";
        var match = System.Text.RegularExpressions.Regex.Match(input, pattern);

        if (match.Success)
        {
            string dateString = match.Value;
            DateTime date;
            // Validate and parse
            if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date.ToString("yyyy-MM-dd");
            }
        }

        return null;
    }
}
