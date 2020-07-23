using FiguresLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <summary>
        /// Метод замены фигуры
        /// </summary>
        /// <param name="index">Индекс заменяемой фигуры</param>
        /// <param name="fig">Фигура, на которую заменяют</param>
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
        /// <summary>
        /// Метод поиска фигуры
        /// </summary>
        /// <param name="fig">Шаблон фигуры</param>
        /// <returns></returns>
        public List<Figure> Searche(Figure fig)
        {
            return figures.Where(f => f.Equals(fig)).Select(f => f.Value).ToList();
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
        /// <summary>
        /// Метод получения фигуры определенного материала
        /// </summary>
        /// <param name="material">Если true - бумажный, если false - пленочный</param>
        /// <returns></returns>
        public List<Figure> GetExactFigureByMaterial(bool material)
        {
            List<Figure> res = new List<Figure>();
            foreach (KeyValuePair<int, Figure> item in figures)
            {
                if (material && item.Value is PaperFigure)
                    res.Add(item.Value);
                if(!material && item.Value is FilmFigure)
                    res.Add(item.Value);
            }
            return res;
        }
        /// <summary>
        /// Метод сохраняющий все фигуры в xml файл
        /// </summary>
        /// <param name="filename">имя файла</param>
        /// <returns></returns>
        public bool SaveFiguresXmlWriter(string filename)
        {
            try
            {
                if (filename == "" || filename.Split('.')[1] != "xml")
                    throw new Exception();
                using (XmlWriter writer = XmlWriter.Create(filename))
                {
                    writer.WriteStartElement("figures");
                    foreach (KeyValuePair<int, Figure> item in figures)
                    {
                        writer.WriteStartElement("figure");
                        foreach (KeyValuePair<string, string> pair in item.Value.AttributeXml())
                        {
                            writer.WriteAttributeString(pair.Key, pair.Value);
                        }
                        writer.WriteString(item.Value.XmlString());
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
        /// Метод сохраняющий фигуры из определенного материала в xml файл
        /// </summary>
        /// <param name="filename">имя файла</param>
        /// <param name="material">заданный материал</param>
        /// <returns></returns>
        //public bool SaveFiguresXmlWriter(string filename, Material material)
        //{
        //    try
        //    {
        //        using (XmlWriter writer = XmlWriter.Create(filename))
        //        {
        //            writer.WriteStartElement("figures");
        //            foreach (KeyValuePair<int, Figure> item in figures)
        //            {
        //                if (item.Value.Material == material)
        //                {
        //                    writer.WriteStartElement("figure");
        //                    foreach (KeyValuePair<string, string> pair in item.Value.AttributeXml())
        //                    {
        //                        writer.WriteAttributeString(pair.Key, pair.Value);
        //                    }
        //                    writer.WriteString(item.Value.XmlString());
        //                }
        //            }
        //            writer.WriteEndElement();
        //            writer.WriteEndDocument();
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        /// <summary>
        /// Метод получения фигур из xml файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
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
                            switch (reader.Value)
                            {
                                //case "Circle":
                                //    {
                                //        Circle circle = new Circle();
                                //        circle.R = double.Parse(reader.GetAttribute("radius"));
                                //        circle.Color = (Color)Enum.Parse(typeof(Color), reader.GetAttribute("color"));
                                //        circle.Material = (Material)Enum.Parse(typeof(Material), reader.GetAttribute("material"));
                                //        this.AddFigure(circle);
                                //        break;
                                //    }
                                  
                                //case "Rectangle":
                                //    {
                                //        Rectangle rectangle = new Rectangle();
                                //        rectangle.Width = double.Parse(reader.GetAttribute("width"));
                                //        rectangle.Height = double.Parse(reader.GetAttribute("height"));
                                //        rectangle.Color = (Color)Enum.Parse(typeof(Color), reader.GetAttribute("color"));
                                //        this.AddFigure(rectangle);
                                //        break;
                                //    }
                                   
                                //case "Triangle":
                                //    {
                                //        Triangle triangle = new Triangle();
                                //        triangle.FirstSide = double.Parse(reader.GetAttribute("first"));
                                //        triangle.SecondSide = double.Parse(reader.GetAttribute("second"));
                                //        triangle.ThirdSide = double.Parse(reader.GetAttribute("third"));
                                //        triangle.Color = (Color)Enum.Parse(typeof(Color), reader.GetAttribute("color"));
                                //        this.AddFigure(triangle);
                                //        break;
                                //    }
                                   
                                //case "Square":
                                //    {
                                //        Square square = new Square();
                                //        square.Side = double.Parse(reader.GetAttribute("side"));
                                //        square.Color = (Color)Enum.Parse(typeof(Color), reader.GetAttribute("color"));
                                //        this.AddFigure(square);
                                //        break;
                                //    }
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
                   EqualityComparer<Dictionary<int, Figure>>.Default.Equals(figures, box.figures);
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
