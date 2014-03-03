using System.Collections;

namespace Extensions
{
    public static class EnumerableExtension
    {
        public static void Log(this IEnumerable collection)
        {
            foreach (var e in collection)
            {
                System.Console.Write("{0} ", e);
            }

            System.Console.WriteLine();
        }
    }
}
