using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    using System.Linq;

    using CodePatterns.Entities;

    public class DescendingByCurrency : SortStrategy
    {
        public override List<Country> Sort(List<Country> list)
        {
          return list.OrderByDescending(c => c.Currency).ToList();
        }
    }
}