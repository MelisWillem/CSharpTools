using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace CSharpTools.CodeReader.Domain
{
    public class InterfaceBuilder : IBuilder<Interface, InterfaceDeclarationSyntax>
    {
        private readonly IBuilder<Interface.Property, PropertyDeclarationSyntax> propBuilder;

        public InterfaceBuilder(
            IBuilder<Interface.Property,PropertyDeclarationSyntax> propBuilder)
        {
            this.propBuilder = propBuilder;
        }

        public Interface Build(InterfaceDeclarationSyntax inter)
        {
            return new Interface
            {
                Properties = inter.Members
                    .OfType<PropertyDeclarationSyntax>()
                    .Select(p=> propBuilder
                    .Build(p))
                    .ToList()
            };
        }
    }
}
