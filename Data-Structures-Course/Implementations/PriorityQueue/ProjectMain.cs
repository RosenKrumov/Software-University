using System;

namespace PriorityQueue
{
    public class ProjectMain
    {
        static void Main()
        {
            var queue = new PriorityQueue<string>(); //priority is smaller-first
            queue.Enqueue("nasko");
            queue.Enqueue("ani");
            queue.Enqueue("pesho");
            queue.Enqueue("gosho");
            queue.Enqueue("misho");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
