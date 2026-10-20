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
            for (int i = 0; i < array.Count; i++)
            {
                if (finalNumbers[i])
                {
                    sb.Append(array[i] + ",");
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
        int[] currentSelection = new int[noOfPlaces];
        if (noOfPlaces > 0)
        {
            CreateCombination(0, 0, noOfPlaces, maxNumberToUse, currentSelection);
        }
    }

    public void CreateCombination(int currentPosition, int currentElement, int noOfPlaces, int maxNumberToUse, int[] currentSelection)
    {
        if (currentPosition == noOfPlaces)
        {
            int finalNum = 0;
            for (int i = 0; i < maxNumberToUse; i++)
            {
                finalNum = finalNum * 10 + currentSelection[i];
            }
        }
        else
        {
            for (int i = currentPosition; i < maxNumberToUse; i++)
            {
                currentSelection[currentPosition] = i;
                CreateCombination(currentPosition + 1, i + 1, noOfPlaces, maxNumberToUse, currentSelection);
            }
        }
    }

    public int MinSubArrayLen(int target, int[] nums)
    {
        int[] prefixSum = new int[nums.Length + 1];

        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        int j = 0;
        int k = 0;
        var minLength = Int32.MaxValue;
        var currentSum = 0;
        while (j < prefixSum.Length && k < prefixSum.Length)
        {
            currentSum = prefixSum[k] - prefixSum[j];
            if (currentSum == target)
            {
                var currentLength = k - j;
                if (currentLength < minLength)
                {
                    minLength = currentLength;
                }
                j++;
            }
            else if (currentSum < target)
            {
                k++;
            }
            else
            {
                j++;
            }
        }
        return minLength == Int32.MaxValue ? 0 : minLength;
    }

    public int MinSubArrayLenOfLengthK(int target, int[] nums)
    {


        return 0;
    }

}
