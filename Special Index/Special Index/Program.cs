// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
SpecialIndex.PivotIndex(new int[] { 1, 7, 3, 6, 5, 6 });
public class SpecialIndex
{

    public static int PivotIndex(int[] nums)
    {
        var sumLeft = 0;
        var sumTotal = nums.Sum(x => x);
        double sumRight = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sumRight = sumTotal - sumLeft - nums[i];
            if (sumLeft == sumRight) { return i; }
            sumLeft += nums[i];
        }
        return -1;
    }

    public int SpecialIndexFinder(int[] nums)
    {
        //int[] evenSumArray = new int[nums.Length];
        //int[] oddSumArray = new int[nums.Length];
        var evenSum = 0;
        var oddSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0)
            {
                evenSum += nums[i];
            }
            else
                oddSum += nums[i];
            //evenSumArray[i] = evenSum;
            //oddSumArray[i] = oddSum;
        }
        var prefixEvenSum = 0;
        var prefixOddSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            //double newEvenSum = i % 2 == 0 ? evenSumArray[i] - nums[i] + oddSumArray[nums.Length - 1] - oddSumArray[i] : evenSumArray[i] + oddSumArray[nums.Length - 1] - oddSumArray[i] - nums[i];
            int newEvenSum = i % 2 == 0 ? prefixEvenSum + oddSum - prefixOddSum : prefixEvenSum + oddSum - prefixOddSum - nums[i];
            //double newOddSum = i % 2 != 0 ? oddSumArray[i] - nums[i] + evenSumArray[nums.Length - 1] - evenSumArray[i] : oddSumArray[i] + evenSumArray[nums.Length - 1] - evenSumArray[i] - nums[i];
            int newOddSum = i % 2 != 0 ? prefixOddSum + evenSum - prefixEvenSum: prefixOddSum + evenSum - prefixEvenSum - nums[i];

            if (newEvenSum == newOddSum)
            {
                return i;
            }
        }
        return -1;
    }
}
