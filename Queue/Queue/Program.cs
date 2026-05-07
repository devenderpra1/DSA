
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class QueueUsage
{
    public class MaxInfo
    {
        public int Value;

        public int start;

        public int end;
    }

    public List<MaxInfo> GetMaximumInEachWindow(List<int> inputs, int windowSize)
    {
        var infos = new List<MaxInfo>();
        //First Window

        var queueForProbableMax = new Queue<int>();
        for (int i = 0; i < windowSize; i++)
        {
            while (queueForProbableMax.Count > 1 && queueForProbableMax.Peek() < inputs[i])
            {
                queueForProbableMax.Dequeue();
            }
            queueForProbableMax.Enqueue(inputs[i]);
        }

        infos.Add(new MaxInfo() { start = 0, end = windowSize - 1, Value = queueForProbableMax.Peek() });

        for (int i = windowSize; i < inputs.Count; i++)
        {
            if (queueForProbableMax.Peek() == inputs[i - windowSize])
            {
                queueForProbableMax.Dequeue();
            }
            while (queueForProbableMax.Count > 1 && queueForProbableMax.Peek() < inputs[i])
            {
                queueForProbableMax.Dequeue();
            }
            queueForProbableMax.Enqueue(inputs[i]);
            infos.Add(new MaxInfo() { start = i - windowSize + 1, end = windowSize, Value = queueForProbableMax.Peek() });
        }
        return infos;
    }


    public class DoubleEndedQueue<T>
    {
        public DoubleLinkedNode<T> front;

        public DoubleLinkedNode<T> rear;

        public T PeekFront()
        {
            if (front == null)
                return default;
            return front.Value;
        }
        public T PeekRear()
        {
            if (rear == null)
                return default;
            return rear.Value;
        }
        public void Enque(T value)
        {
            var node = new DoubleLinkedNode<T>(value);
            node.NextBackward = rear;
            if (rear != null)
            {
                rear.NextForward = node;
            }
            else//Single Node Condition
            {
                front = node;
            }
            rear = node;
        }
        public void EnqueFront(T value)
        {
            var node = new DoubleLinkedNode<T>(value);
            node.NextForward = front;
            if (front != null)
            {
                front.NextBackward = node;
            }
            else
            {
                rear = node;
            }
            front = node;
        }

        public T Deque()
        {
            if (front == null)
                return default;
            var removedNode = front;
            front = front.NextForward;
            if (front == null)
            {
                rear = null;
            }
            else
                front.NextBackward = null;
            return removedNode.Value;
        }
        public T DequeRear()
        {
            if (rear == null)
                return default;
            var removedNode = rear;
            rear = rear.NextBackward;
            if (rear == null)
            {
                front = null;
            }
            else
            {
                rear.NextForward = null;
            }
            return removedNode.Value;
        }

        public class DoubleLinkedNode<T>
        {
            public DoubleLinkedNode(T value)
            {
                this.Value = value;
            }
            public T Value;

            public DoubleLinkedNode<T> NextBackward;

            public DoubleLinkedNode<T> NextForward;
        }
    }
}