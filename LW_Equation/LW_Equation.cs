using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_Equation
{
    using System.Runtime.ExceptionServices;

    public class LinearEquation
    {
        public List<float> coefficients;
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
        /// <param name="aN">Последний коэффициент</param>
        /// <param name="coefficients">Остальные коэффициенты</param>
        public LinearEquation(float aN,params float[] coefficients)
        {
            this.coefficients = new List<float>(coefficients);
            //this.coefficients.AddRange(coefficients);
            this.coefficients.Insert(0,aN);
        }
        public LinearEquation(List<float> coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients = coefficients;
        }

        //static public bool operator ==(LinearEquation linear_A,LinearEquation obj)
        //{
        //    if (linear_A!=null && obj != null)
        //    {
        //        if (obj is LinearEquation linear_B)
        //        {
        //            if (linear_A.Size == linear_B.Size)
        //            {
        //                int i;
        //                for (i = 0; i < linear_A.Size;)
        //                {
        //                    if (linear_A.coefficients[i] == linear_B.coefficients[i])
        //                        i++;
        //                    else
        //                        break;
        //                }
        //                if(i==linear_A.Size)
        //                    return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

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
            equation.coefficients[equation.Size-1] -= second;
            return equation;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is LinearEquation linear_B)
                {
                    if (Size == linear_B.Size)
                    {
                        int i;
                        for (i = 0; i < Size;)
                        {
                            if (coefficients[i] == linear_B.coefficients[i])
                                i++;
                            else
                                break;
                        }
                        if (i == Size)
                            return true;
                    }
                }
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

        static public LinearEquation operator +(LinearEquation first, LinearEquation second)
        {
            int size;
            LinearEquation equation,plusEquation;
            if (first.Size >= second.Size)
            {
                equation = first;
                plusEquation = second;
                size = second.Size;
            }
            else
            {
                equation = second;
                plusEquation = first;
                size = first.Size;
            }
            int k = 0;
            while (k!=size)
            {
                equation[k] += plusEquation[k];
                k++;
            }

            return equation;
        }

        static public LinearEquation operator -(LinearEquation first, LinearEquation second)
        {
            if (first.Equals(second))
            {
                return null;
            }
            int size;
            LinearEquation equation, minusEquation;
            if (first.Size >= second.Size)
            {
                equation = first;
                minusEquation = second;
                size = second.Size;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Вычитаемое уровнение больше чем то из которого вычитаем");
            }
            int k = 0;
            while (k != size)
            {
                equation[k] -= minusEquation[k];
                k++;
            }

            return equation;
        }
    }
}
