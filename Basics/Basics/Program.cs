// See https://aka.ms/new-console-template for more information
using System.Collections.ObjectModel;
UInt32 i = 6;
UInt32 j = 7;
UInt32 k = ~i;
var num = Convert.ToString(i,2).PadLeft(32,'0');
var num1 = Convert.ToString(j,2).PadLeft(32,'0');
var num2 = Convert.ToString(k,2).PadLeft(32,'0');


Console.WriteLine("Hello, World!");

public static class LinqExtention
{
    public static long flippingBits(long n)
    {
        var UnLong = (UInt32)Math.Abs(n);
        UInt32 k = ~UnLong;
        return k;
    }
    public static IEnumerable<T> ToEnumerable<T>(this T item)
    {
        yield return item;
    }

    public static TValue GetValueOrAddNew<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue Value)
    {
        if (dict.TryGetValue(key, out TValue value))
        {
            return value;
        }
        else
        {
            dict.Add(key, Value);
            return Value;
        }
    }

    public static int IndexOf<T>(this List<T> list, Predicate<T> selector)
    {
        var i = 0;
        foreach (var item in list)
        {
            if (selector(item))
            {
                return i;
            }
            i++;
        }
        return -1;
    }

    public static IEnumerable<T> AddRange<T>(this ICollection<T> enumerable, IEnumerable<T> itemToAdd)
    {
        foreach (var item in itemToAdd)
        {
            enumerable.Add(item);
        }
        return enumerable;
    }

    public static IDictionary<TKey, TValue> AddDictionary<TKey, TValue>(this IDictionary<TKey, TValue> OriginalDictionary, IDictionary<TKey, TValue> ValueToAdd)
    {
        foreach (var keyValuePair in ValueToAdd)
        {
            OriginalDictionary.Add(keyValuePair.Key, keyValuePair.Value);
        }
        return OriginalDictionary;
    }


    public static IEnumerable<T> GetFlattenList<T>(this IEnumerable<T> enumerable, IEnumerable<IEnumerable<T>> listToFlatten)
    {
        return listToFlatten.SelectMany(a => a);
    }



    public static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
    {
        int i = 1;
        Convert.ToByte(i);

        SinglyLinkedListNode head = llist;
        if (position == 1)
        {
            return new SinglyLinkedListNode() { data = data, next = head };
        }

        SinglyLinkedListNode current = llist;
        SinglyLinkedListNode next = llist;
        while (i < position)
        {
            current = next;
            next = current.next;
            i++;
        }
        current.next = new SinglyLinkedListNode() { data = data, next = next };
        return head;
    }

    //public static IEnumerable<T> SelectWhere<T>(this IEnumerable<T> enumerable, Func<> )
}

public class SinglyLinkedListNode
{
    public int data;
    public SinglyLinkedListNode next;
}