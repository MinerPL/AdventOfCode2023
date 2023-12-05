using System;
using System.Linq;

namespace Task4._1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 212; i++)
            {
                string line = Console.ReadLine();
                string[] items = line.Split(':');

                var numbers = items[1].Trim().Split('|');

                var winningNumbers = numbers[0].Trim().Split(' ');
                var cardNumbers = numbers[1].Trim().Split(' ');

                var sum2 = 0;
                
                foreach (var winningNumber in winningNumbers)
                {
                    if(winningNumber == "") continue;
                    if (cardNumbers.Contains(winningNumber))
                    {
                        if (sum2 == 0)
                        {
                            sum2 = 1;
                        }
                        else
                        {
                            sum2 *= 2;
                        }
                    }
                }

                sum += sum2;
            }

            Console.WriteLine(sum);
        }
    }
}