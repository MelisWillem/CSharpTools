using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools.CodeReader.Domain
{
    public class SyntaxTokenTypeNameBuilder : IBuilder<TypeName, SyntaxToken>
    {
        public TypeName Build(SyntaxToken token)
        {
            return new TypeName
            {
                Name = token.ValueText,
                Namespace = GetNameSpace(token)
            };
        }

        private List<string> GetNameSpace(SyntaxToken token)
        {
            switch (token.Parent.Parent)
            {
                case NamespaceDeclarationSyntax @namespace:
                    return @namespace.Name.ToString().Split('.').ToList();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
