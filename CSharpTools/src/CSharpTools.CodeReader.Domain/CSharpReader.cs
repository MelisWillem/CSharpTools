using CSharpTools.CodeReader.Contracts;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = CSharpTools.Entities.Type;

namespace CSharpTools.CodeReader.Domain
{
    public class CSharpReader
    {
        private readonly ISourceFileReader reader;
        private readonly IGenerator<Type, NamespaceDeclarationSyntax> namespaceGenerator;

        public CSharpReader(
            ISourceFileReader reader,
            IGenerator<Type, NamespaceDeclarationSyntax> namespaceGenerator)
        {
            this.reader = reader;
            this.namespaceGenerator = namespaceGenerator;
        }

        public IEnumerable<Type> Read()
        {
            var root = (CompilationUnitSyntax) CSharpSyntaxTree
                .ParseText(reader.Read())
                .GetRoot();

            switch (root.Members.First())
            {
                case NamespaceDeclarationSyntax namespaceNode:
                    return namespaceGenerator.Generate(namespaceNode);
                default:
                    break;
            }

            return Enumerable.Empty<Type>();
        }
    }
}
