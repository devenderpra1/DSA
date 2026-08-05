// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Hello, World!");


public class BinaryNode
{
    private BinaryNode()
    {

    }

    public BinaryNode(int value)
    {
        this.Value = value;
    }

    public BinaryNode right;
    public BinaryNode left;

    public int Value;

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not BinaryNode)
            return false;

        return this.Value == ((BinaryNode)obj).Value;
    }

    public class BinaryNodeBuilder
    {
        public BinaryNodeBuilder()
        {
            this.BinaryNode = new BinaryNode();
        }

        private BinaryNode BinaryNode;

        public BinaryNodeBuilder AddLeft(BinaryNode leftBinaryNode)
        {
            this.BinaryNode.left = leftBinaryNode;
            return this;
        }
        public BinaryNodeBuilder AddRight(BinaryNode rightBinaryNode)
        {
            this.BinaryNode.right = rightBinaryNode;
            return this;
        }
        public BinaryNode Build()
        {
            return BinaryNode;
        }
    }
}

public class BinaryTree
{
    BinaryNode head;
    public class RecursiveBinaryTreeHelper
    {
        //Left Head Right
        public void InOrderTreeTraversal(BinaryNode node)
        {
            if (node == null)
            {
                return;
            }
            InOrderTreeTraversal(node.left);
            Console.WriteLine(node.Value);
            InOrderTreeTraversal(node.right);
        }
        public void InOrderTreeTraversal(BinaryNode node, List<int> binaryNodes)
        {
            if (node == null)
            {
                return;
            }
            InOrderTreeTraversal(node.left, binaryNodes);
            binaryNodes.Add(node.Value);
            InOrderTreeTraversal(node.right, binaryNodes);
        }
        //Node Left Right
        public void PreOrderTreeTraversal(BinaryNode node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.Value);
            PreOrderTreeTraversal(node.left);
            PreOrderTreeTraversal(node.right);
        }
        public void PostOrderTreeTraversal(BinaryNode node)
        {
            if (node == null)
            {
                return;
            }
            PostOrderTreeTraversal(node.left);
            PostOrderTreeTraversal(node.right);
            Console.WriteLine(node.Value);
        }
        public int HeightOfATree(BinaryNode binaryNode)
        {
            if (binaryNode == null)
                return -1;

            var leftHeight = HeightOfATree(binaryNode.left);
            var rightHeight = HeightOfATree(binaryNode.right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }
    public class IterativeBinaryTreeHelper
    {
        //Left To Right on each Level
        public void LevelOrderTraversal(BinaryNode headNode)
        {
            Queue<BinaryNode> queue = new Queue<BinaryNode>();
            queue.Enqueue(headNode);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.left != null)
                    queue.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    queue.Enqueue(currentNode.right);
                Console.WriteLine(currentNode.Value);
            }
        }
        public List<BinaryNode> LevelOrderTraversalLeftToRight(BinaryNode headNode)
        {
            if (headNode == null)
            {
                return new List<BinaryNode>();
            }
            Queue<BinaryNode> queue = new Queue<BinaryNode>();
            queue.Enqueue(headNode);
            queue.Enqueue(null);
            var levelOrderTraversal = new List<BinaryNode>();
            while (queue.Count > 1)
            {
                var currentNode = queue.Dequeue();
                if (currentNode == null && queue.Count > 1)
                {
                    queue.Enqueue(null);
                }
                levelOrderTraversal.Add(currentNode);
                if (currentNode.left != null)
                    queue.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    queue.Enqueue(currentNode.right);
            }
            return levelOrderTraversal;
        }
        public List<BinaryNode> LevelOrderTraversalRightToLeft(BinaryNode headNode)
        {
            if (headNode == null)
            {
                return new List<BinaryNode>();
            }
            Queue<BinaryNode> queue = new Queue<BinaryNode>();
            queue.Enqueue(headNode);
            var levelOrderTraversal = new List<BinaryNode>();
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                levelOrderTraversal.Add(currentNode.left);
                if (currentNode.right != null)
                    queue.Enqueue(currentNode.right);
                if (currentNode.left != null)
                    queue.Enqueue(currentNode.left);
            }
            return levelOrderTraversal;
        }
        public int HeightOfTreeIterativeWithNullNode(BinaryNode head) // N -> logN
        {
            if (head == null)
            {
                return 0;
            }
            Queue<BinaryNode> queue = new Queue<BinaryNode>();
            queue.Enqueue(head);
            queue.Enqueue(null);
            var height = 0;
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode == null)
                {
                    height++;
                    if (queue.Count > 0)
                        queue.Enqueue(null);
                    continue;
                }
                if (currentNode.left != null)
                    queue.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    queue.Enqueue(currentNode.right);
            }
            return height;
        }
        public int HeightOfTreeIterative(BinaryNode head) // N -> logN
        {
            if (head == null)
            {
                return 0;
            }
            Queue<BinaryNode> queue = new Queue<BinaryNode>();
            queue.Enqueue(head);
            var height = 0;
            while (queue.Count > 0)
            {
                var elementsInCurrentLevel = queue.Count;
                for (var i = 0; i < elementsInCurrentLevel; i++)//Add all the next level element
                {
                    var currentNode = queue.Dequeue();
                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);
                }
                if (queue.Count > 1)//If next level has element add to height
                    height++;
            }
            return height;
        }
        public void InOrderTraversal(BinaryNode head)
        {
            Stack<BinaryNode> stack = new Stack<BinaryNode>();
            var currentNode = head;
            while (stack.Count > 0 || currentNode != null)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }
                var node = stack.Pop();
                Console.WriteLine(node);
                if (node.right != null)
                    currentNode = node.right;
            }
        }
        public List<BinaryNode> VerticalOrderTraversal(BinaryNode head)
        {
            if (head == null)
                return new List<BinaryNode>();
            Queue<(BinaryNode node, int height)> nodesWithHeight = new Queue<(BinaryNode node, int height)>();
            nodesWithHeight.Enqueue((head, 0));

            Dictionary<int, List<BinaryNode>> nodeAtEachHeight = new Dictionary<int, List<BinaryNode>>();

            var maxHeight = 0;
            var minHeight = 0;

            while (nodesWithHeight.Count > 0)
            {
                var currentNode = nodesWithHeight.Dequeue();
                maxHeight = Math.Max(maxHeight, currentNode.height);
                minHeight = Math.Min(minHeight, currentNode.height);
                if (nodeAtEachHeight.TryGetValue(currentNode.height, out var nodeList))
                {
                    nodeList.Add(currentNode.node);
                }
                else
                {
                    nodeAtEachHeight[currentNode.height] = new List<BinaryNode>() { currentNode.node };
                }

                if (currentNode.node.left != null)
                {
                    var leftNode = currentNode.node.left;
                    nodesWithHeight.Enqueue((leftNode, currentNode.height - 1));
                }
                if (currentNode.node.right != null)
                {
                    var rightNode = currentNode.node.right;
                    nodesWithHeight.Enqueue((rightNode, currentNode.height + 1));
                }
            }

            var verticalOrderTraversal = new List<BinaryNode>();
            for (int i = minHeight; i <= maxHeight; i++)
            {
                foreach (var node in nodeAtEachHeight[i])
                {
                    verticalOrderTraversal.Add(node);
                }
            }
            return verticalOrderTraversal;
        }
        public void LeftView(BinaryNode headNode)
        {
            //First Element in level order with null identifier or
            //prepare with height info as well and first element of each height
        }
        public void RightView()
        {
            //Last Element in level order(L->R) with null identifier or
            //First Element in level order(R->L) with null identifier or
            //prepare with height info as well and first element of each height
        }
        public void TopView()
        {
            //First item in each level in vertical order
        }
        public void BottomView()
        {
            //Last item in each level in vertical order
        }

        //Post Order and In Order
        public BinaryNode CreateTreePostAndInOrder(Dictionary<int, int> inOrderNodePosition, List<int> postOrder, List<int> inOrder, int postStart, int postEnd, int inStart, int inEnd)
        {
            if (inStart > inEnd)
                return null;

            var currentNode = new BinaryNode(postOrder[postEnd]);
            var inHeadposition = inOrderNodePosition[postOrder[postEnd]];
            var noOfLeftElements = (inHeadposition - 1) - inStart + 1;
            currentNode.left = CreateTreePostAndInOrder(inOrderNodePosition, postOrder, inOrder, postStart, postStart + noOfLeftElements, inStart, inHeadposition - 1);
            currentNode.right = CreateTreePostAndInOrder(inOrderNodePosition, postOrder, inOrder, postStart + noOfLeftElements + 1, postEnd - 1, inHeadposition + 1, inEnd);
            return currentNode;
        }

        public BinaryNode CreateTreePreAndInOrder(Dictionary<int, int> preNodePosition, List<int> preOrder, List<int> inOrder, int prestart, int preEnd, int inStart, int inEnd)
        {
            if (inStart > inEnd)
                return null;

            var currentNode = new BinaryNode(preOrder[prestart]);
            var inHeadposition = preNodePosition[preOrder[prestart]];
            int noOfItemOnPreLeft = (inHeadposition - 1) - inStart + 1;
            currentNode.left = CreateTreePreAndInOrder(preNodePosition, preOrder, inOrder, prestart + 1, prestart + noOfItemOnPreLeft, inStart, inHeadposition - 1);
            currentNode.right = CreateTreePreAndInOrder(preNodePosition, preOrder, inOrder, prestart + noOfItemOnPreLeft + 1, preEnd, inHeadposition + 1, inEnd);
            return currentNode;
        }
    }
    public class BinarySearchTree
    {
        public BinaryNode SearchNode(BinaryNode head, int value)
        {
            if (head == null)
                return null;
            if (head.Value == value)
                return head;
            if (head.Value >= value)
            {
                return SearchNode(head.left, value);
            }
            else
            {
                return SearchNode(head.right, value);
            }
        }
        public BinaryNode InsertNodeRecursive(BinaryNode head, int value)
        {
            if (head == null)
                return new BinaryNode(value);
            if (value < head.Value)
            {
                head.left = InsertNodeRecursive(head.left, value);
            }
            else if (value > head.Value)
            {
                head.right = InsertNodeRecursive(head.right, value);
            }
            return head;
        }
        public BinaryNode InsertNodeIterative(BinaryNode head, int value)
        {
            if (head == null)
            {
                head = new BinaryNode(value);
            }
            else
            {
                var parent = head;
                var current = head;
                while (current != null)
                {
                    parent = current;
                    if (value < parent.Value)
                    {
                        current = current.left;
                    }
                    else
                    {
                        current = current.right;
                    }
                }

                if (value < parent.Value)
                {
                    parent.left = new BinaryNode(value);
                }
                else
                {
                    parent.right = new BinaryNode(value);
                }
            }
            return head;
        }
        public BinaryNode DeleteNode(BinaryNode head, int value)
        {
            var nodeToDelete = SearchNode(head, value);

            if (nodeToDelete != null)
            {
                if (nodeToDelete.right == null || nodeToDelete.right == null)
                {

                }
            }
            return nodeToDelete;
        }

        public bool isBST(BinaryNode head, int minValue = Int32.MinValue, int max = Int32.MaxValue)
        {
            if (head == null)
            { return true; }
            if (head.Value < max && head.Value > minValue)
            {
                return isBST(head.left, minValue, head.Value - 1) && isBST(head.right, head.Value + 1, max);
            }
            return false;
        }
    }
}

