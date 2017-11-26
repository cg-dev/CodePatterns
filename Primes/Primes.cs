using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    public static class Primes
    {
        public static int[] Generate(int value)
        {
            return value == 1 ? new int[] { } : new int[] { 2 };
        }
    }
}
