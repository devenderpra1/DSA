// See https://aka.ms/new-console-template for more information

var typeOffunc = new TypeOfFunction();
//await typeOffunc.OnlyDoSomethingGetNothing(); cannot do this
typeOffunc.OnlyDoSomethingGetNothing();
var num = 1;
Console.WriteLine($"Hello, MAin Executed!,{Thread.CurrentThread.ManagedThreadId}");
num++;
var newNum = num;




public class TypeOfFunction
{
    public async void OnlyDoSomethingGetNothing()
    {
        DoSomethingGetNothingButEnsurity();
    }

    public async Task<int> DoSomethingGetNothingButEnsurity()
    {
        int i = 0;
        //DoSomethingGetSomethingWithTask();
        while (i < 50)
        {
            Console.WriteLine($"Hello while,{Thread.CurrentThread.ManagedThreadId}");
            i++;

           // new Task(() =>
            {
                //Thread.Sleep(5000);
                Console.WriteLine($"Hello,{Thread.CurrentThread.ManagedThreadId}");
            }
           // ).Start();
        }
        return i;
    }

    public Task DoSomethingGetSomethingWithTask()
    {
        return Task.CompletedTask;
    }

    public async void DoSomethingGetSomethingCallBack(Func<int, string> func)
    {

    }

    public async void DoSomethingGetSomethingCallBackDelegate(ReturnNothingCallBack returnNothingCallBack)
    {

    }

    public void JustDoSomething(string input)
    {
        Console.Write(input);
    }
}

public delegate void ReturnNothingCallBack(int num);