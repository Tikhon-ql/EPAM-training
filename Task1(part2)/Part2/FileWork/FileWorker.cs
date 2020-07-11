using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Figures;
using Figures.Models;
using FileWork.FactoryMethod;

namespace FileWork
{
    public static class FileWorker
    {
        /// <summary>
        /// Метод получения данных из текстового файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public static List<Figure> ReadFromFile(string filename)
        {
            List<Figure> figures = new List<Figure>();

            TriangleCreator trCreator = new TriangleCreator();

            SquareCreator sqCreator = new SquareCreator();

            RectanlgeCreator rtCreator = new RectanlgeCreator();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string[] strs = reader.ReadLine().Split(';');
                    switch (strs[0])
                    {
                        case "Triangle":
                            figures.Add(trCreator.FigureCreate(strs));
                            break;
                        case "Square":
                            figures.Add(sqCreator.FigureCreate(strs));
                            break;
                        case "Rectangle":
                            figures.Add(rtCreator.FigureCreate(strs));
                            break;
                    }
                }
            }
            return figures;
        }
    }
}
