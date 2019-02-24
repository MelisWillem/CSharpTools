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
        private readonly IBuilder<List<string>, NamespaceDeclarationSyntax> namespaceBuilder;
        private readonly IBuilder<Interface, List<string>, InterfaceDeclarationSyntax> interfaceBuilder;

        public NamespaceTypeGenerator(
            IBuilder<List<string>, NamespaceDeclarationSyntax> namespaceBuilder,
            IBuilder<Interface,List<string>,InterfaceDeclarationSyntax> interfaceBuilder)
        {
            this.namespaceBuilder = namespaceBuilder;
            this.interfaceBuilder = interfaceBuilder;
        }

        public IEnumerable<Type> Generate(NamespaceDeclarationSyntax @namespace)
        {
            var namespaceName = namespaceBuilder.Build(@namespace);

            return @namespace
                .Members
                .Select(m =>
                {
                    switch (m)
                    {
                        case InterfaceDeclarationSyntax interfaceNode:
                            return (Type) interfaceBuilder
                                .Build(namespaceName.ToList(), interfaceNode);
                        default:
                            throw new NotImplementedException();
                    }
                });
        }
    }
}
