using System;
using System.Collections.Generic;
using TwistedFizzBuzz;

namespace TwistedFizzBuzzSpecificUseCases
{
    class Program
    {
        static void Main()
        {
            // Define the custom tokens and divisors
            Dictionary<int, string> rules = new Dictionary<int, string>
            {
                { 5, "Fizz" },
                { 9, "Buzz" },
                { 27, "Bar" }
            };

            // Create an instance of TwistedFizzBuzz
            FizzBuzz fb = new FizzBuzz(rules);

            Console.WriteLine("Output the numbers from -20 to 127 with the custom FizzBuzz rules");

            for (int i = -20; i <= 127; i++)
            {
                List<string> output = fb.GetFizzBuzzRange(i, i);
                Console.WriteLine(string.Join("", output));
            }

            Console.ReadLine();
        }
    }
}