// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
MyClass.GetStatus();
MyClass.GetStatus();



public class MyClass
{
    public static async void GetStatus()
    {
        bool IsResultReady = false;
        Console.WriteLine("Wait");
        if(IsResultReady)
        {
            Console.WriteLine("Done");
            return;
        }

        Task.Delay(1000).Wait();
        IsResultReady = true;
    }
}