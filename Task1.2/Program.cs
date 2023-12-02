using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task1
{
    internal class Program
    {
        public static Dictionary<string, int> Numbers = new()
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
        };
        
        public static void Main(string[] args)
        {
            int result2 = 0;
            string pattern = @"(?=(\d|one|two|three|four|five|six|seven|eight|nine)).*(\d|one|two|three|four|five|six|seven|eight|nine)";
            foreach (var i in Enumerable.Range(1, 1000))
            {
                var userInput = Console.ReadLine();
                Match m = Regex.Match(userInput, pattern);

                var firstItem = Numbers.ContainsKey(m.Groups[1].Value) ? Numbers[m.Groups[1].Value] : int.Parse(m.Groups[1].Value);
                var lastItem = Numbers.ContainsKey(m.Groups[m.Groups.Count - 1].Value) ? Numbers[m.Groups[m.Groups.Count - 1].Value] : int.Parse(m.Groups[m.Groups.Count - 1].Value);
                
                result2 += int.Parse($"{firstItem}{lastItem}");
            }
            Console.WriteLine(result2);
        }
    }
}