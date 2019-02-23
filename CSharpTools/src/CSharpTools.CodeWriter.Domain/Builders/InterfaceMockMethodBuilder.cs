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
        /// <summary>
        /// returns fluid based method to create property
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public MethodDeclarationSyntax Build(Interface.Property @interface)
        {
            var MockBuilderName = @interface.Name;

            TypeSyntax returnType = 
                SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("string"));
            SyntaxToken identifier = SyntaxFactory.ParseToken("With"+@interface.Name);
            return  SyntaxFactory.MethodDeclaration(
                returnType,
                identifier);
        }
    }
}
