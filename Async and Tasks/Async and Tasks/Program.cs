// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

KindsOfMethods KindsOfMethods = new KindsOfMethods();
Thread Thread1 = new Thread(KindsOfMethods.PrintOnce);
Thread Thread2 = new Thread(KindsOfMethods.PrintOnce);
Thread Thread3 = new Thread(KindsOfMethods.PrintOnce);
Thread1.Start();
Thread2.Start();
Thread3.Start();



public class KindsOfMethods
{
    public static void printMessage()
    {
        Task.Run(() => Thread.Sleep(200000));
        Console.WriteLine("Print Ended");
    }

    public void PrintOnce()
    {
        lock (this)
        {
            Console.WriteLine("Print Started");
            Thread.Sleep(10000);
            Console.WriteLine("Print Ended");
        }
        Console.WriteLine("Cosequent calls but not affecting locked things");
    }
}