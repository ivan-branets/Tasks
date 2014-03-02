using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArrayMidian
{
    public class RandomCollection
    {
        public RandomCollection()
        {
            Random = new Random();
        }

        private const int MaxValue = 1000000;
        private Random Random { get; set; }

        public int this[long index]
        {
            get
            {
                return MaxValue - Random.Next(MaxValue);
            }
        }
    }
}
