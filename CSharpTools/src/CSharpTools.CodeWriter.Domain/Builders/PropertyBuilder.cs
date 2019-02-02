using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.CodeWriter.Domain.Builders
{
    public class PropertyBuilder : IBuilder<PropertyDeclarationSyntax, Interface.Property>
    {
        public PropertyDeclarationSyntax Build(Interface.Property property)
        {
            throw new NotImplementedException();
        }
    }
}