public class BinarySearchTree
{

    //One way is GetInOrder and find the first anomaly where bigger will be present before smaller as any element Swapped will defy this logic.
    //And larger will come first than the smaller - you will keep i-1 as First and i as second Element
    //Simmilarly you need to scan the rest of the array finding the anomaly and you can update the second
    public (int?, int?) FindSwappedNumbersOnTheFly(BinaryNode head)
    {
        int? first = null;
        int? second = null;
        BinaryNode prevNode = null;
        FindSwappedNumbersInorder(head, prevNode, ref first, ref second);
        return (first, second);
    }

    private void FindSwappedNumbersInorder(BinaryNode current, BinaryNode prevNode, ref int? first, ref int? second)
    {
        if (current == null)
            return;
        FindSwappedNumbersInorder(current.left, prevNode, ref first, ref second);
        if (prevNode != null && prevNode.Value > current.Value)
        {
            if (first == null) first = prevNode.Value;
            second = prevNode.Value;
        }
        else
        {
            prevNode = current;
            FindSwappedNumbersInorder(current.right, prevNode, ref first, ref second);
        }
    }

    public void FindCommonPathBetweenTwoNodes()
    {

    }

    public List<BinaryNode> FindPath(BinaryNode head, BinaryNode targetNode, bool isBST)
    {
        if (head == null)
        {
            return new List<BinaryNode>();
        }
        Stack<BinaryNode> pathStack = new Stack<BinaryNode>();
        if (isBST)
            FindElementInBSTWithPath(head, targetNode, pathStack);
        else
            FindElementWithPath(head, targetNode, pathStack);
        return pathStack.ToList();
    }

