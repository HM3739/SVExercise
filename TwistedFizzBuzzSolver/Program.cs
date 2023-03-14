using System;
using TwistedFizzBuzz;

namespace TwistedFizzBuzzSolverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //As per the instructions this takes no command line input and hardcoded the range to be 1 to 100 as I took that to be the "first 100 numbers"

            FizzBuzz fb = new FizzBuzz();
            string output = string.Join(Environment.NewLine, fb.GetFizzBuzzRange(1, 100));

            Console.WriteLine("Working out FizzBuzz from 1 to 100");
            Console.WriteLine(output);

            Console.ReadLine();
        }
    }
}