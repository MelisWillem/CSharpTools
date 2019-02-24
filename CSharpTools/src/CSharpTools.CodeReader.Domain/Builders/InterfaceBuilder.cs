using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTools.CodeReader.Domain.Builders
{
    public class InterfaceBuilder : IBuilder<Interface,List<string> ,InterfaceDeclarationSyntax>
    {
        private readonly IBuilder<Interface.Property, PropertyDeclarationSyntax> propBuilder;

        public InterfaceBuilder(IBuilder<Interface.Property,PropertyDeclarationSyntax> propBuilder)
        {
            this.propBuilder = propBuilder;
        }

        public Interface Build(List<string> @namespace, InterfaceDeclarationSyntax inter)
        {
            return new Interface
            {
                Name = new TypeName
                {
                    Namespace =@namespace,
                    Name = inter.Identifier.Text.Split('.').Last()
                },
                Properties = inter.Members
                    .OfType<PropertyDeclarationSyntax>()
                    .Select(p=> propBuilder
                    .Build(p))
                    .ToList()
            };
        }
    }
}
