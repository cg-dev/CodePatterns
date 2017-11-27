namespace Primes
{
    using System.Collections.Generic;

    public static class Primes
    {
        public static List<int> Generate(int number)
        {
            var result = new List<int>();
            var divisor = 2;

            for (; number > 1; divisor++)
            {
                for (; number % divisor == 0; number /= divisor)
                {
                    result.Add(divisor);
                }
            }

            return result;
        }
    }
}