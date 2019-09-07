﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node<T> head;

        public int Count
        {
            get { return counter; }
        }

        private int counter;

        private Comparison<T> comparer;

    
        public BinarySearchTree(IEnumerable<T> elements, Comparison<T> comparer = null)
        {
            if (ReferenceEquals(elements, null))
                throw new ArgumentNullException($"{nameof(elements)} must not be null");

            if (typeof(T).GetInterfaces().Contains(typeof(IComparable)) ||
                typeof(T).GetInterfaces().Contains(typeof(IComparable<T>)) ||
                typeof(T).GetInterfaces().Contains(typeof(IComparer)) ||
                typeof(T).GetInterfaces().Contains(typeof(IComparer<T>)))
            {
                if (ReferenceEquals(comparer, null)) this.comparer = Comparer<T>.Default.Compare;
                else this.comparer = comparer;
            }
            else throw new ArgumentException($"Type {nameof(T)} doesn't have default method Comparer. Grant your own comparer or implement " +
                                             $"IComparer or IComparable interfaces for your type");

            foreach (T value in elements)
            {
                Add(value);
            }
        }

        public BinarySearchTree(IEnumerable<T> elements, IComparer<T> comparer) : this(elements, comparer.Compare)
        {
        }

      
        public void Add(T item)
        {
            if (ReferenceEquals(item, null)) throw new ArgumentNullException($"{nameof(item)} must not be null");

            Node<T> node = new Node<T>(item);

            if (head == null)
                head = node;
            else
            {
                Node<T> current = head, parent = null;

                while (current != null)
                {
                    parent = current;
                    if (comparer(item, current.Value) < 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }

                if (comparer(item, parent.Value) < 0)
                    parent.Left = node;
                else
                    parent.Right = node;
            }
            ++counter;
        }

       
        public void AddElements(IEnumerable<T> elems)
        {
            if (ReferenceEquals(elems, null)) throw new ArgumentNullException($"{nameof(elems)} must not be null");

            foreach (T element in elems)
            {
                Add(element);
            }
        }

       
        public bool Contains(T value)
        {
            if (ReferenceEquals(value, null)) return false;

            Node<T> curent = head;

            while (curent != null)
            {
                if (comparer(curent.Value, value) == 0) return true;

                if (comparer(value, curent.Value) > 0) curent = curent.Right;
                else curent = curent.Left;
            }
            return false;
        }

     
        public void Clear()
        {
            head = null;
            counter = 0;
        }

       
        public void Remove(T value)
        {
            if (ReferenceEquals(value, null)) throw new ArgumentNullException($"{nameof(value)} must not be null");
            if (!Contains(value)) return;

            Node<T> curent = head;
            Node<T> parentCurent = null;

            while (comparer(curent.Value, value) != 0)
            {
                parentCurent = curent;
                if (comparer(value, curent.Value) > 0)
                {
                    curent = curent.Right;
                }
                else curent = curent.Left;
            }

            if (curent.Right == null)
            {
                if (parentCurent == null)
                {
                    head = curent.Left;
                }
                else
                {
                    if (comparer(curent.Value, parentCurent.Left.Value) == 0)
                    {
                        parentCurent.Left = curent.Left;
                    }
                    else
                    {
                        parentCurent.Right = curent.Right;
                    }
                }
            }
            else
            {
                Node<T> temp = curent.Right;
                Node<T> parentTemp = null;

                while (temp.Left != null)
                {
                    parentTemp = temp;
                    temp = temp.Left;
                }
                if (parentTemp != null)
                {
                    parentTemp.Left = temp.Right;
                }
                else
                {
                    curent.Right = temp.Right;
                }
                curent.Value = temp.Value;
            }

            counter--;
        }

        
        public IEnumerable<T> Inorder()
        {
            if (head == null)
                yield break;

            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> node = head;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }

      
        public IEnumerable<T> Preorder()
        {
            if (head == null)
                yield break;

            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(head);

            while (stack.Count > 0)
            {
                Node<T> node = stack.Pop();
                yield return node.Value;
                if (node.Right != null)
                    stack.Push(node.Right);
                if (node.Left != null)
                    stack.Push(node.Left);
            }
        }

       
        public IEnumerable<T> Postorder()
        {
            if (head == null)
                yield break;

            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> node = head;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    if (stack.Count > 0 && node.Right == stack.Peek())
                    {
                        stack.Pop();
                        stack.Push(node);
                        node = node.Right;
                    }
                    else
                    {
                        yield return node.Value;
                        node = null;
                    }
                }
                else
                {
                    if (node.Right != null)
                        stack.Push(node.Right);
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }

        public IEnumerator<T> GetEnumerator() => Inorder().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }


    internal sealed class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

       
        public Node(T obj)
        {
            if (ReferenceEquals(obj, null)) throw new ArgumentNullException($"{nameof(obj)} must not be null");

            Value = obj;
        }

    }
}
