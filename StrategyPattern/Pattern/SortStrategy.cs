using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    public abstract class SortStrategy
    {
        public abstract string Sort(List<string> list);
    }
}