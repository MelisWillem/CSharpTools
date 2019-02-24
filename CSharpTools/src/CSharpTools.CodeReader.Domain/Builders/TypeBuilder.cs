using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.CodeReader.Domain.Builders
{
    public class TypeBuilder : IBuilder<TypeName, TypeSyntax>
    {
        public TypeName Build(TypeSyntax input)
        {
            return new TypeName
            {
                Name = GetName(input),
                Namespace=null
            };
        }

        public string GetName(TypeSyntax type)
        {
            switch (type)
            {
                case QualifiedNameSyntax syntax:
                    return this.Build(syntax.Right).Name;
                case SimpleNameSyntax syntax:
                    return syntax.Identifier.Text;
                case PredefinedTypeSyntax preSyn:
                    return preSyn.Keyword.Text;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
