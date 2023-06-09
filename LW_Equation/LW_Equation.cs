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
        static public LinearEquation operator +(LinearEquation first, float second)
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
            set { coefficients[i] = value; }
        }
    /// <summary>
    /// Перегрузка оператора +
    /// </summary>
    /// <param name="a">левый операнд, уравнение</param>
    /// <param name="b">правый операнд, уравнение</param>
    /// <returns>возвращает сумму уравнений</returns>
    public static LinearEquation operator +(LinearEquation a, LinearEquation b)
    {
        if (a.Size != b.Size)
            throw new IndexOutOfRangeException("Уравнения разной длинны");

        //копируем уравнение
        LinearEquation temp = a;

        //складываем коэф
        for (int i = 0; i < temp.Size; i++)
            temp.coefficients[i] += b.coefficients[i];

        return temp;
    }

    /// <summary>
    /// Перегрузка оператора -
    /// </summary>
    /// <param name="a">левый операнд, уравнение</param>
    /// <param name="b">правый операнд, уравнение</param>
    /// <returns>возвращает разность уравнений</returns>
    public static LinearEquation operator -(LinearEquation a, LinearEquation b)
    {
        if (a.Size != b.Size)
            throw new IndexOutOfRangeException("Уравнения разной длинны");

        //копируем уравнение
        LinearEquation temp = a;

        //складываем коэф
        for (int i = 0; i < temp.Size; i++)
            temp.coefficients[i] -= b.coefficients[i];

        return temp;
    }
        /// <summary>
        /// оператор bool 
        /// </summary>
        /// <param name="a">возвращает true, если есть корни, иначе false</param>
        public static implicit operator bool(LinearEquation a)
        {
            //если свободный член равен 0(последний в массиве), то уравнение имеет корни
            if (a.coefficients[a.Size - 1] == 0)
                return true;
            //если хотя бы один коэф. не ноль, то уравнение имеет корни
            for (int i = 0; i < a.Size - 1; i++)
                if (a.coefficients[i] != 0)
                    return true;
            //иначе уравнение не имеет корней
            return false;
        }

        /// <summary>
        /// Перегрузка оператора !
        /// </summary>
        /// <param name="a">уравнение</param>
        /// <returns></returns>
        public static bool operator !(LinearEquation a)
        {
            if (a)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Решение уравнения с одним неизвестным
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Получение корней уравнения, уравнение с 1 неизвестным</returns>
        public float? GetRoot(LinearEquation a)
        {
            if (a.Size != 2)
                return null;
            else
                return -a.coefficients[1] / coefficients[0];
        }
        /// <summary>
        /// Преобразование уравнения к строке
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "";
            bool first = true;
            for (int i = 0; i < this.Size - 1; i++)
            {
                if (this.coefficients[i] != 0 && first)
                {
                    //если 1
                    if (this.coefficients[i] == 1)
                        str += "x";
                    //если -1
                    else if (this.coefficients[i] == -1)
                        str += $"-x";
                    //иначе ставим коэф.
                    else
                        str += $"{this.coefficients[i]}x";
                    first = false;
                }
                //если не первый
                else
                {
                    if (this.coefficients[i] < 0)
                    {
                        //если -1
                        if (this.coefficients[i] == -1)
                            str += $"-x";
                        //иначе
                        else
                            str += $"{this.coefficients[i]}x";
                    }
                    //если коэф положительный
                    else if (this.coefficients[i] != 0)
                    {
                        if (this.coefficients[i] == 1)
                            str += $"+x";
                        else
                            str += $"+{this.coefficients[i]}x";
                    }
                }
            }
            //добавляем свободный член
            if (this.coefficients[this.Size - 1] < 0)
                str += $"{this.coefficients[this.Size - 1]}";
            else if (this.coefficients[this.Size - 1] != 0)
                str += $"+{this.coefficients[this.Size - 1]}";

            //добавляем в конце =0
            str += "=0";
            return str;
        }
    }
}