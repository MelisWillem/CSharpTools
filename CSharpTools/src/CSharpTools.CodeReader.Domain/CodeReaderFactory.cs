using CSharpTools.CodeReader.Contracts;
using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
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
            =>  CreateCSharpReader(new SingleSourceFileReader(path));

        public static CSharpReader CreateCSharpReaderString(string sourceCode)
            => CreateCSharpReader(new StringSourceFileReader(sourceCode));

        public static CSharpReader CreateCSharpReader(ISourceFileReader reader)
            => new CSharpReader(
                reader,
                CreateNamespaceTypeGenerator());

        public static IGenerator<Type, NamespaceDeclarationSyntax> CreateNamespaceTypeGenerator()
            => new  NamespaceTypeGenerator(CreateInterfaceBuilder());

        public static IBuilder<TypeName, SyntaxToken> CreateSyntaxTokenTypeNameBuilder()
            => new SyntaxTokenTypeNameBuilder();

        public static IBuilder<TypeName,TypeSyntax> CreateTypeNameBuilder()
            => new TypeNameBuilder();

        public static IBuilder<Interface.Property, PropertyDeclarationSyntax> CreateInterfacePropertyBuilder() 
            => new InterfacePropertyBuilder(CreateTypeNameBuilder());

        public static IBuilder<Interface, InterfaceDeclarationSyntax> CreateInterfaceBuilder()
            => new InterfaceBuilder(
                CreateSyntaxTokenTypeNameBuilder(),
                CreateInterfacePropertyBuilder());
    }
}
