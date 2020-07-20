using BoxLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BoxLibrary.Box
{
    public class Box
    {
        /// <summary>
        /// Максимальное количество фигур
        /// </summary>
        const int maxCount = 20;
        /// <summary>
        /// Текущее количество фигур
        /// </summary>
        public int Count { get; set; } = 0;
        /// <summary>
        /// список фигур
        /// </summary>
        Dictionary<int, Figure> figures = new Dictionary<int, Figure>();
        /// <summary>
        /// Метод добавления фигуры
        /// </summary>
        /// <param name="fig">Фигура</param>
        public void AddFigure(Figure fig)
        {
            if (fig != null && Count != maxCount && Searche(fig).Count == 0)
            {
                figures.Add(Count, fig);
                Count++;
            }
        }
        /// <summary>
        /// Метод просмотра фигуры
        /// </summary>
        /// <param name="index">Индекс фигуры</param>
        /// <returns></returns>
        public Figure SeeFigure(int index)
        {
            if (index < figures.Count)
                return figures.FirstOrDefault(i => i.Key == index).Value;
            else
                throw new IndexOutOfRangeException();
        }
        /// <summary>
        /// Метод получения фигуры
        /// </summary>
        /// <param name="index">Индекс фигуры</param>
        /// <returns></returns>
        public Figure GetFigure(int index)
        {
            if (index < figures.Count)
            {
                Figure res = figures.FirstOrDefault(i => i.Key == index).Value;
                figures.Remove(index);
                return res;
            }
            else
                throw new IndexOutOfRangeException();
        }
        public void Replace(int index, Figure fig)
        {
            if (index < figures.Count)
            {
                figures.Remove(index);
                AddFigure(fig);
            }
            else
                throw new IndexOutOfRangeException();
        }
        public List<Figure> Searche(Figure fig)
        {
            return figures.Where(f => f.Equals(fig)).Select(f=>f.Value).ToList();
        }
        /// <summary>
        /// Метод получения(просмотра) всех фигур
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetCurrentFigures()
        {
            return figures.Select(f => f.Value).ToList();
        }
        /// <summary>
        /// Метод получения суммарной площади 
        /// </summary>
        /// <returns></returns>
        public double GetSumS()
        {
            double s = 0;
            foreach (KeyValuePair<int,Figure> item in figures)
            {
                s += item.Value.S();
            }
            return s;
        }
        /// <summary>
        /// Метод получения суммарого периметра
        /// </summary>
        /// <returns></returns>
        public double GetSumP()
        {
            double p = 0;
            foreach (KeyValuePair<int, Figure> item in figures)
            {
                p += item.Value.P();
            }
            return p;
        }
        /// <summary>
        /// Метод получения опеределенно фигуры
        /// </summary>
        /// <param name="typename">Название типы получаемой фигуры</param>
        /// <returns></returns>
        public List<Figure> GetExactrFugire(string typename)
        {
            List<Figure> res = new List<Figure>();
            foreach (KeyValuePair<int, Figure> item in figures)
            {
                if (item.GetType().Name == typename)
                    res.Add(item.Value);
            }
            return res;
        }
        public List<Figure> GetExactFigureByMaterial(Material material)
        {
            List<Figure> res = new List<Figure>();
            foreach (KeyValuePair<int, Figure> item in figures)
            {
                if (item.Value.Material == material)
                    res.Add(item.Value);
            }
            return res;
        }
    }
}
