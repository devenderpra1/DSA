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
            int number = 0;
            for (var index = finalNumber.Length; index > 0; index--)
            {
                number = number * 10 + finalNumber[index - 1];
                //sb.Append(number);
            }
            //Console.WriteLine(sb.ToString());
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

    public void CreateCombination(int noOfPlaces, int maxNumberToUse)
    {
        List<int> currentSelection = new List<int>();
        if (noOfPlaces > 0)
        {
            CreateCombination(0,0, noOfPlaces, maxNumberToUse, currentSelection);
        }
    }

    public void CreateCombination(int currentPosition, int  int noOfPlaces, int maxNumberToUse, List<int> currentSelection)
    {
        if (currentPosition == noOfPlaces)
        {
            for (int i = 0; i < maxNumberToUse; i++)
            {
                if ()
            }
        }
        else
        {
            for (int i = currentPosition; i < maxNumberToUse; i++)
            {
                CreateCombination(i, noOfPlaces, maxNumberToUse, currentSelection);
            }
        }
    }

}
