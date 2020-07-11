﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Models
{
    public class Square : Figure
    {
        public Square(double s)
        {
            Side = s;
        }
        public double Side { get; set; } = 0;

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
            return "Square;" + Side;
        }
    }
}
