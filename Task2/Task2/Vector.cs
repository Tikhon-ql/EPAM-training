using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Vector
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Z { get; set; } = 0;
        public double Length { get; set; } = 0;

        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            Length = Math.Sqrt(X*X + Y*Y + Z*Z);
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector v1,Vector v2)
        {
            return new Vector(v1.X + v2.X,v1.Y + v2.Y,v1.Z + v1.Z);
        }
        /// <summary>
        /// Перегрузка оператора вычитания
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v1.Z);
        }
        /// <summary>
        /// Перегрузка оператора умножения
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.Y*v2.Z - v1.Z * v2.Y,v1.Z*v2.X - v1.X*v2.Z,v1.X*v2.Y - v1.Y*v2.X);
        }
        /// <summary>
        /// Перегрузка оператора деления
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator /(Vector v1, Vector v2)
        {
            return v1 * new Vector(1/v2.X,1/v2.Y,1/v2.Z);
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
        public static Vector operator %(Vector v1, Vector v2)
        {
            Vector v = v1 / v2;
            Vector nv = new Vector(Convert.ToInt32(v.X),Convert.ToInt32(v.Y),Convert.ToInt32(v.Z));
            return v - nv;
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
    }
}
