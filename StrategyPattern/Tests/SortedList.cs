using System.Collections.Generic;
using StrategyPattern.Pattern;

namespace StrategyPattern.Tests
{
    using CodePatterns.Model;

    public class SortedList
    {
        private SortStrategy _sortStrategy;

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public List<Country> Sort(List<Country> unsortedList)
        {
            return _sortStrategy.Sort(unsortedList);
        }
    }
}