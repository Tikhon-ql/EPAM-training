
using BoxLibrary.Enums;
using ColorsLibrary;
using FiguresLibrary.Abstract;
using FiguresLibrary.Models.FilmFigures;
using FiguresLibrary.Models.PaperFigures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BoxLibrary
{
    /// <summary>
    /// Box's class
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Maximum number of figures
        /// </summary>
        const int maxCount = 20;
        public Box(params Figure[] figs)
        {
            if (figs.Length <= 20)
            {
                int i = 0;
                for (i = 0; i < figs.Length; i++)
                    if (Search(figs[i]) == null)
                        figures.Add(i, figs[i]);
                Count = i;
            }
            else
                throw new Exception("В коробке нет места на такое количество фигур");
        }
        /// <summary>
        /// Current number of figures
        /// </summary>  
        public int Count { get; set; } = 0;
        /// <summary>
        /// Figures's list
        /// </summary>
        Dictionary<int, Figure> figures = new Dictionary<int, Figure>();
        /// <summary>
        /// Add method
        /// </summary>
        /// <param name="fig">Figure</param>
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
        /// Add method on exact place
        /// </summary>
        /// <param name="fig">Figure</param>
        /// <param name="index">Exact place</param>
        /// <returns></returns>
        public bool AddFigure(Figure fig, int index)
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
        /// Figure view
        /// </summary>
        /// <param name="index">Figures's index</param>
        /// <returns></returns>
        public Figure SeeFigure(int index)
        {
            if (index < figures.Count)
                return figures.FirstOrDefault(i => i.Key == index).Value;
            else
                throw new IndexOutOfRangeException();
        }
        /// <summary>
        /// Figure pop method
        /// </summary>
        /// <param name="index">Figures's index</param>
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
        /// Figure replace method
        /// </summary>
        /// <param name="index">Index of the figure to replace/param>
        /// <param name="fig">Figure to replace</param>
        public bool Replace(int index, Figure fig)
        {
            if (index < figures.Count)
            {
                Figure figure = figures.FirstOrDefault(f => f.Key == index).Value;
                figures.Remove(index);
                Count--;
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
        /// Figure search method
        /// </summary>
        /// <param name="fig">Figures's template</param>
        /// <returns></returns>
        public Figure Search(Figure fig)
        {
            if (fig is PaperFigure)
            {
                return figures.FirstOrDefault(f => f.Value.P() == fig.P() && f.Value.S() == fig.S() && ((PaperFigure)f.Value).Color == ((PaperFigure)fig).Color).Value;
            }
            else
            {
                return figures.FirstOrDefault(f => f.Value.P() == fig.P() && f.Value.S() == fig.S()).Value;
            }

        }
        /// <summary>
        /// All figures view method
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetCurrentFigures()
        {
            return figures.Select(f => f.Value).ToList();
        }
        /// <summary>
        /// Get sum squares
        /// </summary>
        /// <returns></returns>
        public double GetSumS()
        {
            double s = 0;
            foreach (KeyValuePair<int, Figure> item in figures)
            {
                s += item.Value.S();
            }
            return Math.Round(s, 2);
        }
        /// <summary>
        /// Get sum perimetrs
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
        /// Get circles
        /// </summary>
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get film figures
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetFilmFigures()
        {
            return figures.Where(f => f.Value is FilmFigure).Select(f => f.Value).ToList();
        }
        /// <summary>
        /// Save all figures in xml file through XmlWriter
        /// </summary>
        /// <param name="filename">File's name</param>
        /// <param name="saveType">Save type</param>
        /// <returns></returns>
        public bool SaveFiguresXmlWriter(string filename, SaveType saveType = SaveType.AllFigures)
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
        /// Figures load in xml file method through XmlReader
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
        public bool LoadFiguresXmlReader(string filename)
        {
            try
            {
                if (filename == "" || filename == null)
                    throw new Exception();
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
        /// <summary>
        /// Figures load in xml file method through StreamReader
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
        public bool LoadFiguresStreamReader(string filename)
        {
            try
            {
                if (filename == "" || filename == null)
                    throw new Exception();
                using (StreamReader reader = new StreamReader(filename))
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(reader);
                    XmlNodeList nodeList = document.GetElementsByTagName("Figure");
                    foreach (XmlNode item in nodeList)
                    {
                        switch (item.Attributes["type"].Value)
                        {
                            case "PaperCircle":
                                {
                                    PaperCircle circle = new PaperCircle();
                                    circle.R = double.Parse(item.Attributes["radius"].Value);
                                    circle.Color = (Colors)Enum.Parse(typeof(Colors), item.Attributes["color"].Value);
                                    this.AddFigure(circle);
                                    break;
                                }

                            case "PaperRectangle":
                                {
                                    PaperRectangle rectangle = new PaperRectangle();
                                    rectangle.Width = double.Parse(item.Attributes["width"].Value);
                                    rectangle.Height = double.Parse(item.Attributes["height"].Value);
                                    rectangle.Color = (Colors)Enum.Parse(typeof(Colors), item.Attributes["color"].Value);
                                    this.AddFigure(rectangle);
                                    break;
                                }

                            case "PaperTriangle":
                                {
                                    PaperTriangle triangle = new PaperTriangle();
                                    triangle.FirstSide = double.Parse(item.Attributes["first"].Value);
                                    triangle.SecondSide = double.Parse(item.Attributes["second"].Value);
                                    triangle.ThirdSide = double.Parse(item.Attributes["third"].Value);
                                    triangle.Color = (Colors)Enum.Parse(typeof(Colors), item.Attributes["color"].Value);
                                    this.AddFigure(triangle);
                                    break;
                                }

                            case "PaperSquare":
                                {
                                    PaperSquare square = new PaperSquare();
                                    square.Side = double.Parse(item.Attributes["side"].Value);
                                    square.Color = (Colors)Enum.Parse(typeof(Colors), item.Attributes["color"].Value);
                                    this.AddFigure(square);
                                    break;
                                }
                            case "FilmSquare":
                                {
                                    FilmSquare square = new FilmSquare();
                                    square.Side = double.Parse(item.Attributes["side"].Value);
                                    this.AddFigure(square);
                                    break;
                                }
                            case "FilmCircle":
                                {
                                    FilmCircle circle = new FilmCircle();
                                    circle.R = double.Parse(item.Attributes["radius"].Value);
                                    this.AddFigure(circle);
                                    break;
                                }
                            case "FilmRectangle":
                                {
                                    FilmRectangle rectangle = new FilmRectangle();
                                    rectangle.Width = double.Parse(item.Attributes["width"].Value);
                                    rectangle.Height = double.Parse(item.Attributes["height"].Value);
                                    this.AddFigure(rectangle);
                                    break;
                                }
                            case "FilmTriangle":
                                {
                                    FilmTriangle triangle = new FilmTriangle();
                                    triangle.FirstSide = double.Parse(item.Attributes["first"].Value);
                                    triangle.SecondSide = double.Parse(item.Attributes["second"].Value);
                                    triangle.ThirdSide = double.Parse(item.Attributes["third"].Value);
                                    this.AddFigure(triangle);
                                    break;
                                }
                        }
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Save all figures in xml file through StreamWriter
        /// </summary>
        /// <param name="filename">File's name</param>
        /// <param name="saveType">Save type</param>
        /// <returns></returns>
        public bool SaveFiguresStreamWriter(string filename, SaveType saveType = SaveType.AllFigures)
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
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    string xml = "<?xml version =\"1.0\" encoding=\"utf-8\" ?><Figures>";
                    foreach (Figure item in saveFigures)
                    {
                        xml += "<Figure ";
                        foreach (KeyValuePair<string, string> pair in item.AttributeXml())
                        {
                            xml += pair.Key + "=" + "\"" + pair.Value + "\" ";
                        }
                        xml += "/>";
                    }
                    xml += "</Figures>";
                    xml.Trim();
                    writer.WriteLine(xml);
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
