using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task3._1
{
    internal class Program
    {
        public static List<string> Lines = new List<string>();
        
        public static bool IsSymbol(char c)
        {
            return c != '.' && !char.IsNumber(c);
        }
        
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
            
            var sum = 0;
            foreach (var strings in GetNumbers(Lines))
            {
                var key = int.Parse(strings[0]);
                var line = strings[1];
                var start = int.Parse(strings[2]);
                var stop = int.Parse(strings[3]);
                var number = int.Parse(strings[4]);
                
                if (
                    (start >= 0 && IsSymbol(line[start])) || 
                    (stop < line.Length && IsSymbol(line[stop]))
                )
                {
                    sum += number;
                    continue;
                }

                for (int i = start; i <= stop; i++)
                {
                    if(Lines[key].Length == i) continue;
                    if (key > 0 && IsSymbol(Lines[key - 1][i]))
                    {
                        sum += number;
                        break;
                    }

                    if (key < Lines.Count - 1 && IsSymbol(Lines[key + 1][i]))
                    {
                        sum += number;
                        break;
                    } 
                }
            } 
            
            Console.WriteLine(sum);
        }
    }
}