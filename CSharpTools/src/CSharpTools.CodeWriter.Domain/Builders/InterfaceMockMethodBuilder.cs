using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.CodeWriter.Domain.Builders
{
    public class InterfaceMockMethodBuilder : IBuilder<MethodDeclarationSyntax, Interface.Property>
    {
        private readonly IBuilder<SyntaxToken, AccessModifier> modBuilder;

        public InterfaceMockMethodBuilder(IBuilder<SyntaxToken, AccessModifier> modBuilder)
        {
            this.modBuilder = modBuilder;
        }

        /// <summary>
        /// returns fluid based method to create property
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public MethodDeclarationSyntax Build(Interface.Property property)
        {
            var MockBuilderName = property.Name;

            TypeSyntax returnType = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("string"));
            SyntaxToken methodName = SyntaxFactory.ParseToken("With"+property.Name);

            return  SyntaxFactory
                .MethodDeclaration(
                    returnType,
                    methodName)
                .AddModifiers(modBuilder.Build(AccessModifier.@public))
                ;
        }
    }
}
