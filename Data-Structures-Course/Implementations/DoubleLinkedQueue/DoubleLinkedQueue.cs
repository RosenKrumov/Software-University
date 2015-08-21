using System;

namespace LinkedQueue
{
    public class DoubleLinkedQueue<T>
    {
        private QueueNode<T> lastNode;
        private QueueNode<T> firstNode; 

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = new QueueNode<T>(element);
                this.lastNode = this.firstNode;
            }
            else
            {
                var node = new QueueNode<T>(element);
                node.PrevNode = this.lastNode;
                this.lastNode.NextNode = node;
                this.lastNode = node;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var result = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;

            this.Count--;
            return result;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            var index = 0;
            while (this.Count > 0)
            {
                resultArr[index] = this.firstNode.Value;
                this.Dequeue();
                index++;
            }
            return resultArr;
        }

        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> PrevNode { get; set; }
            public QueueNode<T> NextNode { get; set; }

            public QueueNode(T value)
            {
                this.Value = value;
            } 
        }
    }

    public class Test
    {
        static void Main()
        {
            
        }
    }
}
