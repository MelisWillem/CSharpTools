using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.Generic.Contracts
{
    public interface IBuilder<Tout,Tin>
    {
        Tout Build(Tin input);
    }
}
