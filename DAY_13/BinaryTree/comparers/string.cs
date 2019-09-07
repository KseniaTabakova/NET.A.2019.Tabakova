﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.comparers
{
    public class CustomStringComparer : IComparer<string>
    {
        
        public int Compare(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }
    }
}
