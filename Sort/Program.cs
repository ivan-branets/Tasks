using System;
using System.Collections.Generic;
using Extensions;

namespace Sort
{
    class Program
    {
        static void Main()
        {
            var list = new List<int>();

            list.GenerateRandomList(10, 10);
            list.Log();

            new List<int>(list).SelectionSort().Log();
            new List<int>(list).InsertionSort().Log();

            Console.ReadKey();
        }
    }

    internal static class Sort
    {
        public static IList<int> SelectionSort(this IList<int> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var minPos = i;
                for (var j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minPos])
                    {
                        minPos = j;
                    }
                }

                list.Switch(i, minPos);
            }

            return list;
        }

        public static IList<int> InsertionSort(this IList<int> list)
        {
            for (var i = 1; i < list.Count; i++)
            {
                var pos = i;
                for (var j = pos - 1; j >= 0 && list[pos] < list[j]; j--, pos--)
                {
                    list.Switch(pos, j);
                }
            }

            return list;
        }
    }
}
