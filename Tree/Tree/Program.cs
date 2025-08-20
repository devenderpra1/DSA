// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class BinaryNode
{
    public BinaryNode right;
    public BinaryNode left;

    public int Value;
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

        public int HeightOfTreeIterative(BinaryNode head)
        {
            if (head == null)
            {
                return 0;
            }
            Queue<BinaryNode> queue = new Queue<BinaryNode>();
            queue.Enqueue(head);
            BinaryNode dummyNode = null;
            queue.Enqueue(dummyNode);
            var height = 1;
            while (queue.Count > 1)
            {
                var currentNode = queue.Dequeue();
                if (currentNode == null)
                {
                    height++;
                    queue.Enqueue(dummyNode);
                    continue;
                }
                if (currentNode.left != null)
                    queue.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    queue.Enqueue(currentNode.right);

                Console.WriteLine(currentNode.Value);
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
    }
}