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
            var sortStrategy = new AscendingByName();

            var result = sortStrategy.Sort(new World().Countries);

            Assert.Less(result[0].Name, result[result.Count - 1].Name);
        }
        
        [Test]
        public void StrategySortShouldPerformTheCorrectSortForTheDescendingStrategy()
        {
            var sortStrategy = new DescendingByName();

            var result = sortStrategy.Sort(new World().Countries);

            Assert.Less(result[result.Count - 1].Name, result[0].Name);
        }    
    
        [Test]
        public void StrategySortShouldPerformTheCorrectSortForTheAscendingByCurrencyStrategy()
        {
            var sortStrategy = new AscendingByCurrency();

            var result = sortStrategy.Sort(new World().Countries);

            Assert.Less(result[0].Currency, result[result.Count - 1].Currency);
        }    

        [Test]
        public void StrategySortShouldPerformTheCorrectSortForTheDescendingByCurrencyStrategy()
        {
            var sortStrategy = new DescendingByCurrency();

            var result = sortStrategy.Sort(new World().Countries);

            Assert.Less(result[result.Count - 1].Currency, result[0].Currency);
        }
    }
}
