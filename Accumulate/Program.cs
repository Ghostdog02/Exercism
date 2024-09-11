using System;
using System.Collections.Generic;

namespace Accumulate
{
    public static class AccumulateExtensions
    {
        public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
        {
            
            var result = new Lazy<IEnumerable<U>>(() =>
            {
                var newCollection = new List<U>();

                foreach (var element in collection)
                {
                    //yield return func(element);

                    var newElement = func(element);
                    newCollection.Add(newElement);
                }

                return newCollection;
            });

            return (IEnumerable<U>)result;

            
        }
    }
}
