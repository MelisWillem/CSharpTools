using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools.CodeReader.Domain.Builders
{
    public class TypeNameBuilder : IBuilder<TypeName, TypeSyntax>
    {
        public TypeName Build(TypeSyntax typeNode)
            => new TypeName()
            {
                Name = typeNode.ToString(),
                Namespace=GetNameSpace(typeNode)
            };

        private List<string> GetNameSpace(TypeSyntax token)
        {
            switch (token)
            {
                case PredefinedTypeSyntax type:
                    return null;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
