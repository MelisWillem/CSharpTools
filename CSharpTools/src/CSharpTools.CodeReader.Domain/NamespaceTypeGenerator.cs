using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = CSharpTools.Entities.Type;

namespace CSharpTools.CodeReader.Domain
{
    public class NamespaceTypeGenerator : IGenerator<Type, NamespaceDeclarationSyntax>
    {
        private readonly IBuilder<Interface, InterfaceDeclarationSyntax> interfaceBuilder;

        public NamespaceTypeGenerator(
            IBuilder<Interface,InterfaceDeclarationSyntax> interfaceBuilder)
        {
            this.interfaceBuilder = interfaceBuilder;
        }

        public IEnumerable<Type> Generate(NamespaceDeclarationSyntax input)
        {
            return input
                .Members
                .Select(m =>
                {
                    switch (m)
                    {
                        case InterfaceDeclarationSyntax interfaceNode:
                            return (Type) interfaceBuilder
                                .Build(interfaceNode);
                        default:
                            throw new NotImplementedException();
                    }
                });
        }
    }
}
