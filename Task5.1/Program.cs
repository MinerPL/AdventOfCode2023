using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Task5._1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = "";
            if (File.Exists("./input.txt"))
            {
                input = File.ReadAllText("./input.txt");
            }
            else
            {
                Console.WriteLine("Missing input.txt file");
                Console.ReadKey();
            }

            string[] inputSplit = input.Replace("\r", "").Split(new string[] { "\n\n" }, StringSplitOptions.None);
            
            string[] seeds = inputSplit[0]
                .Split(new string[] { ": " }, StringSplitOptions.None)[1].Trim()
                .Split(' ');
            
            List<List<List<long>>> rules = new  List<List<List<long>>>();

            inputSplit = inputSplit.Skip(1).ToArray();
            
            for (int i = 0; i < inputSplit.Length; i++)
            {
                var rule = inputSplit[i]
                    .Split(new string[] { ":\n" }, StringSplitOptions.None)[1].Trim()
                    .Split(new string[] { "\n" }, StringSplitOptions.None);;
                
                List<List<long>> ruleList = rule.Select(r => 
                    r.Split(' ')
                        .Select(s => long.Parse(s))
                        .ToList()
                    ).ToList();
                rules.Add(ruleList);
            }

            var end = long.MaxValue;
            foreach (var seed in seeds)
            {
                var seedA = long.Parse(seed);
                foreach (var rule in rules)
                {
                    foreach (var rule2 in rule.Where(rule2 => seedA >= rule2[1] && seedA < rule2[1] + rule2[2]))
                    {
                        seedA = rule2[0] + (seedA - rule2[1]);
                        break;
                    }
                }

                end = Math.Min(end, seedA);
            }
            
            Console.WriteLine(end);
        }
    }
}