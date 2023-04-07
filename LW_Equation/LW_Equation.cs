using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LW_Equation
{
    public class LinearEquation
    {
        List<float> coefficients;
        public int Size => coefficients.Count;

        /// <summary>
        /// Конструрирует уравнение вида aN*x + coefficients[0]y + ... + coefficients[N-2]z + coefficients[N-1] = 0
        /// </summary>
        /// Примеры:
        /// <example>
        /// LinearEquation(1,2,3,4) => 1x + 2y + 3z + 4 = 0
        /// LinearEquation(1,2) => 1x + 2 = 0
        /// LinearEquation(1) => 1 = 0 (не имеет решений)
        /// </example>
        /// <param name="aN">Последний коэффициент</param>
        /// <param name="coefficients">Остальные коэффициенты</param>
        public LinearEquation(params float[] coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients.AddRange(coefficients);
        }
        /// <summary>
        /// Конструктор из листа
        /// </summary>
        /// <param name="coefficients"></param>
        public LinearEquation(List<float> coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients = coefficients;
        }

        /// <summary>
        /// Суммирует свободный член first с second
        /// </summary>
        static public LinearEquation operator +(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.Size-1] += second;
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
            if (first.Equals(second))
                return false;
            else 
                return true;
        }
        public float this[int i]
        {
            get { return coefficients[i]; }
            set { coefficients[i] = value; }
        }
    }
}
