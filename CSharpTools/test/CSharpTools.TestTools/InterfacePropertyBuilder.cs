using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.TestTools
{
    public class InterfacePropertyBuilder : IBuilder<Interface.Property>
    {
        private Interface.Property property = new Interface.Property();

        public Interface.Property Build()
        {
            return property;
        }

        public InterfacePropertyBuilder WithName(string name)
        {
            property.Name = name;

            return this;
        }
        public InterfacePropertyBuilder WithType(TypeName type)
        {
            property.Type = type;

            return this;
        }
    }
}
