using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;

namespace Permutations
{
    class Program
    {
        static void Main()
        {
            var array = GetInitialPermutation(5).ToArray();
            foreach (var permutation in GetPermutations(array))
            {
                permutation.Log();
            }

            Console.ReadKey();
        }

        private static IEnumerable<int> GetInitialPermutation(int length)
        {
            for (var i = 1; i <= length; i++)
            {
                yield return i;
            }
        }

        private static IEnumerable<IEnumerable<int>> GetPermutations(int[] array)
        {
            yield return array;

            while (true)
            {
                int i;
                for (i = array.Length - 2; i >= 0 && array[i] > array[i + 1]; i--) { }

                if (i == -1)
                {
                    break;
                }

                Exchange(array, i, GetMaxJ(array, i));
                Flip(array, i + 1);

                yield return array;
            }
        }

        private static int GetMaxJ(IList<int> array, int i)
        {
            var maxJ = i + 1;
            for (var j = maxJ + 1; j < array.Count; j++)
            {
                if (array[i] < array[j])
                {
                    maxJ = j;
                }
            }
            return maxJ;
        }

        private static void Flip(int[] array, int i)
        {
            var j = array.Length - 1;

            for (; i < j; i++, j--)
            {
                Exchange(array, i, j);
            }
        }

        private static void Exchange(int[] array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
