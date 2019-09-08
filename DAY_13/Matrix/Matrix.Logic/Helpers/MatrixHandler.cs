using System;

namespace Matrix
{
    /// <summary>
    /// Class contains additional information for event.
    /// </summary>
    public class ElementChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Message to show.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Message to show.</param>
        public ElementChangedEventArgs(string message)
        {
            this.Message = message;
        }
    }
}
