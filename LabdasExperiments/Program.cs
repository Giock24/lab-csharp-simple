using System;
using System.Collections.Generic;

namespace LabdasExperiments
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> (new int[] { -10, 20, 30, 40 });
            var newList = Filter(list, new OnlyPositive());
            foreach (var elem in newList) Console.Write(elem+" ");
        }

        class OnlyPositive : IIntPredicate
        {
            public bool filter(int i) => i > 0;
        }

        interface IIntPredicate
        {
            bool filter(int i);
        }

        static IList<int> Filter(IList<int> list, IIntPredicate predicate)
        {
            var l = new List<int>();
            foreach (var t in list) if (predicate.filter(t)) l.Add(t);
            return l;
        }
    }
}
