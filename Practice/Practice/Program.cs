// See https://aka.ms/new-console-template for more information
using System.Reflection.PortableExecutable;
using System.Text;

int num = 25;
var res = new Result();
//Console.WriteLine(res.GetSquareRoot(24));
//Console.WriteLine(res.GetSquareRoot(16));
//Console.WriteLine(res.GetSquareRoot(4));
//Console.WriteLine(res.GetSquareRoot(25));

// array
//var array = new int[2, 2];
//array[0, 0] = 1;
//array[0, 1] = 2;
//array[1, 0] = 3;
//array[1, 1] = 4;
////Console.WriteLine(array.ToString());
////var final = res.RotateArray(array);
//res.TraverseArray(array);
//res.GetOpenDoor(10);

//for (int i = 1; i < 16; i++)
//{

//    res.TheLastSurvived(i);
//}

//res.ReverseSentenceButNotWordsWithDelimiter("abc_def_get");

//res.IndexOfSubArrayWithSumValue(new[] { 5, 1, 2, -3, 1, 4, -2 }, 0);
//res.IndexOfSubArrayWithSumValueWithoutSpace(new[] { 5, 1, 2, -3, 1, 4, -2 }, 0);
//res.DistictElementInSubArray(new[] { 3, 3, 3, 3, 1, 3, 3 }, 3);

//Console.WriteLine(res.GetHCForGCD(5, 5));
//Console.WriteLine(res.GetHCForGCD(5, 0));
//Console.WriteLine(res.GetHCForGCD(5, 1));
//Console.WriteLine(res.GetHCForGCD(15, 20));
//Console.WriteLine(res.GetHCForGCD(4, 2));

Console.WriteLine(string.Join(",", res.GetPrimeNumbers(50)));
res.GetLowestPrimeFactor(50);
Console.WriteLine("Hello, World!");


