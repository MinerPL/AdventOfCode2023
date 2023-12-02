using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    internal class Program
    {
        public enum Bags
        {
            red = 1,
            blue = 2,
            green = 3
        }
    
        public static Dictionary<Bags, int> Limits = new Dictionary<Bags, int>()
        {
            { Bags.red, 12},
            { Bags.green, 13},
            { Bags.blue, 14},
        };
        
        public static Dictionary<int, Dictionary<Bags, int>> Games = new Dictionary<int, Dictionary<Bags, int>>();
        
        public static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                var game = Console.ReadLine();
                var gameDetails = game.Split(':');
                var gameNumber = int.Parse(gameDetails[0].Split(' ')[1]);
                var gameBags = gameDetails[1].Replace(";", ",").Split(new string[] { ", " }, StringSplitOptions.None);
                var isValid = true;
                var cubes  = new Dictionary<Bags, int>();
                foreach (var bagDetail in gameBags)
                {
                    var bagDetailDetails = bagDetail.Trim().Split(' ');
                    var bagColor = (Bags) Enum.Parse(typeof(Bags), bagDetailDetails[1]);
                    var bagCount = int.Parse(bagDetailDetails[0]);

                    if (cubes.TryGetValue(bagColor, out var cnt))
                    {
                        if (cnt < bagCount)
                        {
                            cubes[bagColor] = bagCount;
                        }
                    }
                    else
                    {
                        cubes.Add(bagColor, bagCount);
                    }
                }
                Games.Add(gameNumber, cubes);
            }

            var sum = 0;
            
            foreach (var keyValuePair in Games)
            {
                var gameSum = 1;
                foreach (var valuePair in keyValuePair.Value)
                {
                    gameSum *= valuePair.Value;
                }

                sum += gameSum;
            }
            
            Console.WriteLine(sum);
        }
    }
}