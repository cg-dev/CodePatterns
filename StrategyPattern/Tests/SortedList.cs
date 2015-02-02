using System.Collections.Generic;
using StrategyPattern.Pattern;

namespace StrategyPattern.Tests
{
    public class SortedList
    {
        private SortStrategy _sortStrategy;

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public string Sort(List<string> unsortedList)
        {
            return _sortStrategy.Sort(unsortedList);
        }
    }
}