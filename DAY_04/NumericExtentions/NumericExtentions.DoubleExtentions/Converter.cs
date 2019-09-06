using System;

namespace NumericExtentions.DoubleExtentions
{
    /// <summary>
    /// Converts number from double to its binary representation.
    /// </summary>
    public static class Converter
    {
        private const int _bitsInByte = 8;

        #region GetBinaryValue method

        /// <summary>
        /// Converts double to its binary representation.
        /// </summary>
        /// <param name="number">Double number.</param>
        /// <param name="bits">Size of double number.</param>
        /// <param name="expBits">Size of bits offset.</param>
        /// <returns>String format of binary number representation.</returns>
        public static string GetBinaryValue(this double number, int bits, int expBits)
        {
            CheckRepresentationOfDoubleNumber(bits, expBits, "Number format must be 32(64) bits and 8(11) bits offset exponent respectively");
            string possibleAnswer = GetBinaryValueSpecialNumbers(number);
            if (possibleAnswer != string.Empty)
            {
                return possibleAnswer;
            }

            int bitCount = sizeof(double) * _bitsInByte;
            long hexValue = GexHexValue(number, bits, expBits);

            char[] result = new char[bitCount];
            result[0] = hexValue < 0 ? '1' : '0';
            for (int i = bitCount - 2, j = 1; i >= 0; i--, j++)
            {
                result[j] = (hexValue & (1L << i)) != 0 ? '1' : '0';
            }
            return new string(result);
        }

        /// <summary>
        /// Converts double to its hex representation.
        /// </summary>
        /// <param name="number">Double number.</param>
        /// <param name="bits">Size of double number.</param>
        /// <param name="expBits">Size of bits offset.</param>
        /// <returns>Hex number representation.</returns>
        private static long GexHexValue(double number, int bits, int expBits)
        {
            int significandBits = bits - expBits - 1;                        // -1 for sign bit
            long signBit = 0;
            double fNorm = 0.0;
            int shift = 0;
            long significant = 0;
            long exponent = 0;

            if (number < 0)                                                        // check sign and begin normalization
            {
                signBit = 1; fNorm = -number;
            }
            else
            {
                signBit = 0; fNorm = number;
            }

            while (fNorm >= 2.0)                                                   // get the normalized form of f and track the exponent
            {
                fNorm /= 2.0;
                shift++;
            }

            while (fNorm < 1.0)
            {
                fNorm *= 2.0;
                shift--;
            }
            fNorm = fNorm - 1.0;

            significant = (long)(fNorm * ((1L << significandBits) + 0.5f));         // calculate the binary form (non-float) of the significand data

            exponent = shift + ((1 << (expBits - 1)) - 1);                          // get the biased exponent, shift + bias

            long hexValue = (signBit << (bits - 1)) | (exponent << (bits - expBits - 1)) | significant;
            return hexValue;                                                        // final answer
        }

        #endregion

        /// <summary>
        /// Check the size of input number for valid values. 
        /// </summary>
        /// <param name="bits">Given size of number.</param>
        /// <param name="expBits">Given bits offset of number.</param>
        /// <param name="message">Message to be show.</param>
        private static void CheckRepresentationOfDoubleNumber(int bits, int expBits, string message)
        {
            if ((bits != 64 && expBits != 11))
            {
                if ((bits != 32 && expBits != 8))
                    throw new ArgumentOutOfRangeException(message);
            }
        }
        /// <summary>
        /// Class defines binary representation for special values. 
        /// </summary>
        /// <param name="number">Double number.</param>
        /// <returns>Binary representation.</returns>
        private static string GetBinaryValueSpecialNumbers(this double number)
        {
            string answer = string.Empty;
            if (double.IsNaN(number))
            {
                answer = "1111111111111000000000000000000000000000000000000000000000000000";
            }

            if (double.IsNegativeInfinity(number))
            {
                answer = "1111111111110000000000000000000000000000000000000000000000000000";
            }

            if (double.IsPositiveInfinity(number))
            {
                answer = "0111111111110000000000000000000000000000000000000000000000000000";
            }

            if (number == 0.0)
            {
                answer = "0000000000000000000000000000000000000000000000000000000000000000";
            }

            if (double.IsNegativeInfinity(1 / number))
            {
                answer = "1000000000000000000000000000000000000000000000000000000000000000";
            }

            if (number == double.Epsilon)
            {
                answer = "0000000000000000000000000000000000000000000000000000000000000001";
            }
            return answer;
        }

    }
}
