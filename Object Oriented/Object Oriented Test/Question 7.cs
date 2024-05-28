using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Use full path, relative path should work too
        string filePath = "C:/testfile.txt";

        try
        {
            string content = File.ReadAllText(filePath);

            // Clean up text file for word count
            string[] words = content.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            Console.WriteLine($"Word count: {wordCount}");
        }

        catch (FileNotFoundException e)
        {
            Console.WriteLine($"File not found: {e.Message}");
        }

        catch (IOException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}
