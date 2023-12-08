using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_8._1
{
    internal class Program
    {
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


            var Next = items.FirstOrDefault(x => x.Key == "AAA").Key;
            var L = items.FirstOrDefault(x => x.Key == "AAA").Value[0];
            var R = items.FirstOrDefault(x => x.Key == "AAA").Value[1];

            var s = 0;
            var i = 0;

            while (Next != "ZZZ")
            {
                items.TryGetValue(Next, out List<string> item);

                L = item[0];
                R = item[1];

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

            Console.WriteLine(s);
        }
    }
}