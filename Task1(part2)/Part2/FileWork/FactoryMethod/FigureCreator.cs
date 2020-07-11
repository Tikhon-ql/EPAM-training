using Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork.FactoryMethod
{
    //Интерфейс для реализации создания фигуры
    interface FigureCreator
    {
       Figure FigureCreate(string[] str);
    }
}
