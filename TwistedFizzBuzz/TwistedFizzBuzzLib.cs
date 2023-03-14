using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TwistedFizzBuzz
{
    public class FizzBuzz
    {
        private readonly Dictionary<int, string> _divisorToToken;

        public FizzBuzz()
        {
            // Default divisors and tokens
            _divisorToToken = new Dictionary<int, string>
            {
                {3, "Fizz"},
                {5, "Buzz"}
            };
        }


        public async Task<bool> InitializeFromUrlAsync(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //It is possible to hardcode the URL here or to have an enum that gets used but it felt very fragile to do it that way so I've left it as is
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var data = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

                        if (data.ContainsKey("multiple") && data.ContainsKey("word"))
                        {
                            var multiples = (JsonElement)data["multiple"];
                            var words = (JsonElement)data["word"];
                            
                            //This "if" is not strictly necessary since I've only ever seen the api return a single value for divisor and multiple but since it's not documented anywhere better safe than sorry
                            if (multiples.ValueKind == JsonValueKind.Array && words.ValueKind == JsonValueKind.Array)
                            {
                                for (int i = 0; i < multiples.GetArrayLength(); i++)
                                {
                                    var divisor = multiples[i].GetInt32();
                                    var token = words[i].GetString();

                                    if (!_divisorToToken.ContainsKey(divisor))
                                    {
                                        _divisorToToken.Add(divisor, token);
                                    }
                                }

                                return true;
                            }
                            else
                            {
                                var divisor = multiples.GetInt32();
                                var token = words.GetString();

                                if (!_divisorToToken.ContainsKey(divisor))
                                {
                                    _divisorToToken.Add(divisor, token);
                                }

                                return true;
                            }
                        }
                    }

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }



        public FizzBuzz(Dictionary<int, string> divisorToToken)
        {
            // Custom divisors and tokens
            _divisorToToken = divisorToToken;
        }

        // Get the FizzBuzz output for a single number
        //NOTE: I wasn't certain on how zero should be treated so I looked it up and it seems the convention is to let it return the divisors (FizzBuzz) rather than 0, so that's what I went with
        public string GetFizzBuzz(int n)
        {
            string output = "";
            foreach (var divisor in _divisorToToken.Keys)
            {
                if (n % divisor == 0)
                {
                    output += _divisorToToken[divisor];
                }
            }
            return output == "" ? n.ToString() : output;
        }

        //Get FizzBuzz for a range of numbers
        public List<string> GetFizzBuzzRange(int start, int end)
        {
            var output = new List<string>();

            // Determine the step value based on whether the range is forward or reverse
            int step = start <= end ? 1 : -1;

            for (int i = start; i != end + step; i += step)
            {
                output.Add(GetFizzBuzz(i));
            }
            return output;
        }

        // Get the FizzBuzz output for a list of numbers
        public List<string> GetFizzBuzzNumbers(int[] numbers)
        {
            var output = new List<string>();
            foreach (var n in numbers)
            {
                output.Add(GetFizzBuzz(n));
            }
            return output;
        }
    }
}
