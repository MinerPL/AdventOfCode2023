using System;
using System.IO;
using System.Linq;

namespace Task6._2
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
            
            string[] lines = input.Split('\n');
            string time = lines[0].Split(':')[1].Trim().Replace(" ", "");
            string distance = lines[1].Split(':')[1].Trim().Replace(" ", "");
            
            var sum = 0;

            var raceTime = long.Parse(time);
            var raceDistance = long.Parse(distance);
            for (int i = 0; i < raceTime; i++)
            {
                var calc = i * (raceTime - i);
                if (calc > raceDistance) {
                    sum++; 
                }
            }
            
            Console.WriteLine(sum);
        }
    }
}