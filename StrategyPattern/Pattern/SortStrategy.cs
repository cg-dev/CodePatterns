using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    using CodePatterns.Model;

    public abstract class SortStrategy
    {
        public abstract List<Country> Sort(List<Country> list);
    }
}