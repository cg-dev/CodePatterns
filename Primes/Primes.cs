namespace Primes
{
    using System;
    using System.Collections.Generic;

    public static class Primes
    {
        public static void Main()
        {
            const int Number = 13122004;

            Console.WriteLine($"Prime factors for {Number}");
            Console.WriteLine($"==========================");

            ShowList(Generate(Number));

            Console.WriteLine($"==========================");
            Console.WriteLine($"Press any key to continue.");

            Console.ReadKey();
        }

        private static void ShowList(List<int> primeFactors)
        {
            foreach (var primeFactor in primeFactors)
            {
                Console.WriteLine(primeFactor);
            }
        }

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