using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeKnight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IsleapYear(1600);

            //var tree = new Node() { Value = 1 };

            List<int> nums = new List<int>() { -4, 3, -9, 0, 4, 1 };
            plusMinus(nums);
        }
        public static void plusMinus(List<int> arr)
        {
            /*
            double avgPositive = arr.Count(a => a > 0);
            double avgNegative = arr.Count(a => a < 0);
            double avgzero = arr.Count(a => a == 0);

            double rPos = avgPositive / arr.Count;
            double rNeg = avgNegative / arr.Count;
            double rZer = avgzero / arr.Count;

            Console.WriteLine($"{Math.Round((double)(avgPositive / arr.Count), 6)}{Environment.NewLine}{Math.Round((double)(avgNegative / arr.Count), 6)}{Environment.NewLine}{Math.Round((double)(avgzero / arr.Count), 6)}");
            */

            List<string> stringList = new List<string>() { "abc", "defg", "jklmk", "nopkqidjdj" };

            stringList.Sort(ComapareString);

            stringList.ForEach(a => Console.WriteLine(a));
        }

        public static int ComapareString(this string first, string second)
        {
            if (first.Count() > second.Count())
                return -1;
            return 1;
        }

        public static bool IsleapYear(int year)
        {
            Console.WriteLine(year % 100 != 0 ? year / 100 + 1 : year / 100);
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
                return true;
            return false;
        }
    }

    public class Node
    {
        public Node()
        {

        }
        public string Value;
        public Node Right;
        public Node Left;


        public void PrintINOrder(Node node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.Value);
            PrintINOrder(node.Left);
            PrintINOrder(node.Right);
        }
    }

    public static class General
    {
        public static int ComapareString(this string first, string second)
        {
            if (first.Count() > second.Count())
                return -1;
            return 0;
        }
    }
}
