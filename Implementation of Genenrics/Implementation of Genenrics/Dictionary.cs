using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation_of_Genenrics
{
    public static class Dictionary
    {
        public static KeyValuePair<TKey, ICollection<T>()) AddValue<TKey, T>(this IDictionary<TKey, ICollection> dictionary, TKey Key, ICollection<T> Value)
        {
            if (dictionary.TryGetValue(Key, out ICollection value))
            {
                if (value != null)
                {
                    value.AddRange(Value);
                }
            }
            return new KeyValuePair<TKey, TValue>(Key, Value);
        }
        public static IEnumerable<T> AddRange<T>(this ICollection<T> enumerable, IEnumerable<T> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                enumerable.Add(item);
            }
            return enumerable;
        }
    }

}
