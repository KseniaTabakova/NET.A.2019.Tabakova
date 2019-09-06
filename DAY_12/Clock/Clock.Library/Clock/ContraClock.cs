using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clock.Library
{
    public class ContraClock
    {     
        public event EventHandler<TimeEventArgs> ClockWorking;

        private void OnClockWorking(object sender, TimeEventArgs e)
        {
            ClockWorking?.Invoke(this, e);
        }

        public void WhatTimeIs(int milliseconds)
        {
            var initialTime = DateTime.Now;
            Thread.Sleep(milliseconds);

            OnClockWorking(this, new TimeEventArgs(initialTime, milliseconds));
        }
    }
}
