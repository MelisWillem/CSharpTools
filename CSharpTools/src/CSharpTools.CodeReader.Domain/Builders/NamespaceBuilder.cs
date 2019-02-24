using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools.CodeReader.Domain.Builders
{
    public class NamespaceBuilder : IBuilder<List<string>, NamespaceDeclarationSyntax>
    {
        public List<string> Build(NamespaceDeclarationSyntax input)
            => input.Name.ToString().Split('.').ToList();
    }
}
