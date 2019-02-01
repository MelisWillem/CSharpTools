using CSharpTools.Entities;
using System.Collections.Generic;

namespace CSharpTools.Helpers
{
    public static class EqualityComparerFactory
    {
        public static IEqualityComparer<TypeName> CreateTypeNameEqualityComparer()
            => new TypeNameEqualityComparer();

        public static IEqualityComparer<Interface.Property> CreateInterfacePropertyEqualityComparer()
            => new InterfacePropertyEqualityComparer(CreateTypeNameEqualityComparer());

        public static IEqualityComparer<Interface> CreateInterfaceEqualityComparer()
            => new InterfaceEqualityComparer(
                CreateTypeNameEqualityComparer(),
                CreateInterfacePropertyEqualityComparer());
    }
}
