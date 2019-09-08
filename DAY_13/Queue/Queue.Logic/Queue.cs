using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    /// <summary>
    /// Class represents generalized collection queue.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public sealed class Queue<T> : IEnumerable<T>, IEnumerable
    {
        private T[] array;
        private int head;
        private int tail;
        private int counter;
        private int capacity = 8;

        /// <summary>
        /// Encapsulated field of queue length. 
        /// </summary>
        public int Count { get { return counter; } }

        /// <summary>
        /// Constructor initialize new queue.
        /// </summary>
        public Queue()
        {
            array = new T[capacity];
        }

        /// <summary>
        /// Constructor initialize new queue from IEnumerable collection in input.
        /// </summary>
        /// <param name="obj">IEnumerable collection.</param>
        public Queue(IEnumerable<T> obj) : this()
        {
            if (obj == null)
                throw new ArgumentNullException($"{obj} can not be null");
            foreach (var i in obj)
            {
                Enqueue(i);
            }
        }

        /// <summary>
        /// Add element to the end of queue.
        /// </summary>
        /// <param name="obj">Element to be added.</param>
        public void Enqueue(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException($"{obj} can not be null");
            if (counter == array.Length)
            {
                Resize(counter * 2);
            }
            array[tail] = obj;
            tail = (tail + 1) % array.Length;
            counter++;
        }

        /// <summary>
        /// Remove element from the beginning of queue.
        /// </summary>
        /// <returns>Removed element.</returns>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("No elements in the queue");
            T removedObj = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            counter--;
            return removedObj;
        }

        /// <summary>
        /// Clear queue without changing the previous capacity.
        /// </summary>
        public void Clear()
        {
            array = new T[capacity];
            head = 0;
            tail = 0;
            counter = 0;
        }

        /// <summary>
        /// Check the availability of appropriate element in the queue.
        /// </summary>
        /// <param name="obj">Appropriate element.</param>
        /// <param name="comparer">Criteria for equal check.</param>
        /// <returns></returns>
        public bool Contains(T obj, EqualityComparer<T> comparer = null)
        {
            if (obj == null)
                return false;
            if (comparer == null)
                comparer = EqualityComparer<T>.Default;

            int size = Count;
            int index = head;
            while (size-- > 0)
            {
                if (index == array.Length) index = 0;
                if (comparer.Equals(array[index], obj))
                    return true;
                index++;
            }
            return false;
        }

        /// <summary>
        /// Show the first element in the queue.
        /// </summary>
        /// <returns>First element.</returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("No elements in the queue.");
            return array[head];
        }

        /// <summary>
        /// Change the queue previous capacity by coping to the new array.
        /// </summary>
        /// <param name="newSize">New capacity.</param>
        private void Resize(int newSize)
        {
            T[] newArray = new T[newSize];
            if (head < tail)
            {
                Array.Copy(array, head, newArray, 0, counter);
            }
            else
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
            }
            array = newArray;
            head = 0;
            tail = counter;
        }

        /// <summary>
        /// Remove excess capacity.
        /// </summary>
        public void Trim()
        {
            if (Count != 0)
                Resize(counter);
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.Trim();
            return new QueueIterator(this);

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Struct represents iterator for queue.
        /// </summary>
        private struct QueueIterator : IEnumerator<T>
        {
            private readonly Queue<T> queue;
            private int currentIndex;

            /// <summary>
            /// Property return current element. 
            /// </summary>
            object IEnumerator.Current { get { return Current; } }

            /// <summary>
            /// Constructor with required queue in input.
            /// </summary>
            /// <param name="queue">Required queue.</param>
            public QueueIterator(Queue<T> queue)
            {
                this.queue = queue;
                currentIndex = -1;
            }

            /// <summary>
            /// Logic to find current element.
            /// </summary>
            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == queue.Count)
                        throw new InvalidOperationException();

                    return queue.array[currentIndex];
                }
            }

            /// <summary>
            /// Logic to move to the next element in the queue.
            /// </summary>
            /// <returns>True if not the end of queue.</returns>
            public bool MoveNext()
            {
                return ++currentIndex < queue.Count;
            }
            /// <summary>
            /// Reset to the begin.
            /// </summary>
            public void Reset()
            {
                currentIndex = -1;
            }
}
        }
        //public IEnumerator<T> GetEnumerator()
        //{
        //    int index = head;
        //    int size = Count;
        //    while (size-- > 0)
        //    {
        //        if (index == array.Length) index = 0;
        //        yield return array[index];
        //        index++;
        //    }
        //}
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return array.GetEnumerator();
        //}
    }
}