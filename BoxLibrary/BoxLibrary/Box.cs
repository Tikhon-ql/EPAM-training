
using BoxLibrary.Enums;
using ColorsLibrary;
using FiguresLibrary.Abstract;
using FiguresLibrary.Models.FilmFigures;
using FiguresLibrary.Models.PaperFigures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BoxLibrary
{
    /// <summary>
    /// Класс коробки
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Максимальное количество фигур
        /// </summary>
        const int maxCount = 20;
        public Box(params Figure[] figs)
        {
            if (figs.Length <= 20)
            {
                int i = 0;
                for (i = 0; i < figs.Length; i++)
                    if(Search(figs[i]) == null)
                        figures.Add(i, figs[i]);
                Count = i;
            }
            else
                throw new Exception("В коробке нет места на такое количество фигур");
        }
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
        public bool AddFigure(Figure fig)
        {
            if (fig != null && Count != maxCount && Search(fig) == null)
            {
                figures.Add(Count, fig);
                Count++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Метод добавления фигуры
        /// </summary>
        /// <param name="fig">Фигура</param>
        /// <param name="index">Место добавления</param>
        /// <returns></returns>
        public bool AddFigure(Figure fig,int index)
        {
            if (fig != null && Search(fig) == null && !figures.ContainsKey(index))
            {
                figures.Add(index, fig);
                Count++;
                return true;
            }
            return false;
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
        /// Метод извлечения фигуры
        /// </summary>
        /// <param name="index">Индекс фигуры</param>
        /// <returns></returns>
        public Figure PopFigure(int index)
        {
            if (index < figures.Count)
            {
                Figure res = figures.FirstOrDefault(i => i.Key == index).Value;
                figures.Remove(index);
                Count--;
                return res;
            }
            else
                throw new IndexOutOfRangeException();
        }
        /// <summary>
        /// Метод замены фигуры
        /// </summary>
        /// <param name="index">Индекс заменяемой фигуры</param>
        /// <param name="fig">Фигура, на которую заменяют</param>
        public bool Replace(int index, Figure fig)
        {
            if (index < figures.Count)
            {
                Figure figure = figures.FirstOrDefault(f=>f.Key == index).Value;
                figures.Remove(index);
                Count--;
                //если не удалось добавить фигуру возвращаем предыдущую
                if (!AddFigure(fig, index))
                {
                     AddFigure(figure, index);
                }
                return true;
            }
            else
                throw new IndexOutOfRangeException();
        }
        /// <summary>
        /// Метод поиска фигуры
        /// </summary>
        /// <param name="fig">Шаблон фигуры</param>
        /// <returns></returns>
        public Figure Search(Figure fig)
        {
            if(fig is PaperFigure)
            {
                return figures.FirstOrDefault(f => f.Value.P() == fig.P() && f.Value.S() == fig.S() && ((PaperFigure)f.Value).Color == ((PaperFigure)fig).Color).Value;
            }
            else
            {
                return figures.FirstOrDefault(f => f.Value.P() == fig.P() && f.Value.S() == fig.S()).Value;
            }
           
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
            foreach (KeyValuePair<int, Figure> item in figures)
            {
                s += item.Value.S();
            }
            return Math.Round(s,2);
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
            return Math.Round(p, 2);
        }
        /// <summary>
        /// Метод получения опеределенно фигуры
        /// </summary>
        /// <param name="typename">Название типы получаемой фигуры</param>
        /// <returns></returns>
        public List<Figure> GetCircle()
        {
            try
            {
                List<Figure> res = new List<Figure>();
                foreach (KeyValuePair<int, Figure> item in figures)
                {
                    if (item.Value is PaperCircle || item.Value is FilmCircle)
                        res.Add(item.Value);
                }
                return res;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Метод получения пленочных фигуры 
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetFilmFigures()
        {
            return figures.Where(f => f.Value is FilmFigure).Select(f=>f.Value).ToList();
        }
        /// <summary>
        /// Метод сохраняющий все фигуры в xml файл
        /// </summary>
        /// <param name="filename">имя файла</param>
        /// <returns></returns>
        /// ////////////////////////////////////////////////////////////
        public bool SaveFiguresXmlWriter(string filename,SaveType saveType = SaveType.AllFigures)
        {
            try
            {
                if (filename == "" || filename == null)
                    throw new Exception();
                List<Figure> saveFigures = new List<Figure>();
                switch (saveType) 
                {
                    case SaveType.AllFigures:
                        {
                            saveFigures = figures.Values.ToList();
                            break;
                        }
                    case SaveType.FilmFigures:
                        {
                            saveFigures = GetFilmFigures();
                            break;
                        }
                    case SaveType.PaperFigures:
                        {
                            saveFigures = figures.Where(f => f.Value is PaperFigure).Select(f => f.Value).ToList();
                            break;
                        }
                }
                using (XmlWriter writer = XmlWriter.Create(filename))
                {
                    writer.WriteStartElement("Figures");
                    foreach (Figure item in saveFigures)
                    {
                        writer.WriteStartElement("Figure");
                        foreach (KeyValuePair<string, string> pair in item.AttributeXml())
                        {
                            writer.WriteAttributeString(pair.Key, pair.Value);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Метод получения фигур из xml файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
        /// ////////////////////////
        public bool LoadFiguresXmlReader(string filename)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(filename))
                {

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.GetAttribute("type"))
                            {
                                case "PaperCircle":
                                    {
                                        PaperCircle circle = new PaperCircle();
                                        circle.R = double.Parse(reader.GetAttribute("radius"));
                                        circle.Color = (Colors)Enum.Parse(typeof(Colors), reader.GetAttribute("color"));
                                        this.AddFigure(circle);
                                        break;
                                    }

                                case "PaperRectangle":
                                    {
                                        PaperRectangle rectangle = new PaperRectangle();
                                        rectangle.Width = double.Parse(reader.GetAttribute("width"));
                                        rectangle.Height = double.Parse(reader.GetAttribute("height"));
                                        rectangle.Color = (Colors)Enum.Parse(typeof(Colors), reader.GetAttribute("color"));
                                        this.AddFigure(rectangle);
                                        break;
                                    }

                                case "PaperTriangle":
                                    {
                                        PaperTriangle triangle = new PaperTriangle();
                                        triangle.FirstSide = double.Parse(reader.GetAttribute("first"));
                                        triangle.SecondSide = double.Parse(reader.GetAttribute("second"));
                                        triangle.ThirdSide = double.Parse(reader.GetAttribute("third"));
                                        triangle.Color = (Colors)Enum.Parse(typeof(Colors), reader.GetAttribute("color"));
                                        this.AddFigure(triangle);
                                        break;
                                    }

                                case "PaperSquare":
                                    {
                                        PaperSquare square = new PaperSquare();
                                        square.Side = double.Parse(reader.GetAttribute("side"));
                                        square.Color = (Colors)Enum.Parse(typeof(Colors), reader.GetAttribute("color"));
                                        this.AddFigure(square);
                                        break;
                                    }
                                case "FilmSquare":
                                    {
                                        FilmSquare square = new FilmSquare();
                                        square.Side = double.Parse(reader.GetAttribute("side"));
                                        this.AddFigure(square);
                                        break;
                                    }
                                case "FilmCircle":
                                    {
                                        FilmCircle circle = new FilmCircle();
                                        circle.R = double.Parse(reader.GetAttribute("radius"));
                                        this.AddFigure(circle);
                                        break;
                                    }
                                case "FilmRectangle":
                                    {
                                        FilmRectangle rectangle = new FilmRectangle();
                                        rectangle.Width = double.Parse(reader.GetAttribute("width"));
                                        rectangle.Height = double.Parse(reader.GetAttribute("height"));
                                        this.AddFigure(rectangle);
                                        break;
                                    }
                                case "FilmTriangle":
                                    {
                                        FilmTriangle triangle = new FilmTriangle();
                                        triangle.FirstSide = double.Parse(reader.GetAttribute("first"));
                                        triangle.SecondSide = double.Parse(reader.GetAttribute("second"));
                                        triangle.ThirdSide = double.Parse(reader.GetAttribute("third"));
                                        this.AddFigure(triangle);
                                        break;
                                    }
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Box box &&
                   Count == box.Count &&
                   Equals(figures, box.figures);
        }

        public override int GetHashCode()
        {
            int hashCode = -13909310;
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<int, Figure>>.Default.GetHashCode(figures);
            return hashCode;
        }
    }
}
