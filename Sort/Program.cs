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
            new List<int>(list).MergeSort().Log();

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

        public static IList<int> MergeSort(this IList<int> list)
        {
            _mergeSortArray = new int[list.Count];
            MergeSort(list, 0, list.Count - 1);

            return list;
        }

        private static void MergeSort(IList<int> list, int start, int end)
        {
            if (start == end) return;

            var middle = start + (end - start) / 2;

            MergeSort(list, start, middle);
            MergeSort(list, middle + 1, end);
            Merge(list, start, middle, end);
        }

        private static int[] _mergeSortArray;
        private static void Merge(IList<int> list, int start, int middle, int end)
        {
            list.CopyTo(_mergeSortArray, 0);

            var i = start;
            var j = middle + 1;

            for (var k = start; k <= end; k++)
            {
                if (i > middle) list[k] = _mergeSortArray[j++];
                else if (j > end) list[k] = _mergeSortArray[i++];
                else list[k] = _mergeSortArray[i] < _mergeSortArray[j] ? _mergeSortArray[i++] : _mergeSortArray[j++];
            }
        }
    }
}
