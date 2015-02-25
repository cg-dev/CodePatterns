using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    using System.Linq;

    using CodePatterns.Model;

    public class DescendingByName : SortStrategy
    {
        public override List<Country> Sort(List<Country> list)
        {
            return list.OrderByDescending(c => c.Name).ToList();
        }
    }
}