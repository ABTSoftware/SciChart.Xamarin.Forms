﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class Uint32Math : IMath<uint>
    {
        public uint MinValue
        {
            get { return uint.MinValue; }
        }

        public uint MaxValue
        {
            get { return uint.MaxValue; }
        }

        public uint ZeroValue
        {
            get { return 0; }
        }

        public uint Max(uint a, uint b)
        {
            return a > b ? a : b;
        }

        public uint Min(uint a, uint b)
        {
            return a < b ? a : b;
        }

        public uint MinGreaterThan(uint floor, uint a, uint b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(uint value)
        {
            return false;
        }

        public uint Subtract(uint a, uint b)
        {
            return a - b;
        }

        public uint Abs(uint a)
        {
            return a;
        }

        public double ToDouble(uint value)
        {
            return value;
        }

        public uint Mult(uint lhs, uint rhs)
        {
            return lhs * rhs;
        }

        public uint Mult(uint lhs, double rhs)
        {
            return (uint) (lhs * rhs);
        }

        public uint Div(uint lhs, uint rhs)
        {
            return (lhs / rhs);
        }

        public uint Add(uint lhs, uint rhs)
        {
            return lhs + rhs;
        }

        public uint Inc(ref uint value)
        {
            return ++value;
        }
        public uint Dec(ref uint value)
        {
            return --value;
        }

        public uint FromDouble(double dValue)
        {
            return (uint) dValue;
        }
    }
}