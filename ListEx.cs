using System;
using System.Collections.Generic;
using System.Linq;

namespace Absolutly
{

    public static class ListEx
    {
        public static void AddRange<T>(this List<T> list, IEnumerable<T> elements, Func<T, bool> filter)
        {
            list.AddRange(elements.Where<T>(filter));
        }
    }
}

