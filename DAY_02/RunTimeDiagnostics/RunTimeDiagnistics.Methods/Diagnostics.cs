using System;

namespace RunTimeDiagnistics
{
    /// <summary>
    /// Class provides evaluation of the time spent on finding the biggest nearest using the method NumberFinder.
   /// </summary>
    public class Diagnostics
    {
        #region Summary runtime calculator

        /// <summary>
        /// The summary of methods, which calculate time spent on evaluating.
        /// </summary>
        /// <param name="method">Find the largest nearest number consisting of the digits of the input number.</param>
        /// <param name="input">Incoming number.</param>
        /// <param name="totalDiagnosticsResult">Calculation of results runtime.</param>
        /// <returns>The largest nearest number.</returns>
        public static int FixTotalRunTime(Func<int, int> method, int input, out string totalDiagnosticsResult)
        {
            string resultOfRunningFirstMethod = StopwatchMethod(NumberFinder.Algorithms.Extensions.FindNextBiggerNumber, input, out int modificationResult);
            string resultOfRunningSecondMethod = TickCountMethod(NumberFinder.Algorithms.Extensions.FindNextBiggerNumber, input, out _);
            string resultOfRunningThirdMethod = UtcNowTicksMethod(NumberFinder.Algorithms.Extensions.FindNextBiggerNumber, input, out _);
            string resultOfRunningFourthMethod = QueryPerformanceCounterMethod(NumberFinder.Algorithms.Extensions.FindNextBiggerNumber, input, out _);

            totalDiagnosticsResult = string.Format("Run Time diagnostics results:\n\n" + resultOfRunningFirstMethod +
                                        "\n" + resultOfRunningSecondMethod + "\n" + resultOfRunningThirdMethod+
                                        "\n"+ resultOfRunningFourthMethod);
            return modificationResult;
        }

        #endregion

        #region Method #1 to measure execution time - StopWatch.Elapsed

        /// <summary>
        /// Methods, which calculate time spent on evaluating
        /// </summary>
        /// <param name="method">Find the largest nearest number consisting of the digits of the input number.</param>
        /// <param name="input">Incoming number.</param>
        /// <param name="result">The largest nearest number.</param>
        /// <returns>Results runtime.</returns>
        private static string StopwatchMethod(Func<int, int> method, int input, out int result)
        {
            var myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            result = method(input);
            myStopwatch.Stop();
            TimeSpan ts = myStopwatch.Elapsed;
            return $"Stopwatch: {ts.Milliseconds:00} ms.";
        }

        #endregion

        #region Method #2 to measure execution time - Environment.TickCount

        /// <summary>
        /// Methods, which calculate time spent on evaluating
        /// </summary>
        /// <param name="method">Find the largest nearest number consisting of the digits of the input number.</param>
        /// <param name="input">Incoming number.</param>
        /// <param name="result">The largest nearest number.</param>
        /// <returns>Results runtime.</returns>
        private static string TickCountMethod(Func<int, int> method, int input, out int result)
        {
            long tickStartCounter;
            long delta;
            tickStartCounter = Environment.TickCount;
            result = method(input);
            delta = Environment.TickCount - tickStartCounter;
            return $"TickCount: {delta:00} ms.";
        }

        #endregion

        #region Method #3 to measure execution time - DateTime.UtcNow.Ticks

        /// <summary>
        /// Methods, which calculate time spent on evaluating
        /// </summary>
        /// <param name="method">Find the largest nearest number consisting of the digits of the input number.</param>
        /// <param name="input">Incoming number.</param>
        /// <param name="result">The largest nearest number.</param>
        /// <returns>Results runtime.</returns>
        private static string UtcNowTicksMethod(Func<int, int> method, int input, out int result)
        {
            long DTStartCounter;
            long dtTicks;
            DTStartCounter = DateTime.UtcNow.Ticks;
            result = method(input);
            dtTicks = DateTime.UtcNow.Ticks - DTStartCounter;
            return $"UtcNow.Ticks: {dtTicks / 10000.0:00} ms.";
        }

        #endregion

        #region Method #4 to measure execution time - QueryPerformanceCounter

        /// <summary>
        /// Methods, which calculate time spent on evaluating
        /// </summary>
        /// <param name="method">Find the largest nearest number consisting of the digits of the input number.</param>
        /// <param name="input">Incoming number.</param>
        /// <param name="result">The largest nearest number.</param>
        /// <returns>Results runtime.</returns>
        private static string QueryPerformanceCounterMethod(Func<int, int> method, int input, out int result)
        {
            HiPerformTimer pt = new HiPerformTimer();
            pt.Start();
            result = method(input);
            pt.Stop();
            return $"QueryPerformanceCounter: {pt.Duration:00} ms.";
        }

        #endregion
    }
}
