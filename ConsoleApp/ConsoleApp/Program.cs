// See https://aka.ms/new-console-template for more information
using ConsoleApp;

//var threadChecks = new ThreadChecks();
//ThreadStart threadstart = threadChecks.GetNothingDosomething;
//Thread Thread = new Thread(new ThreadStart(() => Console.WriteLine()));
//Thread.Start();

//int a = 1;
//ParameterizedThreadStart threadstart1 = threadChecks.DoSomethingGetSomeThing;
//Thread Thread2 = new Thread(threadstart1);
//Thread2.Start(a);

await Task.Run(() => Console.WriteLine());

Func<int> func = () => 1;
var abc = await Task.Run(func);

Func<int, int> func2 = (x) => x * x;

var abc1 = await Task.Run(func2());

int GEtInt()
{
    return 1;
}
//Console.WriteLine("Hello, World!");
//P p1 = new A();
//P p2 = new C();
//var check = p2 as A;

//var CallBack = new CallBack();
//var request = new Request();
//request.Validation = RequestValidation.Verified;
//CallBack.GetReport(request);



//Console.WriteLine("calling overrride :" + p1.GEtNAmevirtual());
//Console.WriteLine("calling hiding :" + p2.GEtNAmevirtual());


public class TaskReturn
{

    public async Task<int> ReturnAsync()
    {
        return 4;
    }
    public async void Return()
    {
        //DO Something and don't return anything
    }
}


public class P
{

    public virtual int GEtNAmevirtual()
    {
        return 5;
    }
}

public class A : P
{
    public override int GEtNAmevirtual()
    {
        return 4;
    }
}

public class C : P
{
    public new int GEtNAmevirtual()
    {
        return 6;
    }
}