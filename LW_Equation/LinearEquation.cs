﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_Equation
{
    public class LinearEquation
    {
        List<double> coefficient = new();
        Random rand;
        public LinearEquation(params double[] coef)
        {
            //int cout = 0;
            Array.Reverse(coef);
            coefficient.InsertRange(0, coef);
            //cout++;
        }
        public LinearEquation(List<double> list)
        {
            list.Reverse();
            coefficient = list;
        }
        public LinearEquation(string str)
        {
            string[] ar = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = ar.Length - 1; i > -1; i--)
            {
                coefficient.Add(double.Parse(ar[i]));
            }
        }
        public static LinearEquation FillSame(int n, int k)
        {
            LinearEquation Same = new();
            for (int i = 0; i < n; i++)
            {
                Same.coefficient.Add(k);
            }
            return Same;
        }
        public int Length { get { return coefficient.Count; } }
        public void Round()
        {
            LinearEquation result = this;
            for (int i = 0; i < this.coefficient.Count; i++)
            {
                this.coefficient[i] = Math.Round(this.coefficient[i], 1);
            }
        }
        public static LinearEquation operator +(LinearEquation a, LinearEquation b)
        {
            int max = Math.Max(a.Length, b.Length);
            int min = Math.Min(a.Length, b.Length);
            LinearEquation count = FillSame(max, 0);
            for (int i = 0; i < min; i++)
            {
                count.coefficient[i] = a.coefficient[i] + b.coefficient[i];
            }
            if (max == a.Length)
                for (int j = min; j < max; j++)
                {
                    count.coefficient[j] = a.coefficient[j];
                }
            else if (max == b.Length)
                for (int j = min; j < max; j++)
                    count.coefficient[j] = b.coefficient[j];
            return count;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(LinearEquation a, LinearEquation b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a.coefficient[i] != b.coefficient[i])
                        return false;
                }
            }
            return true;
        }
        public static bool operator !=(LinearEquation a, LinearEquation b)
        {
            return !(a == b);
        }
        public double this[int i]
        {
            get { return coefficient[coefficient.Count - i - 1]; }
        }
        public static LinearEquation operator -(LinearEquation a, LinearEquation b)
        {
            int max = Math.Max(a.Length, b.Length);
            int min = Math.Min(a.Length, b.Length);
            LinearEquation count = FillSame(max, 0);
            if (max == a.Length)
            {
                for (int i = 0; i < b.Length; i++)
                {
                    count.coefficient[i] = a.coefficient[i] - b.coefficient[i];
                }
                for (int j = b.Length; j < a.Length; j++)
                {
                    count.coefficient[j] = a.coefficient[j];
                }
            }
            else if (max == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    count.coefficient[i] = a.coefficient[i] - b.coefficient[i];
                }
                for (int j = a.Length; j < b.Length; j++)
                {
                    count.coefficient[j] = -b.coefficient[j];
                }
            }
            return count;
        }
        public static bool operator false(LinearEquation a)
        {
            int count = 0;
            if (a.coefficient[a.Length - 1] != 0)
                for (int i = 0; i < a.Length - 1; i++)
                {
                    if (a.coefficient[i] == 0) count++;
                }
            if (count == a.Length - 1)
                return true;
            else
                return false;
        }
        public static bool operator true(LinearEquation a)
        {
            int count = 0;
            if (a.coefficient[0] != 0)
                for (int i = 0; i < a.Length - 1; i++)
                {
                    if (a.coefficient[i] == 0) count++;
                }
            if (count == a.Length - 2)
                return true;
            else
                return false;
        }
    }
}
