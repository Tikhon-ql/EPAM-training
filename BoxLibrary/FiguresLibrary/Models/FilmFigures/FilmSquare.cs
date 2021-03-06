﻿using FiguresLibrary.Abstract;
using FiguresLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Models.FilmFigures
{
    public class FilmSquare:FilmFigure
    {
        public FilmSquare(double s)
        {
            Side = s;
        }
        public FilmSquare()
        {

        }
        public FilmSquare(FilmFigure figure,double s)
        {
            Side = s;
            if(this.S() > figure.S())
                throw new CannotCutableException("Невозможно вырезать фигуру");
        }
        // side of square
        public double Side { get; set; } = 0;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return -1545931474 + Side.GetHashCode();
        }

        public override double P()
        {
            return Side * 4;
        }
        public override double S()
        {

            return Side * Side;
        }
        public override string ToString()
        {
            return "FilmSquare;" + Side;
        }
        public override Dictionary<string, string> AttributeXml()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("side", Side.ToString());
            dictionary.Add("type", "FilmSquare");
            return dictionary;
        }
    }
}
