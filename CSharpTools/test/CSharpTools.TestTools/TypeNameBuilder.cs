using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools.TestTools
{
    public class TypeNameBuilder : IBuilder<TypeName>
    {
        private TypeName typeName = new TypeName();

        public TypeName Build()
        {
            return typeName;
        }

        public TypeNameBuilder WithName(string name)
        {
            typeName.Name = name;

            return this;
        }

        public TypeNameBuilder WithNamespace(params string[] names)
        {
            typeName.Namespace = names.ToList();

            return this;
        }
    }
}
