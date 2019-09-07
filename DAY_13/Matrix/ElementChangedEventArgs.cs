using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
   
    public class ElementChangedEventArgs : EventArgs
    {
       
        public ElementChangedEventArgs(string message) : base()
        {
            this.Message = message;
        }

        
        public string Message { get; }
    }
}
