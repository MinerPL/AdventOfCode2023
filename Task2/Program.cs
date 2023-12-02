using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

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
      
        public static void Main(string[] args)
        {
            var sum = 0;
            for (int i = 0; i < 100; i++)
            {
                var game = Console.ReadLine();
                var gameDetails = game.Split(':');
                var gameNumber = int.Parse(gameDetails[0].Split(' ')[1]);
                var gameBags = gameDetails[1].Replace(";", ",").Split(new string[] { ", " }, StringSplitOptions.None);
                var isValid = true;
                
                    foreach (var bagDetail in gameBags)
                    {
                        var bagDetailDetails = bagDetail.Trim().Split(' ');
                        var bagColor = (Bags) Enum.Parse(typeof(Bags), bagDetailDetails[1]);
                        var bagCount = int.Parse(bagDetailDetails[0]);
                        
                        if (bagCount > Limits[bagColor])
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid) sum += gameNumber;
            }
            
            Console.WriteLine(sum);
            
        }
    }
}