// using sequences rather than for each or for next loops
namespace OO.Tests
{
    using NUnit.Framework;
    using System;
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
                    Rate = 12.50,
                    Speed = TimeSpan.FromHours(.25)
                },
                new Painter
                {
                    IsAvailable = false,
                    Rate = 11.50,
                    Speed = TimeSpan.FromHours(.3)
                },
                new Painter
                {
                    IsAvailable = true,
                    Rate = 10.50,
                    Speed = TimeSpan.FromHours(.4)
                },
                new Painter
                {
                    IsAvailable = false,
                    Rate = 9.50,
                    Speed = TimeSpan.FromHours(.5)
                },
                new Painter
                {
                    IsAvailable = true,
                    Rate = 11.00,
                    Speed = TimeSpan.FromHours(.35)
                }
            };
        }

        [Test]
        public void GetCheapestAvailableShouldReturnCheapestAvailablePainter()
        {
            var result = _painters
                .Where(p => p.IsAvailable)
                .Lowest(p => p.EstimateCost(50));

            Assert.AreEqual(10.50 * 50, result.EstimateCost(50));
        }

        [Test]
        public void GetCheapestShouldReturnCheapestPainter()
        {
            var result = _painters
                .Lowest(p => p.EstimateCost(75));

            Assert.AreEqual(9.50 * 75, result.EstimateCost(75));
        }

        [Test]
        public void GetMostExpensiveShouldReturnMostExpensivePainter()
        {
            var result = _painters
                .Highest(p => p.EstimateCost(82.5));

            Assert.AreEqual(12.50 * 82.5, result.EstimateCost(82.5));
        }

        [Test]
        public void GetCheapestShouldReturnNullIfNoPaintersAreInTheSequence()
        {
            var painters = new List<Painter>();

            var result = painters
                .Lowest(p => p.EstimateCost(75));

            Assert.IsNull(result);
        }

        [Test]
        public void GetFastestShouldReturnFastestAvailablePainters()
        {
            var result = _painters
                .Lowest(p => p.EstimateTime(75));

            Assert.AreEqual(TimeSpan.FromHours(0.25 * 75), result.EstimateTime(75));
        }
    }
}