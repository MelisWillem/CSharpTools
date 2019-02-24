using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.Generic.Contracts
{
    public interface IBuilder<Tout,Tin1,Tin2>
    {
        Tout Build(Tin1 input1, Tin2 input2);
    }
}
