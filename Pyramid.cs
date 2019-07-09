﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MDPyramid
{
    public class Pyramid
    {
        private readonly Func<int?, bool> _even = n => n % 2 == 0;
        private readonly Func<int?, bool> _odd = n => n % 2 != 0;

        public int?[][] Matrix { get; set; }

        public Pyramid(string[] r)
        {
            Matrix = new int?[r.Length][];
            AddLines(r);
        }


        public void CleanInvalidNodes()
        {
            for (var i = 0; i < Matrix.Length; i++)
            {
                var wrong = _even(i) ? _odd : _even;
                for (var j = 0; j < Matrix[i].Length; j++)
                {
                    if (wrong(Matrix[i][j]))
                    {
                        Matrix[i][j] = default;
                    }
                }
            }
        }

        public void CleanUnreachableNodes()
        {
            for (var i = 0; i < Matrix.Length; i++)
            {
                for (var j = 0; j < Matrix[i].Length; j++)
                {
                    if (i + 1 < Matrix.Length
                        && Matrix.ElementAtOrDefault(i + 1, j) == default
                        && Matrix.ElementAtOrDefault(i + 1, j + 1) == default)
                    {
                        Matrix[i][j] = default;
                    }

                    if (i > 0
                        && Matrix.ElementAtOrDefault(i - 1, j) == default
                        && Matrix.ElementAtOrDefault(i - 1, j - 1) == default)
                    {
                        Matrix[i][j] = default;
                    }
                }
            }
        }

        public void Clean()
        {
            if (_odd(Matrix[0][0]))
            {
                Matrix = Matrix.ExpandArray();
                Matrix[0][0] = 0;
            }
            CleanInvalidNodes();
            CleanUnreachableNodes();

            Matrix = Matrix.resizeArray3();
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (var i = 0; i < Matrix.Length; i++)
            {
                Console.Write($"{i:D2}__");

                for (var j = 0; j < Matrix[i].Length; j++)
                {
                    Console.Write($"[{j:D2}] {Matrix[i][j]?.ToString("D3") ?? "   "} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void AddLines(string[] lines)
        {
            for (var i = 0; i < lines.Length; i++)
            {
                Matrix[i] = lines[i]
                    .Split(" ")
                    .Select(int.Parse)
                    .Cast<int?>()
                    .ToArray();
            }
        }

        public Path MySolve()
        {
            Clean();
            Print();
            var results = Solve(0, 0, 0, new List<int>());
            return results.OrderByDescending(x => x.Sum).First();
        }
        private IEnumerable<Path> Solve(int i, int j, int sum, List<int> path)
        {
            var start = Matrix.ElementAtOrDefault(i, j);
            if (start == default)
                yield break;

            if (i + 1 == Matrix.Length)
            {
                yield return new Path(new List<int>(path).MyAdd(start.Value), sum + start.Value) { };
                yield break;
            }

            foreach (var s in Solve(i + 1, j, start.Value + sum, new List<int>(path).MyAdd(start.Value)))
                yield return s;

            foreach (var s in Solve(i + 1, j + 1, start.Value + sum, new List<int>(path).MyAdd(start.Value))) yield return s;
        }
    }
}
