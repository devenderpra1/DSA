using System;

namespace QueueStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            queue.Enqueue(6);
            queue.Enqueue(5);
            queue.Enqueue(11);
            queue.Enqueue(34);
            queue.PrintQueue();
            queue.Dequeue();
            queue.PrintQueue();
        }
    }

    public class Queue
    {
        public Queue()
        {
            _queue = new int[10];
            Front = Rear = -1;

        }
        private int[] _queue;
        public int[] queue
        {
            get
            {
                if (_queue == null)
                    return _queue = new int[10];
                else
                    return _queue;
            }
        }

        public int Front;

        public int Rear;

        private bool IsFull()
        {
            if (((Rear + 1) % queue.Length) == Front)
                return true;
            return false;
        }

        private bool IsEmpty()
        {
            if (Front == -1 && Rear == -1)
                return true;
            return false;
        }

        public void Enqueue(int val)
        {
            if (IsFull())
                return;
            else if (IsEmpty())
            {
                Front = Rear = 0;
                queue[Rear] = val;
            }
            else
            {
                Rear = (Rear + 1) % _queue.Length;
                queue[Rear] = val;
            }
        }

        public void Dequeue()
        {
            if (IsEmpty())
                return;
            else if (Rear == Front)
                Rear = Front = -1;
            else
                Front = (Front + 1 + queue.Length) % queue.Length;
        }


        public void PrintQueue()
        {
            if (Front != -1)
            {
                Console.WriteLine("The Current Queue is as follows \n");
                for (var i = Front; i <= queue.Length - 1; i = (i + 1) % queue.Length)
                {
                    if (queue[i] != 0)
                    {
                        if (IsFull() i == Rear)
                            break;
                        Console.WriteLine("The queue position " + (i - Front + 1) + " and Actual Position is " + i + " " + queue[i] + "\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Queue is Empty");
            }
        }
    }
}
