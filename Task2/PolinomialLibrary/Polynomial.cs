using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
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
            if (!ReferenceEquals(p1, null) && !ReferenceEquals(p2, null))
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
                    res.Add(a + b);
                }
                return new Polynomial(res.ToArray());
            }
            else
            {
                if (p1 != null)
                    return new Polynomial(p1.Coefficients.ToArray());
                return new Polynomial(p2.Coefficients.ToArray());
            }
        }
        /// <summary>
        /// Перегрузка оператора вычитания двух многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            if (p1 != null && p2 != null)
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
            else
            {
                if (p1 != null)
                    return new Polynomial(p1.Coefficients.ToArray());
                return new Polynomial(p2.Coefficients.ToArray());
            }
        }
        /// <summary>
        /// Перегрузка оператора умножения двух многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (!ReferenceEquals(p1, null) && !ReferenceEquals(p2, null))
            {
                double[] res = new double[p1.Coefficients.Count + p2.Coefficients.Count - 1];
                for (int i = 0; i < p1.Coefficients.Count; i++)
                {
                    for (int j = 0; j < p2.Coefficients.Count; j++)
                    {
                        res[i + j] += p1.Coefficients[i] * p2.Coefficients[j];
                    }
                }
                return new Polynomial(res);

            }
            else
            {
                if (p1 != null)
                    return new Polynomial(p1.Coefficients.ToArray());
                return new Polynomial(p2.Coefficients.ToArray());
            }
        }
        /// <summary>
        /// Перегрузка оператора деления двух многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polynomial operator /(Polynomial p1, Polynomial p2)
        {
            if(p1 != null && p2 != null)
            {
                List<double> res = new List<double>();
                List<double> tmp = p1.Coefficients.ToList();
                int currentDegree = p1.Coefficients.Count + 1;
                for (int i = 0; i <= p1.Coefficients.Count - p2.Coefficients.Count; i++)
                {
                    if (currentDegree >= 0)
                    {
                        res.Add(Math.Round(tmp[i] / p2.Coefficients[0],2));
                        for (int j = 0; j < p2.Coefficients.Count; j++)
                        {
                            tmp[i + j] = tmp[i + j] - (res[i] * p2.Coefficients[j]);
                        }
                        currentDegree--;
                    }
                    else
                    {
                        res.Add(Math.Round(tmp[i] / p2.Coefficients[0],2));
                    }
                }
                return new Polynomial(res.ToArray());
            }
            else
            {
                if (p1 != null)
                    return new Polynomial(p1.Coefficients.ToArray());
                return new Polynomial(p2.Coefficients.ToArray());
            }
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
                res.Add(Math.Round(item/p,2));
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
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if(!ReferenceEquals(p1,null) && !ReferenceEquals(p2, null))
                return p1.Coefficients.SequenceEqual(p2.Coefficients);
            return false;
        }
        /// <summary>
        /// Перегрузка оператора неравенства двух многочленов
        /// </summary>
        /// <param name = "p1" ></ param >
        /// < param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Polynomial polynomial &&
                   this.Coefficients.SequenceEqual(((Polynomial)obj).Coefficients);
        }

        public override int GetHashCode()
        {
            return -971426165 + Coefficients.GetHashCode();
        }
        public override string ToString()
        {
            if(this != null)
            {
                string str = "";
                Coefficients.ForEach(i => { str += i.ToString() + ";"; });
                return str;
            }
            else
            {
                return "";
            }
        }
    }
}
