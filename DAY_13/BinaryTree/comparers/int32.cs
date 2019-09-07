using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.comparers
{
    public class CustomInt32Comparer : IComparer<int>
    {
        
        public int Compare(int x, int y)
        {
            return x.ToString().Length.CompareTo(y.ToString().Length);
        }
    }
}
