using System;
using System.Collections.Generic;
using System.Linq;

namespace MDPyramid
{
    public class Pyramid
    {
        private readonly Func<int?, bool> _even = n => n % 2 == 0;
        private readonly Func<int?, bool> _odd = n => n % 2 != 0;

        private int[][] Matrix { get; set; }

        public Pyramid(IReadOnlyList<string> lines)
        {
            Matrix = new int[lines.Count][];
            AddLines(lines);
        }

        public Path FindPath()
        {
            var bestPath = FindPaths(0, 0, new List<int>())
                .OrderByDescending(x => x.Sum)
                .First();
            Print(bestPath);
            return bestPath;
        }

        private IEnumerable<Path> FindPaths(int i, int j, IReadOnlyCollection<int> path)
        {
            var start = Matrix.ElementAtOrDefault(i, j);
            if (start == default)
            {
                yield break;
            }

            var isOK = _even(start) ? _odd : _even;
            var newPath = new List<int>(path) { start };

            if (i + 1 == Matrix.Length)
            {
                yield return new Path(newPath);
                yield break;
            }

            var down = Matrix.ElementAtOrDefault(i + 1, j);
            var diagonal = Matrix.ElementAtOrDefault(i + 1, j + 1);

            if (isOK(down))
            {
                foreach (var s in FindPaths(i + 1, j, newPath))
                {
                    yield return s;
                }
            }

            if (isOK(diagonal))
            {
                foreach (var s in FindPaths(i + 1, j + 1, newPath))
                {
                    yield return s;
                }
            }
        }

        private void Print(Path bestPath)
        {
            for (var i = 0; i < Matrix.Length; i++)
            {
                for (var j = 0; j < Matrix[i].Length; j++)
                {
                    var value = Matrix[i][j];
                    var best = bestPath.Nodes[i];
                    var print = value.ToString("D3");
                    if (value == best)
                    {
                        print = $"[{print}]";
                    }
                    Console.Write($"{print,-6}");
                }
                Console.WriteLine();
            }
        }

        private void AddLines(IReadOnlyList<string> lines)
        {
            for (var i = 0; i < lines.Count; i++)
            {
                Matrix[i] = lines[i]
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
            }
        }
    }
}

