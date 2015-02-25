using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    using System.Linq;

    using CodePatterns.Model;

    public class AscendingByCurrency : SortStrategy
    {
        public override List<Country> Sort(List<Country> list)
        {
          return list.OrderBy(c => c.Currency).ToList();
        }
    }
}