// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class HashMaps
{

    public void GetMinimumDistanceBetweenTwoRepeatingNumbers(List<int> ints)
    {
        var dictLatestPointer = new Dictionary<int, int>();
        var minDistance = Int32.MaxValue;
        for (int i = 0; i < ints.Count; i++)
        {
            if (dictLatestPointer.TryGetValue(ints[i], out int lastIndex))
            {
                var currDistance = i - lastIndex + 1;
                if (currDistance < minDistance)
                {
                    minDistance = currDistance;
                }
            }
            dictLatestPointer[ints[i]] = i;
        }

        return minDistance == int.MaxValue ? -1 : minDistance;
    }

}