using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock.Library
{
    public abstract class ClockUser
    {
        protected abstract void Message(object sender, TimeEventArgs e);

        public void Add(ContraClock clock)
        {
            clock.ClockWorking += Message;
            Console.WriteLine($"{GetType()} registered.");
        }

        public void Remove(ContraClock clock)
        {
            clock.ClockWorking -= Message;
            Console.WriteLine($"{GetType()} unregistered.");
        }

    }
}
