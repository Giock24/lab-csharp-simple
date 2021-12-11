using System;
using System.Collections.Generic;

namespace LabdasExperiments
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> (new int[] { -10, 20, 30, 40 });
            var newList = Filter(list, i => i > 0 );
            foreach (var elem in newList) Console.Write(elem+" ");
        }

        static IList<int> Filter(IList<int> list, Predicate<int> predicate)
        {
            var l = new List<int>();
            foreach (var t in list) if (predicate(t)) l.Add(t);
            return l;
        }
    }
}
