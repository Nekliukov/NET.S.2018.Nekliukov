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
            FifoQueue<int> intQueue = new FifoQueue<int>(new int[] { 1, 2, 3, 4 });

            FifoQueue<int>.QueueIterator iterator = intQueue.Iterator();

            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
            Console.WriteLine("======================");
            intQueue.Enqueue(5);
            intQueue.Enqueue(6,7);
            intQueue.Enqueue(8,9,200,1000);

            iterator.Reset();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }
    }
}
