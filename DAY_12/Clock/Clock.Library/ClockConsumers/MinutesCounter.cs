using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock.Library
{
    /// <summary>
    /// Customer.
    /// </summary>
    public class MinutesCounter : ClockInfo
    {
        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="info">Additional information about event.</param>
        protected override void MessageHandler(object sender, TimeEventArgs info)
        {
            Console.WriteLine($"We started at {info.Start} and spent {info.Milliseconds / (double)60000} minutes.");
        }
    }
}
