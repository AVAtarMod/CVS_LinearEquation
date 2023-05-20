using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_Equation
{
    public class LinearEquation
    {
        List<float> coefficients = new List<float>();
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
        public LinearEquation(params float[] coefficients)
        {        
            this.coefficients.AddRange(coefficients);           
        }
        public LinearEquation(List<float> coefficients)
        {
            this.coefficients = coefficients;
        }

        /// <summary>
        /// Суммирует свободный член first с second
        /// </summary>
        static public LinearEquation operator +(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            int lastc = equation.coefficients.Count - 1 ;
            equation.coefficients[lastc] += second;
            return equation;
        }
        /// <summary>
        /// Вычитает second из свободного члена first
        /// </summary>
        static public LinearEquation operator -(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            int lastc = equation.coefficients.Count - 1;
            equation.coefficients[lastc] -= second;
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

            if (first.Size != second.Size)
                throw new IndexOutOfRangeException("Разная размерность");
            List<float> result = new List<float>();
            for (int i = 0; i < second.Size; i++)
                {
                    result.Add(first[i] - second[i]);
                }
                
            return new LinearEquation(result);
            
        }
        static public LinearEquation operator +(LinearEquation first, LinearEquation second)
        {

            if (first.Size != second.Size)
                throw new IndexOutOfRangeException("Разная размерность");
            List<float> result = new List<float>();
            for (int i = 0; i < second.Size; i++)
            {
                result.Add(first[i] + second[i]);
            }

            return new LinearEquation(result);

        }
        static public implicit operator bool(LinearEquation first)
        {
            int lastk = first.Size - 1;

            if (first[lastk] == 0)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < lastk; i++)
                {
                    if (first[i] != 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public int? Solution_Equation(LinearEquation first)
        {
            int solut = 0;
            for(int i = -10000; i < 10000; i++)
            {
                if(first[0] * i + first[1] == 0)
                {
                    solut = i;
                    return solut;
                }
            }
            
            return null;
        }

    }
}
