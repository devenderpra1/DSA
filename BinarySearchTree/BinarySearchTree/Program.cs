using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BST nums = new BST();
            nums.Insert(50);
            nums.Insert(17);
            //nums.Insert(23);
            //nums.Insert(12);
            //nums.Insert(19);
            //nums.Insert(54);
            //nums.Insert(9);
            //nums.Insert(14);
            //nums.Insert(67);
            //nums.Insert(76);
            //nums.Insert(72);

            nums.PrintBST(nums.Head);
            Console.WriteLine(nums.Search(9));
            Console.WriteLine(nums.Max());
            Console.WriteLine(nums.Min());
        }
    }

    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value;

        public Node Right;
        public Node Left;

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class BST
    {
        public BST()
        {

        }

        public Node Head;

        public Node Current;

        public Node LatestParent;

        public void Insert(int value)
        {
            if (Head == null)
            {
                Head = new Node(value);
            }
            else
            {
                Current = Head;
                while (true)
                {
                    LatestParent = Current;
                    if (value < Current.Value)
                    {
                        Current = Current.Left;
                        if (Current == null)
                        {
                            LatestParent.Left = new Node(value);
                            break;
                        }
                    }
                    else if (value == Current.Value)
                    {
                        Current = Current.Left;
                        if (Current == null)
                        {
                            LatestParent.Left = new Node(value);
                            break;
                        }
                    }
                    else
                    {
                        Current = Current.Right;
                        if (Current == null)
                        {
                            LatestParent.Right = new Node(value);
                            break;
                        }
                    }
                }
            }
        }

        public void InsertRec(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);
            }
            InsertRecHelper(Head, new Node(data));
        }

        public void InsertRecHelper(Node parent, Node newNode)
        {
            if (newNode.Value < parent.Value)
            {
                if (parent.Left == null)
                    parent.Left = newNode;
                else
                    InsertRecHelper(parent.Left, newNode);
            }
            else if (newNode.Value == parent.Value)
            {
                if (parent.Left == null)
                    parent.Left = newNode;
                else
                    InsertRecHelper(parent.Left, newNode);
            }
            if (newNode.Value > parent.Value)
            {
                if (parent.Right == null)
                    parent.Right = newNode;
                else
                    InsertRecHelper(parent.Right, newNode);
            }
        }

        public void DeleteNode(int value)
        {
            if (Head == null)
                return;
            Delete(value, Head);
        }

        private Node Delete(int value, Node root)
        {
            if (root == null)
                return root;
            if (value == root.Value)
            {
                if (root.Right == null && root.Left == null)
                {
                    root = null;
                }
                else if (root.Right != null)
                {
                    root = root.Right;
                }
                else if (root.Left != null)
                {
                    root = root.Left;
                }
                else
                {
                    root.Value = MinHelper(root.Right).Value;
                    root.Right = Delete(root.Value, root.Right);
                }
            }
            else if (value < root.Value)
            {
                root.Left = Delete(value, root.Left);
            }
            else
            {
                root.Left = Delete(value, root.Left);
            }
            return root;
        }

        public bool Search(int value)
        {
            if (Head == null)
                return false;
            else
            {
                Current = Head;
                while (true)
                {
                    if (Current.Value == value)
                        return true;
                    else if (value < Current.Value)
                    {
                        Current = Current.Left;
                        if (Current == null)
                            return false;
                    }
                    else
                    {
                        Current = Current.Right;
                        if (Current == null)
                            return false;
                    }
                }

            }
        }

        public object SearchRecursive(int value, Node node)
        {
            if (node == null)
                return "Not found";
            else
            {
                Current = node;
                if (Current.Value == value)
                    return value;
                else if (value < Current.Value)
                {
                    return SearchRecursive(value, Current.Left);
                }
                else
                {
                    return SearchRecursive(value, Current.Right);
                }
            }
        }

        public void PrintBST(Node node)
        {
            if (node == null)
                return;

            if (node.Left != null)
                PrintBST(node.Left);

            Console.WriteLine(node.Value);

            if (node.Right != null)
                PrintBST(node.Right);
        }

        public Node Min()
        {
            if (Head == null)
                return Head;
            return MinHelper(Head);
        }

        private Node MinHelper(Node node)
        {
            if (node.Left == null)
                return node;
            return MinHelper(node.Left);
        }

        public Node Max()
        {
            if (Head == null)
                return Head;
            return MaxHelper(Head);
        }

        private Node MaxHelper(Node node)
        {
            if (node.Right == null)
                return node;
            return MaxHelper(node.Right);
        }

        private void InsertNode(int value)
        {
            if (Head == null)
                return;
            var Current = Head;
            while (true)
            {
                if (Current == null)
                {
                    Current = new Node(value);
                }
                else if (value < Current.Value)
                {
                    InsertNode()
                }
                else if (value > Current.Value)
                {

                }
            }
        }

    }
}