    private bool FindElementWithPath(BinaryNode head, BinaryNode targetNode, Stack<BinaryNode> pathStack)
    {
        if (head == null)
            return false;

        if (head.Value == targetNode.Value)
        {
            return true;
        }

        if (FindElementWithPath(head.left, targetNode, pathStack) || FindElementWithPath(head.right, targetNode, pathStack))
        {
            pathStack.Push(head);
            return true;
        }
        return false;
    }

    private bool FindElementInBSTWithPath(BinaryNode head, BinaryNode targetNode, Stack<BinaryNode> pathStack)
    {
        if (head == null)
            return false;

        if (head.Value == targetNode.Value)
        {
            return true;
        }

        if (targetNode.Value < head.Value)
        {
            var elementFound = FindElementInBSTWithPath(head.left, targetNode, pathStack);
            if (elementFound) pathStack.Push(head);
            return elementFound;
        }
        else if (targetNode.Value > head.Value)
        {
            var elementFound = FindElementInBSTWithPath(head.right, targetNode, pathStack);
            if (elementFound) pathStack.Push(head);
            return elementFound;
        }
        return false;
    }

    public BinaryNode FindLowestCommonAncestorInBST(BinaryNode head, BinaryNode node1, BinaryNode node2)
    {
        if (head == null)
            return null;


        if (node1.Value < head.Value && node2.Value < head.Value)
        {
            return FindLowestCommonAncestorInBST(head.left, node1, node2);
        }
        else if (node1.Value > head.Value && node2.Value > head.Value)
        {
            return FindLowestCommonAncestorInBST(head.left, node1, node2);
        }
        else
        {
            return head;
        }
    }

