using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock.Library
{
    public class MinutesCounter : ClockUser
    {
        protected override void Message(object sender, TimeEventArgs e)
        {
            Console.WriteLine($"We started at {e.Initial} and spent {e.Milliseconds / (double)60000} minutes.");
        }
    }
}
