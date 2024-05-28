using System;

public class Program
{
	static void Main()
	{
		Console.WriteLine("Enter a word:");
		string input = Console.ReadLine();

		char[] charArray = input.ToCharArray();
		Array.Reverse(charArray);
		string reversed = new string(charArray);

		bool isPalindrome = input == reversedInput;

		if (isPalindrome)
		{
			Console.WriteLine("The input is a palindrome.");
		}
		else
		{
			Console.WriteLine("The input is not a palindrome.")
		}
	}
}
