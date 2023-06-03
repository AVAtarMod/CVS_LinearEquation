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
        /// <param name="aN">Последний коэффициент</param>
        /// <param name="coefficients">Остальные коэффициенты</param>
       
        public LinearEquation(float aN, params float[] coefficients)
        {
            this.coefficients = new List<float>(coefficients); // Исправление: Инициализируем список coefficients
            this.coefficients.Insert(0, aN); // Исправление: Вставляем aN в начало списка с помощью метода
        }

        public LinearEquation(List<float> coefficients)
        {
            this.coefficients = new List<float>(coefficients); // Исправлено
        }

        /// <summary>
        /// Суммирует свободный член first с second
        /// </summary>
        static public LinearEquation operator +(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.coefficients.Count - 1] += second; // Исправлено
            return equation;
        }

        /// <summary>
        /// Вычитает second из свободного члена first
        /// </summary>
        static public LinearEquation operator -(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.coefficients.Count - 1] -= second; // Исправлено
            return equation;
        }

        public override bool Equals(object obj)
        {
            if (obj is LinearEquation equation)
            {
                if (Size != equation.Size)
                    return false; // Исправление: Возвращаем false, если размеры уравнений не совпадают.
                for (int i = 0; i < Size; i++)
                {
                    if (this.coefficients[i] != equation.coefficients[i])
                        return false; // Исправление: Возвращаем false, если найдено несовпадение коэффициентов.
                }
                return true; // Исправление: Возвращаем true, если все коэффициенты совпадают.
            }
            return false; // Исправление: Возвращаем false, если объект не является экземпляром LinearEquation.
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
