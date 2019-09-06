using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgebraicalPolynomials.Algorithms
{
    /// <summary>
    /// Polynomial immutable class for working with degree polynomials.
    /// </summary>
    public class Polynomial : ICloneable
    {
        /// <summary>
        /// Array of coefficients.
        /// </summary>
        private readonly SortedList<int, double> _coefficients = new SortedList<int, double>();

        #region Polynomial base members

        public int Length => _coefficients.Count;

        /// <summary>
        /// Polynomial degree.
        /// </summary>
        public int Degree { get; private set; }

        /// <summary>
        /// Polynomial coefficients.
        /// </summary>
        /// <param name="Power">The degree of the variable at which we take the coefficient.</param>
        /// <returns>Coefficient.</returns>
        public double this[int Power]
        {
            get => _coefficients.ContainsKey(Power) ? _coefficients[Power] : 0;
            set
            {
                // Assign a coefficient value and calculate the degree             
                _coefficients[Power] = value;
                if (value == 0)
                    _coefficients.Remove(Power);
                Degree = _coefficients.Count == 0 ? 0 : _coefficients.Keys[_coefficients.Count - 1];
            }
        }

        /// <summary>
        /// Setting coefficients from double array.
        /// </summary>
        /// <param name="coeff">Array of coefficients of a polynomials.</param>
        public Polynomial(params double[] coeff)
        {
            ThrowArgumentNullException(coeff, "No array has been given.");
            for (int i = 0; i < coeff.Length; i++)
                this[i] = coeff[i];
        }

        /// <summary>
        /// Get polynomial instance with coefficients.
        /// </summary>
        /// <returns>Polynomial instance.</returns>
        public Polynomial GetCoefficients()
        {
            Polynomial newPolynomial = new Polynomial();
            foreach (var kvp in _coefficients)
                newPolynomial[kvp.Key] = kvp.Value;
            return newPolynomial;
        }

        /// <summary>
        /// Deep polynomial equals.
        /// </summary>
        /// <param name="other">Another polynom.</param>
        /// <returns>The result of equals.</returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (_coefficients.Count != other._coefficients.Count)
                return false;
            return this == other;
        }
        #endregion

        #region Overloading object methods 

        /// <summary>
        /// Overrided representation of instance in String format.
        /// </summary>
        /// <returns>Representation of instance.</returns>
        public override string ToString()
        {
            if (_coefficients.Count == 0)
                return "0";

            var sb = new StringBuilder();
            foreach (var kvp in _coefficients)
            {
                string format = kvp.Value < 0 ? "-{0}" : "+{0}";
                if (kvp.Key > 0 && kvp.Value == -1)
                    format = "-";
                if (kvp.Key > 0 && kvp.Value == 1)
                    format = "+";
                sb.AppendFormat(format, System.Math.Abs(kvp.Value));

                format = "x^{0}";
                if (kvp.Key == 0)
                    format = "";
                if (kvp.Key == 1)
                    format = "x";
                sb.AppendFormat(format, kvp.Key);
            }

            if (sb[0] == '+') sb.Remove(0, 1);
            return sb.ToString();
        }

        /// <summary>
        /// Overrided deep polynomial equals.
        /// </summary>
        /// <param name="obj">Object instance.</param>
        /// <returns>The result of equals.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Polynomial)obj);
        }

        /// <summary>
        /// Returns a hash code for the instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i <= Degree; i++)
            {
                hashCode += this[i].GetHashCode() + i * 32;
            }
            return hashCode;
        }

        #endregion

        #region Operators overloading

        /// <summary>
        /// Operator overload for adding two polynomials.
        /// </summary>
        /// <param name="pol1">The first polynomial.</param>
        /// <param name="pol2">The second polynomial.</param>
        /// <returns>The result of addition.</returns>
        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            Polynomial newPolynomial = new Polynomial(pol1);
            foreach (var kvp in pol2._coefficients)
                newPolynomial[kvp.Key] += kvp.Value;
            return newPolynomial;
        }

        /// <summary>
        /// Operator overload for addition of number and polynomial.
        /// </summary>
        /// <param name="pol1">The first polynomial.</param>
        /// <param name="number">Given number.</param>
        /// <returns>The result of addition.</returns>
        public static Polynomial operator +(Polynomial pol1, int number)
        {
            Polynomial newPolynomial = new Polynomial(pol1);
            newPolynomial[0] += number;
            return newPolynomial;
        }

        /// <summary>
        /// Operator overload for addition of polynomial and number.
        /// </summary>
        /// <param name="number">Given number.</param>
        /// <param name="pol2">The second polynomial.</param>
        /// <returns>The result of addition.</returns>
        public static Polynomial operator +(int number, Polynomial pol2)
        {
            return pol2 + number;
        }

        /// <summary>
        /// Operator overload for multiplication of two polynomials.
        /// </summary>
        /// <param name="pol1">The first polynomial.</param>
        /// <param name="pol2">The second polynomial.</param>
        /// <returns>Multiplication result.</returns>
        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            Polynomial newPolynomial = new Polynomial();
            foreach (var kvc1 in pol1._coefficients)
            {
                foreach (var kvc2 in pol2._coefficients)
                    newPolynomial[kvc1.Key + kvc2.Key] += kvc1.Value * kvc2.Value;
            }
            return newPolynomial;
        }

        /// <summary>
        /// Operator overload for multiplication of polynomial and number.
        /// </summary>
        /// <param name="pol1">The first polynomial.</param>
        /// <param name="number">Given number.</param>
        /// <returns>Multiplication result.</returns>
        public static Polynomial operator *(Polynomial pol1, int number)
        {
            Polynomial newPolynomial = new Polynomial();
            foreach (var kvp in pol1._coefficients)
                newPolynomial[kvp.Key] = kvp.Value * number;
            return newPolynomial;
        }

        /// <summary>
        /// Operator overload for multiplication of number and polynomial.
        /// </summary>
        /// <param name="number">Given number.</param>
        /// <param name="pol2">The second polynomial.</param>
        /// <returns>Multiplication result.</returns>
        public static Polynomial operator *(int number, Polynomial pol2)
        {
            return pol2 * number;
        }

        /// <summary>
        /// The unary minus operation.
        /// </summary>
        /// <param name="pol1">The first polynomial.</param>
        /// <returns>Subtraction result.</returns>
        public static Polynomial operator -(Polynomial pol1)
        {
            return pol1 * -1;
        }

        /// <summary>
        /// Operator overload for subtaction of two polynomial.
        /// </summary>
        /// <param name="pol1">The first polynomial.</param>
        /// <param name="pol2">The second polynomial.</param>
        /// <returns>Subtraction result.</returns>
        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
        {
            return pol1 + (-1) * pol2;
        }

        /// <summary>
        /// Operator overload for subtraction a number from a polynomial.
        /// </summary>
        /// <param name="pol1">The first polynomial.</param>
        /// <param name="number">Given number.</param>
        /// <returns>Subtraction result.</returns>
        public static Polynomial operator -(Polynomial pol1, int number)
        {
            return pol1 + (-1) * number;
        }

        /// <summary>
        /// Operator overload for subtraction a polynomial from a number.
        /// </summary>
        /// <param name="number">Given number.</param>
        /// <param name="pol2">The second polynomial.</param>
        /// <returns>Subtraction result.</returns>
        public static Polynomial operator -(int number, Polynomial pol2)
        {
            return number + (-1) * pol2;
        }
        #endregion

        #region Static methods

        /// <summary>
        /// Overloaded addition methods.
        /// </summary>
        public static Polynomial Add(Polynomial pol1, Polynomial pol2) => (pol1 + pol2);
        public static Polynomial Add(int number, Polynomial pol2) => (number + pol2);
        public static Polynomial Add(Polynomial pol1, int number) => (pol1 + number);

        /// <summary>
        /// Overloaded subtraction methods.
        /// </summary>
        public static Polynomial Subtract(Polynomial pol1, Polynomial pol2) => pol1 - pol2;
        public static Polynomial Subtract(int number, Polynomial pol2) => number - pol2;
        public static Polynomial Subtract(Polynomial pol1, int number) => pol1 - number;
        public static Polynomial Subtract(Polynomial pol1) => pol1;

        /// <summary>
        /// Overloaded multiplication methods.
        /// </summary>
        public static Polynomial Multiply(Polynomial pol1, Polynomial pol2) => pol1 * pol2;
        public static Polynomial Multiply(int number, Polynomial pol2) => number * pol2;
        public static Polynomial Multiply(Polynomial pol1, int number) => pol1 * number;

        #endregion

        #region Operators == and != overloading
        /// <summary>
        /// Implementation of == operator.
        /// </summary>
        /// <param name="pol1">The first polynomial.</param>
        /// <param name="pol2">The second polynomial.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (object.ReferenceEquals(pol1, null) || object.ReferenceEquals(pol2, null))
                return false;
            bool b1 = pol1._coefficients.OrderBy(k => k.Key).SequenceEqual(pol2._coefficients.OrderBy(v => v.Key));
            bool b2 = pol1._coefficients.OrderBy(k => k.Value).SequenceEqual(pol2._coefficients.OrderBy(v => v.Value));
            if (b1 && b2)
                return true;
            return false;
        }

        /// <summary>
        /// Implementation of != operator.
        /// </summary>
        /// <param name="pol1">The first polynomial.</param>
        /// <param name="pol2">The second polynomial.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !(pol1 == pol2);
        }
        #endregion

        #region Clone implementation

        /// <summary>
        /// Implementation of ICloneable method Clone, witch transfers responsibility to the Polynomial method Clone.
        /// </summary>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Instance (coefficients) cloning method.
        /// </summary>
        /// <returns>New polynomial instance.</returns>
        public Polynomial Clone()
        {
            Polynomial p = GetCoefficients();
            return p;
        }

        #endregion

        /// <summary>
        /// Throwing argument null exception in case of unforeseen consequence.
        /// </summary>
        /// <param name="array">Array witch can cause an exception.</param>
        /// <param name="message">Message to be show.</param>
        private static void ThrowArgumentNullException(double[] array, string message)
        {
            if (array == null)
                throw new ArgumentNullException(message);
        }
    }
}
