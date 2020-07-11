using Figures;
using Figures.Models;
using FileWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Figure> figures = FileWorker.ReadFromFile(@"D:\Тихон\Git\EPAM-training\Task1(part2)\Part2\Part2\Resources\test.txt");
            foreach(Figure item in figures)
            {
                Console.WriteLine(item.ToString());
            }
            //Rectangle;14,65;61,45;13,51;95,42
            Figure fig = new Square(15);
            Console.WriteLine("----------------------------------");
            foreach (Figure item in figures)
            {
                if (item.Equals(fig))
                {
                    Console.WriteLine(item.ToString()); 
                }
            }
        }
    }
}
