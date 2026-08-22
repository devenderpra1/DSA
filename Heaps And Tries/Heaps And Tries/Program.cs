Console.WriteLine("Hello, World!");


public class Tree
{

}
public class Heap
{
    List<int> ArrayRepresentationOfCBT { get; set; }

    public Heap(Tree head)
    {
        //LevelOrderTraversal and Update ArrayRepresentationOfCBT
    }

    public List<int> MaxHeap { get; set; }
    public List<int> MinHeap { get; set; }

    public List<int> BuildMinHeap()
    {
        var totalNoOfElement = ArrayRepresentationOfCBT.Count;
        for (var i = (totalNoOfElement / 2) - 1; i >= 0; i--)
        {

        }
    }

    public void Heapify(int index, int totalCount)
    {
        var left = index * 2 + 1;
        var right = index * 2 + 2;
        var minimum = index;

        if (left < totalCount && ArrayRepresentationOfCBT[left] < ArrayRepresentationOfCBT[minimum])
        {
            minimum = left;
        }
        if (right < totalCount && ArrayRepresentationOfCBT[right] < ArrayRepresentationOfCBT[minimum])
        {
            minimum = right;
        }

        if (ArrayRepresentationOfCBT[minimum] != ArrayRepresentationOfCBT[index])
        {
            //Swap(ArrayRepresentationOfCBT[minimum], ArrayRepresentationOfCBT[index]);
            Heapify(minimum, totalCount);
        }
    }
}