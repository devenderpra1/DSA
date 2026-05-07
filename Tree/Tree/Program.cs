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
    public class RecursiveBSTHelper
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
        public void InorderTreeTraversal(BinaryNode node, List<int> binaryNodes)
        {
            if (node == null)
            {
                return;
            }
            InOrderTreeTraversal(node.left);
            binaryNodes.Add(node.Value);
            InOrderTreeTraversal(node.right);
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
    public class IterativeBSTHelper
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
}