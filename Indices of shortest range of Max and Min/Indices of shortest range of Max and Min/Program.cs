// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Numbers
{
    public void GetRangeMaxMin(List<int> nums)
    {
        int min = Int32.MaxValue;
        int max = Int32.MinValue;

        for (int i = 0; i < nums.Count; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
            }
            else if (nums[i] < min)
            {
                min = nums[i];
            }
        }

        int prevMax = Int32.MinValue;
        int prevMin = Int32.MinValue;
        int currentmax = Int32.MinValue;
        int currentmin = Int32.MaxValue;

        for (var i = 0; i < nums.Count; i++)
        {
            if (nums[i] == max)
            if(currentmax - currentmin <)
            {
                currentmax = nums[i];
            }
        }
    }
}
