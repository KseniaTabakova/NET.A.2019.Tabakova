using System.Text.RegularExpressions;

namespace Bank.Library.Helpers
{
    /// <summary>
    /// Class provides the correctness of input data.
    /// </summary>
    class Validator
    {
        /// <summary>
        /// Find out the correctness of sum.
        /// </summary>
        /// <param name="sum">Requied sum.</param>
        /// <returns>Operation result status.</returns>
        internal static bool SumIsValid(int sum)
        {
            return sum <= 0 ? false : true;
        }

        /// <summary>
        /// Find out the correctness of withdrawed sum.
        /// </summary>
        /// <param name="sum">Requied sum.</param>
        /// <returns>Operation result status.</returns>
        internal static bool WithdrawIsValid(int sum)
        {
            return sum <= 0 || sum>=100000 ? false : true;
        }

        /// <summary>
        /// Find out the correctness of input name.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <returns>Operation result status.</returns>
        internal static bool NameIsValid(string name)
        {
            if (name is null)
                return false;
            name = name.ToLower();
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] < 97 || name[i] > 122)
                {
                    if (name[i] != 32)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Find out the correctness of input phone number.
        /// </summary>
        /// <param name="phone">Phone number.</param>
        /// <returns>Operation result status.</returns>
        internal static bool PhoneIsValid(string phone)
        {
            if (phone is null)
                return false;
            if (!Regex.Match(phone, @"^((80|\+375)[\- ]?)?(\(?\d{2}\)?[\- ]?)?[\d\- ]{7,9}$").Success)
                return false;
            return true;
        }
    }
}