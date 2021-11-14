using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Common
{
    public class Map<T1, T2>
    {
        private Dictionary<T1, T2> _forward = new Dictionary<T1, T2>();
        private Dictionary<T2, T1> _backward = new Dictionary<T2, T1>();

        public void Add(T1 t1, T2 t2)
        {
            _forward.Add(t1, t2);
            _backward.Add(t2, t1);
        }

        public IReadOnlyDictionary<T1, T2> Forward =>  _forward;
        public IReadOnlyDictionary<T2, T1> Backward => _backward;
    }
}
