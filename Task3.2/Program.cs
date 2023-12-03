using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task3._2
{
    internal class Program
    {
        public static List<string> Lines = new List<string>();
        
        public static List<string> Gears = new List<string>();
        
    public static IEnumerable<string[]> GetNumbers(IEnumerable<string> lines)
    {
        foreach (var (line, index) in lines.Select((line, index) => (line, index)))
        {
            foreach (Match match in Regex.Matches(line, @"\d+"))
            {
                string[] resultArray = { index.ToString(), line, (match.Index - 1 < 0 ? 0 : match.Index - 1).ToString(), (match.Index + match.Length).ToString(), match.Value };
                yield return resultArray;
            }
        }
    }
        
        public static void Main(string[] args)
        {
            for (int i = 0; i < 140; i++)
            {
                Lines.Add(Console.ReadLine());
            }

            for (int i = 0; i < Lines.Count; i++)
            {
                
                for (int j = 0; j < Lines[i].Length; j++)
                {
                    if(Lines[i][j] != '*') continue;
                    
                    Gears.Add($"{i}-{j}");
                }
            }

            int sum = 0;
            
            foreach (var keyValuePair in Gears)
            {
                var Key = int.Parse(keyValuePair.Split('-')[0]);
                var Value = int.Parse(keyValuePair.Split('-')[1]);
                var ssum = 1;
                var zsum = 0;
                for(int i = Key - 1; i <= Key + 1; i++)
                {
                    foreach (Match match in Regex.Matches(Lines[i], @"\d+"))
                    {
                        int start = match.Index - 1 < 0 ? 0 : match.Index - 1;
                        int stop = match.Index + match.Length;
                        int number = int.Parse(match.Value);
                        
                        if (start <= Value && stop >= Value)
                        {
                            zsum++;
                            ssum *= number;
                        }
                    }
                }
                
                if(zsum < 2) continue;
                
                sum += ssum;
            }
            
            Console.WriteLine(sum);
        }
    }
}