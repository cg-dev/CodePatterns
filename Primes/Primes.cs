using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    public static class Primes
    {
        public static List<int> Generate(int number)
        {
            var result = new List<int>();
            var divisor = 2;

            while (number > 1)
            {
                for (; number % divisor == 0; divisor++)
                {
                    result.Add(divisor);
                    number /= divisor;
                }
                //divisor++;
            }

            return result;
        }
    }
}