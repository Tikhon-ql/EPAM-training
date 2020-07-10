using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Figures;
using Figures.Models;

namespace FileWork
{
    public static class FileWork
    {
        /// <summary>
        /// Метод получения данных из текстового файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public static List<Figure> ReadFromFile(string filename)
        {
            List<Figure> figures = new List<Figure>();
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string[] strs = reader.ReadLine().Split(';');
                    switch (strs[0])
                    {
                        case "Triangle":
                            // Название + 1-ая сторна + 2-ая сторона + 3-ая сторона
                            if(strs.Length == 4)
                            {
                                Triangle triangle = new Triangle(double.Parse(strs[1]),Convert.ToDouble(strs[2]),Convert.ToDouble(strs[3]));
                            }
                            else
                            {
                                Point tp1 = new Point(int.Parse(strs[1]), Convert.ToInt32(strs[2]));
                                Point tp2 = new Point(int.Parse(strs[3]), Convert.ToInt32(strs[4]));
                                Point tp3 = new Point(int.Parse(strs[5]), Convert.ToInt32(strs[6]));
                                figures.Add(new Triangle(tp1, tp2, tp3));
                            }
                            break;
                        case "Square":
                            // Название + 1-ая сторна + 2-ая сторона + 3-ая сторона + 4-ая сторона
                            if (strs.Length == 5)
                            {
                                Square square = new Square(double.Parse(strs[1]), Convert.ToDouble(strs[2]), Convert.ToDouble(strs[3]),double.Parse(strs[4]));
                            }
                            else
                            {
                                Point sp1 = new Point(int.Parse(strs[1]), Convert.ToInt32(strs[2]));
                                Point sp2 = new Point(int.Parse(strs[3]), Convert.ToInt32(strs[4]));
                                Point sp3 = new Point(int.Parse(strs[5]), Convert.ToInt32(strs[6]));
                                Point sp4 = new Point(int.Parse(strs[7]), Convert.ToInt32(strs[8]));
                                figures.Add(new Square(sp1, sp2, sp3, sp4));
                            }
                            break;
                        case "Rectangle":
                            if (strs.Length == 5)
                            {
                                Rectangle square = new Rectangle(double.Parse(strs[1]), Convert.ToDouble(strs[2]), Convert.ToDouble(strs[3]), double.Parse(strs[4]));
                            }
                            else
                            {
                                Point sp1 = new Point(int.Parse(strs[1]), Convert.ToInt32(strs[2]));
                                Point sp2 = new Point(int.Parse(strs[3]), Convert.ToInt32(strs[4]));
                                Point sp3 = new Point(int.Parse(strs[5]), Convert.ToInt32(strs[6]));
                                Point sp4 = new Point(int.Parse(strs[7]), Convert.ToInt32(strs[8]));
                                figures.Add(new Rectangle(sp1, sp2, sp3, sp4));
                            }
                            break;
                    }
                }
            }
            return figures;
        }
    }
}
