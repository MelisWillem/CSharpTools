using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTools.Helpers
{
    public class TypeNameEqualityComparer : IEqualityComparer<TypeName>
    {
        public bool Equals(TypeName x, TypeName y)
            => x.Name == y.Name
            && x.Namespace.GetValueOrEmpty().SequenceEqual(y.Namespace.GetValueOrEmpty()) ; 

        public int GetHashCode(TypeName obj)
        {
            throw new NotImplementedException();
        }
    }
}
