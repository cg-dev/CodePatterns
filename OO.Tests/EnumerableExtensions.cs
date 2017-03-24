using System;
using System.Collections.Generic;
using System.Linq;

namespace OO.Tests
{
    public static class EnumerableExtensions
    {
        public static T Lowest<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey>
            => sequence
            .Select(o => Tuple.Create(o, criterion(o)))
            .Aggregate((Tuple<T, TKey>)null, (best, cur) => best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best)?.Item1;

        public static T Highest<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> 
            => sequence
            .Select(o => Tuple.Create(o, criterion(o)))
            .Aggregate((Tuple<T, TKey>)null, (best, cur) => best == null || cur.Item2.CompareTo(best.Item2) > 0 ? cur : best)?.Item1;
    }
}