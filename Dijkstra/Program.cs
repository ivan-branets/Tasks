using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class Program
    {
        private const int M = int.MaxValue / 2;
        private const int L = 5;

        private static void Main()
        {
            var waights = new[,]
            {
                {M, 10, 30, 50, 10},
                {M, M, M, M, M},
                {M, M, M, M, 10},
                {M, 40, 20, M, M},
                {10, M, 10, 30, M}
            };

            var curr = 0;

            var currPassWaights = InitPath(curr);
            var passed = new List<int>();
            
            var shortestWay = new int[L];

            for (var i = 0; i < L; i++)
            {
                shortestWay[i] = curr;
            }

            for (var i = 0; i < L; i++)
            {
                Console.Write("{0} ", curr);
                passed.Add(curr);

                for (var j = 0; j < L; j++)
                {
                    var newWaight = currPassWaights[curr] + waights[curr, j];
                    if (newWaight < currPassWaights[j])
                    {
                        currPassWaights[j] = newWaight;
                        shortestWay[j] = curr;
                    }
                }

                curr = GetNextVertex(passed, currPassWaights);
            }

            Console.WriteLine();
            for (var j = 0; j < L; j++)
            {
                Console.Write("{0} ", currPassWaights[j]);
            }

            Console.WriteLine();
            for (var j = 0; j < L; j++)
            {
                Console.Write("{0} ", shortestWay[j]);
            }

            Console.ReadKey();
        }

        private static List<int> InitPath(int start)
        {
            var list = new List<int>();
            for (var i = 0; i < L; i++)
            {
                list.Add(M);
            }

            list[start] = 0;

            return list;
        }

        private static int GetNextVertex(IList<int> passed, IList<int> currPassWaights)
        {
            var minInd = -1;
            var minValue = int.MaxValue;

            for (var i = 0; i < L; i++)
            {
                if (!passed.Contains(i) && currPassWaights[i] < minValue)
                {
                    minInd = i;
                    minValue = currPassWaights[minInd];
                }
            }

            return minInd;
        }
    }
}
