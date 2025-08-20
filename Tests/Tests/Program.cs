// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");



Tuple<string, int> tuple = new Tuple<string, int>("ABC",1);

var AnonymousType = new { Name = "ABC", Roll = 1 };

var anonymousArray = new[] { new { Name = "Student1" }, new { Name = "Student2" } };

var ValueTuple = (Name: "ABC", roll: 123);

//List<int> list = new List<int>() { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
//int n = 9;
//Console.WriteLine($"No of Pairs {Result.sockMerchant(n, list)}");
Sorting.maxMin(3, new List<int>() { 10, 100, 300, 200, 1000, 20, 30 });

Console.WriteLine( nameof(ValueTuple.Name));
/*nameof is a keyword which works during compilation.
 *So to Answer the first point to Access X.a you need an instance of the object
 *But the nameof() operator returns the name as a string instead of using the Reference of an object
 *The operators mostly have operand and do a set of operation which is tightly coupled with language. These can also have oveloaded.
 * Whereas function can take multiple parameters, can perform complex result and customizable.*/

class Result
{
    public static int sockMerchant(int n, List<int> ar)
    {
        Dictionary<int, int> numCounter = new Dictionary<int, int>();
        foreach (var num in ar)
        {
            if (numCounter.ContainsKey(num))
            {
                numCounter[num] = numCounter[num] + 1;
            }
            else
            {
                numCounter[num] = 1;
            }
        }
        int counts = 0;
        foreach (var num in numCounter)
        {
            if ((num.Value / 2) >= 1)
            {
                counts = counts + (int)num.Value / 2;
            }
        }
        return counts;
    }
}

class Sorting
{
    public static int maxMin(int k, List<int> arr)
    {
        arr.Sort();
        int prevdiff = Int32.MaxValue;
        for (int i = 0; i < arr.Count; i++)
        {
            if (i + k >= arr.Count)
            {
                break;
            }
            if (arr[i + k] - arr[i] < prevdiff)
            {
                prevdiff = arr[i + k] - arr[i];
            }
        }
        return prevdiff;
    }

}


