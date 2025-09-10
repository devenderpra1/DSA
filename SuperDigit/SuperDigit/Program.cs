
using System.Numerics;
using System.Reflection;
using System.Text;
using System.IO;


//StringBuilder textWriter = new StringBuilder();
//Result.Moves(new List<string> { ".X.", ".X.", "..." }, 0, 0, 0, 2);
//Result.caesarCipher("abc", 1);
//int tests = Convert.ToInt32(Console.ReadLine());

//for (int testsItr = 0; testsItr < tests; testsItr++)
//{
//    SinglyLinkedList llist = new SinglyLinkedList();

//    int llistCount = Convert.ToInt32(Console.ReadLine());

//    for (int i = 0; i < llistCount; i++)
//    {
//        int llistItem = Convert.ToInt32(Console.ReadLine());
//        llist.InsertNode(llistItem);
//    }


//    SinglyLinkedListNode llist1 = Result.reverse(llist.head);

//    Result.PrintSinglyLinkedList(llist1, " ", textWriter);
//    Console.WriteLine(textWriter.ToString());
//}
//Console.WriteLine(Result.isValid("aaaaabc"));
//Result.minimumBribes(new List<int>() { 2, 1, 5, 3, 4 });
//SuperDigit.superDigit("3546630947312051453014172159647935984478824945973141333062252613718025688716704470547449723886626736", 100000);
//SuperDigit.PrintTriangle();



var folders = System.IO.Directory.GetDirectories("C:\\Users\\deven\\Downloads\\takeout-20240812T033837Z-001\\Drive All Photos\\Google Photos");
//Console.WriteLine(String.Join("\n", folders.Select(a => a)));
List<string> allFiles = new List<string>();
foreach (var folder in folders)
{
    var files = System.IO.Directory.GetFiles(folder);
    allFiles.AddRange(files);
}
foreach (var file in allFiles)
{
    if (!file.Contains(".json"))
        //Console.WriteLine($"C:\\Users\\deven\\Downloads\\Filtered Photos\\{file.Substring(file.LastIndexOf("\\"))}");
        try
        {
            System.IO.Directory.Move(file, $"C:\\Users\\deven\\Downloads\\Filtered Photos\\{file.Substring(file.LastIndexOf("\\"))}");
        }
        catch 
        {
            System.IO.Directory.Move(file, $"C:\\Users\\deven\\Downloads\\Filtered Photos\\{file.Substring(file.LastIndexOf("\\"))}1");
            
        }
}
Console.ReadLine();

public class SuperDigit
{
    public static int SuperDigitHelper(string n, bool firstCall, int k = 0)
    {
        BigInteger num = BigInteger.Parse(n);
        if (num <= 9)
            return ((int)num);
        BigInteger sum = n.Select(a => ((int)Char.GetNumericValue(a))).Sum();
        if (firstCall)
            sum = sum * k;
        return SuperDigitHelper(sum.ToString(), false);
    }
    public static int superDigit(string n, int k)
    {
        return SuperDigitHelper(n, true, k);
    }
    public static void PrintTriangle()
    {
        int number, i, k, count = 1;
        Console.Write("Enter number of rows: ");
        number = int.Parse(Console.ReadLine());
        count = number - 1;
        for (k = 1; k <= number; k++)
        {
            for (i = 1; i <= count; i++)
                Console.Write(" ");
            count--;
            for (i = 1; i <= 2 * k - 1; i++)
                Console.Write("*");
            Console.WriteLine();
        }
    }
}

public class Bribes
{
    public static void minimumBribes(List<int> q)
    {
        int count = 0;
        string output = "";
        for (int i = 2; i < q.Count; i++)
        {
            if (q[i - 2] - q[i - 1] <= 2 && q[i - 2] - q[i - 1] >= 0)
            {
                count++;
            }
            else
            {
                output = "Too chaotic";
                break;
            }
            if (q[i] - q[i - 1] >= 2 && q[i - 2] - q[i - 1] >= 0)
            {
                count++;
            }
            else
            {
                output = "Too chaotic";
                break;
            }
        }
        if (string.IsNullOrEmpty(output))
        {
            Console.WriteLine($"{count}");
        }
        else
        {
            Console.WriteLine(output);
        }
    }

    public static string isValid(string s)
    {

        // Count occurrences of each character
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        // Get distinct counts of character occurrences
        var distinctCounts = charCount.Values.Distinct().ToList();

        // If there is only one distinct count, it means all characters appear the same number of times
        if (distinctCounts.Count == 1)
        {
            return "YES";
        }

        // If there are exactly two distinct counts and one of them occurs only once,
        // check if removing one occurrence of it would make all characters appear the same number of times
        if (distinctCounts.Count == 2)
        {
            int count1 = distinctCounts[0];
            int count2 = distinctCounts[1];
            int freq1 = charCount.Count(kv => kv.Value == count1);
            int freq2 = charCount.Count(kv => kv.Value == count2);

            // Check if one of the counts occurs only once and the difference between the counts is 1
            if (Math.Abs(count1 - count2) > 1 && !((count1 == 1 && count2 > 1) || (count2 == 1 && count1 > 1)))
            {
                return "NO";
            }
            else if ((freq1 == 1 && count1 == 1) || (freq2 == 1 && count2 == 1))
            {
                return "YES";
            }
            else if ((freq1 == 1 || (freq2 == 1 && Math.Abs(count2 - count1) == 1)))
            {
                return "YES";
            }
        }

        // If none of the above conditions are met, the string is not valid
        return "NO";
    }

