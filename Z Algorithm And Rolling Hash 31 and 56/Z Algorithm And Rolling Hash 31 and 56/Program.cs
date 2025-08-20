// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class StringComparision
{
    public bool SearchAStringWithZ(string searchSpace, string stringToSearch)
    {
        int LeftStartSearchSpaceMatched = 0;
        int RightEndSearchSpaceMatched = 0;

        var stringToSearchPrefixWithSearchSpace = stringToSearch + '$' + searchSpace;

        int[] zArray = new int[stringToSearchPrefixWithSearchSpace.Length];


        for (var i = 0; i < stringToSearchPrefixWithSearchSpace.Length; i++)
        {
            int j = 0; int k = i;
            ///in my current search space
            if (i <= RightEndSearchSpaceMatched)
            {
                //rely on already calculated mirror
                if (zArray[k - LeftStartSearchSpaceMatched] < (RightEndSearchSpaceMatched - k))
                {
                    // less than the remaining mirror size
                    zArray[i] = zArray[k - LeftStartSearchSpaceMatched];
                }
                else
                {
                    //try to search for More matching 
                    //update the left boundary and right boundary
                    k = RightEndSearchSpaceMatched + 1;
                    j = RightEndSearchSpaceMatched + 1 - i;
                    while (k < stringToSearchPrefixWithSearchSpace.Length && (stringToSearchPrefixWithSearchSpace[j] == stringToSearchPrefixWithSearchSpace[k]))
                    {
                        j++;
                        k++;
                    }
                    zArray[i] = k - i;
                    if (stringToSearch.Length == (k - i))
                        return true;
                    LeftStartSearchSpaceMatched = i;
                    RightEndSearchSpaceMatched = k - 1;
                }
            }
            else //search the prefix match with brute force
            {
                while (k < stringToSearchPrefixWithSearchSpace.Length && (stringToSearchPrefixWithSearchSpace[j] == stringToSearchPrefixWithSearchSpace[k]))
                {
                    j++;
                    k++;
                }
                zArray[i] = k - i;
                if (stringToSearch.Length == (k - i))
                    return true;
                LeftStartSearchSpaceMatched = i;
                RightEndSearchSpaceMatched = k - 1;
                //update the left boundary and right boundary matched or unMatched
            }
        }
        return true;
    }
}

