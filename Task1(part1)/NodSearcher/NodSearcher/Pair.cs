using System;
using System.Collections.Generic;
using System.Text;

namespace NodSearcher
{
    public class Pair<T1, T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }

        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }
        public override string ToString()
        {
            return First + " " + Second;
        }
    }
}
