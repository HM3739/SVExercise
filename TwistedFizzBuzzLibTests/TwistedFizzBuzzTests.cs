using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TwistedFizzBuzz;

namespace TwistedFizzBuzzLibTests
{
    [TestFixture]
    class TwistedFizzBuzzTests
    {
        [TestCase(0, "FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(9, "Fizz")]
        [TestCase(15, "FizzBuzz")]
        public void GetFizzBuzz_ReturnsCorrectOutput(int n, string expectedOutput)
        {
            var fb = new FizzBuzz();

            string output = fb.GetFizzBuzz(n);

            Assert.AreEqual(expectedOutput, output);
        }

        [TestCase(-1, 1, new string[] { "-1", "FizzBuzz", "1" })]
        [TestCase(1, 5, new string[] { "1", "2", "Fizz", "4", "Buzz" })]
        [TestCase(15, 10, new string[] { "FizzBuzz", "14", "13", "Fizz", "11", "Buzz" })]
        [TestCase(-2, -15, new string[] { "-2", "Fizz", "-4", "Buzz", "Fizz", "-7", "-8", "Fizz", "Buzz", "-11", "Fizz", "-13", "-14", "FizzBuzz" })]
        public void GetFizzBuzzRange_ReturnsCorrectOutput(int start, int end, string[] expectedOutput)
        {
            var fb = new FizzBuzz();

            List<string> output = new List<string>();
            try
            {
                output = fb.GetFizzBuzzRange(start, end);
            }
            catch (ArgumentException ex)
            {
                output.Add(ex.Message);
            }

            Assert.AreEqual(expectedOutput, output);
        }

        [TestCase(new int[] { 0, 3, 5, 9, 15 }, new string[] { "FizzBuzz", "Fizz", "Buzz", "Fizz", "FizzBuzz" })]
        [TestCase(new int[] { -3, -5, -9, -15 }, new string[] { "Fizz", "Buzz", "Fizz", "FizzBuzz" })]
        [TestCase(new int[] { 2, 5, 1, 4, 9, 7, 8 }, new string[] { "2", "Buzz", "1", "4", "Fizz", "7", "8" })]
        public void GetFizzBuzzNumbers_ReturnsCorrectOutput(int[] numbers, string[] expectedOutput)
        {
            var fb = new FizzBuzz();

            var output = fb.GetFizzBuzzNumbers(numbers);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public async Task InitializeFromUrlAsync_ShouldQueryUrlSuccessfully()
        {
            var url = "https://rich-red-cocoon-veil.cyclic.app/random";
            var fb = new FizzBuzz();

            var result = await fb.InitializeFromUrlAsync(url);

            Assert.IsTrue(result);
        }




    }
}
