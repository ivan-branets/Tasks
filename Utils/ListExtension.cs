using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtension
    {
        public static IList<T> Reverse<T>(this IList<T> collection, int start, int end)
        {
            for (; start < end; start++, end--)
            {
                collection.Switch(start, end);
            }

            return collection;
        }

        public static IList<T> Reverse<T>(this IList<T> collection, int start)
        {
            return collection.Reverse(start, collection.Count - 1);
        }

        public static IList<T> Reverse<T>(this IList<T> collection)
        {
            return collection.Reverse(0, collection.Count - 1);
        }

        public static IList<T> Switch<T>(this IList<T> collection, int indexA, int indexB)
        {
            var tmp = collection[indexA];
            collection[indexA] = collection[indexB];
            collection[indexB] = tmp;

            return collection;
        }

        public static IList<T> ShiftRight<T>(this IList<T> collection, int value)
        {
            return collection.Reverse().Reverse(0, value - 1).Reverse(value);
        }

        public static IList<T> ShiftLeft<T>(this IList<T> collection, int value)
        {
            value = collection.Count - value;
            return collection.ShiftRight(value);
        }

        public static IList<int> FillOrdered(this IList<int> collection, int length)
        {
            for (var i = 0; i < length; i++)
            {
                collection.Add(i);
            }

            return collection;
        } 
    }
}
