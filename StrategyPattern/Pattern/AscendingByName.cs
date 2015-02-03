using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    using CodePatterns.Entities;

    public class AscendingByName : SortStrategy
    {
        public override List<Country> Sort(List<Country> list)
        {
          list.Sort();

          return list;
        }
    }
}