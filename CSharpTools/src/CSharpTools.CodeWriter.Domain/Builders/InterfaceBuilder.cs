using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.CodeWriter.Domain.Builders
{
    public class InterfaceBuilder : IBuilder<NamespaceDeclarationSyntax, Interface>
    {
        public NamespaceDeclarationSyntax Build(Interface @interface)
        {
            throw new NotImplementedException();
        }
    }
}