class Result
{
    #region
    //Math Operation
    public void GetFactors(int num)
    {
        for (var i = 0; i * i <= num; i++)
        {
            if (num % i == 0)
            {
                var otherFactor = num / i;
                if (i != otherFactor)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(i);
                    Console.WriteLine(num / i);
                }
            }
        }
    }

    public double GetSquareRoot(double num)
    {
        double x = 0;
        double y = num / 2;

        while (x <= y)
        {
            var mid = (x + y) / 2;
            var sq = mid * mid;
            if (sq == num)
                return mid;
            else if (sq < num)
                x = mid + 1;
            else
                y = mid - 1;
        }
        return -1;
    }

    public int PowerOfNumber(int num, int power)
    {
        var outputPower = 1;
        int i = 0;
        while (i < power)
        {
            outputPower *= num;
            i++;
        }
        return outputPower;
    }

    public double PowerOfNumber(double baseNum, double power)
    {
        if (power == 0)
            return 1;
        if (power == 1)
            return baseNum;
        var actualPower = 0.0;
        var halfPower = PowerOfNumber(baseNum, Math.Floor(power / 2));
        actualPower = halfPower * halfPower;
        if (power % 2 != 0)
        {
            actualPower *= baseNum;
        }
        return power < 0 ? 1 / actualPower : actualPower;
    }

    #endregion


    public static int GetPriceAtWhichWhereInvestThenSellNextDay(List<int> ratesForEachDay)
    {
        if (ratesForEachDay.Count == 0)
        {
            return -1;
        }
        var previousOption = ratesForEachDay[0];
        var maxProfit = 0;
        for (var i = 1; i < ratesForEachDay.Count; i++)
        {
            if (previousOption < ratesForEachDay[i])
            {
                var currentProfit = ratesForEachDay[i] - previousOption;
                if (currentProfit > maxProfit)
                    maxProfit = currentProfit;
            }
            previousOption = ratesForEachDay[i];
        }
        return maxProfit;
    }

    public static int GetPriceAtWhichWhenToInvestThenSell(List<int> ratesForEachDay)
    {
        if (ratesForEachDay.Count == 0)
        {
            return -1;
        }
        var minBuy = ratesForEachDay[0];
        var maxProfit = 0;

        for (var i = 1; i < ratesForEachDay.Count; i++)
        {
            if (minBuy > ratesForEachDay[i])
            {
                minBuy = ratesForEachDay[i];
            }
            else
            {
                var currentProfit = ratesForEachDay[i] - minBuy;
                if (currentProfit > maxProfit)
                    maxProfit = currentProfit;
            }
        }
        return maxProfit;
    }

    #region
    //Array
    public int[,] RotateArray(int[,] rectangularArray)
    {
        var result = TransposeArray(rectangularArray);
        ReverseEveryRow(result);
        return result;
    }
    public int[,] TransposeArray(int[,] rectangularArray)
    {
        var noOfRow = rectangularArray.GetLength(0);
        var noOfColumns = rectangularArray.GetLength(1);
        var resultantArray = new int[noOfColumns, noOfRow];

        for (int i = 0; i < noOfRow; i++)
        {
            for (int j = 0; j < noOfColumns; j++)
            {
                resultantArray[j, i] = rectangularArray[i, j];
            }
        }
        return resultantArray;
    }
    public void ReverseEveryRow(int[,] rectangularArray)
    {
        var noOfRow = rectangularArray.GetLength(0);
        var noOfColumns = rectangularArray.GetLength(1);
        for (int i = 0; i < noOfRow; i++)
        {
            for (int j = 0; j < noOfColumns / 2; j++)
            {
                var temp = rectangularArray[i, j];
                rectangularArray[i, j] = rectangularArray[i, noOfColumns - j - 1];
                rectangularArray[i, noOfColumns - j - 1] = temp;
            }
        }
    }
    public void TraverseArray(int[,] rectangularArray)
    {
        var noOfRow = rectangularArray.GetLength(0);
        var noOfColumns = rectangularArray.GetLength(1);

        for (int j = noOfColumns - 1; j >= 0; j--)
        {
            var i = 0;
            var k = j;
            StringBuilder sb = new StringBuilder();
            while (k >= 0 && i <= noOfRow - 1)
            {
                sb.Append(rectangularArray[i, k]);
                k--;
                i++;
            }
            Console.WriteLine(sb.ToString());
        }
        for (int i = 1; i < noOfRow; i++)
        {
            var j = noOfColumns - 1;
            var k = i;
            StringBuilder sb = new StringBuilder();
            while (j >= 0 && k <= noOfRow - 1)
            {
                sb.Append(rectangularArray[k, j]);
                j--;
                k++;
            }
            Console.WriteLine(sb.ToString());
        }
    }
    public void DigonalTraversalOfArray(int[,] rectangularArray)
    {
        var rowLength = rectangularArray.GetLength(0);
        var columnLength = rectangularArray.GetLength(1);
        for (int j = 0; j < columnLength - 1; j++)
        {
            int i = 0;
            TraverseWithIndices(i, j, rowLength, columnLength, rectangularArray);
        }
        for (int i = 0; i < rowLength; i++)
        {
            int j = columnLength - 1;
            TraverseWithIndices(i, j, rowLength, columnLength, rectangularArray);
        }
    }

    private void TraverseWithIndices(int row, int col, int rowLength, int colLength, int[,] rectangularArray)
    {
        while (row <= rowLength - 1 && col >= 0)
        {
            Console.Write(rectangularArray[row, col]);
            row++;
            col--;
        }
    }
    public int MaximumSumWithSubArrayofLength(int[] nums, int k)
    {
        if (nums == null || nums.Length < k)
        {
            return 0;
        }
        var sum = Int32.MinValue;
        int prefixKSum = 0;
        for (int i = 0; i < k; i++)
        {
            prefixKSum += nums[i];
        }
        if (prefixKSum > sum)
            sum = prefixKSum;
        for (int i = 1; i < nums.Length - k + 1; i++)
        {
            prefixKSum = prefixKSum - nums[i - 1] + nums[i + k - 1];
            if (prefixKSum > sum)
                sum = prefixKSum;
        }
        return sum;
    }

    public void SumOfAllIndividualSubArray(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            var prefixSum = 0;
            for (int j = i; j < nums.Length; j++)
            {
                prefixSum += nums[j];
                Console.WriteLine(prefixSum);
            }
        }
    }

    public List<int> GetSumOfSubArray(int[] nums)
    {
        List<int> prefixSum = new List<int>();
        int preSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            preSum += nums[i];
            prefixSum.Add(preSum);
        }
        return prefixSum;
    }

    public void IndexOfSubArrayWithSumValue(int[] nums, int sumValue) // or anything other than 0
    {
        var prefixSumArray = GetSumOfSubArray(nums);
        for (int i = 0; i < prefixSumArray.Count; i++)
        {
            var prefixSum = i == 0 ? 0 : prefixSumArray[i - 1];
            for (int j = i; j < nums.Length; j++)
            {
                var sum = prefixSum - prefixSumArray[j];
                if (sum == sumValue)
                {
                    Console.WriteLine($"{i},{j}");
                }
            }
        }
    }

    public void IndexOfSubArrayWithSumValueWithoutSpace(int[] nums, int sumValue) // or anything other than 0
    {
        for (int i = 0; i < nums.Length; i++)
        {
            var prefixSum = 0;
            for (int j = i; j < nums.Length; j++)
            {
                prefixSum += nums[j];
                if (prefixSum == sumValue)
                {
                    Console.WriteLine($"{i},{j}");
                }
            }
        }
    }
    #endregion


    //Simillarly XOR can be used for Uniqueness
    public int GetCountOfPairs(List<int> ints)
    {
        int count = 0;
        for (int i = 0; i < ints.Count; i++)
        {
            for (int j = i + 1; j < ints.Count - (i - 1); j++)
            {
                if ((ints[i] ^ ints[j]) == 0)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public void GetOpenDoor(int N)
    {
        bool[] counter = new bool[N];
        for (int i = 1; i < N; i++)
        {
            for (int j = i; j < N; j = j + i)
            {
                counter[j - 1] = !counter[j - 1];
            }

        }
        for (int i = 0; i < N; i++)
            if (counter[i])
                Console.WriteLine(i + 1);

        //Instead we can say the numbers which has odd no of factors will have reverted
    }

    //Moore's Theorem
    public int GetNumberWithAFrequencyToGetMajority(int[] nums, int noWhichGivesYouMajority)
    {
        if (nums.Length == 0)
            return -1;
        int maxFrequencyNumber = nums.First();
        int count = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (maxFrequencyNumber == nums[i])
            {
                count++;
            }
            else if (count == 0)
            {
                maxFrequencyNumber = nums[i];
            }
            else
            {
                count--;
            }
        }
        var frequency = 0;
        //if (count == 0)
        //    return -1;
        foreach (int i in nums)
        {
            if (i == maxFrequencyNumber)
            {
                frequency++;
            }
        }
        return frequency > noWhichGivesYouMajority ? maxFrequencyNumber : -1;
    }

    public void TheLastSurvived(int noOfPerson)
    {
        if (noOfPerson == 1)
        {
            Console.WriteLine($"Person 1 is alive");
            return;
        }

        bool[] SurvivalSatus = new bool[noOfPerson];
        var nearestPowerOf2 = (int)Math.Log2(noOfPerson);
        var totalNoOfKillRequiredToReachOnItself = noOfPerson - Math.Pow(2, nearestPowerOf2);
        int nextMurder = 1;
        var nextKiller = 0;
        var noOfKills = 0;
        while (noOfKills < totalNoOfKillRequiredToReachOnItself)
        {
            noOfKills++;
            nextKiller = nextKiller + 2;
            SurvivalSatus[nextMurder] = true;
            nextMurder = nextMurder + 2;
        }
        Console.WriteLine($"Person {nextKiller + 1} is alive");
    }

    //when you delete an element penalty Will be sum of all the array
    //Simply go to each object and Calculate the sum of rest and then make itself 0
    //Else sort and find the contribution of each one
    //else sort and move with prefix sum
    public void MinimumPenaltyForDeletingAnElementTillAllElementsAreDeleted(List<int> ints)
    {
        ints.Sort();

        var prefixSum = ints.Sum();
        var penalty = 0;
        for (int i = 0; i < ints.Count; i++)
        {
            penalty += prefixSum;
            prefixSum = prefixSum - ints[i];
        }
    }

    //If count of numbers lesser than the magnitude of number then its a Nobel Number
    public void NobleElement(List<int> ints)
    {
        if (ints.Count == 0) Console.WriteLine("No Noble Element");
        ints.Sort();

        var nobleCount = 0;
        int noOfDistinctCount = 0;
        if (ints[0] == noOfDistinctCount)
        {
            nobleCount++;
        }
        for (int i = 1; i < ints.Count; i++)
        {
            if (ints[i] != ints[i - 1])
            {
                noOfDistinctCount++;
            }
            if (ints[i] == noOfDistinctCount)
                nobleCount++;

        }
        Console.WriteLine($"No of Noble Element {nobleCount}");
    }

    public void ReverseSentenceButNotWordsWithDelimiter(string input)
    {
        if (string.IsNullOrEmpty(input))
            Console.WriteLine(input);
        var length = input.Length;
        var charArray = new char[length];
        for (int a = 0; a <= length / 2; a++)
        {
            charArray[a] = input[length - a - 1];
            charArray[length - a - 1] = input[a];
        }
        int i = 0, j = 0;
        while (i < length && j < length)
        {
            if (charArray[j] == '_')
            {
                Reverse(charArray, i, j - 1);
                i = j + 1;
            }
            else if (j == length - 1)
            {
                Reverse(charArray, i, j);
            }
            j++;
        }
        Console.WriteLine(new string(charArray));

    }

    public void Reverse(char[] charArray, int startIndex, int endIndex)
    {
        for (int a = startIndex; a < (endIndex + startIndex) / 2; a++)
        {
            var temp = charArray[endIndex - a + startIndex];
            charArray[endIndex - a + startIndex] = charArray[a];
            charArray[a] = temp;
        }
    }

    public void LongestPalindrome(string sentence)
    {
        int maxLength = Int32.MinValue;
        var length = sentence.Length;
        for (int i = 0; i < sentence.Length; i++)
        {
            int leftIndex = i - 1;
            int rightIndex = i + 1;
            int currentLength = 1;
            while (leftIndex >= 0 && rightIndex < length && sentence[leftIndex] == sentence[rightIndex])
            {
                currentLength = currentLength + 2;
                maxLength = Math.Max(maxLength, currentLength);
                leftIndex--;
                rightIndex++;
            }
        }
        for (int i = 0; i < sentence.Length; i++)
        {
            int leftIndex = i;
            int rightIndex = i + 1;
            int currentLength = 0;
            while (leftIndex >= 0 && rightIndex < length && sentence[leftIndex] == sentence[rightIndex])
            {
                currentLength = currentLength + 2;
                maxLength = Math.Max(maxLength, currentLength);
                leftIndex--;
                rightIndex++;
            }
        }
        Console.WriteLine($"Longest Palindrome {maxLength}");
    }

    public void SumOfTwoIndexWithTargetSum(int[] inputArray, int targetSum)
    {
        HashSet<int> uniqueInts = new HashSet<int>();

        for (int i = 0; i < inputArray.Length; i++)
        {
            if (uniqueInts.Contains(targetSum - inputArray[i]))
            {
                Console.WriteLine("Found the index with");
            }
            uniqueInts.Add(inputArray[i]);
        }
    }

    public void AllSumOfTwoIndexWithSum(int[] inputArray, int targetSum, bool onlyDistinct)
    {
        Dictionary<int, int> uniqueInts = new Dictionary<int, int>();
        for (int i = 0; i < inputArray.Length; i++)
        {
            int number;
            if (!uniqueInts.TryGetValue(inputArray[i], out number))
            {
                uniqueInts.Add(inputArray[i], 1);
            }
            else
            {
                number++;
                uniqueInts[inputArray[i]] = number;
            }
        }

        int totalCount = 0;
        for (int i = 0; i < uniqueInts.Keys.Count; i++)
        {
            var targetNumber = targetSum - inputArray[i];
            int targetNumberFrequency;
            if (uniqueInts.TryGetValue(targetNumber, out targetNumberFrequency))
            {
                if (inputArray[i] == targetNumber)
                {
                    if (onlyDistinct)
                    {
                        //figure out
                    }
                    else
                    {
                        totalCount += targetNumberFrequency * (targetNumberFrequency - 1);
                    }
                }
                else
                {
                    int currentNumberFrequency;
                    uniqueInts.TryGetValue(inputArray[i], out currentNumberFrequency);
                    totalCount += targetNumberFrequency * currentNumberFrequency;
                }
            }
        }
        Console.WriteLine(totalCount);
    }

    public void DistictElementInSubArray(int[] inputArray, int k)
    {
        Dictionary<int, int> keyValues = new Dictionary<int, int>();
        for (int i = 0; i < k; i++)
        {
            if (keyValues.TryGetValue(inputArray[i], out int value))
            {
                value++;
                keyValues[inputArray[i]] = value;
            }
            else
                keyValues[inputArray[i]] = 1;
            Console.WriteLine(keyValues.Count);
        }

        for (int i = 1; i < inputArray.Length - k; i++)
        {
            //remove previous item
            if (keyValues.TryGetValue(inputArray[i - 1], out int oldValue))
            {
                oldValue--;
                if (oldValue == 0)
                    keyValues.Remove(inputArray[i - 1]);
                else
                    keyValues[inputArray[i - 1]] = oldValue;
            }
            //add new item
            if (keyValues.TryGetValue(inputArray[i + k - 1], out int newValue))
            {
                keyValues[inputArray[i + k - 1]]++;
            }
            else
                keyValues[inputArray[i + k - 1]] = 1;
            Console.WriteLine(keyValues.Count);
        }
    }

    public void MaxLengthOfSubArrayWithSum0(List<int> ints)
    {
        var prefixHashSet = new Dictionary<int, int>();
        var prefixSum = 0;
        var maxDistance = Int32.MinValue;
        for (var i = 0; i < ints.Count; i++)
        {
            prefixSum += ints[i];
            if (prefixSum == 0)
            {
                if (i > maxDistance)
                {
                    maxDistance = i + 1;
                }
            }
            else if (prefixHashSet.TryGetValue(prefixSum, out int index))
            {
                var distance = i - index;
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }
            else
                prefixHashSet[prefixSum] = i;
        }
    }

    public void MaxLengthOfSubArrayWithSum0(List<int> ints, int targetSum)
    {
        var prefixHashSet = new Dictionary<int, int>();
        var prefixSum = 0;
        var maxDistance = Int32.MinValue;
        for (var i = 0; i < ints.Count; i++)
        {
            prefixSum += ints[i];
            if (prefixSum == targetSum)
            {
                if (i > maxDistance)
                {
                    maxDistance = i + 1;
                }
            }
            if (prefixHashSet.TryGetValue(prefixSum - targetSum, out int index))
            {
                var distance = i - index;
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }
            prefixHashSet[prefixSum] = i;
        }
    }

    public void PrintReverseSequence(int n, StringBuilder? stringBuilder = null)
    {
        if (stringBuilder == null)
            stringBuilder = new StringBuilder();
        if (n == 0)
        {
            return;
        }
        Console.WriteLine(n);
        PrintReverseSequence(n - 1, stringBuilder);
    }

    public void PrintSequence(int n)
    {
        if (n == 0)
        {
            return;
        }
        PrintSequence(n - 1);
        Console.WriteLine(n);
    }

    public int FibonaciSeries(int valueAtTargetIndex)
    {
        if (valueAtTargetIndex == 0) { return 0; }
        if (valueAtTargetIndex == 1) { return 1; }
        return FibonaciSeries(valueAtTargetIndex - 2) + FibonaciSeries(valueAtTargetIndex - 1);
    }

    public int GetSumOfXORofAllThePair(List<int> ints)
    {
        // Get all the pair option and on run time keep adding the sum
        // This will be sum of all the pairs so it will take N^2

        for (var bitIndex = 0; bitIndex < 32; bitIndex++)
        {
            for (int i = 0; i < ints.Count; i++)
            {
                if (((ints[i] << bitIndex) & 1) == 0)
                {

                }
            }
        }
        return 0;
    }


    #region

    public class Node
    {
        public int Value;
        public Node Right;
        public Node Left;
    }
    //Trees
    public void PreOrder(Node startNode)
    {
        if (startNode == null)
            return;

        Console.WriteLine(startNode.Value);
        PreOrder(startNode.Left);
        PreOrder(startNode.Right);
    }

    public void InOrder(Node startNode)
    {
        if (startNode == null)
            return;

        InOrder(startNode.Left);
        Console.WriteLine(startNode.Value);
        InOrder(startNode.Right);
    }
    public void PostOrder(Node startNode)
    {
        if (startNode == null)
            return;

        PostOrder(startNode.Left);
        PostOrder(startNode.Right);
        Console.WriteLine(startNode.Value);
    }

    public int Height(Node startNode)
    {
        if (startNode == null)
            return -1;
        return Math.Max(Height(startNode.Right), Height(startNode.Left)) + 1;
    }
    #endregion

    #region
    //SubSequence

    public void GetAllSubsequence()
    {

    }
    #endregion

    public int GetHCForGCD(int a, int b)
    {
        if (a == 0 || b == 0)
            return -1;
        if (b < a)
        {
            var temp = b;
            b = a;
            a = temp;
        }
        var gcd = b % a == 0 ? a : 1;
        while (b % a != 0)
        {
            gcd = b % a;
            b = a;
            a = gcd;
        }

        return gcd;
    }

    #region
    //Seive Algorithm
    public List<int> GetPrimeNumbers(int endNumber)
    {
        bool[] hasAFactor = new bool[endNumber + 1];

        List<int> primeNumbers = new List<int>();

        for (int i = 2; i * i <= endNumber; i++)// all the lowest factor will have been visited by lower numbers
        {
            if (!hasAFactor[i])
            {
                for (int j = i * i; j <= endNumber; j += i)// Multiple of that prime
                {
                    hasAFactor[j] = true;
                }
            }
        }

        for (var i = 1; i < endNumber; i++)
        {
            if (!hasAFactor[i])
                primeNumbers.Add(i);
        }
        return primeNumbers;
    }
    public void GetLowestPrimeFactor(int endNumber)
    {
        int[] lowestFactor = new int[endNumber + 1];

        for (int i = 2; i * i <= endNumber; i++)// all the lowest factor will have been visited by lower numbers
        {
            if (lowestFactor[i] == 0)
            {
                for (int j = i * i; j <= endNumber; j += i)// Multiple of that prime
                {
                    lowestFactor[j] = i;
                }
            }
        }

        for (int i = 0; i <= endNumber; i++)
        {
            if (lowestFactor[i] == 0)
                Console.WriteLine($"Lowest prime factor of {i} is {i}");
            else
                Console.WriteLine($"Lowest prime factor of {i} is {lowestFactor[i]}");
        }
    }
    public List<int> GetFactorsRevision(int num)
    {
        List<int> Factors = new List<int>();
        for (var i = 1; i * i <= num; i++)
        {
            if (i % num == 0)
            {
                Factors.Add(i);
                if (i != num / i)
                {
                    Factors.Add(num / i);
                }
            }
        }
        return Factors;
    }
    #endregion

}