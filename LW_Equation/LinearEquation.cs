using System;
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

        /// <summary>
        /// Конструирует уравнение вида coefficients[0]x + ... + coefficients[N-2]y + (aN)z + b = 0
        /// </summary>
        /// <param name="b">Свободный член</param>
        /// <param name="aN">Последний коэффициент</param>
        /// <param name="coefficients">Остальные коэффициенты</param>
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

        /// <summary>
        /// Суммирует свободный член first с second
        /// </summary>
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
        static public LinearEquation operator -(LinearEquation left, LinearEquation right)
        {
            int size = Math.Max(left.Size, right.Size);
            LinearEquation ans = new LinearEquation(true, size, 0);
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
            LinearEquation ans = new LinearEquation(true, size, 0);
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
        }
    }
}
