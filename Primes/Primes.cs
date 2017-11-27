namespace Primes
{
    using System;
    using System.Collections.Generic;

    public static class Primes
    {
        public static void Main()
        {
            var number = 13122004;

            Console.WriteLine($"Prime factors for {number}");
            Console.WriteLine($"==========================");
            ShowList(Generate(number));
            Console.WriteLine($"==========================");

            number = 104729;

            Console.WriteLine();
            Console.WriteLine($"Prime factors for {number}");
            Console.WriteLine($"==========================");
            ShowList(Generate(number));
            
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