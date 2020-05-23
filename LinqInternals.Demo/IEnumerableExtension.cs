using System;
using System.Collections.Generic;

namespace LinqInternals.Demo
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<T> NewWhere<T>(this IEnumerable<T> items,
            Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> NewSelect<T, TResult>(this IEnumerable<T> items,
            Func<T, TResult> selector)
        {
            foreach (var item in items)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> NewSelectMany<T, TResult>(this IEnumerable<T> items,
            Func<T, IEnumerable<TResult>> selector)
        {
            foreach (var item in items)
            {
                foreach (var innerItem in selector(item))
                {
                    yield return innerItem;
                } 
            }
        }

        public static IEnumerable<TResult> NewJoin<T, TH, TKey, TResult>(
            this IEnumerable<T> items,
            IEnumerable<TH> innerItems,
            Func<T, TKey> outerKeySelector,
            Func<TH, TKey> innerKeySelector,
            Func<T, TH, TResult> resultSelector
            )
        {
            foreach (var item in items)
            {
                foreach (var innerItem in innerItems)
                {
                    if (outerKeySelector(item).Equals(innerKeySelector(innerItem)))
                    {
                        yield return resultSelector(item, innerItem);
                    }
                }
            }
        }
    }
}
