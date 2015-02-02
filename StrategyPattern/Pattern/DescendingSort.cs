using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    public class DescendingSort : SortStrategy
    {
        public override string Sort(List<string> list)
        {
            list.Sort();
            return "Sorted into descending order";
        }
    }
}