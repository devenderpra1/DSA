public class MyClass
{
    public static async Task MyAsyncStaticMethod(int id)
    {
        Console.WriteLine($"Start of MyAsyncStaticMethod for ID: {id}");
        await Task.Delay(2000); // Simulate an asynchronous operation
        Console.WriteLine($"End of MyAsyncStaticMethod for ID: {id}");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        var task1 = MyClass.MyAsyncStaticMethod(1);
        var task2 = MyClass.MyAsyncStaticMethod(2);

        // Wait for both tasks to complete
        await Task.WhenAll(task1, task2);
    }
}