using System;

namespace Clock.Library
{
    /// <summary>
    /// Class of event (un)registration.
    /// </summary>
    public abstract class ClockInfo
    {
        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="info">Additional information about event.</param>
        protected abstract void MessageHandler(object sender, TimeEventArgs info);

        /// <summary>
        /// Add an event handler.
        /// </summary>
        /// <param name="clock">Customer of event.</param>
        public void Add(ContraClock clock)
        {
            clock.ClockWorking += MessageHandler;

            Console.WriteLine($"{GetType()} registered.");
        }

        /// <summary>
        /// Remove an event handler.
        /// </summary>
        /// <param name="clock">Customer of event.</param>
        public void Remove(ContraClock clock)
        {
            clock.ClockWorking -= MessageHandler;

            Console.WriteLine($"{GetType()} unregistered.");
        }
    }
}
