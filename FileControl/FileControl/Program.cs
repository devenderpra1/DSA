// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

var Files = Directory.GetFiles("D:\\Scaler");
foreach (var currentFilePath in Files)
{
    if (currentFilePath.Contains("LLD"))
    {
        var Split = currentFilePath.Split('.');
        var number = Split.First().Substring(Split.First().Length - 1);
        try
        {
            var newFilename = currentFilePath.Replace($"{number}.LLD", $"LLD_{number}");
            Console.WriteLine(currentFilePath);
            Console.WriteLine(newFilename);
            Console.WriteLine("/\n");
            if (File.Exists(currentFilePath))
            {
                // Rename the file
                File.Move(currentFilePath, newFilename);
                Console.WriteLine("File renamed successfully.");
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
var arr = new List<int>();

for (var i = 0; i < arr.Count; i++)
{
    for (int j = i; j < arr.Count; j++)
    {
        for (int k = i; k < j; k++)
        {
            Console.WriteLine(arr[k]);
        }
    }
}

for (var i = 0; i < arr.Count; i++)
{
    var prefixSum = 0;
    for (int j = i; j < arr.Count; j++)
    {
        prefixSum += arr[j];
        Console.WriteLine(prefixSum);
    }
}

var totalSum = 0;
for (var i = 0; i < arr.Count; i++)
{
    totalSum += arr[i] * (i + 1) * (arr.Count - i);
}
