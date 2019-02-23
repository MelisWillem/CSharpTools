using CSharpTools.Entities;
using System.Collections.Generic;

namespace CSharpTools.Contracts
{
    public interface ICSharptools
    {
        IEnumerable<Type> ReadCode();

        void GenerateMockedBuilders(IEnumerable<Interface> interfaces);
    }
}
