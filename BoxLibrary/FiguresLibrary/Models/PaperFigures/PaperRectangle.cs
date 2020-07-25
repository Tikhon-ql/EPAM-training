﻿using ColorsLibrary;
using FiguresLibrary.Abstract;
using FiguresLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Models.PaperFigures
{
    public class PaperRectangle:PaperFigure
    {
        public PaperRectangle(double h, double w,Colors color) : base(color)
        {
            Height = h;
            Width = w;
        }
        public PaperRectangle(double h, double w) : base()
        {
            Height = h;
            Width = w;
        }
        public PaperRectangle(PaperFigure figure,double widht,double height)
        {
            Width = widht;
            Height = height;
            Color = figure.Color;
            if(S() > figure.S())
                throw new CannotCutableException("Невозможно вырезать фигуру");
        }
        public PaperRectangle() : base()
        {

        }
        // длинна квадрата
        public double Height { get; set; } = 0;
        // ширина квадрата
        public double Width { get; set; } = 0;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            int hashCode = 168294001;
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            return hashCode;
        }

        public override double P()
        {

            return (Width + Height) * 2;
        }

        public override double S()
        {
            return Height * Width;
        }
        public override string ToString()
        {
            return "PaperRectangle;" + Height + ";" + Width;
        }
        public override Dictionary<string, string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("width", Width.ToString());
            dictionary.Add("height", Height.ToString());
            dictionary.Add("color", Color.ToString());
            dictionary.Add("type", "PaperRectangle");
            return dictionary;
        }
    }
}
