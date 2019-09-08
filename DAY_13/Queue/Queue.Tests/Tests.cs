using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace QueueTests
{
    [TestClass]
    public class CustomQueueTests
    {
        [TestMethod]
        [DataRow(new double[] { 1, 2, 3, 3, 5 }, 5)]
        [DataRow(new double[] { }, 0)]
        public void ConstructorWithParameter(IEnumerable<double> collection, int expected)
        {
            Queue.Queue<double> queue = new Queue.Queue<double>(collection);
            var result = queue.Count;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new int[] { 1 }, 2, new int[] { 1, 2 })]
        [DataRow(new int[] { }, 22, new int[] { 22 })]
        public void Enqueue(IEnumerable<char> collection, char value, IEnumerable<char> expected)
        {
            Queue.Queue<char> queue = new Queue.Queue<char>(collection);
            queue.Enqueue(value);
            CollectionAssert.AreEqual(expected.ToArray(), queue.ToArray());
        }

        [TestMethod]
        [DataRow(new string[] { "aaa", "bbbb", "cccc" }, "aaa")]
        [DataRow(new string[] { null, "zzzz", "aaa", "bbbb", "cccc" }, null)]
        public void Peek(IEnumerable<string> collection, string expected)
        {
            Queue.Queue<string> queue = new Queue.Queue<string>(collection);
            var result = queue.Dequeue();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetEnumerator()
        {
            int[] sourceArray = { 1, 2, 3, 4, 5 };
            Queue.Queue<int> queue = new Queue.Queue<int>(sourceArray);
            List<int> result = new List<int>();
            foreach (var item in queue)
            {
                result.Add(item);
            }
            CollectionAssert.AreEqual(sourceArray, result);
        }
    }
}