﻿using System.Collections.Generic;

namespace StrategyPattern.Pattern
{
    using CodePatterns.Entities;

    public abstract class SortStrategy
    {
        public abstract List<Country> Sort(List<Country> list);
    }
}