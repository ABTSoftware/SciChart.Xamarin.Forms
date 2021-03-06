﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SciChart.Xamarin.Views.Utility
{
    /// <summary>
    /// Allows assertions to be built with the following syntax: 
    /// <code>
    /// Guard.Assert(123).IsLessThan(456);
    /// </code>
    /// </summary>
    internal static class Guard
    {
        public static void IsTrue(bool value, string message)
        {
            if (value == false)
            {
                throw new ArgumentException(message);
            }
        }

        public static void NotNull(object arg, string name)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(name, string.Format("The Argument {0} cannot be null", name));
            }
        }

        public static void NotEmpty(int count, string collectionName)
        {
            if (count == 0)
            {
                throw new IndexOutOfRangeException(string.Format("The {0} collection cannot be empty", collectionName));
            }
        }

        public static void ArrayLengthsSame(int count1, string array1Name, int count2, string array2Name)
        {
            if (count1 != count2)
            {
                throw new InvalidOperationException(string.Format("Arrays {0} and {1} must have the same length", array1Name, array2Name));
            }
        }

        /// <summary>
        /// Asserts that the argument is a real number
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <param name="doubleValue">The double value.</param>
        /// <remarks></remarks>
        public static void ArgumentIsRealNumber(double doubleValue)
        {
            if (!doubleValue.IsRealNumber())
            {
                throw new InvalidOperationException(string.Format("Value {0} is not a real number", doubleValue));
            }
        }

        /// <summary>
        /// Asserts that the DateTime is defined, i.e. is not <see cref="DateTime.MinValue"/> or <see cref="DateTime.MaxValue"/>
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <param name="value">The value.</param>
        /// <param name="argName">Name of the arg.</param>
        /// <remarks></remarks>
        public static void DateTimeArgumentIsDefined(DateTime value, string argName)
        {
            if (DateTime.MinValue == value || DateTime.MaxValue == value)
            {
                throw new InvalidOperationException(string.Format("DateTime Argument {0} is not defined", argName));
            }
        }

        /// <summary>
        /// Builds an assertion in conjunction with <see cref="GuardConstraint"/>
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argName">Name of the arg.</param>
        /// <example>
        /// <code>
        /// Guard.Assert(123).IsLessThan(456);
        /// </code>
        /// </example>
        /// <returns></returns>
        /// <remarks></remarks>
        public static GuardConstraint Assert(IComparable value, string argName)
        {
            return new GuardConstraint(value, argName);
        }

        public static void AssertIsNotWinRTPlatform(String message)
        {
#if NETFX_CORE
            throw new PlatformNotSupportedException(message);
#endif
        }

        /// <summary>
        /// Try-Catch wrapper around a delegate, with exception message
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        public static void Try(Action action, string message)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(message, ex);
            }
        }
    }

    /// <summary>
    /// Allows assertions to be built with the following syntax: 
    /// <code>
    /// Guard.Assert(123).IsLessThan(456);
    /// </code>
    /// </summary>
    public class GuardConstraint
    {
        private readonly IComparable _value;
        private readonly string _argName;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardConstraint"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argName">Name of the arg.</param>
        /// <remarks></remarks>
        public GuardConstraint(IComparable value, string argName)
        {
            _value = value;
            _argName = argName;
        }

        /// <summary>
        /// Asserts that the current value is less than the specified other value
        /// </summary>
        /// <param name="other">The other value.</param>
        /// <param name="otherArgName">Name of the other arg.</param>
        /// <remarks></remarks>
        public void IsLessThan(IComparable other, string otherArgName)
        {
            if (_value.CompareTo(other) >= 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "The argument \"{0}\", value={1}, must be less than argument \"{2}\", value={3}", _argName, _value, otherArgName, other));
            }
        }

        /// <summary>
        /// Asserts that the current value is not equal to the specified other value
        /// </summary>
        /// <param name="other">The other value.</param>
        /// <param name="otherArgName">Name of the other arg.</param>
        /// <remarks></remarks>
        public void IsNotEqualTo(IComparable other, string otherArgName)
        {
            if (_value.CompareTo(other) == 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "The argument \"{0}\", value={1}, must not be equal to argument \"{2}\", value={3}", _argName, _value, otherArgName, other));
            }
        }

        /// <summary>
        /// Asserts that the current value is equal to the specified other value
        /// </summary>
        /// <param name="other">The other value.</param>
        /// <param name="otherArgName">Name of the other arg.</param>
        /// <remarks></remarks>
        public void IsEqualTo(IComparable other, string otherArgName)
        {
            if (_value.CompareTo(other) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "The argument \"{0}\", value={1}, must be equal to argument \"{2}\", value={3}", _argName, _value, otherArgName, other));
            }
        }

        /// <summary>
        /// Asserts that the current value is not equal to the specified other value
        /// </summary>
        /// <param name="other">The other value.</param>
        /// <remarks></remarks>
        public void IsNotEqualTo(IComparable other)
        {
            if (_value.CompareTo(other) == 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "The argument \"{0}\", value={1}, must not be equal to {2}", _argName, _value, other));
            }
        }

        /// <summary>
        /// Asserts that the current value is less than or equal to the specified other value
        /// </summary>
        /// <param name="other">The other value.</param>
        /// <param name="otherArgName">Name of the other arg.</param>
        /// <remarks></remarks>
        public void IsLessThanOrEqualTo(IComparable other, string otherArgName)
        {
            if (_value.CompareTo(other) > 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "The argument \"{0}\", value={1}, must be less than or equal to argument \"{2}\", value={3}", _argName, _value, otherArgName, other));
            }
        }

        /// <summary>
        /// Asserts that the current value is greater than or equal to the specified other value
        /// </summary>
        /// <param name="other">The other value.</param>
        /// <remarks></remarks>
        public void IsGreaterThanOrEqualTo(IComparable other)
        {
            if (_value.CompareTo(other) < 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "The argument \"{0}\", value={1}, must be greater than or equal to {2}", _argName, _value, other));
            }
        }

        /// <summary>
        /// Asserts that the current value is greater to the specified other value
        /// </summary>
        /// <param name="other">The other value.</param>
        /// <remarks></remarks>
        public void IsGreaterThan(IComparable other)
        {
            if (_value.CompareTo(other) <= 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "The argument \"{0}\", value={1}, must be greater than {2}", _argName, _value, other));
            }
        }
    }
}
