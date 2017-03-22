namespace OO.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class PainterTests
    {
        List<Painter> _painters;

        [SetUp]
        public void SetUp()
        {
            _painters = new List<Painter>
            {
                new Painter
                {
                    IsAvailable = true,
                    Rate = 12.50
                },
                new Painter
                {
                    IsAvailable = false,
                    Rate = 11.50
                },
                new Painter
                {
                    IsAvailable = true,
                    Rate = 10.50
                },
                new Painter
                {
                    IsAvailable = false,
                    Rate = 9.50
                },
                new Painter
                {
                    IsAvailable = true,
                    Rate = 11.00
                }
            };
        }

        [Test]
        public void GetCheapestAvailableShouldReturnCheapestAvailablePainter()
        {
            var result = _painters
                .Where(p => p.IsAvailable)
                .Lowest(p => p.Estimate(50));

            Assert.AreEqual(10.50 * 50, result.Estimate(50));
        }

        [Test]
        public void GetCheapestShouldReturnCheapestPainter()
        {
            var result = _painters
                .Lowest(p => p.Estimate(75));

            Assert.AreEqual(9.50 * 75, result.Estimate(75));
        }

        [Test]
        public void GetMostExpensiveShouldReturnMostExpensivePainter()
        {
            var result = _painters
                .Highest(p => p.Estimate(82.5));

            Assert.AreEqual(12.50 * 82.5, result.Estimate(82.5));
        }

        [Test]
        public void GetCheapestShouldReturnNullIfNoPaintersAreInTheSequence()
        {
            var painters = new List<Painter>();

            var result = painters
                .Lowest(p => p.Estimate(75));

            Assert.IsNull(result);
        }
    }
}