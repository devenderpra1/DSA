// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var container =  new Container();
container.Register("A", () => A.Initialise(container));
container.Register("B", () => B.Initialise(container));
Test(container);


static void Test(Container container)
{
    Console.WriteLine(container.GetValue("B"));
    //Console.WriteLine(container.GetValue("A"));
}


public class Container
{
    public int GetValue(string id)
    {
        if (values.TryGetValue(id, out int value)) { return value; }
        var action = initializers[id];
        action();
        return values[id];
    }

    public void SetValue(string id, int value)
    {
        values[id] = value;
    }

    public void Register(string id , Action valueProvider)
    {
        initializers[id] = valueProvider;
    }

    Dictionary<string, int> values = new Dictionary<string, int>();
    Dictionary<string, Action> initializers = new Dictionary<string, Action>();
}

class A
{
    static int a;
    static int A_b;
    public static void Initialise(Container container)
    {
        a = 1;
        container.SetValue("A", a);
        var A_b = container.GetValue("B");
    }
}

class B
{
    static int b;
    static int B_a;
    public static void Initialise(Container container)
    {
        b = 1;
        container.SetValue("B", b);
         B_a = container.GetValue("A");
    }
}