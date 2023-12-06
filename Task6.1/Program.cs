using System;
using System.IO;
using System.Linq;

namespace Task6._1
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
            string[] time = lines[0].Split(':')[1].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] distance = lines[1].Split(':')[1].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            
            var sum = 1;
            for (int i = 0; i < time.Length; i++)
            {
                var sum2 = 0;

                var raceTime = int.Parse(time[i]);
                var raceDistance = int.Parse(distance[i]);
                for (int j = 0; j < raceTime; j++)
                {
                    var calc = j * (raceTime - j);
                    if (calc > raceDistance)
                    {
                        sum2++;
                    }
                }
                
                sum *= sum2;
            }
            
            Console.WriteLine(sum);
        }
    }
}