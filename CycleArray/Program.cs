using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Extensions;

namespace ShiftArray
{
    class Program
    {
        static void Main()
        {
            var collection = new List<int>().FillOrdered(10);

            collection.ShiftRight(3);

            collection.Log();

            collection.ShiftLeft(3);

            collection.Log();

            Console.ReadKey();
        }
    }
}
