// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine(Arrays.FindFirstMissingInteger(new List<int>() { 6, 4, 3, 5, 2, 1 }));

int[,] array = new int[6, 5] { { 0, 0, 0, 0, 1 }, { 0, 0, 1, 1, 1 }, { 0, 0, 0, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 0, 0, 1, 1, 1 } };
Console.WriteLine(Arrays.FindMaximumTrueOr1sInSortedBoolArray(array));
public class Arrays
{
    // Without Modifying will take S(N)
    public static int FindFirstMissingInteger(List<int> input)
    {
        int i = 0;
        while (i < input.Count)
        {
            if (input[i] > 0 && input[i] < input.Count && input[input[i] - 1] != input[i])
            {
                var correctPosition = input[i] - 1;
                input[i] = input[correctPosition];
                input[correctPosition] = correctPosition + 1;
            }
            else
                i++;
        }

        for (var k = 0; k < input.Count; k++)
        {
            if (k + 1 != input[k])
                return k + 1;
        }
        return -1;

    }

    public static int FindMaximumTrueOr1sInSortedBoolArray(int[,] ints)
    {
        int maxNoOfOnes = 0;
        int nextToSearch = ints.GetLength(1) - 1;
        for (var i = 0; i < ints.GetLength(0); i++)
        {
            for (var j = nextToSearch; j >= 0; j--)
            {
                if (ints[i, j] == 1)
                {
                    maxNoOfOnes = ints.GetLength(1) - j;
                }
                else
                {
                    nextToSearch = j;
                    break;
                }
            }
        }
        return maxNoOfOnes;
    }

    public static int KadaneWithNegativeNumber(int[] input)
    {
        if (input == null || !input.Any())
        {
            return 0;
        }

        int maxSum = input[0];
        int currentMax = input[0];

        var start = 0;
        var end = 0;

        for (var i = 1; i < input.Length; i++)
        {
            if (currentMax >= currentMax + input[i])
            {
                currentMax += input[i];
            }
            else
            {
                currentMax = input[i];
            }

            if (currentMax > maxSum)
            {

            }
        }
        return maxSum;
    }


    public static int KadaneWithPositiveSum(int[] input)
    {
        if (input == null || !input.Any())
        {
            return 0;
        }

        int maxSum = input[0];

        var answerStart = -1;
        var answerEnd = -1;

        var start = 0;
        var end = 0;

        var prefixSum = 0;

        for (var i = 0; i < input.Length; i++)
        {
            prefixSum += input[i];
            if (prefixSum < 0)
            {
                prefixSum = 0;
                start = i + 1;
            }
            if (prefixSum > maxSum)
            {
                maxSum = prefixSum;
                answerStart = start;
                answerEnd = end = i;
            }
        }

        return maxSum;
    }
}