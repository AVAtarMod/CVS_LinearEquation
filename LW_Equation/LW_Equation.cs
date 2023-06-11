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
        /// Конструирует уравнение вида aN*x + coefficients[0]y + ... + coefficients[N-2]z + coefficients[N-1] = 0
        /// </summary>
        /// 
        /// Примеры:
        /// <example>
        /// LinearEquation(1,2,3,4) => 1x + 2y + 3z + 4 = 0
        /// LinearEquation(1,2) => 1x + 2 = 0
        /// LinearEquation(1) => 1 = 0 (не имеет решений)
        /// </example>
        /// 
        /// <param name="aN">Первый коэффициент коэффициент</param>
        /// <param name="coefficients">Остальные коэффициенты</param>
        public LinearEquation(float aN, params float[] coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients.Add(aN);
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
        static public LinearEquation operator +(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.coefficients.Count - 1] += second;
            return equation;
        }
        /// <summary>
        /// Вычитает second из свободного члена first
        /// </summary>
        static public LinearEquation operator -(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.coefficients.Count - 1] -= second;
            return equation;
        }

        public static LinearEquation operator +(LinearEquation first, LinearEquation second)
        {
            if (first.Size != second.Size)
                throw new IndexOutOfRangeException("Уравнения разной длинны");

            LinearEquation temp = first;

            for (int i = 0; i < temp.Size; i++)
                temp.coefficients[i] += second.coefficients[i];

            return temp;
        }

        public static LinearEquation operator -(LinearEquation first, LinearEquation second)
        {
            if (first.Size != second.Size)
                throw new IndexOutOfRangeException("Уравнения разной длинны");

            LinearEquation temp = first;

            for (int i = 0; i < temp.Size; i++)
                temp.coefficients[i] -= second.coefficients[i];

            return temp;
        }

        public static implicit operator bool(LinearEquation a)
        {
            if (a.coefficients[a.Size - 1] == 0)
                return true;
            for (int i = 0; i < a.Size - 1; i++)
                if (a.coefficients[i] != 0)
                    return true;
            return false;
        }

        public float Solve(LinearEquation a)
        {
            return -a.coefficients[1] / coefficients[0];
        }

        public override string ToString()
        {
            string tempStr = "";
            string alphabet = "xyzqwertuiopasdfghjklzcvbnm";
            for (int i = 0; i < this.coefficients.Count - 1; i++)
            {
                if (coefficients[i] < 0)
                    tempStr += this.coefficients[i].ToString() + alphabet[i];
                else
                {
                    if (i != 0)
                        tempStr += "+" + this.coefficients[i].ToString() + alphabet[i];
                    else tempStr += this.coefficients[i].ToString() + alphabet[i];
                }
            }
            if (this.coefficients[coefficients.Count - 1] < 0)
            {
                tempStr += this.coefficients[coefficients.Count - 1];
            }
            else tempStr += "+" + this.coefficients[coefficients.Count - 1];
            return tempStr;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
            get { return coefficients[i]; }
        }
    }
}
