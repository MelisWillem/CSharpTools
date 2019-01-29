using CSharpTools.CodeReader.Contracts;
using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using Type = CSharpTools.Entities.Type;

namespace CSharpTools.CodeReader.Domain
{
    public static class CodeReaderFactory
    {
        public static CSharpReader CreateCSharpReaderSingleFile(string path)
        {
            return CreateCSharpReader(new SingleSourceFileReader(path));
        }

        public static CSharpReader CreateCSharpReader(ISourceFileReader reader)
        {
            return new CSharpReader(
                reader,
                CreateNamespaceTypeGenerator());
        }

        public static IGenerator<Type, NamespaceDeclarationSyntax> CreateNamespaceTypeGenerator()
        {
            return new NamespaceTypeGenerator(CreateInterfaceBuilder());
        }

        public static IBuilder<Interface.Property,PropertyDeclarationSyntax> CreateInterfacePropertyBuilder()
        {
            return new InterfacePropertyBuilder();
        }

        public static IBuilder<Interface, InterfaceDeclarationSyntax> CreateInterfaceBuilder()
        {
            return new InterfaceBuilder(CreateInterfacePropertyBuilder());
        }
    }
}
