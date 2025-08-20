// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

(int, string) tuple = (1, "2");
tuple.Item1 = 4;

(int Roll, string Name) RollNAmes = (Roll: 2, Name: "Devender");

Tuple<int, String> tuple1 = new Tuple<int, string>(1, "2");
var dict = new Dictionary<int, List<string>>();
dict = null;
dict.AddRangeToList(1, new List<string>() { "1", "2", "3", "4" });
dict.AddRangeToList(1, new List<string>() { "1", "2", "3", "4" });


C c = new C();
B.Initialize(c);
Console.WriteLine($"{c.TransferA} \n{c.TransferB}");

public static class DictionaryExtention
{
    public static void AddRangeToList<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary, TKey key, List<TValue> values)
    {
        if (!dictionary.TryGetValue(key, out var value))
        {
            dictionary[key] = values;
        }
        else
            value.AddRange(values);
    }
}

class A
{
    public static int ConfigRead()
    {
        Console.WriteLine("a initilised");
        return 1;
    }

    static readonly int? a = ConfigRead();
    static int? A_b;
    public static void Initialize(Implement implement)
    {
        implement.TransferA = a;
        if (implement.TransferB == null)
        {
            B.Initialize(implement);
        }
        A_b = implement.TransferA.Value;

    }
}


class B
{
    public static int ConfigRead()
    {
        Console.WriteLine("b initilised");
        return 2;
    }
    static readonly int? b = ConfigRead();
    static int? B_a;
    public static void Initialize(Implement implement)
    {
        implement.TransferB = b;
        if (implement.TransferA == null)
        {
            A.Initialize(implement);
        }
        B_a = implement.TransferA.Value;
    }
}

class C : Implement
{
    public int? TransferA { get; set; }
    public int? TransferB { get; set; }
    public void Initialize()
    {
        if (TransferA == null)
        {
            A.Initialize(this);
        }
        if (TransferB == null)
        {
            B.Initialize(this);
        }

    }
}

interface Implement
{
    int? TransferA { get; set; }
    int? TransferB { get; set; }
    public void Initialize();
}