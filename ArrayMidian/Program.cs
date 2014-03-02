using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrayMidian
{
    class Program
    {
        static void Main()
        {
            const long lenght = 2684354560;
            const int threadCount = 2;

            var mainList = new BlockingCollection<List<long>>();

            var start = DateTime.Now;

            Parallel.For(0, threadCount, i =>
            {
                var collection = new RandomCollection();                
                var list = new List<long>();

                long sum = 0;
                long count = 0;

                const long localLenght = lenght/threadCount;

                for (long j = 0; j < localLenght; j++)
                {
                    sum += collection[j];                        
                    count++;

                    if (sum > int.MaxValue || sum < int.MinValue || j == localLenght - 1)
                    {
                        if (count > 0)
                        {
                            list.Add(sum / count);                                

                            count = 0;
                            sum = 0;
                        }
                    }
                }

                mainList.Add(list);
            }
                );

            var median = mainList.Sum(l => l.Sum()) / mainList.Sum(l => l.Count);

            Console.WriteLine(DateTime.Now - start);
            Console.WriteLine(median);

            Console.ReadKey();
        }
    }
}
