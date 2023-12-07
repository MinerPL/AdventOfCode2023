using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task7._1
{
    internal class Program
    {
        public static Dictionary<int, List<string>> Pairs = new Dictionary<int, List<string>>();
        public static Dictionary<string, int> Decks = new Dictionary<string, int>();
        public static Dictionary<char, int> cardValues = new Dictionary<char, int>
        {
            { 'A', 14 },
            { 'K', 13 },
            { 'Q', 12 },
            { 'J', 11 },
            { 'T', 10 },
            { '9', 9 },
            { '8', 8 },
            { '7', 7 },
            { '6', 6 },
            { '5', 5 },
            { '4', 4 },
            { '3', 3 },
            { '2', 2 }
        };
        
        public static void GetPairs(string deck)
        {
            Dictionary<string, int> items = new Dictionary<string, int>();
            
            foreach (var item in deck)
            {
                if (items.ContainsKey(item.ToString()))
                {
                    items[item.ToString()]++;
                }
                else
                {
                    items.Add(item.ToString(), 1);
                }
            }

            var i = 1;
            if (items.Any(x => x.Value == 5)) i = 7;
            else if (items.Any(x => x.Value == 4)) i = 6;
            else if (items.Any(x => x.Value == 3) && items.Any(x => x.Value == 2)) i = 5;
            else if (items.Any(x => x.Value == 3)) i = 4;
            else if (items.Count(x => x.Value == 2) == 2) i = 3;
            else if (items.Any(x => x.Value == 2)) i = 2;
            else if (items.Count == 5 && !items.Any(x => x.Value > 1)) i = 1;
            
            
            if (Pairs.TryGetValue(i, out List<string> value))
            {
                value.Add(deck);
            }
            else
            {
                Pairs.Add(i, new List<string> {deck});
            }
        }
        
        private static int CompareHandsByCardStrength(string handA, string handB)
        {
            for (int i = 0; i < handA.Length; i++)
            {
                if (handA[i] != handB[i])
                {
                    return CompareCards(handA[i], handB[i]);
                }
            }

            return 0;
        }

        private static int CompareCards(char cardA, char cardB)
        {
            int valueA = cardValues[cardA];
            int valueB = cardValues[cardB];

            if (valueA < valueB)
            {
                return -1;
            }
            else if (valueA > valueB)
            {
                return 1;
            }

            return 0;
        }
        
        public static void Main(string[] args)
        {
            var lines = (File.ReadAllText("input.txt")).Replace("\r", "")
                .Split(new string[] { "\n" }, StringSplitOptions.None);

            foreach (var line in lines)
            {
                var split = line.Trim().Split(' ');
                Decks.Add(split[0].Trim(), int.Parse(split[1].Trim()));
                GetPairs(split[0].Trim());
            }

            var result = Pairs.OrderByDescending(x => x.Key);
            var sum = 0;
            var rate = Decks.Count;
            
            foreach (var keyValuePair in result)
            {
                if (keyValuePair.Value.Count == 1)
                {
                    if (!Decks.TryGetValue(keyValuePair.Value[0], out var deck)) continue;
                    sum += rate * deck;
                    rate--;
                }
                else
                {
                    keyValuePair.Value.Sort((a, b) => CompareHandsByCardStrength(b, a));

                    foreach (var deck in keyValuePair.Value)
                    {
                        if (!Decks.TryGetValue(deck, out var deckOut)) continue;
                        sum += rate * deckOut;
                        rate--;
                    }
                }
                
            }
            
            Console.Write(sum);
        }
    }
}