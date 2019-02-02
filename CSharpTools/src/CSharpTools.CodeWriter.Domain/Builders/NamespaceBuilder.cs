using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.CodeWriter.Domain.Builders
{
    public class NamespaceBuilder : IBuilder<NamespaceDeclarationSyntax, IEnumerable<Type>>
    {
        public NamespaceDeclarationSyntax Build(IEnumerable<Type> input)
        {
            throw new NotImplementedException();
        }
    }
}
