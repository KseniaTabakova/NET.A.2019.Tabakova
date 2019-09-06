using System.Runtime.InteropServices;
using System.Threading;

namespace MathTasks.Diagnostics
{
    /// <summary>
    /// Class provides performance counter.
    /// </summary>
    public class HiPerformTimer
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        private long _startTime, _stopTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="HiPerformTimer"/> class.
        /// </summary>
        public HiPerformTimer()
        {
            _startTime = 0;
            _stopTime = 0;
        }

        /// <summary>
        /// The begging of evaluation.
        /// </summary>
        public void Start()
        {
            Thread.Sleep(0);
            QueryPerformanceCounter(out _startTime);
        }

        /// <summary>
        /// The end of evaluation.
        /// </summary>
        public void Stop()
        {
            QueryPerformanceCounter(out _stopTime);
        }

        /// <summary>
        /// Lead time.
        /// </summary>
        public double Duration
        {
            get
            {
                return (_stopTime - _startTime) / 1000;
            }
        }
    }
}
