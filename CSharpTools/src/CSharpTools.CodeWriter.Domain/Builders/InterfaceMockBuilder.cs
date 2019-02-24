using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools.CodeWriter.Domain.Builders
{
    public class InterfaceMockBuilder : IBuilder<ClassDeclarationSyntax, Interface>
    {
        private readonly IBuilder<MethodDeclarationSyntax, ClassDeclarationSyntax, Interface.Property> methodBuilder;

        public InterfaceMockBuilder(IBuilder<MethodDeclarationSyntax, ClassDeclarationSyntax, Interface.Property> methodBuilder)
        {
            this.methodBuilder = methodBuilder;
        }

        public ClassDeclarationSyntax Build(Interface @interface)
        {
            var className = "Mocked"
                + @interface.Name.Name
                + "Builder";

            var builder = ClassDeclaration(className);

            var returnSelfBuildMethod = MethodDeclaration(
                ParseTypeName(className),
                ParseToken("Build"))
                .AddBodyStatements(ReturnStatement(ThisExpression()))
                .AddModifiers(Token(SyntaxKind.PublicKeyword));

            @interface.Properties
                .Select(p=>methodBuilder.Build(builder, p))
                .ForEach(m=> builder = builder.AddMembers(m));

            return builder
                .AddMembers(returnSelfBuildMethod);
        }
    }
}
