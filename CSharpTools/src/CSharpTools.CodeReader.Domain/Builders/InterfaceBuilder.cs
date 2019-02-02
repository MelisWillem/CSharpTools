using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace CSharpTools.CodeReader.Domain.Builders
{
    public class InterfaceBuilder : IBuilder<Interface, InterfaceDeclarationSyntax>
    {
        private readonly IBuilder<TypeName, SyntaxToken> nameBuilder;
        private readonly IBuilder<Interface.Property, PropertyDeclarationSyntax> propBuilder;

        public InterfaceBuilder(
            IBuilder<TypeName, SyntaxToken> nameBuilder,
            IBuilder<Interface.Property,PropertyDeclarationSyntax> propBuilder)
        {
            this.nameBuilder = nameBuilder;
            this.propBuilder = propBuilder;
        }

        public Interface Build(InterfaceDeclarationSyntax inter)
        {
            return new Interface
            {
                Name = nameBuilder.Build(inter.Identifier),
                Properties = inter.Members
                    .OfType<PropertyDeclarationSyntax>()
                    .Select(p=> propBuilder
                    .Build(p))
                    .ToList()
            };
        }
    }
}
