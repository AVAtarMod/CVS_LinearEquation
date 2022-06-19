﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_Equation
{
    public class LinearEquation
    {
        List<float> coefficients;
        public int Size => coefficients.Count;
        public LinearEquation()
        {
            coefficients = new List<float>();
        }
        public LinearEquation(float b, float aN, params float[] coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients.Add(b);
            this.coefficients.Add(aN);
            this.coefficients.AddRange(coefficients);
            Normalization(ref this.coefficients);
        }
        public LinearEquation(List<float> coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients = coefficients;
            Normalization(ref this.coefficients);
        }
        static public LinearEquation operator +(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[0] += second;
            Normalization(ref equation.coefficients);
            return equation;
        }
        static public LinearEquation operator -(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[0] -= second;
            Normalization(ref equation.coefficients);
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
            get => coefficients[i];
            set => coefficients[i] = value;
        }
        private static void Normalization(ref List<float> coef)
        {
            int i = coef.Count - 1;
            while (coef[i] == 0)
            {
                coef.RemoveAt(coef.Count - 1);
                i--;
            }
        }
        static public LinearEquation operator +(LinearEquation first, LinearEquation second)
        {
            int i;
            List<float> coef = new List<float>();
            if (first.Size < second.Size)
            {
                for (i = 0; i < first.Size; i++) coef.Add(first[i] + second[i]);
                for (; i < second.Size; i++) coef.Add(second[i]);
            }
            else
            {
                for (i = 0; i < second.Size; i++) coef.Add(first[i] + second[i]);
                for (; i < first.Size; i++) coef.Add(first[i]);
            }
            Normalization(ref coef);
            return new LinearEquation(coef);
        }
        static public LinearEquation operator -(LinearEquation first, LinearEquation second)
        {
            int i;
            List<float> coef = new List<float>();
            if (first.Size < second.Size)
            {
                for (i = 0; i < first.Size; i++) coef.Add(first[i] - second[i]);
                for (; i < second.Size; i++) coef.Add(-second[i]);
            }
            else
            {
                for (i = 0; i < second.Size; i++) coef.Add(first[i] - second[i]);
                for (; i < first.Size; i++) coef.Add(first[i]);
            }
            Normalization(ref coef);
            return new LinearEquation(coef);
        }
        static public bool operator true(LinearEquation eq)
        {
            if (eq.Size == 0) return true;
            else if (eq[0] == 0) return true;
            else return false;
        }
        static public bool operator false(LinearEquation eq)
        {
            if (eq.Size == 0) return false;
            else if (eq[0] == 0) return false;
            else return true;
        }
        public bool Solve(out float ans)
        {
            ans = 0;
            int counter = 0;
            int ind = -1;
            for (int i = Size - 1; i >= 0; i--)
            {
                if (this[i] == 0) counter++;
                else ind = i;
            }

            if (counter == Size - 2 && this[Size - 1] != 0)
            {
                ans = (0 - this[Size - 1]) / (this[ind]);
                return true;
            }

            return false;
        }
        public override String ToString()
        {
            String ans = "";
            for (int i = 0; i < this.Size - 1; i++)
            {
                ans += this[i].ToString();
                ans += ",";
            }
            ans += this[this.Size - 1].ToString();
            return ans;
        }
        public LinearEquation(bool t, int size)
        {
            Random rng = new Random();
            this.coefficients = new List<float>();
            for (int i = 0; i < size; i++)
                coefficients.Add((float)rng.NextDouble() * 100);
        }
        public LinearEquation(bool t, int size, float a)
        {
            this.coefficients = new List<float>();
            for (int i = 0; i < size; i++)
                coefficients.Add(a);
        }
        public LinearEquation MultiplyByNumber(float val)
        {
            LinearEquation ans = new LinearEquation(this.coefficients);

            for (int i = 0; i < ans.Size; i++)
            {
                ans[i] *= val;
            }

            return ans;
        }
        static public LinearEquation operator -(LinearEquation first)
        {
            LinearEquation ans = first;
            for (int i = 0; i < ans.Size; i++)
            {
                ans[i] *= -1;
            }
            return ans;
        }
        public List<double> ToList()
        {
            List<double> ans = new List<double>();

            for (int i = 0; i < this.Size; i++)
                ans.Add((double)this.coefficients[i]);

            return ans;
        }
    }
}
