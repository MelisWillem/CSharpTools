using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools.Generic.Contracts
{
    public static class ExtensionIEnumerable
    {
        public static IEnumerable<T> GetValueOrEmpty<T>(this IEnumerable<T> list)
        {
            return list ?? Enumerable.Empty<T>();
        }
    }
}
