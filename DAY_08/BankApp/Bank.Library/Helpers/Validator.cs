namespace Bank.Library.Helpers
{
    public class Validator
    {
        internal static bool SumIsValid(int sum)
        {
            if (sum <= 0)
            {
                return false;
            }
            return true;
        }

        internal static bool WithdrawIsValid(decimal sum, decimal balance)
        {
            if (balance <= sum || sum <= 0)
            {
                return false;
            }
            return true;
            //"Can't  withdraw {value}, because actual balance is {balance}."
        }


        internal static bool NameIsValid(string name)
        {
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


        internal static bool PhoneIsValid(string phone)
        {
            for (int i = 0; i < phone.Length; i++)
            {
                if (phone[i] < 48 || phone[i] > 57)
                {
                    if (phone[i] != 43 && phone[i] != 40 && phone[i] != 41 && phone[i] != 45 && phone[i] != 32)
                    {
                        return false;                       
                    }
                }
            }
            return true;

        }
    }
}