using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensSolver.DataStructures
{
    public class PriorityQueue<T>
    {
        private SortedDictionary<int, Queue<T>> dict = new SortedDictionary<int, Queue<T>>();

        public int Count { get; private set; } = 0;

        public void Enqueue(T item, int priority)
        {
            if (!dict.ContainsKey(priority))
            {
                dict[priority] = new Queue<T>();
            }
            dict[priority].Enqueue(item);
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            var item = dict.First();
            var queue = item.Value;

            var result = queue.Dequeue();
            if (queue.Count == 0)
                dict.Remove(item.Key);
            Count--;
            return result;
        }
    }
}
