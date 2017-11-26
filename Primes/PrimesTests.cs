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
        public void CallingGenerateWithAValueShouldReturnAListOfPrimeFactors(int number, int[] expectedFactors)
        {
            Assert.AreEqual(expectedFactors.Length, Primes.Generate(number).Length);
            Assert.AreEqual(expectedFactors, Primes.Generate(number));
        }
    }
}