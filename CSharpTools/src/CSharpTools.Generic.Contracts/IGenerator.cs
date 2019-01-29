using System.Collections.Generic;

namespace CSharpTools.Generic.Contracts
{
    public interface IGenerator<Tout,Tin>
    {
        IEnumerable<Tout> Generate(Tin input);
    }
}
