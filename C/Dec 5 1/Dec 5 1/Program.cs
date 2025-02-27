using System;

namespace Dec_5_1
{
    internal class Program
    {
        public class Calculator
        {
            public int Add(int number1, int number2)
            {
                return number1 + number2;
            }

            public int Subtract(int number1, int number2)
            {
                return number1 - number2;
            }

            public int Multiply(int number1, int number2)
            {
                return number1 * number2;
            }

            public int Divide(int number1, int number2)
            {
                if (number2 == 0)
                {
                    throw new DivideByZeroException("Error: Can't divide by zero.");
                }
                return number1 / number2;
            }

            public int Modulus(int number1, int number2)
            {
                if (number2 == 0)
                {
                    throw new DivideByZeroException("Error: Can't modulus by zero.");
                }
                return number1 % number2;
            }
        }

        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            bool exit = false;
            int number1 = 57;
            int number2 = 25;

            while (!exit)
            {
                Console.WriteLine($"Input: {number1} and {number2}");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Modulus");
                Console.WriteLine("6. Exit");
                Console.Write("Enter a selection: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("The sum is: " + calculator.Add(number1, number2));
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("The difference is: " + calculator.Subtract(number1, number2));
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("The product is: " + calculator.Multiply(number1, number2));
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("The quotient is: " + calculator.Divide(number1, number2));
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine();
                        Console.WriteLine("The remainder is: " + calculator.Modulus(number1, number2));
                        Console.WriteLine();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
