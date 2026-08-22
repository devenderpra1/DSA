
// Stacks using Linked List

//public class Stack<T>
//{
//    public class Node
//    {
//        public Node(T value)
//        {
//            Value = value;
//        }

//        public Node(T value, Node nextNode)
//            : this(value)
//        {
//            this.Next = nextNode;
//        }

//        public T Value;

//        public Node Next;
//    }
//    public Stack()
//    {
//        top = null;
//    }

//    private Node top;

//    public T Peek()
//    {
//        if (top == null)
//            throw new NotImplementedException("No Element in Stack");
//        return top.Value;
//    }

//    public T Push(T value)
//    {
//        if (top == null)
//            top = new Node(value);
//        else
//        {
//            var node = new Node(value);
//            node.Next = top;
//            top = node;
//        }
//        return top.Value;
//    }
//    public T Pop()
//    {
//        if (top == null)
//            throw new NotImplementedException("No Element in Stack");
//        var removedNode = top;
//        removedNode.Next = null;
//        top = top.Next;
//        return removedNode.Value;
//    }
//    public bool IsEmpty { get { return top == null; } }
//}

public class Results
{
    public int[] GetNearestLeftMin(int[] input)
    {
        System.Collections.Generic.Stack<int> stack = new System.Collections.Generic.Stack<int>();
        var result = new int[input.Length];
        int index = -1;
        for (int i = 0; i < input.Length; i++)
        {
            while (stack.TryPeek(out index) && input[index] >= input[i])
            {
                stack.Pop();
            }
            result[i] = stack.Count >= 1 ? stack.Peek() : -1;
            stack.Push(i);
        }
        return result;
    }

    public int[] GetNearestRightMin(int[] input)
    {
        System.Collections.Generic.Stack<int> stack = new System.Collections.Generic.Stack<int>();
        var result = new int[input.Length];

        int index = -1;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            while (stack.TryPeek(out index) && input[index] >= input[i])
            {
                stack.Pop();
            }
            result[i] = stack.Count >= 1 ? stack.Peek() : -1;
            stack.Push(i);
        }
        return result;
    }

    public Stack<int> SortAStackWithAStack(Stack<int> input)
    {
        var helperStack = new Stack<int>();
        while (!input.IsEmpty)
        {
            var current = input.Pop();
            while (!helperStack.IsEmpty && current < helperStack.Peek())
            {
                input.Push(helperStack.Pop());
            }
            //move to other
            helperStack.Push(current);
        }
        return helperStack;
    }

    public int[] GetNearestLeftMax(int[] inputs)
    {
        var result = new int[inputs.Length];
        Stack<int> indexStack = new Stack<int>();

        for (int i = 0; i < inputs.Length; i++)
        {
            while (!indexStack.IsEmpty && inputs[indexStack.Peek()] <= inputs[i])
            {
                indexStack.Pop();
            }

            result[i] = indexStack.IsEmpty ? -1 : indexStack.Peek();
            indexStack.Push(i);
        }
        return result;
    }

    public int[] GetNearestRightMax(int[] inputs)
    {
        var result = new int[inputs.Length];
        Stack<int> indexStack = new Stack<int>();

        for (int i = inputs.Length - 1; i >= 0; i--)
        {
            while (!indexStack.IsEmpty && inputs[indexStack.Peek()] <= inputs[i])
            {
                indexStack.Pop();
            }

            result[i] = indexStack.IsEmpty ? -1 : indexStack.Peek();
            indexStack.Push(i);
        }
        return result;
    }

    public int GetMaxRectangularAreaInHistogram(int[] heightOfEachBarOfHistogram)
    {
        int maxArea = 0;
        if (heightOfEachBarOfHistogram == null || heightOfEachBarOfHistogram.Any())
        {
            return maxArea;
        }
        // Get the point on left and right where height is same and not smaller to make a rectangular

        var leftMinArray = GetNearestLeftMin(heightOfEachBarOfHistogram);
        var rightMinArray = GetNearestRightMin(heightOfEachBarOfHistogram);

        for (var i = 0; i < heightOfEachBarOfHistogram.Length; i++)
        {
            var leftEnd = (leftMinArray[i] + 1);
            var rightEnd = (rightMinArray[i] == -1 ? heightOfEachBarOfHistogram.Length : rightMinArray[i]);
            maxArea = Math.Max(maxArea, (rightEnd - leftEnd) * heightOfEachBarOfHistogram[i]);
        }

        return maxArea;
    }

    public int GetSumOfAllDifferenceOfMaxMinOfAllSubArray(int[] input)
    {
        var totalSum = 0;

        var leftMinArray = GetNearestLeftMin(input);
        var leftMaxArray = GetNearestLeftMax(input);
        var rightMaxArray = GetNearestRightMax(input);
        var rightMinArray = GetNearestRightMin(input);

        var left = -1;
        var right = -1;
        var minContribution = 0;
        var maxContribution = 0;

        for (var i = 0; i < input.Length; i++)
        {
            //For each Index Find in how many sub array it is max and min for 
            left = leftMinArray[i];
            right = rightMinArray[i] == -1 ? input.Length : rightMinArray[i];
            minContribution = (i - left + 2) * (input.Length - right - 1 - i) * input[i];

            left = leftMaxArray[i];
            right = rightMaxArray[i] == -1 ? input.Length : rightMaxArray[i];
            maxContribution = (i - left + 2) * (input.Length - right - 1 - i) * input[i];

            totalSum += maxContribution - minContribution;
        }
        return totalSum;
    }

    public bool IsValid(string s)
    {
        Dictionary<char, char> brackets = new Dictionary<char, char>
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (brackets.TryGetValue(c, out char reqdOpening))
            {
                if (stack.TryPop(out char prevOpening))
                {
                    if (prevOpening != reqdOpening)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                stack.Push(c);
            }
        }
        return stack.Count > 0 ? false : true;
    }
}