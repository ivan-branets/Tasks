using System;
using System.Linq;
using System.Text;

namespace WhiteSpaces
{
    class Program
    {
        static void Main()
        {
            const string str = "123  \t\t4567 78\t\t\t\t9123  \t\t  5345\t \t  1234  \t\t2 3  4  \t\t  5\t";
            Console.WriteLine(Normalize(str).Trim());
            Console.WriteLine(NormalizePart(str).Trim());
            Console.ReadKey();
        }

        private const int BufferSize = 3;
        private static char _lastSymbol = ' ';

        static string Normalize(string str)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < str.Length; i += BufferSize)
            {
                var part = _lastSymbol + str.Substring(i, i + BufferSize < str.Length ? BufferSize : str.Length - i);
                var normalizedPart = NormalizePart(part);

                if (normalizedPart.Length == 0) continue;

                _lastSymbol = normalizedPart[normalizedPart.Length - 1];
                builder.Append(normalizedPart.Substring(0, normalizedPart.Length - 1));
            }

            return builder.ToString();
        }

        static string NormalizePart(string str)
        {
            var list = str.ToList();
            for (var i = 0; i < list.Count - 1; i++)
            {
                var curr = list[i];
                var next = list[i + 1];
                if (((curr == ' ' || curr == '\t') && curr == next) || (curr == '\t' && next == ' '))
                {
                    list.RemoveAt(i);
                    i--;
                    continue;
                }

                if (curr == ' ' && next == '\t')
                {
                    list.RemoveAt(i + 1);
                    i--;
                }
            }
            return new string(list.ToArray());
        }
    }
}
