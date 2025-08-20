// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine(Result.MySqrt(4));


public static class Result
{
    public static int BinarySearch(this List<int> SearchSpace, int noToFind)
    {
        var left = 0;
        var right = SearchSpace.Count - 1;
        var mid = (right - left) / 2;
        while (left <= right)
        {
            if (SearchSpace[mid] == noToFind)
            {
                return mid;
            }
            else if (SearchSpace[mid] < noToFind)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }

    public static int GetFloor(this List<int> SearchSpace, int input)
    {
        var left = 0;
        var right = SearchSpace.Count - 1;
        var mid = (right - left) / 2;

        int floor = -1;
        while (left <= right)
        {
            if (SearchSpace[mid] == input)
            {
                return SearchSpace[mid];
            }
            else if (SearchSpace[mid] < input)
            {
                floor = SearchSpace[mid];
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    } // USe of indices

    public static int GetFrequencyOfANumberInSortedArray(List<int> SearchSpace, int findFrequencyForNumber)
    {
        var firstOccurance = FirstOccurance(SearchSpace, findFrequencyForNumber);
        var lastOccurance = LastOccurance(SearchSpace, findFrequencyForNumber);
        if (firstOccurance == -1)
        {
            return -1;
        }
        else
        {
            return lastOccurance - firstOccurance + 1;
        }

    }
    public static int FirstOccurance(List<int> SearchSpace, int numberToFind)
    {
        var mid = (SearchSpace.Count - 1) / 2;
        var left = 0;
        var right = SearchSpace.Count - 1;
        var firstOccurance = -1;
        while (left <= right)
        {
            if (SearchSpace[mid] == numberToFind)
            {
                firstOccurance = mid;
                right = mid - 1;
            }
            else if (SearchSpace[mid] < numberToFind)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return firstOccurance;
    }
    public static int LastOccurance(List<int> SearchSpace, int numberToFind)
    {
        var mid = (SearchSpace.Count - 1) / 2;
        var left = 0;
        var right = SearchSpace.Count - 1;
        var lastOccurance = -1;
        while (left <= right)
        {
            if (SearchSpace[mid] == numberToFind)
            {
                lastOccurance = mid;
                left = mid + 1;
            }
            else if (SearchSpace[mid] < numberToFind)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return lastOccurance;
    }

    public static int MySqrt(int x)
    {

        int leftindex = 0;
        int rightindex = x / 2;
        int sqrt = -1;
        var tolerance = 0.0001;

        while (rightindex - leftindex > tolerance)  //General Convention leftindex <= rightindex
        {
            var mid = (rightindex - leftindex) / 2;
            var midSquare = mid * mid;
            if (Math.Abs(midSquare - x) < tolerance)
            {
                return mid;
            }
            else if (midSquare < x)
            {
                sqrt = mid;
                leftindex = mid + 1;
            }
            else
            {
                rightindex = mid - 1;
            }
        }
        return sqrt;
    } // Direct use of numbers

    public static int GetMaxSizeOfSubArrayWithATargetSum(List<int> positiveIntegers, int targetSum)
    {
        var left = 0;
        var right = positiveIntegers.Count;
        int mid;
        var answer = -1;
        while (left < right)
        {
            mid = (left + right) / 2;
            if (CheckForThisSize(positiveIntegers, mid, targetSum))
            {
                left = mid + 1;
                answer = mid;
            }
            else
            {
                right = mid - 1;
            }
        }
        return answer;
    } // Idea to find perfect something
    public static bool CheckForThisSize(List<int> input, int sizeToCheck, int targetSum)
    {
        if (input.Count < sizeToCheck)
        {
            return false;
        }
        var prefixsum = 0;
        for (var i = 0; i <= sizeToCheck; i++)
        {
            prefixsum += input[i];
        }
        if (prefixsum > targetSum)
        {
            return false;
        }
        for (int i = sizeToCheck; i < input.Count; i++)
        {
            prefixsum += input[i];
            prefixsum -= input[i - 1 - sizeToCheck];
            if (prefixsum > targetSum)
            {
                return false;
            }
        }
        return true;
    }

    public static int PlacingNCowsMaximumDistanceWithMPlacesNotEqualSpaceButProvidedSpaces(int noOfCows, List<int> noOfAvailablePlacesSorted)
    {
        int left = 0;
        int right = noOfAvailablePlacesSorted[noOfAvailablePlacesSorted.Count - 1];
        var mid = (right - left) / 2;
        var answer = -1;
        while (left <= right)
        {
            if (CheckPlacement(noOfCows, noOfAvailablePlacesSorted, mid))
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return answer;
    }

    public static bool CheckPlacement(int noOfCows, List<int> noOfAvailablePlacesSorted, int checkDistance)
    {
        int placed = 1;
        int nextPlacement = noOfAvailablePlacesSorted[0] + checkDistance;
        for (int i = 1; i < noOfAvailablePlacesSorted.Count; i++)
        {
            if (noOfAvailablePlacesSorted[i] >= nextPlacement)
            {
                placed++;
                if (placed == noOfCows)
                {
                    return true;
                }
                nextPlacement = noOfAvailablePlacesSorted[i] + checkDistance;
            }
        }
        return false;
    }

    public static int GetMaximumLengthofasubarrayWithATargetSum(List<int> ints, int targetSum)
    {
        var left = 1;
        var right = ints.Count;
        var maxlengthOfSubarray = 0;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (MaxSum(ints, mid, targetSum))
            {
                left = mid + 1;
                maxlengthOfSubarray = mid;
            }
            else
            {
                right = mid - 1;
            }
        }

        return maxlengthOfSubarray;
    }

    public static bool MaxSum(List<int> ints, int sizeOfSubarray, int MaxSum)
    {
        var slidingArraySum = 0;
        if (slidingArraySum > MaxSum)
        {
            return false;
        }
        return true;
    }

    public static void GetNoOfPairsTartgetSumAddition(List<int> input, int target)
    {
        //i Not equals to j
        // increasing sorted order
        var i = 0;
        var j = input.Count;
        var pairCount = 0;

        while (i < j)
        {
            var sum = input[i] + input[j];
            if (sum == target)
            {
                pairCount++;
            }
            else if (sum > target)
            {
                //reduce greater as no Greater has no probabilty to pair with any smaller number if you increment i it will be larger that the current smaller
                j--;
            }
            else
            {
                i++;
            }
        }
    }
    public static int GetPairWithDifferenceIsEqualsToTarget(List<int> input, int target)
    {
        if (input.Count <= 1) return 0;
        var i = 0;
        var j = 1;
        var pairCount = 0;
        var diff = 0;
        while (i < j && j < input.Count)
        {
            diff = Math.Abs(input[i] - input[j]);
            if (diff == target)
            {
                pairCount++;
                i++; j++;
            }
            else if (diff > target)
            {
                i++;
            }
            else
            {
                j++;
            }
        }
        return pairCount;
    }
}