    public static string IsValid(string s)
    {

        // Count occurrences of each character
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        // Get distinct counts of character occurrences
        var distinctCounts = charCount.Values.Distinct().ToList();

        // If there is only one distinct count, it means all characters appear the same number of times
        if (distinctCounts.Count == 1)
        {
            return "YES";
        }

        // If there are exactly two distinct counts and one of them occurs only once,
        // check if removing one occurrence of it would make all characters appear the same number of times
        if (distinctCounts.Count == 2)
        {
            int count1 = distinctCounts[0];
            int count2 = distinctCounts[1];
            int freq1 = charCount.Count(kv => kv.Value == count1);
            int freq2 = charCount.Count(kv => kv.Value == count2);

            // Check if one of the counts occurs only once and the difference between the counts is 1

            if ((freq1 == 1 && count1 == 1) || (freq2 == 1 && count2 == 1))
            {
                return "YES";
            }
            else if (Math.Abs(count1 - count2) > 1 && ((count1 == 1 && freq1 == 1) || (count2 == 1 && freq2 == 1)))
            {
                return "YES";
            }
            else if ((freq1 == 1 || freq2 == 1) && Math.Abs(count2 - count1) == 1)
            {
                return "YES";
            }
        }

        // If none of the above conditions are met, the string is not valid
        return "NO";
    }

}

public class SinglyLinkedListNode
{
    public int data;
    public SinglyLinkedListNode next;

    public SinglyLinkedListNode(int nodeData)
    {
        this.data = nodeData;
        this.next = null;
    }
}

public class SinglyLinkedList
{
    public SinglyLinkedListNode head;
    public SinglyLinkedListNode tail;

    public SinglyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public void InsertNode(int nodeData)
    {
        SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

        if (this.head == null)
        {
            this.head = node;
        }
        else
        {
            this.tail.next = node;
        }

        this.tail = node;
    }
}

public class Result
{

    public static string caesarCipher(string s, int k)
    {
        k = 2;
        s = "z";
        k = k % 26;
        char[] returnString = new char[s.Length];
        int count = 0;
        foreach (var chr in s)
        {
            var asciValue = (int)(chr);
            int added = asciValue + k;
            int output;
            if (asciValue >= 65 && asciValue <= 90)
            {
                if (added > 90)
                {
                    added = added - 90;
                    output = 65 + added;
                }
                else
                    output = added;
            }
            else if (asciValue >= 96 && asciValue <= 122)
            {
                if (added > 122)
                {
                    added = added - 122;
                    output = 96 + added;
                }
                else
                    output = added;
            }
            else
            {
                output = chr;
            }

            returnString[count] = (char)(output);
            count++;
        }
        return new string(returnString);
    }

    public static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, StringBuilder textWriter)
    {
        while (node != null)
        {
            textWriter.Append(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Append(sep);
            }
        }
    }

    public static int Moves(List<string> grid, int startX, int startY, int goalX, int goalY)
    {
        var numberofWays = 0;
        if (startX > goalX)
        {
            var temp = goalX;
            goalX = startX;
            startX = temp;
        }
        if (startY > goalY)
        {
            var temp = goalY;
            goalY = startY;
            startY = temp;
        }
        for (int i = startX; i <= goalX; i++)
        {
            //int j = 0;
            //foreach (char s in grid[i])
            //{
            //    if (j < goalY || j >= goalY)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        if ((s == '.'))
            //        {
            //            numberofWays++;
            //        }
            //    }
            //    j++;
            //}
            for (int k = startY; k <= goalY; k++)
            {
                if (grid[k][i] == '.')
                {
                    numberofWays++;
                }
            }
        }

        return numberofWays;
    }

    public static SinglyLinkedListNode reverse(SinglyLinkedListNode llist)
    {
        if (llist == null)
            return null;
        SinglyLinkedListNode Current = llist;
        SinglyLinkedListNode Next = null;
        SinglyLinkedListNode Previous = null;
        while (Current.next != null)
        {
            Next = Current.next;
            Current.next = Previous;
            Previous = Current;
            Current = Next;
        }
        return Previous;
    }

}

public class MinBribes
{
    public static void PrintBribes(List<int> people)
    {
        for (int i = people.Count - 1; i > 0; i--)
        {
            if (people[i] >= i + 2)
            {
                Console.WriteLine("Too Chaotic");

            }
        }
        for (int i = 0; i < people.Count; i++)
        {

        }
    }
}





