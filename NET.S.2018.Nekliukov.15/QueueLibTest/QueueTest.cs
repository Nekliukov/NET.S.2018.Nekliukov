using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QueueLib;
namespace QueueLibTest
{
    [TestFixture]
    public class QueueTest
    {
        [TestCase]
        public void FirstTest()
        {
            FifoQueue<int> a = new FifoQueue<int>(new int[] { 1, 2, 3 });
            FifoQueue<int> b = new FifoQueue<int>();
            FifoQueue<int> c = new FifoQueue<int>(7);
            FifoQueue<int>[] queues = new FifoQueue<int>[3];

            queues[0] = a; queues[1] = b; queues[2] = c;
            for (int i = 0; i < queues.Length; i++) {
                Console.WriteLine("====================================");
                Console.WriteLine($"Queue size = {queues[i].Count}");
                foreach (var el in queues[i])
                    Console.Write(el + "   ");

                queues[i].Enqueue(5);
                queues[i].Enqueue(int.MinValue);
                Console.WriteLine();

                FifoQueue<int>.Enumerator iterator = queues[i].GetEnumerator();
                while (iterator.MoveNext())
                    Console.Write(iterator.Current + "   ");

                Console.WriteLine($"Queue size = {queues[i].Count}");
                Console.WriteLine("Removing: ");
                Console.WriteLine(queues[i].Dequeue() + " was removed from queue");
                Console.WriteLine(queues[i].Dequeue() + " was removed from queue");

                foreach (var el in queues[i])
                    Console.Write(el + "   ");
                Console.WriteLine($"Queue size = {queues[i].Count}");
                Console.WriteLine();
            }

        }
    }
}
