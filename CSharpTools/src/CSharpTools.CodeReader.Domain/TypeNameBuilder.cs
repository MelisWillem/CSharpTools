using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools.CodeReader.Domain
{
    class TypeNameBuilder : IBuilder<TypeName, TypeSyntax>
    {
        public TypeName Build(TypeSyntax typeNode)
            => new TypeName()
            {
                Name = typeNode.ToString().Split('.').Last()
            };
    }
}
