using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Task11._1
{
    internal class Program
    {
        static long distance(int a, int b, List<int> empty)
        {
            var c = Math.Min(a, b);
            var d = Math.Abs(a - b);
            return d + 999999 * empty.Count(x => x >= c && x <= c + d);
        }
        
        public static void Main(string[] args)
        {
            var input = (File.ReadAllText("input.txt")).Replace("\r", "");
            
            var lines = input.Split('\n');

            var i = 1;
            Dictionary<int, List<int>> place = new Dictionary<int, List<int>>();
            for (var j = 0; j < lines.Length; j++)
            {
                for (var i1 = 0; i1 < lines[j].Length; i1++)
                {
                    if (lines[j][i1] != '#') continue;
                    place.Add(i, new List<int>() {j, i1});
                    i++;
                }
            }
            
            List<int> blankCol = new List<int>();

            for (int j = 0; j < lines.Length; j++)
            {
                if(lines[j].All(a => a == '.')) blankCol.Add(j);
            }
            
            List<int> blankRow = new List<int>();
            
            for (int j = 0; j < lines[0].Length; j++)
            {
                if(lines.All(a => a[j] == '.')) blankRow.Add(j);
            }

            long sum = 0;
            foreach (var first in place)
            {
                foreach (var keyValuePair in place.Where(key => (key.Key != first.Key && key.Key > first.Key)))
                {
                    var firstDiff = distance(first.Value[0], keyValuePair.Value[0], blankCol);
                    var secondDiff = distance(first.Value[1], keyValuePair.Value[1], blankRow);

                    sum += firstDiff + secondDiff;
                }
            }
            
            Console.WriteLine(sum);
        }
    }
}