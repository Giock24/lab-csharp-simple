using System;
using System.Collections.Generic;

namespace LabdasExperiments
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> (new int[] { 10, 20, 30, 40 });
            var newList = Filter(list);
            foreach (var elem in newList) Console.Write(elem+" ");
        }

        static IList<int> Filter(IList<int> list)
        {
            var l = new List<int>();
            foreach (var t in list) if (t > 0) l.Add(t);
            return l;
        }
    }
}
