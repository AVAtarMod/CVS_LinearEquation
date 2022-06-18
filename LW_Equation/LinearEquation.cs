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
        public float this[int i]
        {
            get { return this.coefficients[i]; }
            set { this.coefficients[i] = value; }
        }
    }
}
