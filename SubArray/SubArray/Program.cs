// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Solver.PrintSubArray(new List<int> { 0,1, 2, 3, 4 });



public static class Solver
{
    public static void PrintSubArray<T>(List<T> values)
    {
        for (int i = 0; i < values.Count; i++)
        {
            for (int j = i; j < values.Count; j++)
            {
                //Console.WriteLine(i + "," + j);// this will print you oly indices
                var output = string.Empty;
                for (int k = i; k <= j; k++)
                {
                    output += values[k];
                }
                Console.WriteLine(output);
            }
        }
        char[] chars = new char[1024];
        char[] charsa = new char[1024];
    }
}