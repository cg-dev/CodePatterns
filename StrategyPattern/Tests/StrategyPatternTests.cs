using CodePatterns.Entities;
using NUnit.Framework;
using StrategyPattern.Pattern;

namespace StrategyPattern.Tests
{
    [TestFixture]
    class StrategyPatternTests
    {
        [Test]
        public void StrategySortShouldPerformTheCorrectSortForTheStrategyPassedToIt()
        {
            var world = new World();
            var sortedList = new SortedList();

            var sortStrategy = SortStrategy(new AscendingSort);

            var result = sortedList.Sort(world.Countries.ToArray());

            Assert.AreEqual("Sorted ascending", result);
        }
    }
}
