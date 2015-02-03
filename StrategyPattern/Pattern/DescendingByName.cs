using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    using CodePatterns.Entities;

    public class DescendingByName : SortStrategy
    {
        public override List<Country> Sort(List<Country> list)
        {
            list.Sort();
            list.Reverse();

            return list;
        }
    }
}