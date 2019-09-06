using System;

namespace NumberFinder.Algorithms
{
    /// <summary>
    /// Class provides a finder of the largest nearest number.
    /// </summary>
    public class Extensions
    {
        
        #region Finder of the largest nearest number  

        /// <summary>
        /// Find the largest nearest number consisting of the digits of the input number.
        /// </summary>
        /// <param name="number">Incoming number.</param>
        /// <returns>The largest nearest number.</returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 10 )
            {
                SendAdditionalMessage("The argument must be more than ten.");
                return number;
            }
           
            int count = 0;
            string numberCouldBeCompared = number.ToString();
            
            for (int i = 0; i < numberCouldBeCompared.Length - 1; i++)
            {
                if (numberCouldBeCompared[i] > numberCouldBeCompared[i + 1])
                    count++;
            }

            if (count == numberCouldBeCompared.Length - 1)
            {
                SendAdditionalMessage("There is no such number.");
                return number;
            }

            int increasedNumber = number + 1;

            while (!CheckIsItEqualToDigits(increasedNumber.ToString(), numberCouldBeCompared))
            {
                increasedNumber++;
            }
            return increasedNumber;
        }

        /// <summary>
        /// Method checks the presence of all digits of the input number in the supposedly found one.
        /// </summary>
        /// <param name="possibleNumber">Supposedly the largest nearest number.</param>
        /// <param name="incomingNumber">Incoming number.</param>
        /// <returns>Loyalty to finding.</returns>
        private static bool CheckIsItEqualToDigits(string possibleNumber, string incomingNumber)
        {
            int count = 0;
            char[] digitsOfPossibleNumber = possibleNumber.ToCharArray();
            char[] digitsOfIncomingNumber = incomingNumber.ToCharArray();
            
            for (int i = digitsOfPossibleNumber.Length - 1; i >= 0; i--)
            {
                for (int j = digitsOfIncomingNumber.Length - 1; j >= 0; j--)
                {
                    if (digitsOfIncomingNumber[j] == digitsOfPossibleNumber[i])
                    {
                        digitsOfIncomingNumber[j] = '?';
                        digitsOfPossibleNumber[i] = '!';
                        count++;
                    }
                }
            }

            bool nearestLargestNumber;
            return nearestLargestNumber = digitsOfIncomingNumber.Length == count ? true : false;        
        }

        #endregion
        
        /// <summary>
        /// Additional information for any event.
        /// </summary>
        /// <param name="message">Message to be show.</param>
        private static void SendAdditionalMessage(string message) => Console.WriteLine(message);
    }
}

