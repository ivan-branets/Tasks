using System;

namespace Euclid
{
    class Program
    {
        static void Main()
        {
            const int n = 2166;
            const int m = 6099;

            Console.WriteLine(Euclid(n, m));
            Console.WriteLine(EuclidR(n, m));
            Console.WriteLine(EuclidD(n, m));
            Console.ReadKey();
        }

        static int Euclid(int n, int m)
        {

            for (var r = m % n; r != 0; r = m % n)
            {
                m = n;
                n = r;
            }

            return n;
        }

        static int EuclidR(int n, int m)
        {
            var r = m % n;
            return r == 0 ? n : EuclidR(r, n);
        }

        static int EuclidD(int n, int m)
        {
            var r = Math.Abs(m - n);
            return r == 0 ? n : EuclidR(r, Math.Min(m, n));
        }
    }
}
