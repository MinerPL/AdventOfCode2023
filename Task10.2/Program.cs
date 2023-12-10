using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task10._2
{
    internal abstract class Program
    {
        private static readonly Dictionary<char, List<string>> Pipes = new Dictionary<char, List<string>>()
        {
            { '|', new List<string>() { "n", "s" } },
            { '-', new List<string>() { "w", "e" } },
            { 'L', new List<string>() { "n", "e" } },
            { 'J', new List<string>() { "n", "w" } },
            { '7', new List<string>() { "s", "w" } },
            { 'F', new List<string>() { "s", "e" } },
            { 'S', new List<string>() { "n", "s", "w", "e" } },
        };

        private static int[] FindStart(string[] lines)
        {
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'S')
                    {
                        return new[] {j, i};
                    }
                }
            }

            return new[] {0, 0};
        }

        private static readonly Dictionary<string, List<int[]>> C = new Dictionary<string, List<int[]>>();

        public static void Main(string[] args)
        {
            var lines = (File.ReadAllText("input.txt")).Replace("\r", "").Split('\n');

            var start = FindStart(lines);
            
            C.Add($"{start[0]}-{start[1]}", new List<int[]>());

            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    if (!Pipes.ContainsKey(line[x])) continue;
                    
                    var pipe = Pipes[line[x]];
                    
                    var moves = new List<int[]>();
                    
                    foreach (var direction in pipe)
                    {
                        switch (direction)
                        {
                            case "n":
                                moves.Add(new[] {0 + x, -1 + y});
                                break;
                            case "s":
                                moves.Add(new[] {0 + x, 1 + y});
                                break;
                            case "w":
                                moves.Add(new[] {-1 + x, 0 + y});
                                break;
                            case "e":
                                moves.Add(new[] {1 + x, 0 + y});
                                break;
                        }
                    }

                    foreach (var move in moves)
                    {
                        if (move[0] == start[0] && move[1] == start[1])
                        {
                            C[$"{start[0]}-{start[1]}"].Add(new []{x, y});
                        }
                    }
                    
                    if (start[0] == x && start[1] == y) continue;
                    if (C.TryGetValue($"{x}-{y}", out var items))
                    {
                        C[$"{x}-{y}"] = items.Concat(moves).ToList();
                    }
                    else
                    {
                        C.Add($"{x}-{y}", moves);
                    }
                }
            }
            
            Dictionary<string, int> visited = new Dictionary<string, int>()
            {
                {$"{start[0]}-{start[1]}", 0}
            };
            List<string> queue = new List<string>() {$"{start[0]}-{start[1]}"};

            while (queue.Count > 0)
            {
                var current = queue[0];
                queue.RemoveAt(0);

                if (!C.TryGetValue(current, out var value)) continue;
                foreach (var next in value)
                {
                    if (visited.ContainsKey($"{next[0]}-{next[1]}")) continue;
                    visited.Add($"{next[0]}-{next[1]}", visited[current] + 1);
                    queue.Add($"{next[0]}-{next[1]}");
                }
            }

            var sum = 1;
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                int p = 0;
                for (var x = 0; x < line.Length; x++)
                {
                    var con = lines[y][x];

                    if (visited.ContainsKey($"{x}-{y}"))
                    {
                        var pd = Pipes[con];
                        if (pd.Contains("n"))
                        {
                            p += 1;
                        }
                        continue;
                    }

                    if (p % 2 != 0)
                    {
                        sum += 1;
                    }
                }
            }
            
            
            
            Console.WriteLine(sum);
        }
    }
}