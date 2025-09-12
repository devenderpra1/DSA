// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Int64 n = 64;
var number = Convert.ToUInt32(n);
var numberstrin = Convert.ToString(n, 2);
foreach (var i in numberstrin)
{
    Convert.ToUInt32(i);
}



foreach (var a in Sorting.MergeSort(new List<int> { 3, 5, 1, 2, 5 }))
{
    Console.WriteLine(a);

}

Sorting.MergeSort(new List<int> { 3, 5, 1, 2 }).ForEach(x => Console.WriteLine(x));


public class Sorting
{
    public string MergeTwoArray(string word1, string word2)
    {
        int i = 0, j = 0;
        char[] newWord = new char[word1.Length + word2.Length];
        while (i < word1.Length && j < word2.Length)
        {
            if (i <= j)
            {
                newWord[i + j] = word1[i];
                i++;
            }
            else
            {
                newWord[i + j] = word2[j];
                j++;
            }
        }
        if (i < word1.Length)
        {
            for (int k = i; k < word1.Length; k++)
            {
                newWord[i + j] = word1[i];
                i++;
            }
        }
        if (j < word2.Length)
        {
            for (int k = j; k < word1.Length; k++)
            {
                newWord[i + j] = word2[j];
                j++;
            }
        }
        return new string(newWord);
    }

    public static List<int> MergeSort(List<int> input)
    {
        if (input.Count == 1)
        {
            return input;
        }
        List<int> finalList = new List<int>();
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        int counter = 0;
        while (counter < input.Count)
        {
            if (counter < input.Count / 2)
            {
                leftList.Add(input[counter]);
            }
            else
            {
                rightList.Add(input[counter]);
            }
            counter++;
        }
        leftList = MergeSort(leftList);
        rightList = MergeSort(rightList);
        int i = 0, j = 0;
        while (i < leftList.Count && j < rightList.Count)
        {
            if (leftList[i] <= rightList[j])
            {
                finalList.Add(leftList[i]);
                i++;
            }
            else if (leftList[i] > rightList[j])
            {
                finalList.Add(rightList[j]);
                j++;
            }
        }
        if (i < leftList.Count)
        {
            while (i < leftList.Count)
            {
                finalList.Add(leftList[i]);
                i++;
            }
        }
        else if (j < rightList.Count)
        {
            while (j < rightList.Count)
            {
                finalList.Add(rightList[j]);
                j++;
            }
        }
        return finalList;
    }

    public static void SelectionSort(IList<int> inputArray)
    {
        for (int index = 0; index < inputArray.Count; index++)
        {
            // To iterate each index
            var min = Int32.MaxValue;
            var swapIndex = -1;
            for (int currIndex = index; currIndex < inputArray.Count; currIndex++)
            {
                // To find Maximum
                if (inputArray[currIndex] < min)
                {
                    min = inputArray[currIndex];
                    swapIndex = currIndex;
                }
            }
            //Swap
            var currentElement = inputArray[index];
            inputArray[index] = inputArray[swapIndex];
            inputArray[swapIndex] = currentElement;
        }
    }

    public static void BubbleSort(IList<int> inputArray)
    {
        for (int index = 0; index < inputArray.Count; index++)
        {
            for (int j = 0; j < inputArray.Count - index - 1; j++)
            {
                if (inputArray[j] < inputArray[j + 1])
                {
                    var currentElement = inputArray[j];
                    inputArray[j] = inputArray[j + 1];
                    inputArray[j + 1] = currentElement;
                }
            }
        }
    }


    public IList<int> SortAndMerge(IList<int> inputArray)
    {
        List<int> sorted = new List<int>();
        IList<int> currentLeft = new List<int>();
        IList<int> currentRight = new List<int>();

        for (int counter = 0; counter < inputArray.Count; counter++)
        {
            if (counter < inputArray.Count / 2)
            {
                currentLeft.Add(inputArray[counter]);
            }
            else
            {
                currentRight.Add(inputArray[counter]);
            }
        }
        currentLeft = SortAndMerge(currentLeft);
        currentRight = SortAndMerge(currentRight);
        int i = 0;
        int j = 0;

        while (i < currentLeft.Count && j < currentRight.Count)
        {
            if (currentLeft[i] < currentRight[j])
            {
                sorted.Add(currentLeft[i]);
                i++;
            }
            else
            {
                sorted.Add(currentRight[j]);
                j++;
            }
        }
        if (i < currentLeft.Count + 1)
        {
            for (; i < currentLeft.Count; i++)
            {
                sorted[i + j] = currentLeft[i];
            }
        }
        else if (j < currentRight.Count + 1)
        {
            for (; j < currentRight.Count; j++)
            {
                sorted[i + j] = currentRight[j];
            }
        }
        return sorted;
    }

}