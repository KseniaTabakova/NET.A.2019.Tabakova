using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clock.Library;
using System.Threading.Tasks;

namespace Clock.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ContraClock funClock = new ContraClock();
            ClockUser userOne = new SecondsCounter();
            ClockUser userTwo = new MinutesCounter();

            userOne.Add(funClock);
            funClock.WhatTimeIs(4000);
            userTwo.Add(funClock);
            funClock.WhatTimeIs(10000);

            userOne.Remove(funClock);
            funClock.WhatTimeIs(2000);
        }
    }
}
