using System;

namespace Clock.Library
{
    /// <summary>
    /// Class contains additional information for event.
    /// </summary>
    public class TimeEventArgs : EventArgs
    {
        /// <summary>
        /// Incapsulation of date time.
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// Incapsulation of given milliseconds.
        /// </summary>
        public int Milliseconds { get; }

        /// <summary>
        /// Message to show.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="start">Start of countdown.</param>
        /// <param name="milliseconds">The expiration of milliseconds.</param>
        public TimeEventArgs(DateTime start, int milliseconds)
        {
            Start = start;
            Milliseconds = milliseconds;
        }
    }
}

