﻿using AlgebraicalPolynomials.Algorithms;
using NUnit.Framework;

namespace AlgebraicalPolynomials.Tests
{
    public class PolynomialTests
    {
        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2, 3, 4 }, new double[] { 2, 4, 6, 8 })]
        [TestCase(new double[] { 1, 2, -1.5, -8.5, 3, 4 }, new double[] { 1, 2, 3, 4 }, new double[] { 2, 4, 1.5, -4.5, 3, 4 })]
        public static void Polynomial_Add(double[] array1, double[] array2, double[] expected)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial p3 = new Polynomial(expected);
            Assert.AreEqual(p1 + p2, p3);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5, 9 }, new double[] { 1, 2, 3, 4 }, new double[] { 0, 0, 0, 0, 5, 9 })]
        [TestCase(new double[] { 1.204, -2.569, 3.987, 4.879, -0.896, 9 }, new double[] { 1, -2, -3, 4 }, new double[] { 0.204, -0.569, 6.987, 0.879, -0.896, 9 })]
        public static void Polynomial_Substract(double[] array1, double[] array2, double[] expected)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial p3 = new Polynomial(expected);
            Assert.AreEqual(p1 - p2, p3);
        }

        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2, 3, 4 }, new double[] { 1, 4, 10, 20, 25, 24, 16 })]
        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2 }, new double[] { 1, 4, 7, 10, 8 })]
        public static void Polynomial_Multiply(double[] array1, double[] array2, double[] expected)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial p3 = new Polynomial(expected);
            Assert.AreEqual(p1 * p2, p3);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00001 }, ExpectedResult = "1+2x+3x^2+4x^3-x^5+11,2564x^6-1E-05x^7")]
        public static string Polynomial_ToString(double[] array)
        {
            Polynomial p1 = new Polynomial(array);
            return p1.ToString();
        }

        [TestCase(new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00001 }, new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00001 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00020 }, new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00019 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.20 }, new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.19 }, ExpectedResult = false)]
        public static bool Polynomial_Equals(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            return p1.Equals(p2);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00001 }, new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00001 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00001 }, null, ExpectedResult = false)]
        public static bool Polynomial_NotEquals(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            object p2 = array2;
            return p1.Equals(p2);
        }

        [TestCase(new double[] { 0, 1, 2 }, new double[] { 2, 1, 0 })]
        public static void Polynomial_GetHashCode_NotEqual(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Assert.AreNotEqual(p1.GetHashCode(), p2.GetHashCode());
        }

    }
}