using System.Collections.Generic;

public class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        //var numList = new List<int>() { 5, 63, 93, 2, 44, 21, 32, 93, 54 };
        //var numList1 = new List<int>() { 5 };

        //var listoperation = new LISTOperation(numList1);
        ////listoperation.GetMAX();
        ////listoperation.GetMIN();
        ////listoperation.GetMaxMin();
        ////listoperation.GetMaxProfitBrutForce();
        ////listoperation.Reverse();
        ////listoperation.GetMaxProfit();

        ////var sorted1 = new List<int>() { 1, 2, 4 };
        ////var sorted2 = new List<int>() { 3 };
        ////listoperation.SortingOfTwoSortedList(sorted1, sorted2);

        //var unsortedArray = new int[3] { 17, 14, 15 };
        //var sortedarray = listoperation.MergeSort(unsortedArray);
        //foreach (int i in sortedarray)
        //{
        //    Console.WriteLine(i);
        //}
        var effectiveDate = "24-02-2021 00:00:00";
        var parsed = DateTime.ParseExact(effectiveDate, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);    
    }
}

public class A : B
{
    public A(int a, int b)
        : base(b)
    {
        this.a = a;
    }

    public int a;
}

public class B
{
    public B(int b)
    {
        this.b = b;
    }
    public int b;
}

public class LISTOperation
{
    public List<int> numList;

    public LISTOperation(List<int> numList1)
    {
        this.numList = numList1;
    }

    public void GetMAX()
    {
        var max1 = Int32.MinValue;
        var max2 = Int32.MinValue;

        foreach (int i in numList)
        {
            if (i > max1)
            {
                max2 = max1;
                max1 = i;
            }
            else if (i < max1 && i > max2)
            {
                max2 = i;
            }
        }
        if (max2 == Int32.MinValue)
            max2 = max1;
        Console.WriteLine($"Maximum is {max1}, Second Maximum is {max2}");
    }

    public void GetMIN()
    {
        var min1 = Int32.MaxValue;
        var min2 = Int32.MaxValue;

        foreach (int i in numList)
        {
            if (i < min1)
            {
                min2 = min1;
                min1 = i;
            }
            else if (i < min2 && i > min1)
            {
                min2 = i;
            }
            if (min2 == Int32.MaxValue)
            {
                min2 = min1;
            }
        }
        Console.WriteLine($"The first minimum is : {min1} and Second: {min2}.");
    }

    public void GetMaxMin()
    {
        var min = Int32.MaxValue;
        var max = Int32.MinValue;

        foreach (int i in numList)
        {
            if (i < min)
            {
                min = i;
            }
            if (i > max)
            {
                max = i;
            }
            if (max == Int32.MinValue)
            {
                max = min;
            }
            if (min == Int32.MaxValue)
            {
                min = max;
            }
        }
        Console.WriteLine($"The maximum is : {max} and Minimum: {min}.");
    }

    public void GetMaxProfit()
    {
        var buyPrice = Int32.MaxValue;
        var sellPrice = Int32.MinValue;
        var profit = 0;
        var count = numList.Count - 1;
        for (int i = 0; i <= count; i++)
        {
            if (numList[i] < buyPrice)
            {
                buyPrice = numList[i];
            }
            if (numList[count - i] > sellPrice) { sellPrice = numList[count - i]; }
        }
        if (buyPrice == Int32.MaxValue)
            Console.WriteLine("You have no share Purchased");
        else { Console.WriteLine($"You can Buy @ {buyPrice} and Sell @ {sellPrice}"); }
    }

    public void GetMaxProfitBrutForce()
    {
        var count = numList.Count;

        List<Tuple<int, int>> buyselloption = new List<Tuple<int, int>>();
        for (int i = 0; i < (count - 1); i++)
        {
            int buyprice = numList[i];
            int sellPrice = 0;
            for (int j = i; j < count - 1; j++)
            {
                int min = buyprice;
                if (numList[j] > min)
                    sellPrice = numList[j];
            }
            if (sellPrice == 0)
                sellPrice = buyprice;
            buyselloption.Add(Tuple.Create(buyprice, sellPrice));
        }

        foreach (var i in buyselloption) { Console.WriteLine($"Buy Price is {i.Item1} and Sell Price is {i.Item2}"); }
    }

    public void Reverse()
    {
        var count = numList.Count - 1;
        for (int i = 0; i <= count; i++)
        {
            var temp = numList[i];
            numList[i] = numList[count - i];
            numList[count - i] = temp;
        }

        foreach (var item in numList)
        {
            Console.WriteLine($"{item}");
        }
    }

    public void SortingOfTwoSortedList(List<int> sortedList1, List<int> sortedList2)
    {
        var countList1 = sortedList1.Count;
        var countList2 = sortedList2.Count;
        int i = 0;
        int j = 0;
        int[] arrayOutput = new int[countList1 + countList2];
        while (i < countList1 && j < countList2)
        {
            if (sortedList1[i] <= sortedList2[j])
            {
                arrayOutput[i + j] = sortedList1[i];
                i++;
            }
            else if (sortedList1[i] > sortedList2[j])
            {
                arrayOutput[i + j] = sortedList2[j];
                j++;
            }
        }
        if (j == countList2)
        {
            while (i < countList1)
            {
                arrayOutput[(i + j)] = sortedList1[i];
                i++;
            }
        }
        if (i == countList1)
        {
            while (j < countList2)
            {
                arrayOutput[(i + j)] = sortedList2[j];
                j++;
            }
        }
        foreach (var item in arrayOutput)
        {
            Console.WriteLine($"{item}");
        }
    }

    public int[] SortingOfTwoSortedArray(int[] sortedList1, int[] sortedList2)
    {
        var countList1 = sortedList1.Length;
        var countList2 = sortedList2.Length;
        int i = 0;
        int j = 0;
        int[] arrayOutput = new int[countList1 + countList2];
        while (i < countList1 && j < countList2)
        {
            if (sortedList1[i] <= sortedList2[j])
            {
                arrayOutput[i + j] = sortedList1[i];
                i++;
            }
            else if (sortedList1[i] > sortedList2[j])
            {
                arrayOutput[i + j] = sortedList2[j];
                j++;
            }
        }
        if (j == countList2)
        {
            while (i < countList1)
            {
                arrayOutput[(i + j)] = sortedList1[i];
                i++;
            }
        }
        if (i == countList1)
        {
            while (j < countList2)
            {
                arrayOutput[(i + j)] = sortedList2[j];
                j++;
            }
        }
        return arrayOutput;
    }

    public int[] MergeSort(int[] unsortedArray)
    {
        var unsortedArrayLength = unsortedArray.Length;
        if (unsortedArray.Count() == 1)
        {
            return unsortedArray;
        }

        var mid = unsortedArrayLength / 2;
        var leftArray = new int[mid];
        var rightArray = new int[unsortedArrayLength - mid];

        for (int i = 0; i < unsortedArrayLength; i++)
        {
            if (i < mid)
                leftArray[i] = unsortedArray[i];
            else
                rightArray[i - mid] = unsortedArray[i];
        }

        leftArray = MergeSort(leftArray);
        rightArray = MergeSort(rightArray);

        return SortingOfTwoSortedArray(leftArray, rightArray);
    }

    //public int[] QuickSort(int[] unsortedArray)
    //{
    //    var pivotIndx = 0;
    //    var end = unsortedArray.Length;
    //    if (unsortedArray.Count() == 1)
    //        return unsortedArray;
    //    int i = 1;
    //    int j = end;
    //    while(pivotIndx < end)
    //    {


    //    }
    //}

    public void TwoSumProblem() { }
}