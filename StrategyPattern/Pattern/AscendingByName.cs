using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    using System.Linq;

    using CodePatterns.Model;

    public class AscendingByName : SortStrategy
    {
        public override List<Country> Sort(List<Country> list)
        {
            return list.OrderBy(c => c.Name).ToList();
        }
    }
}