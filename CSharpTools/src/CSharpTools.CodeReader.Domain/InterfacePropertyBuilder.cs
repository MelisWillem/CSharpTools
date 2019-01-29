using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpTools.CodeReader.Domain
{
    public class InterfacePropertyBuilder : IBuilder<Interface.Property, PropertyDeclarationSyntax>
    {
        public Interface.Property Build(PropertyDeclarationSyntax input)
        {
            return new Interface.Property
            {
            };
        }
    }
}
