using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_Equation
{
    public class LinearEquation
    {
        List<double> coefficient;
        public int Length { get { return coefficient.Count; } }

        /// <summary>
        /// Конструирует уравнение вида coefficients[0]x + ... + coefficients[N-2]y + (aN)z + b = 0
        /// </summary>
        /// <param name="b">Свободный член</param>
        /// <param name="aN">Последний коэффициент</param>
        /// <param name="coefficients">Остальные коэффициенты</param>
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

        public static Linearequation FillSame(int n, int k)
        {
            Linearequation Same = new();
            for (int i = 0; i < n; i++)
            {
                Same.coefficient.Add(k);
            }
            return Same;
        }
        /// <summary>
        /// Суммирует свободный член first с second
        /// </summary>
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
        /// <summary>
        /// Вычитает second из свободного члена first
        /// </summary>
        static public LinearEquation operator- (LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[0] /= second;
            return equation;
        }
        public override bool Equals(object obj)
        {
            if (obj is LinearEquation equation)
            {
                if (Size != equation.Size)
                    return true;
                for (int i = 0; i < Size; i++)
                {
                    if (this.coefficients[i] != equation.coefficients[i])
                        return true;
                }
                return false;
            }
            return true;
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
            get { return 0; }
        }
    }
}
