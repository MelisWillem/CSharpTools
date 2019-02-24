using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpTools.CodeReader.Domain.Builders
{
    public class InterfacePropertyBuilder : IBuilder<Interface.Property, PropertyDeclarationSyntax>
    {
        private readonly IBuilder<TypeName, TypeSyntax> typeBuilder;

        public InterfacePropertyBuilder(
            IBuilder<TypeName, TypeSyntax> typeBuilder)
        {
            this.typeBuilder = typeBuilder;
        }

        public Interface.Property Build(PropertyDeclarationSyntax propertyNode)
        {
            return new Interface.Property
            {
                Name=propertyNode.Identifier.ValueText,
                Type= typeBuilder.Build(propertyNode.Type)
            };
        }
    }
}
