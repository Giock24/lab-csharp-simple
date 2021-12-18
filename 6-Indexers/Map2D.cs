namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {

        //private TValue[][] _values; //= new TValue[3][];
        //private int _size;
        private readonly Dictionary<Tuple<TKey1, TKey2>, TValue> _elem2D = new Dictionary<Tuple<TKey1, TKey2>, TValue>();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements
        {
            get => _elem2D.Count;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {

            get { return _elem2D[Tuple.Create(key1, key2)]; }
            set { _elem2D.Add(Tuple.Create(key1, key2), value); }
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            IList<Tuple<TKey2, TValue>> row = new List<Tuple<TKey2, TValue>>();
            foreach (var elem in _elem2D)
            {
                if (key1.Equals(elem.Key.Item1))
                {
                    row.Add(Tuple.Create(elem.Key.Item2, elem.Value));
                }
            }

            return row;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            /* vers. Prof */
            return _elem2D.Keys
                .Where(tuple => tuple.Item2.Equals(key2))
                .Select(tuple => Tuple.Create(tuple.Item1, _elem2D[tuple]))
                .ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            IList<Tuple<TKey1, TKey2, TValue>> myList = new List<Tuple<TKey1, TKey2, TValue>>();
            foreach (var elem in _elem2D)
            {
                myList.Add(Tuple.Create(elem.Key.Item1, elem.Key.Item2, elem.Value));
            }
            //return myList;

            return _elem2D.Keys
                .Select(tuple => Tuple.Create(tuple.Item1, tuple.Item2, _elem2D[tuple]))
                .ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            foreach (var k1 in keys1)
            {
                foreach (var k2 in keys2)
                {
                    _elem2D.Add(Tuple.Create(k1, k2), generator(k1, k2));
                }
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            return Equals(this, other);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (this == obj)
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return this.Equals(obj as IMap2D<TKey1, TKey2, TValue>);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return this != null ? GetHashCode() : 0;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            return _elem2D.ToString();
        }
    }
}
