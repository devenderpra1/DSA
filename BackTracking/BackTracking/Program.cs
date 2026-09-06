// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");


public class Backtrack
{
    public void CreateNumbers(int howManyDigits, List<int> option)
    {
        if (howManyDigits > 0)
            CreateNumbers(0, howManyDigits, option, new int[howManyDigits]);
    }

    private void CreateNumbers(int currentPlace, int totalNoOfPlaces, List<int> options, int[] finalNumber)
    {
        if (currentPlace == totalNoOfPlaces)
        {
            var sb = new StringBuilder();
            foreach (var number in finalNumber)
            {
                sb.Append(number);
            }
            Console.WriteLine(sb.ToString());
        }
        else
        {
            foreach (var number in options)
            {
                finalNumber[currentPlace] = number;
                CreateNumbers(currentPlace + 1, totalNoOfPlaces, options, finalNumber);
                finalNumber[currentPlace] = number;
            }
        }
    }


    public void CreateAllSubArray(List<int> array)
    {
        if (array.Count > 0)
            CreateSubArray(0, array, new bool[array.Count]);
    }

    private void CreateSubArray(int currentElement, List<int> array, bool[] finalNumbers)
    {
        if (currentElement == array.Count)
        {
            var sb = new StringBuilder();
            foreach (var shouldBeIncluded in finalNumbers)
            {
                if (shouldBeIncluded)
                {
                    sb.Append(array[currentElement] + ",");
                    Console.WriteLine("/n");

                }
            }
            Console.WriteLine(sb.ToString());
        }
        else
        {
            finalNumbers[currentElement] = true;
            CreateSubArray(currentElement + 1, array, finalNumbers);
            finalNumbers[currentElement] = false;
            CreateSubArray(currentElement + 1, array, finalNumbers);
        }
    }
}
