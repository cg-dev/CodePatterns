namespace Primes
{
    using NUnit.Framework;

    [TestFixture]
    public class PrimesTests
    {
        [TestCase(1, new int[] { })]
        [TestCase(2, new int[] { 2 })]
        [TestCase(3, new int[] { 3 })]
        [TestCase(4, new int[] { 2, 2 })]
        [TestCase(5, new int[] { 5 })]
        [TestCase(6, new int[] { 2, 3 })]
        [TestCase(7, new int[] { 7 })]
        [TestCase(8, new int[] { 2, 2, 2 })]
        [TestCase(9, new int[] { 3, 3 })]
        [TestCase(10, new int[] { 2, 5 })]
        [TestCase(11, new int[] { 11 })]
        [TestCase(12, new int[] { 2, 2, 3 })]
        [TestCase(15, new int[] { 3, 5 })]
        [TestCase(24, new int[] { 2, 2, 2, 3 })]
        [TestCase(49, new int[] { 7, 7 })]
        public void CallingGenerateWithAValueShouldReturnAListOfPrimeFactors(int number, int[] expectedFactors)
        {
            var result = Primes.Generate(number).ToArray();

            Assert.AreEqual(expectedFactors.Length, result.Length);
            Assert.AreEqual(expectedFactors, result);
        }
    }
}