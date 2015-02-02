using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    public class AscendingSort : SortStrategy
    {
        public override string Sort(List<string> list)
        {
            list.Sort();
            return "Sorted into ascending order";
        }
    }
}