    public void FindKthSmallestElement(BinaryNode head, ref int position)
    {
        if (head == null)
        {
            return;
        }
        FindKthSmallestElement(head.left, ref position);
        FindKthSmallestElement(head.right, ref position);
    }

    public List<int> MorrisInOrderTraversal()
    {
        List<int> result = new List<int>();
        return result;
    }

    public void DeleteANodeInBST(BinaryNode root, BinaryNode nodeToDelete, BinaryNode prevNode = null)
    {
        if (root == null)
        {
            return;
        }
        else if (root == nodeToDelete)
        {
            var wasLeft = prevNode.left == nodeToDelete;
            if (root.left == null && root.right == null)
            {
                if (wasLeft)
                {
                    prevNode.left = null;
                }
                else
                {
                    prevNode.right = null;
                }
            }
            else if (root.left == null)
            {
                if (wasLeft)
                {
                    prevNode.left = nodeToDelete.right;
                }
                else
                {
                    prevNode.right = nodeToDelete.right;
                }
            }
            else if (root.right == null)
            {
                if (wasLeft)
                {
                    prevNode.left = nodeToDelete.left;
                }
                else
                {
                    prevNode.right = nodeToDelete.left;
                }
            }
            else
            {
                var inorderSuccessor = nodeToDelete.left;
                while (inorderSuccessor.right != null)
                {
                    inorderSuccessor = inorderSuccessor.right;
                }
                if (wasLeft)
                {
                    prevNode.left = inorderSuccessor;
                    inorderSuccessor.right = nodeToDelete.right;
                    inorderSuccessor.left = nodeToDelete.left;
                }
                else
                {
                    prevNode.right = inorderSuccessor;
                    inorderSuccessor.right = nodeToDelete.right;
                    inorderSuccessor.left = nodeToDelete.left;
                }
                DeleteANodeInBST(inorderSuccessor, nodeToDelete);
            }
        }
        else if (root.Value < nodeToDelete.Value)
        {
            prevNode = root;
            DeleteANodeInBST(root.right, nodeToDelete, prevNode);
        }
        else if (root.Value > nodeToDelete.Value)
        {
            prevNode = root;
            DeleteANodeInBST(root.right, nodeToDelete, prevNode);
        }
    }

    public BinaryNode ConstructBinaryTreeFromPostAndInOrder(List<BinaryNode> postOrder, List<BinaryNode> inOrder)
    {
        var inOrderNodePosition = new Dictionary<int, int>();
        for (int i = 0; i < inOrder.Count; i++)
        {
            inOrderNodePosition[inOrder[i].Value] = i;
        }
        return ConstructBinaryTreeFromPreAndInOrder(postOrder, inOrder, inOrderNodePosition, 0, postOrder.Count - 1, 0, postOrder.Count - 1);
    }

    public BinaryNode ConstructBinaryTreeFromPreAndInOrder(List<BinaryNode> preOrder, List<BinaryNode> inOrder, Dictionary<int, int> inOrderNodePosition, int inStart, int inEnd, int preStart, int preEnd)
    {
        if (inStart > inEnd)
            return null;
        var currentNode = preOrder[preStart];
        var inHeadposition = inOrderNodePosition[currentNode.Value];
        int noOfItemOnPreLeft = (inHeadposition - 1) - inStart + 1;
        currentNode.left = ConstructBinaryTreeFromPreAndInOrder(preOrder, inOrder, inOrderNodePosition, inStart, inHeadposition - 1, preStart + 1, preStart + noOfItemOnPreLeft);
        currentNode.right = ConstructBinaryTreeFromPreAndInOrder(preOrder, inOrder, inOrderNodePosition, inHeadposition + 1, inEnd, preStart + noOfItemOnPreLeft + 1, preEnd);
        return currentNode;

    }

    public void InOrderTraversal(BinaryNode head, List<int> result)
    {
        if (head == null)
            return;
        var currentNode = head;

        var stack = new Stack<BinaryNode>();
        stack.Push(currentNode);

        while (currentNode != null)
        {
            while (currentNode.left != null)
            {
                stack.Push(currentNode.left);
                currentNode = currentNode.left;
            }
            currentNode = stack.Pop();
            result.Add(currentNode.Value);
            if (currentNode.right != null)
            {
                stack.Push(currentNode.right);
                currentNode = currentNode.right;
            }
        }
    }
}