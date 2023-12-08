using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task8._2
{
    internal class Program
    {
        static long Lcm(long[] numbers)
        {
            return numbers.Aggregate((x, y) => x * y / Gcd(x, y));
        }
 
        static long Gcd(long a, long b)
        {
            if (b == 0)
                return a;
            return Gcd(b, a % b);
        }
        
        public static void Main(string[] args)
        {
            var lines = (File.ReadAllText("input.txt")).Replace("\r", "")
                .Split(new string[] { "\n" }, StringSplitOptions.None);

            var queue = lines[0].Replace("\r", "");
            lines = lines.Skip(2).ToArray();

            Dictionary<string, List<string>> items = new Dictionary<string, List<string>>();

            foreach (var line in lines)
            {
                var splitted = line.Split(new string[] { " = " }, StringSplitOptions.None);
                var index = splitted[0].Trim();
                var nextSteps = splitted[1]
                    .TrimStart('(')
                    .TrimEnd(')')
                    .Split(new string[] { ", " }, StringSplitOptions.None);

                List<string> itm = new List<string>(){
                    nextSteps[0].Trim(),
                    nextSteps[1].Trim()
                };

                items.Add(index, itm);
            }

            List<long> Results = new List<long>();
            
            foreach (var s1 in items.Where(it => it.Key.EndsWith("A")).Select(x => x.Key).ToList())
            {
                var Next = s1;
                var s = 0;
                var i = 0;
                while (!Next.EndsWith("Z"))
                {
                    items.TryGetValue(Next, out List<string> item);

                    var L = item[0];
                    var R = item[1];

                    switch (queue[i])
                    {
                        case 'R':
                            Next = R;
                            break;
                        case 'L':
                            Next = L;
                            break;
                    }

                    i++;
                    if (i >= queue.Length) i = 0;
                    s++;
                }
                Results.Add(s);
            }
            
            Console.WriteLine(Lcm(Results.ToArray()));
        }
    }
}