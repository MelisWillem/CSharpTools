using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.TestTools
{
    public class InterfaceBuilder : IBuilder<Interface>
    {
        private Interface interf = new Interface();

        public InterfaceBuilder WithName(TypeName Name)
        {
            interf.Name = Name;

            return this;
        }

        public InterfaceBuilder WithProperties(params Interface.Property[] properties)
        {
            interf.Properties= interf.Properties ?? new List<Interface.Property>();
            interf.Properties.AddRange(properties);

            return this;
        }

        public Interface Build()
        {
            return interf;
        }
    }
}
