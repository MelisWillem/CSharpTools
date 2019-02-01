using CSharpTools.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.Helpers
{
    public class InterfacePropertyEqualityComparer : IEqualityComparer<Interface.Property>
    {
        private readonly IEqualityComparer<TypeName> typeNameComparer;

        public InterfacePropertyEqualityComparer(
            IEqualityComparer<TypeName> typeNameComparer)
        {
            this.typeNameComparer = typeNameComparer;
        }

        public bool Equals(Interface.Property x, Interface.Property y)
            => x.Name == y.Name
            && typeNameComparer.Equals(x.Type, y.Type);

        public int GetHashCode(Interface.Property obj)
        {
            throw new NotImplementedException();
        }
    }
}
