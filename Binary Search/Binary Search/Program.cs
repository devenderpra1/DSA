// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class Result
{

    // Could be done with XOR
    public int FindLonelyElementInPairOfAdjacentNumber(List<int> inputs)
    {
        if (inputs.Count == 0 || inputs.Count % 2 == 0)
            return -1;

        var left = 0;
        var right = inputs.Count - 1;
        var mid = (right - left) / 2;

        while (left < right)
        {
            mid = left + (right - left) / 2;
            if (mid % 2 == 1)
                mid--;
            if (inputs[mid] == inputs[mid + 1])// always check for first at mid (odd place) and second at even 
            {
                left = mid + 2;
            }
            else
            {
                right = mid - 1;
            }
        }
        return left;
    }
}