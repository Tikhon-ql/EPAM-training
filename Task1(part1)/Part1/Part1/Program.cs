using System;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(СalculationNOD.EvclideNod(9,6));
            Console.WriteLine(СalculationNOD.EvclideNod(18,9,6));
            Console.WriteLine(СalculationNOD.EvclideNod(18,6,9,27));
            Console.WriteLine(СalculationNOD.EvclideNod(15,20,150,50,125));
            long time = 0;
            Console.WriteLine(СalculationNOD.SteinNod(8,56,out time));
        }
    }
}
