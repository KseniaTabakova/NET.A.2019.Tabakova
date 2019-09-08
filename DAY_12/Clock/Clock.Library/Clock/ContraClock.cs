using System;
using System.Threading;

namespace Clock.Library
{
    /// <summary>
    /// Countdown clock.
    /// </summary>
    public class ContraClock
    {
        /// <summary>
        /// Event of time outflow.
        /// </summary>
        public event EventHandler<TimeEventArgs> ClockWorking;

        /// <summary>
        /// Method to run an event.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="info">Additional information about event.</param>
        public void OnClockWorking(object sender, TimeEventArgs info)
        {
            ClockWorking?.Invoke(this, info);
        }

        /// <summary>
        /// Method starts an event of message passing.
        /// </summary>
        /// <param name="milliseconds">The expiration of milliseconds.</param>
        public void LetWait(int milliseconds)
        {
            var initialTime = DateTime.Now;
            Thread.Sleep(milliseconds);

            OnClockWorking(this, new TimeEventArgs(initialTime, milliseconds));
        }
    }
}
