using CSharpTools.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.Helpers
{
    public class TypeNameEqualityComparer : IEqualityComparer<TypeName>
    {
        public bool Equals(TypeName x, TypeName y)
            => x.Name == y.Name
            && x.Namespace == y.Namespace;

        public int GetHashCode(TypeName obj)
        {
            throw new NotImplementedException();
        }
    }
}
