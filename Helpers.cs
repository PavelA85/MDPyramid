using System;
using System.Linq;

namespace MDPyramid
{
    public static class Helpers
    {
        public static TSource ElementAtOrDefault<TSource>(this TSource[][] source, int index1, int index2)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var elementAtOrDefault = source.ElementAtOrDefault(index1);
            return elementAtOrDefault == default
                ? default
                : elementAtOrDefault.ElementAtOrDefault(index2);
        }
    }
}