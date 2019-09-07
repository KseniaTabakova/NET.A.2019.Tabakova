using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.another
{
   
    /// Represents node of binary search tree
 
    internal class BinarySearchTreeNode<T>
    {
        public BinarySearchTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

      
        public BinarySearchTreeNode<T> Left { get; internal set; }

   
        public BinarySearchTreeNode<T> Right { get; internal set; }

       
        public T Value { get; internal set; }
    }
}
