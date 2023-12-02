using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      int result2 = 0;
      foreach (var i in Enumerable.Range(1, 1000))
      {
        var userInput = Console.ReadLine();
        List<char> result = new List<char>();
        foreach (var c in userInput)
        {
          if (Char.IsNumber(c))
          {
            result.Add(c);
          }
        }
        result2 += int.Parse($"{result.ToArray().First()}{result.ToArray().Last()}");
      }
      Console.WriteLine(result2);
    }
  }
}