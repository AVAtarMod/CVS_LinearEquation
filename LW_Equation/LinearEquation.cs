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
        public LinearEquation(float b, float aN, params float[] coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients.Add(b);
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
        static public LinearEquation operator+ (LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.Size - 1] += second;
            return equation;
        }
        /// <summary>
        /// Вычитает second из свободного члена first
        /// </summary>
        static public LinearEquation operator- (LinearEquation first, float second)
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
            get { return coefficients[i]; }
        }


        static public LinearEquation operator -(LinearEquation first, LinearEquation second)
        {
            for(int i = 0; i < first.Size; i++)
            {
                for(int k = 0; k < second.Size; k++)
                {
                    first.coefficients[i] = first[i] - second[i];
                    i++;
                    if(i >= first.Size)
                    {
                        break;
                    }
                }
                if (i >= first.Size)
                {
                    break;
                }
            }
            return first;
        }
        static public LinearEquation operator +(LinearEquation first, LinearEquation second)
        {
            for (int i = 0; i < first.Size; i++)
            {
                for (int k = 0; k < second.Size; k++)
                {
                    first.coefficients[i] = first[i] + second[i];
                    i++;
                    if (i >= first.Size)
                    {
                        break;
                    }
                }
                if (i >= first.Size)
                {
                    break;
                }
            }
            return first;
        }
        public double IsDesided(params float[] nums)
        {
            if (nums.Length != Size - 1)
                return 0;

            bool stNums = false;
            var sum = coefficients[0];
            for (int i = 1; i < Size - 1; i++)
            {
                if (!stNums)
                    for (int k = 0; k < nums.Length; k++)
                    {
                        sum += nums[k] * coefficients[i];
                        i++;
                    }
                stNums = true;
                if (i < Size - 1)
                    sum += coefficients[i];
            }
            return (-sum) / coefficients.Last();
        }
    }
}
