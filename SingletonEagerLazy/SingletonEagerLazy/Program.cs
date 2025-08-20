// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class SingletonEager
{
    private SingletonEager()
    {

    }

    private static SingletonEager instance = new SingletonEager(); // static field can be accessed by static method

    private object _lock = new object();

    public static SingletonEager GetInstance()
    {
        return instance;
    }
}


public class DBSingletonEager
{
    private DBSingletonEager(string url, string username, string password)
    {

    }

    private static DBSingletonEager instance = new DBSingletonEager("a", "a", "a"); // static field can be accessed by static method

    public static DBSingletonEager GetInstance()
    {
        return instance;
    }

    private string url;
    private string username;
    private string password;


    public void Connect()
    {
        //do something to connect
    }
}

public sealed class DBSingleton
{
    private DBSingleton(string url, string username, string password)
    {

    }

    private static DBSingleton instance; // static field can be accessed by static method

    private static object _lock = new object();

    public static DBSingleton GetInstance()
    {
        if (instance == null)
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new DBSingleton("a", "a", "a");
                    instance.Connect();
                    // this keyword cannot be used in static property
                }
            }
        }
        return instance;
    }

    private string url;
    private string username;
    private string password;


    public void Connect()
    {
        //do something to connect
    }

    public void ExecuteQuery(string query)
    {
        Console.WriteLine($"Executing query: {query}");
    }

    public void CloseConnection()
    {
        Console.WriteLine("Closing database connection.");
    }
}

