using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    class PriorityQueue
    {
        public char Order;
        public N[] Queue;
        public int MaxElements;

        private int Rear;
        private int Front;

        public PriorityQueue(char Order)
        {
            this.Order = Order;
        }

        public PriorityQueue(int Elements)
        {
            MaxElements = Elements;
            Queue = new N[Elements];
            Rear = 0;
            Front = 0;
        }

        public int Enqueue(int a, int priority)
        {
            if (Front == MaxElements) return -1;
            var n = new N(a);
            n.Priority = priority;
            Queue[Front] = n;
            Front++;
            Prioritize();
            return 1;
        }

        public int Dequeue()
        {
            if (Front == 0 && Rear == 0) return -1;
            Front--;
            AdjustQueue();
            return 1;
        }

        private void AdjustQueue()
        {
            for (int i = 0; i < Front; i++)
                Queue[i] = Queue[i + 1];

            for (int i = Front; i < Queue.Length; i++)
                Queue[i] = null;
        }

        private void Prioritize()
        {
            var q = Queue.Where(c => c != null).OrderBy(c => c.Priority).ToArray();
            Queue = null;
            Queue = new N[5];
            for (int i = 0; i < q.Length; i++)
                Queue[i] = q[i];
        }

        public void PrintQueue()
        {
            for (int i = Rear; i < Front; i++)
                Console.Write(Queue[i].Value + " ");
        }

    }

    class N
    {
        public int Value { get; set; }
        public int Priority { get; set; }

        public N(int a)
        {
            Value = a;
        }
    }
}
