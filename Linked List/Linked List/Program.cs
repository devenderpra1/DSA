// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class LinkedList
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public Node(int value, Node nextNode)
            : this(value)
        {
            this.Next = nextNode;
        }

        public int Value;

        public Node Next;
    }

    public class SpecialNode
    {
        public SpecialNode(int value)
        {
            Value = value;
        }

        public SpecialNode(int value, SpecialNode nextNode)
            : this(value)
        {
            this.Next = nextNode;
        }
        public int Value;

        public SpecialNode Next;

        public SpecialNode Random;
    }

    //0 based position

    public Node DeleteAtTail(Node head)
    {
        if (head == null)
            return null;
        if (head.Next == null)
        {
            head = null;
            return head;
        }
        var current = head;
        if (current.Next != null && current.Next.Next != null)
        {
            current = current.Next;
        }
        var temp = current.Next;
        current.Next = null;
        return temp;
    }
    public bool TryInsertNode(ref Node head, int position, int value)
    {
        if (position == 0)
        {
            Node newNode = new Node(value, head);
            head = newNode;
            return true;
        }
        if (head == null)
            return false;

        var positionTracker = 0;
        var currentNode = head;
        while (currentNode != null)
        {
            if (positionTracker == position - 1)
                break;
            currentNode = currentNode.Next;
            positionTracker++;
        }
        if (positionTracker != position - 1)
        {
            return false;
        }
        else
        {
            Node newNode = new Node(value, currentNode.Next);
            currentNode.Next = newNode;

            return true;
        }
    }

    public Node CloneLinkedList(Node head)
    {
        if (head == null)
            return null;
        var newHead = new Node(head.Value);
        var currentNewLinkedList = newHead;
        Node current = head;
        while (current.Next != null)
        {
            currentNewLinkedList.Next = new Node(current.Next.Value);
            currentNewLinkedList = currentNewLinkedList.Next;
            current = current.Next;
        }
        return newHead;
    }
    public SpecialNode DeepCloneASpecialLinkedListWithHashset(SpecialNode head)
    {
        if (head == null)
        {
            return null;
        }
        var current = head;

        Dictionary<SpecialNode, SpecialNode> OldNodeToNewNode = new Dictionary<SpecialNode, SpecialNode>();
        while (current != null)
        {
            var newNode = new SpecialNode(current.Value);

            OldNodeToNewNode.Add(current, newNode);
            current = current.Next;
        }
        current = head;

        while (current != null)
        {
            if (current.Random != null)
                OldNodeToNewNode[current].Random = OldNodeToNewNode[current.Random];
            if (current.Next != null)
                OldNodeToNewNode[current].Next = OldNodeToNewNode[current.Next];
            current = current.Next;
        }
        return OldNodeToNewNode[head];
    }
    public Node ReverseALinkedList(Node head)
    {
        Node prevNode = head;
        if (prevNode == null || prevNode.Next == null)
        {
            return head;
        }
        prevNode.Next = null;
        Node Current = head.Next;
        while (Current != null)
        {
            var tempNext = Current.Next;
            Current.Next = prevNode;
            prevNode = Current;
            Current = tempNext;
        }
        return prevNode;
    }

    public Node ReverseLinkedListPractice(Node head)
    {
        if (head == null)
        {
            return null;
        }
        var newHead = head;
        var next = head.Next;
        Node prev = null;
        newHead.Next = prev;
        while (next != null)
        {
            prev = newHead;
            newHead = next;
            next = newHead.Next;
            newHead.Next = prev;
        }
        return newHead;
    }
    public SpecialNode DeepCloneInterleavingTechnique(SpecialNode head)
    {
        if (head == null)
        {
            return null;
        }
        var current = head;
        while (current != null)
        {
            var newNode = new SpecialNode(current.Value);
            newNode.Next = current.Next;
            current.Next = newNode;
            current = newNode.Next;
        }
        current = head;
        while (current != null)
        {
            if (current.Random != null)
                current.Next.Random = current.Random.Next;
            current = current.Next.Next;
        }
        current = head;
        var newHead = head.Next;
        var newCurrent = newHead;
        while (current != null)
        {
            var tempPointer = current.Next;
            current.Next = tempPointer.Next;
            current = current.Next;
            newCurrent.Next = current.Next;
            newCurrent = newCurrent.Next;
        }
        return newHead;
    }
    public Node MergeSortedLinkedList(Node head1, Node head2)
    {
        var current1 = head1;
        var current2 = head2;
        Node headRequired = null;
        if (current1 == null && current2 == null)
        {
            return null;
        }
        else if (current1 == null)
        {
            return current2;
        }
        else if (current2 == null)
        {
            return current1;
        }
        else
        {
            if (current1.Value < current2.Value)
            {
                headRequired = current1;
                current1 = current1.Next;
            }
            else
            {
                headRequired = current2;
                current2 = current2.Next;
            }
        }

        Node finalHead = headRequired;


        while (current1 != null && current2 != null)
        {
            if (current1.Value < current2.Value)
            {
                headRequired.Next = current1;
                headRequired = headRequired.Next;
                current1 = current1.Next;
            }
            else
            {
                headRequired.Next = current2;
                headRequired = headRequired.Next;
                current2 = current2.Next;
            }
        }

        if (current1 != null)
        {
            headRequired.Next = current1;
        }
        else if (current2 != null)
        {
            headRequired.Next = current2;
        }
        return finalHead;
    }

    //Second Mid in Even Cases
    public Node GetMiddleNode(Node head)
    {
        var slow = head;
        var fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        return slow;
    }
    public Node GetMidNode(Node head)
    {
        var slow = head;
        var fast = head;

        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        return slow;
    }
    public Node MergeSortLinkedList(Node head)
    {
        if (head == null || head.Next == null)
            return head;
        var currentHead = head;
        var mid = GetMidNode(head);
        var firstStart = head;
        var secondStart = mid.Next;
        mid.Next = null;

        MergeSortLinkedList(firstStart);
        MergeSortLinkedList(secondStart);
        return MergeSortedLinkedList(firstStart, secondStart);
    }
    public Node GetCyclicStartNode(Node head)
    {
        if (head == null)
            return null;
        var slow = head;
        var fast = head;

        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
            if (slow == fast)
            {
                break;
            }
        }
        if (fast.Next == null || fast.Next.Next == null)
        {
            return null;
        }

        slow = head;

        while (slow != fast)
        {
            slow = slow.Next;
            fast = fast.Next;
        }
        // No Node Found where things are cyclic
        return slow;
    }

    public class LRUCache
    {
        public LRUCache()
        {
            cache.Add(int.MinValue, new DoublyLinkNode<Student>(new Student() { Id = int.MinValue, Name = "Head" }));
            cache.Add(int.MaxValue, new DoublyLinkNode<Student>(new Student() { Id = int.MaxValue, Name = "Tail" }));
            cache[int.MinValue].Next = cache[int.MaxValue];
            cache[int.MaxValue].Previous = cache[int.MinValue];
        }
        public class Student
        {
            public Student()
            {

            }
            public int Id;

            public string Name;
        }
        public class DoublyLinkNode<T>
        {
            public DoublyLinkNode(T value)
            {
                Value = value;
            }

            public DoublyLinkNode(T value, DoublyLinkNode<T> prevNode, DoublyLinkNode<T> nextNode)
                : this(value)
            {
                this.Next = nextNode;
            }
            public T Value;

            public DoublyLinkNode<T> Next;

            public DoublyLinkNode<T> Previous;
        }

        Dictionary<int, DoublyLinkNode<Student>> cache = new Dictionary<int, DoublyLinkNode<Student>>();

        public void AddToTail(DoublyLinkNode<Student> doublyLinkNode)
        {
            doublyLinkNode.Next = cache[int.MaxValue];
            cache[int.MaxValue].Previous.Next = doublyLinkNode;
            doublyLinkNode.Previous = cache[int.MaxValue].Previous;
            cache[int.MaxValue].Previous = doublyLinkNode;
        }
        public void RemoveFromCacheAndChain(int identifier)
        {
            cache.Remove(identifier, out var doublyLinkNode);
            cache[int.MinValue].Next = doublyLinkNode.Next;
            doublyLinkNode.Next.Previous = doublyLinkNode.Previous;
        }

        public void UpdateLocation(int identifier)
        {
            var node = cache[identifier];
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;

            node.Next = cache[int.MaxValue];
            node.Previous = cache[int.MaxValue].Previous;
            node.Previous.Next = node;
            cache[int.MaxValue].Previous = node;
        }
        public Student GetAndUpdateCache(int identifier)
        {
            if (cache.TryGetValue(identifier, out var student))
            {
                UpdateLocation(identifier);
            }
            else
            {
                var studentFromDB = GetStudent(identifier);

                student = new DoublyLinkNode<Student>(studentFromDB);

                if (cache.Keys.Count == 10)
                {
                    RemoveFromCacheAndChain(cache[int.MinValue].Next.Value.Id);
                }
                cache[identifier] = student;
                AddToTail(student);
            }
            return student.Value;
        }
        public Student GetStudent(int identifier)
        {
            Student student = null;
            if (GetAllStudents().TryGetValue(identifier, out var name))
            {
                student = new Student() { Id = identifier, Name = name };
            }
            return student;
        }
        public Dictionary<int, string> GetAllStudents()
        {
            var students = new Dictionary<int, string>
            {
                { 1, "John" },
                { 2, "Alice" },
                { 3, "Bob" },
                { 4, "Emma" },
                { 5, "David" },
                { 6, "Sophia" },
                { 7, "Michael" },
                { 8, "Olivia" },
                { 9, "Daniel" },
                { 10, "Isabella" }
            };

            return students;
        }
    }
}

