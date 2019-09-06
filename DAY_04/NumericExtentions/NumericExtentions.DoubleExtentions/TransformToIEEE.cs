using System;

namespace NumericExtentions.DoubleExtentions
{
    public class Converter : ITransform
    {
        public string GetBinaryValue(double number)
        {
            return number.GetBinaryValue(64, 11);
        }
    }
}
