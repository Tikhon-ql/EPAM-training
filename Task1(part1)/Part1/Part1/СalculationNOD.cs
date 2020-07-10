using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Part1
{
    static class СalculationNOD
    {
        /// <summary>
        /// Вычисление НОД с помощью алгоритма Евклида
        /// </summary>
        static int EvclideNod(int arg1, int arg2)
        {
            while (arg1 > 0 && arg2 > 0)
            {

                if (arg1 > arg2)
                {
                    arg1 = arg1 % arg2;
                }
                else
                {
                    arg2 = arg2 % arg1;
                }
            }
            return arg1 + arg2;
        }
        // перегрузка метода нахождения НОД с помощью алгоритма Евклида
        static int EvclideNod(int arg1, int arg2, int arg3) => EvclideNod(EvclideNod(arg1,arg2),arg3);

        static int EvclideNod(int arg1, int arg2, int arg3,int arg4)
        {
            return EvclideNod(EvclideNod(EvclideNod(arg1,arg2),arg3),arg4);
        }
        static int EvclideNod(int arg1, int arg2, int arg3, int arg4,int arg5)
        {
            int firstNod = EvclideNod(arg1, arg2);
            int secondNod = EvclideNod(firstNod,arg3);
            int thirdNod = EvclideNod(secondNod, arg4);
            return EvclideNod(thirdNod, arg5);
        }
        /// <summary>
        /// Вычисление НОД с помощью алгоритма Стейна
        /// </summary>
        static int SteinNod(int arg1,int arg2,out long time)
        {
            // Для замера времени работы метода
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (arg1 == 0)
            {
                stopwatch.Stop();
                time = stopwatch.ElapsedMilliseconds;
                return arg2;
            }
                
            if (arg2 == 0)
            {
                stopwatch.Stop();
                time = stopwatch.ElapsedMilliseconds;
                return arg1;
            }

            if (arg1 == arg2)
            {
                stopwatch.Stop();
                time = stopwatch.ElapsedMilliseconds;
                return arg1;
            }
            if (arg1 % 2 == 0 && arg2 % 2 == 0)
            {
                return SteinNod(arg1/2,arg2/2,out time);
            }
            else
            {
                // если arg1 - четное, значит NOD(arg1,arg2) = NOD(arg1/2,arg2)
                if (arg1 % 2 == 0 && arg2 % 2 != 0)
                {
                    return SteinNod(arg1/2,arg2,out time);
                }
                else
                {
                    // если arg2 - четное, значит NOD(arg1,arg2) = NOD(arg1,arg2/2)
                    if (arg2 % 2 == 0)
                    {
                        return SteinNod(arg1, arg2 / 2,out time);
                    }
                    else
                    {
                        // arg1 > arg2, значит NOD(arg1,arg2) = NOD((arg1 - arg2),arg2), но если от одного нечетного числа отнять другое нечетное число получится четное, значит чтобы получить не четное мы можем разделить на 2
                        if(arg1 > arg2)
                        {
                            return SteinNod((arg1 - arg2) / 2,arg2,out time);
                        }
                        else
                        {
                            return SteinNod(arg1, (arg2 - arg1)/2,out time);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Перегразка метода нахождения НОД с помощью алгоритма Евклида с дополнительным выходным параметром для получения времени работы метода
        /// </summary>
        /// <returns></returns>
        static int EvclideNod(int arg1, int arg2, out long time)
        {
            // Для замера времени работы метода
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (arg1 > 0 && arg2 > 0)
            {

                if (arg1 > arg2)
                {
                    arg1 = arg1 % arg2;
                }
                else
                {
                    arg2 = arg2 % arg1;
                }
            }
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return arg1 + arg2;
        }
        static Random rnd = new Random();
        /// <summary>
        /// Метод для подготовки данных о времени работы методов для гистограммы
        /// </summary>
        /// <returns></returns>
        static Pair<long,long> ForBarCharts()
        {
            int arg1 = rnd.Next(0,100);
            int arg2 = rnd.Next(0, 100);
            long evclideTime = 0;
            EvclideNod(arg1,arg2,out evclideTime);
            long steinTime = 0;
            EvclideNod(arg1, arg2,out steinTime);
            return new Pair<long, long>(evclideTime, steinTime);
        }
    }
}
