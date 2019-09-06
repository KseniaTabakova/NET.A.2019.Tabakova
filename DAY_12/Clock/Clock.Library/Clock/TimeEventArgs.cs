using System;

namespace Clock.Library
{
    public class TimeEventArgs : EventArgs
    {

        public DateTime Initial { get; }
        public int Milliseconds { get; }
        public string Message { get; }

        public TimeEventArgs(DateTime initial, int milliseconds)
        {
            Initial = initial;
            Milliseconds = milliseconds;
        }
    }
}

