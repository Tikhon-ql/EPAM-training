using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomialLibrary
{
    public class Polynomial
    {
        public List<double> Coefficients { get; private set; }

        public Polynomial(List<double> coefficients)
        {
            Coefficients = coefficients;
        }
        public static Polynomial operator+(Polynomial p1,Polynomial p2)
        {
            List<double> res = new List<double>();
            int max = Math.Max(p1.Coefficients.Count,p2.Coefficients.Count);
            for(int i = 0; i < max; i++)
            {
                double a = 0;
                double b = 0;
                if (i < p1.Coefficients.Count)
                    a = p1.Coefficients[i];
                if (i < p2.Coefficients.Count)
                    b = p2.Coefficients[i];
                res.Add(a + b);
            }
            return new Polynomial(res);
        }
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            List<double> res = new List<double>();
            int max = Math.Max(p1.Coefficients.Count, p2.Coefficients.Count);
            for (int i = 0; i < max; i++)
            {
                double a = 0;
                double b = 0;
                if (i < p1.Coefficients.Count)
                    a = p1.Coefficients[i];
                if (i < p2.Coefficients.Count)
                    b = p2.Coefficients[i];
                res.Add(a - b);
            }
            return new Polynomial(res);
        }
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            double[] res = new double[p1.Coefficients.Count + p2.Coefficients.Count - 1]
            for(int i = 0; i < p1.Coefficients.Count; i++)
            {
                for(int j = 0;j<p2.Coefficients.Count;j++)
                {
                    res[i + j] += p1.Coefficients[i] * p2.Coefficients[j];
                }
            }
            return new Polynomial(res);
        }
        public static Polynomial operator /(Polynomial p1, Polynomial p2)
        {

        }
    }
}
