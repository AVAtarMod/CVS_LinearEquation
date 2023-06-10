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
        public LinearEquation(float b, float aN, params float[] coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients.Add(aN);
            this.coefficients.Add(b);
            this.coefficients.AddRange(coefficients);
        }
        public LinearEquation(List<float> coefficients)
        {
            this.coefficients = new List<float>();
            this.coefficients = coefficients;
        }
        static public LinearEquation operator +(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[0] *= second;
            return equation;
        }
        static public LinearEquation operator -(LinearEquation first, float second)
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
