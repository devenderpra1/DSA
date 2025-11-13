// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

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


public static class Sorting
{
    public static string MergeTwoArray(string word1, string word2)
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
    public static void MergeSortOptimised(IList<int> inputarray, int leftStart, int rightEnd)
    {
        if (leftStart >= rightEnd)
            return;
        var mid = leftStart + (rightEnd - leftStart) / 2;

        MergeSortOptimised(inputarray, leftStart, mid);
        MergeSortOptimised(inputarray, mid + 1, rightEnd);
        var i = leftStart;
        var j = mid + 1;
        var k = 0;
        int[] currentFinalSorted = new int[rightEnd - leftStart + 1];
        while (i <= mid && j <= rightEnd)
        {
            if (inputarray[i] <= inputarray[j])
            {
                currentFinalSorted[k] = inputarray[i];
                i++;
            }
            else if (inputarray[i] > inputarray[j])
            {
                currentFinalSorted[k] = inputarray[j];
                j++;
            }
            k++;
        }
        while (i <= mid)
        {
            currentFinalSorted[k] = inputarray[i];
            i++; k++;
        }
        while (j <= rightEnd)
        {
            currentFinalSorted[k] = inputarray[j];
            j++;
        }
        for (var index = 0; index < currentFinalSorted.Length; index++)
        {
            inputarray[leftStart + index] = currentFinalSorted[index];
        }
    }
    public static IList<int> SortAndMerge(IList<int> inputArray)
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
    public static int InversionCount(IList<int> inputarray, int leftStart, int rightEnd)
    {
        if (leftStart >= rightEnd)
            return 0;
        var mid = leftStart + (rightEnd - leftStart) / 2;

        var currentAuxArray = new int[rightEnd - leftStart + 1];

        var sortAndCountLeft = InversionCount(inputarray, leftStart, mid);
        var sortAndCountRight = InversionCount(inputarray, mid + 1, rightEnd);

        var i = leftStart;
        var j = mid + 1;
        var k = 0;

        var inversionCountAccrossTwoArray = 0;
        while (i <= mid && j <= rightEnd)
        {
            if (inputarray[i] <= inputarray[j])
            {
                currentAuxArray[k] = inputarray[i];
                inversionCountAccrossTwoArray += (j - mid + 1);
                //this cannot be done as all the left will add up and loop will be closed before adding even first greater element
                i++;
            }
            else
            {
                currentAuxArray[k] = inputarray[j];
                //inversionCountInCommon += (mid - i + 1);
                j++;
            }
            k++;
        }
        while (i <= mid)
        {
            currentAuxArray[k] = inputarray[i];
            //inversionCountInCommon += (j - mid + 1);
            i++; k++;
        }
        while (j <= rightEnd)
        {
            currentAuxArray[k] = inputarray[j];
            j++; k++;
        }
        for (var index = 0; index < currentAuxArray.Length; index++)
        {
            inputarray[leftStart + index] = currentAuxArray[index];
        }
        return sortAndCountLeft + sortAndCountRight + inversionCountAccrossTwoArray;
    }
    public static void QuickSort(IList<int> inputArray)
    {
        QuickSort(inputArray, 0, inputArray.Count - 1);
    }
    public static void QuickSort(IList<int> inputArray, int leftStart, int rightEnd)
    {
        var pivot = ReArrangePivot(inputArray, leftStart, rightEnd);

        QuickSort(inputArray, leftStart, pivot - 1);
        QuickSort(inputArray, pivot + 1, rightEnd);
    }
    public static int ReArrangePivot(IList<int> inputArray, int leftStart, int rightEnd)
    {
        int i = leftStart + 1;
        int j = rightEnd;
        while (i <= j)
        {
            if (inputArray[leftStart] > inputArray[i])
            {
                i++;
            }
            else if (inputArray[j] >= inputArray[leftStart])
            {
                j--;
            }
            else
            {
                Swap(inputArray, i, j);
                i++; j--;
            }
        }
        Swap(inputArray, leftStart, j);
        return j;

    }
    public static void Swap(IList<int> inputArray, int from, int to)
    {
        var currentElement = inputArray[from];
        inputArray[from] = inputArray[to];
        inputArray[to] = currentElement;
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
                if (inputArray[j + 1] < inputArray[j])
                {
                    var currentElement = inputArray[j];
                    inputArray[j] = inputArray[j + 1];
                    inputArray[j + 1] = currentElement;
                }
            }
        }
    }
    public static void InsertionSort(IList<int> inputArray)
    {
        for (int i = 0; i < inputArray.Count - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (inputArray[j - 1] > inputArray[j])
                {
                    var currentElement = inputArray[j - 1];
                    inputArray[j - 1] = inputArray[j];
                    inputArray[j] = currentElement;
                }
                else
                    break;
            }
        }
    }

    public static int InversionCountAlongwithSortingAnArray(List<int> input, int left, int right)
    {
        var mid = left + (right - left) / 2;
        var leftCount = InversionCountAlongwithSortingAnArray(input, left, mid);
        var rightCount = InversionCountAlongwithSortingAnArray(input, mid + 1, right);

        var countAccrossArray = 0;
        var i = left;
        var j = mid + 1;
        var k = 0;
        var auxArray = new int[right - left + 1];
        while (i <= mid && j <= right)
        {
            if (input[i] <= input[j])
            {
                auxArray[k] = input[i];
                k++;
                i++;
            }
            else
            {
                auxArray[k] = input[j];
                countAccrossArray += (mid - i + 1);
                k++;
                j++;
            }
        }

        while (i <= mid)
        {
            auxArray[k] = input[i];
            k++;
            i++;
        }
        while (k <= right)
        {
            auxArray[k] = input[j];
            k++;
            j++;
        }

        var count = 0;
        for (var r = left; r <= right; r++)
        {
            input[r] = auxArray[count];
            count++;
        }
        return leftCount + rightCount + countAccrossArray;
    }
}