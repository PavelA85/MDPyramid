using System;
using System.Collections.Generic;
using System.Linq;

namespace MDPyramid
{
    public static class Helpers
    {
        /// <summary>Returns the element at a specified index1 in a sequence or a default value if the index1 is out of range.</summary>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return an element from.</param>
        /// <param name="index1">The zero-based index1 of the element to retrieve.</param>
        /// <param name="index2"></param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>
        /// <see langword="default" />(<paramref name="TSource" />) if the index1 is outside the bounds of the source sequence; otherwise, the element at the specified position in the source sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is <see langword="null" />.</exception>
        public static TSource ElementAtOrDefault<TSource>(this TSource[,] source, int index1, int index2)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (index1 >= 0 && index2 >= 0)
            {
                if (index1 >= source.GetLength(0))
                {
                    return default;
                }
                if (index2 >= source.GetLength(1))
                {
                    return default;
                }

                return source[index1, index2];
            }
            return default;
        }

        public static TSource ElementAtOrDefault<TSource>(this TSource[][] source, int index1, int index2)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var elementAtOrDefault = source.ElementAtOrDefault(index1);
            return elementAtOrDefault == default
                ? default
                : elementAtOrDefault.ElementAtOrDefault(index2);
        }
        public static T[,] ResizeArray<T>(this T[,] original, int x, int y)
        {
            var newArray = new T[x, y];
            var minX = Math.Min(original.GetLength(0), newArray.GetLength(0));
            var minY = Math.Min(original.GetLength(1), newArray.GetLength(1));

            for (var i = 0; i < minY; ++i)
                Array.Copy(original, i * original.GetLength(0), newArray, i * newArray.GetLength(0), minX);

            return newArray;
        }

        public static T[][] NormalizeArray<T>(this T[][] matrix, T value)
        {
            var array = new T[matrix.Length + 1][];
            matrix.CopyTo(array, 1);
            array[0] = new[] { value };
            return array;
        }

        public static T[][] ReduceArray<T>(this T[][] matrixToResize)
        {
            return matrixToResize.Skip(1).ToArray();
        }

        public static List<T> AddAndReturn<T>(this List<T> that, T item)
        {
            that.Add(item);
            return that;
        }
    }
}