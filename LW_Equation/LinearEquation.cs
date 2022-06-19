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
            get { return this.coefficients[i]; }
        }
        
        static public LinearEquation operator +(LinearEquation a, LinearEquation b)
        {

            List<float> first = a.Size > b.Size ? a.coefficients : b.coefficients;
            List<float> second = a.Size <= b.Size ? a.coefficients : b.coefficients;

            for (int i = second.Count - 1, j = first.Count - 1; i > 0; i--, j--)
            {
                first[j] += second[i];
            }
            first[0] += second[0];
            return new LinearEquation(first);
        }
        static public LinearEquation operator -(LinearEquation a, LinearEquation b)
        {

            List<float> first = a.Size > b.Size ? a.coefficients : b.coefficients;
            List<float> second = a.Size <= b.Size ? a.coefficients : b.coefficients;

            for (int i = second.Count - 1, j = first.Count - 1; i > 0; i--, j--)
            {
                first[j] -= second[i];
            }
            first[0] -= second[0];
            return new LinearEquation(first);
        }
        
        static public bool operator true(LinearEquation eq)
        {
            int count = 0;
            for (int i = 0; i < eq.Size; i++)
            {
                if (eq[i] == 0)
                    count++;
            }
            if (count == eq.Size - 2 && eq[eq.Size - 1] != 0)
                return true;
            else
                return false;
        }
        static public bool operator false(LinearEquation eq)
        {
            int count = 0;
            for (int i = 0; i < eq.Size; i++)
            {
                if (eq[i] == 0)
                    count++;
            }
            if (count == eq.Size - 1)
                return true;
            else
                return false;
        }
        
        public bool Solve(out float ans)
        {
            ans = 0;
            int counter = 0;
            int ind = -1;
            for (int i = Size - 1; i >= 0; i--)
            {
                if (this[i] == 0) counter++;
                else ind = i;
            }

            if (counter == Size - 2 && this[Size - 1] != 0)
            {
                ans = (0 - this[Size - 1]) / (this[ind]);
                return true;
            }

            return false;
        }
        public override String ToString()
        {
            String ans = "";
            for (int i = 0; i < this.Size - 1; i++)
            {
                ans += this[i].ToString();
                ans += ",";
            }
            ans += this[this.Size - 1].ToString();
            return ans;
        }
        
        public LinearEquation(bool t, int size)
        {
            Random rng = new Random();
            this.coefficients = new List<float>();
            for (int i = 0; i < size; i++)
                coefficients.Add((float)rng.NextDouble() * 100);
        }
        public LinearEquation(bool t, int size, float a)
        {
            this.coefficients = new List<float>();
            for (int i = 0; i < size; i++)
                coefficients.Add(a);
        }
        static public LinearEquation operator*(LinearEquation e, float f)
        {
            for (int i = 0; i < e.Size; i++)
            {
                e.coefficients[i] *= f;
            }
            return e;
        }
        static public LinearEquation operator -(LinearEquation a)
        {
            for (int i = 0; i < a.Size; i++)
            {
                a.coefficients[i] *= -1;
            }
            return a;
        }
    }
}
