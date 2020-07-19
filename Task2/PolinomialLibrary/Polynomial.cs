using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolinomialLibrary
{
    public class Polynomial
    {
        /// <summary>
        /// Массив коэффициентов
        /// </summary>
        public List<double> Coefficients { get; private set; }

        public Polynomial(params double[] coefficients)
        {
            Coefficients = coefficients.ToList();
        }
        /// <summary>
        /// Перегрузка оператора сложения двух многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
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
            return new Polynomial(res.ToArray());
        }
        /// <summary>
        /// Перегрузка оператора вычитания двух многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
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
            return new Polynomial(res.ToArray());
        }
        /// <summary>
        /// Перегрузка оператора умножения двух многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            double[] res = new double[p1.Coefficients.Count + p2.Coefficients.Count - 1];
            for(int i = 0; i < p1.Coefficients.Count; i++)
            {
                for(int j = 0;j<p2.Coefficients.Count;j++)
                {
                    res[i + j] += p1.Coefficients[i] * p2.Coefficients[j];
                }
            }
            return new Polynomial(res);
        }
        /// <summary>
        /// Перегрузка оператора деления двух многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polynomial operator /(Polynomial p1, Polynomial p2)
        {
            List<double> tmp = new List<double>();
            List<double> res = p1.Coefficients.ToList();
            int currentDegree = p1.Coefficients.Count - 1;
            for(int i = 0; i <= p1.Coefficients.Count - p2.Coefficients.Count; i++)
            {
                tmp.Add(res[i] / p2.Coefficients[0]);
                if (currentDegree >= 0)
                {
                    for(int j = 0; j < p2.Coefficients.Count; j++)
                    {
                        res[i + j] = res[i + j] - (tmp[i] * p2.Coefficients[j]);
                    }
                    currentDegree--;
                }
            }
            return new Polynomial(res.ToArray());
        }
        /// <summary>
        /// Перегрузка оператора деления многочлена на вещественное число
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Polynomial operator /(Polynomial p1, double p)
        {
            if(p == 0)
            {
                throw new DivideByZeroException();
            }
            List<double> res = new List<double>();
            foreach (double item in p1.Coefficients)
            {
                res.Add(Math.Round(item/p,3));
            }
            return new Polynomial(res.ToArray());
        }
        /// <summary>
        /// Перегрузка оператора умножения многочлена и вещественного числа
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial p1, double p)
        {
            List<double> res = new List<double>();
            foreach (double item in p1.Coefficients)
            {
                res.Add(item * p);
            }
            return new Polynomial(res.ToArray());
        }
        /// <summary>
        /// Перегрузка оператора равенства двух многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomial p1,Polynomial p2)
        {
            return p1.Coefficients.SequenceEqual(p2.Coefficients);
        }
        /// <summary>
        /// Перегрузка оператора неравенства двух многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            if (!p1.Coefficients.SequenceEqual(p2.Coefficients))
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Polynomial polynomial &&
                   this.Coefficients.SequenceEqual(((Polynomial)obj).Coefficients);
        }

        public override int GetHashCode()
        {
            return -971426165 + EqualityComparer<List<double>>.Default.GetHashCode(Coefficients);
        }
        public override string ToString()
        {
            string str = "";
            Coefficients.ForEach(i => { str += i.ToString();});
            return str;
        }
    }
}
