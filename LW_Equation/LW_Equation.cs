using System;
using System.Collections.Generic;

namespace LW_Equation
{
    using System.Numerics;

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

        public LinearEquation(char s, int count)
        {
            List<float> coef = new List<float>();
            switch (s)
            {
                case 'r':
                    {
                        Random rnd = new Random();
                        for (int i = 0; i < count; i++)
                            coef.Add(rnd.Next(100));
                    }
                    break;

                case 'o':
                    {
                        for(int i = 0; i < count; ++i)
                            coef.Add(i);
                    }
                    break;
            }
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
        public static LinearEquation operator -(LinearEquation first, float second)
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

        public static bool operator ==(LinearEquation first, LinearEquation second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(LinearEquation first, LinearEquation second)
        {
            return !first.Equals(second);
        }

        public float this[int i]
        {
            get => coefficients[i];
            set => coefficients[i] = value;
        }

        public static LinearEquation operator +(LinearEquation first, LinearEquation second)
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

        public static LinearEquation operator -(LinearEquation first, LinearEquation second)
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

        /// <summary>
        /// LinearEquation(1) => 1 = 0 (не имеет решений)
        /// </summary>
        /// <returns></returns>
        public bool haveSolution()
        {
            if(Size==1 && coefficients[0]!=0)
                return false;
            return true;
        }


        /// <summary>
        /// LinearEquation(k,b) => kx+b=0
        ///                        kx=-b
        ///                        x=(-b)/k
        /// LinearEquation(b) => b=0 => if(haveSolution) => x=00
        ///
        /// LinearEquation(1,2,3,4,...,k) => 1*(x1) + 2*(x2)+...+(k-1)*(xk-1) + k
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="AggregateException"></exception>
        public float solution()
        {
            if (Size == 2 && coefficients[1] != 0)
            {
                float result=(coefficients[1]*-1)/coefficients[0];
                return result;
            }
            if (Size > 2)
                throw new ArgumentOutOfRangeException("В уравнении больше чем одна неизвестная");
            if (Size < 2)
                throw new ArgumentException("В уравнении меньше чем 1 неизвестная");
            {
                throw new AggregateException("Коэффициент у неизвестного равен 0, а коэффициент у свободного не 0");
            }
        }

        /// <summary>
        /// LinearEquation(2, 2) => 2(x1) + 2
        /// LinearEquation(1,2,3) => 1(x1) + 2(x2) + 3
        /// LinearEquation(-1,2,-3,4) => -1(x1) + 2(x2) -3(x3) + 4
        /// LinearEquation(-1,0,-3,4) => -1(x1) -3(x3) + 4
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string equation="";
            int i=1;
            foreach (var k in this.coefficients)
            {
                if (i<Size && k!=0)
                {
                    if (k>0 && i!=1)
                    {
                        equation = equation + (" + " + k + "(x" + i + ")");
                    }
                    else
                    {
                        equation = equation + (" "+k + "(x" + i + ")");
                    }
                }
                else if(k!=0)
                {
                    equation = equation + (" + " + k);
                }
                i++;
            }
            return equation;
        }

        /// <summary>
        ///  LinearEquation(1,2,3) * 0 => null
        ///  LinearEquation(1,2,3) * 1 => LinearEquation(1,2,3)
        ///  LinearEquation(1,2,3) * k => LinearEquation(1k,2k,3k)
        /// </summary>
        /// <param name="x"></param>
        public void multiplication(float x)
        {
            if(x == 0)
                coefficients.Clear();
            else if(x != 1)
            {
                for (int i = 0; i < Size; i++)
                {
                    coefficients[i] *= x;
                }
            }
        }
    }
}
//feature1
//feature2
//feature3
//feature4
//feature5
//feature6
//feature7