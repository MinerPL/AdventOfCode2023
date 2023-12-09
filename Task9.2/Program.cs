using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task9._2
{
    internal class Program
    {

        public static int[] diffCalc(int[] numbers)
        {
            var diff = new int[numbers.Length - 1];
            for (var i = 0; i < numbers.Length; i++)
            {
                if(i == numbers.Length - 1)
                    break;
                diff[i] = numbers[i + 1] - numbers[i];
            }

            return diff;    
        }
        
        public static void Main(string[] args)
        {
            var lines = (File.ReadAllText("input.txt")).Replace("\r", "")
                .Split(new string[] { "\n" }, StringSplitOptions.None);

            var sum = 0;
            foreach (var line in lines)
            {
                var numbers = line.Split(' ').Select(int.Parse).Reverse().ToArray();
                var diff = numbers;
                var last = new List<int>();
                while (!diff.All(x => x == 0))
                {
                    diff = diffCalc(diff);
                    last.Add(diff.Last());
                }

                sum += numbers.Last() + last.Aggregate((a, b) => a + b);
            }
            
            Console.WriteLine(sum);
        }
    }
}