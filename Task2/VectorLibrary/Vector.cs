using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task2
{
    public class Vector
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double Z { get; set; } = 0;
        public double Length { get; set; } = 0;

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            Length = Math.Round(Math.Sqrt(X * X + Y * Y + Z * Z),3);
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v1.Z);
        }
        /// <summary>
        /// Перегрузка оператора вычитания
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        /// <summary>
        /// Перегрузка оператора умножения
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }
        /// <summary>
        /// Перегрузка оператора деления
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator /(Vector v1, Vector v2)
        {
            double v2x = Math.Round(1 / v2.X,3);
            double v2y = Math.Round(1 / v2.Y,3);
            double v2z = Math.Round(1 / v2.Z,3);
            return v1 * new Vector(v2x,v2y,v2z);
        }
        /// <summary>
        /// Перегрузка оператора унарного минуса
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y, -v.Z);
        }/// <summary>
         /// Перегрузка оператора инкремента
         /// </summary>
         /// <param name="v"></param>
         /// <returns></returns>
        public static Vector operator ++(Vector v)
        {
            return new Vector(v.X + 1, v.Y + 1, v.Z + 1);
        }
        /// <summary>
        /// Перегрузка оператора дикремента
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector operator --(Vector v)
        {
            return new Vector(v.X - 1, v.Y - 1, v.Z - 1);
        }
        // Перегрузка оператора остатка от деления
        public static Vector operator %(Vector v1, Vector v2)
        {
            Vector v = v1 / v2;
            Vector nv = new Vector(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), Convert.ToInt32(v.Z));
            return v - nv;
        }
        // Перегрузка операторова сравнения
        public static bool operator ==(Vector v1, Vector v2)
        {
            if (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z)
                return true;
            return false;
        }
        public static bool operator !=(Vector v1, Vector v2)
        {
            if (v1.X != v2.X && v1.Y != v2.Y && v1.Z != v2.Z)
                return true;
            return false;
        }
       
        public static bool operator >(Vector v1,Vector v2)
        {
            if (v1.Length > v2.Length)
                return true;
            return false;
        }
        public static bool operator <(Vector v1, Vector v2)
        {
            if (v1.Length < v2.Length)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (this.GetHashCode() == obj.GetHashCode())
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return 613529524 + Y.GetHashCode();
        }
        public override string ToString()
        {
            return X + " " + Y + " " + Z;
        }
    }
}
