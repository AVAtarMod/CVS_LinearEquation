﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_Equation
{
    public class EquationSize
    {
        int size;
        public EquationSize(int size)
        {
            Size = size;
        }
        public static implicit operator int(EquationSize size) => size.Size;
        public int Size
        {
            get => size;
            set => size = value;
        }
    }
    public class LinearEquation
    {
        List<float> coefficients;
        public int Size => coefficients.Count;

        public LinearEquation(params float[] coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients.AddRange(coefficients);
        }
        public LinearEquation(List<float> coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients = coefficients;
        }
        public LinearEquation(EquationSize size, float a)
        {
            this.coefficients = new List<float>();
            for (int i = 0; i < size; i++)
                coefficients.Add(a);
        }
        static public LinearEquation operator+ (LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.Size - 1] += second;
            return equation;
        }
        /// <summary>
        /// Вычитает second из свободного члена first
        /// </summary>
        static public LinearEquation operator -(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.Size - 1] -= second;
            return equation;
        }
        public override bool Equals(object obj)
        {
            if (obj is LinearEquation equation)
            {
                if (Size != equation.Size)
                    return false;
                for (int i = 0; i < Size; i++)
                {
                    if (this.coefficients[i] != equation.coefficients[i])
                        return false;
                }
                return true;
            }
            return false;
        }
        static public bool operator ==(LinearEquation first, LinearEquation second)
        {
            return first.Equals(second);
        }
        static public bool operator !=(LinearEquation first, LinearEquation second)
        {
            return !first.Equals(second);
        }
        static public LinearEquation operator -(LinearEquation left, LinearEquation right)
        {
            int size = Math.Max(left.Size, right.Size);
            LinearEquation ans = new LinearEquation(new EquationSize(size), 0);
            for (int i = 1; i <= size; i++)
            {
                if ((left.Size - i) < 0 && (right.Size - i) >= 0)
                {
                    ans[ans.Size - i] = -right[right.Size - i];
                }
                else if ((left.Size - i) >= 0 && (right.Size - i) < 0)
                {
                    ans[ans.Size - i] = left[left.Size - i];
                }
                else
                {
                    ans[ans.Size - i] = left[left.Size - i] - right[right.Size - i];
                }
            }
            return ans;
        }
        static public LinearEquation operator +(LinearEquation left, LinearEquation right)
        {
            int size = Math.Max(left.Size, right.Size);
            LinearEquation ans = new LinearEquation(new EquationSize(size), 0);
            for (int i = 1; i <= size; i++)
            {
                if ((left.Size - i) < 0 && (right.Size - i) >= 0)
                {
                    ans[ans.Size - i] = right[right.Size - i];
                }
                else if ((left.Size - i) >= 0 && (right.Size - i) < 0)
                {
                    ans[ans.Size - i] = left[left.Size - i];
                }
                else
                {
                    ans[ans.Size - i] = left[left.Size - i] + right[right.Size - i];
                }
            }
            return ans;
        }
        static public bool operator true(LinearEquation eq)
        {
            int count = 0;
            for (int i = 0; i < eq.Size; i++)
            {
                if (eq[i] == 0)
                    count++;
            }
            if (count == eq.Size - 2 && eq[eq.Size - 1] != 0)
                return true;
            else
                return false;
        }
        static public bool operator false(LinearEquation eq)
        {
            int count = 0;
            for (int i = 0; i < eq.Size; i++)
            {
                if (eq[i] == 0)
                    count++;
            }
            if (count == eq.Size - 1)
                return true;
            else
                return false;
        }
        public bool Solve(out float ans)
        {
            ans = 0;
            int counter = 0;
            int ind = -1;
            for (int i = Size - 1; i >= 0; i--)
            {
                if (this[i] == 0) counter++;
                
            }

            if (counter == Size - 2 && this[Size] != 0)
            {
                ans = (0 - this[Size]) / (this[ind]);
                return true;
            }

            return false;
        }
        public float this[int i]
        {
            get { return this.coefficients[i]; }
            set { this.coefficients[i] = value; }
        }
    }
}
