using System;

namespace MathOfIsaacNewton.Algorithms
{
    /// <summary>
    /// Class provides root finder of the number.
    /// </summary>
    public class Extensions
    {
        #region Root finder of the number

        /// <summary>
        /// Finds root of specified degree of the number.
        /// </summary>
        /// <param name="input">Input number.</param>
        /// <param name="degree">Degree.</param>
        /// <param name="accuracy">Precision.</param>
        /// <returns>Root of degree.</returns>
        public static double FindNthRoot(double input, int degree, double accuracy = 0.000001)
        {
           ThrowingArgumentException(input, degree, accuracy, "Invalid arguments.");

            double firstNumberApproximation = input / 2;
            double resultNumber = input;

            do
            {
                firstNumberApproximation = resultNumber;
                resultNumber = 1.0 / degree * ((degree - 1) * firstNumberApproximation +
                                               input / Math.Pow(firstNumberApproximation, degree - 1));
            } while (Math.Abs(resultNumber - firstNumberApproximation) > accuracy);

            return Math.Round(resultNumber, 3);
        }
        #endregion

        /// <summary>
        /// Throwing argument exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="input">Input witch can cause an exception.</param>
        /// <param name="degree">Digit witch can cause an exception.</param>
        /// <param name="accuracy">Accuracy witch can cause an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowingArgumentException(double input, int degree, double accuracy, string message)
        {
            if ( degree<=1 || (accuracy >= 1 || accuracy <= 0)|| input < 0 && degree % 2 == 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
