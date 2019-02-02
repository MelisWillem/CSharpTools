using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools.Helpers
{
    public class InterfaceEqualityComparer : IEqualityComparer<Interface>
    {
        private readonly IEqualityComparer<TypeName> nameComparer;
        private readonly IEqualityComparer<Interface.Property> propComparer;

        public InterfaceEqualityComparer(
             IEqualityComparer<TypeName> nameComparer ,
             IEqualityComparer<Interface.Property> propComparer )
        {
            this.nameComparer = nameComparer;
            this.propComparer = propComparer;
        }

        public bool Equals(Interface x, Interface y)
            => nameComparer.Equals(x.Name,y.Name)
            && x.Properties
                .GetValueOrEmpty()
                .OrderBy(p=>p.Name)
                .SequenceEqual(y.Properties
                    .GetValueOrEmpty()
                    .OrderBy(p=>p.Name),
                propComparer);

        public int GetHashCode(Interface obj)
        {
            throw new NotImplementedException();
        }
    }
}
