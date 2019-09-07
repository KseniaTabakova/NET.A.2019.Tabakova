using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.comparers
{
    public class CustomPointComparer : IComparer<Point>
    {
       
        public int Compare(Point a, Point b)
        {
            return Math.Sqrt((a.X * a.X) + (a.Y * a.Y)).CompareTo(Math.Sqrt((b.X * b.X) + (b.Y * b.Y)));
        }
    }
}
