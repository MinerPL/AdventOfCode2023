using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4._2
{
    internal class Program
    {
        public static Dictionary<int, int> ScratchcardsNumber = new Dictionary<int, int>();
        public static Dictionary<int, string> Scratchcards = new Dictionary<int, string>();

        public static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 212; i++)
            {
                string line = Console.ReadLine();
                string[] items = line.Split(':');

                var scratchcard = int.Parse(items[0].Trim().Split(' ').Last());
                ScratchcardsNumber.Add(scratchcard, 1);
                Scratchcards.Add(scratchcard, items[1].Trim());
            }

            foreach (var keyValuePair in Scratchcards)
            {
                int number = keyValuePair.Key;
                int loopTimes = 0;
                if (ScratchcardsNumber.TryGetValue(number, out int num))
                {
                    loopTimes = num;
                }
                for (int i = 1; i < loopTimes + 1; i++)
                {
                    var line = "";
                    if (Scratchcards.TryGetValue(number, out string line2))
                    {
                        line = line2;
                    }

                    var splited = line.Split('|');
                    var winningNumbers = splited[0].Trim().Split(' ');
                    var cardNumbers = splited[1].Trim().Split(' ');
                    var nextCard = number + 1;

                    foreach (var winningNumber in winningNumbers)
                    {
                        if(winningNumber == "") continue;
                        if (cardNumbers.Contains(winningNumber))
                        {
                            ScratchcardsNumber[nextCard]++;
                            nextCard++;
                            sum++;
                        }
                    }
                } 
            }
            
            Console.WriteLine(sum + Scratchcards.Count);
        }
    }
}