using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace CSharpTools.CodeWriter.Domain.Builders
{
    public class InterfaceMockMethodBuilder : IBuilder<MethodDeclarationSyntax, ClassDeclarationSyntax, Interface.Property>
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
        public MethodDeclarationSyntax Build(ClassDeclarationSyntax mockBuilder, Interface.Property property)
        {
            var MockBuilderName = property.Name;

            TypeSyntax returnType = ParseTypeName(mockBuilder.Identifier.ToString());
            SyntaxToken methodName = ParseToken("With"+property.Name);

            var lamdaExpressionMock = SimpleLambdaExpression(
                Parameter(Identifier("m")),
                MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    IdentifierName("m"),
                    IdentifierName(property.Name)));

            var getPropertieExpression = 
                        InvocationExpression(
                            MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                IdentifierName("_mock"),
                                IdentifierName("Setup")))
                        .AddArgumentListArguments(
                            Argument(lamdaExpressionMock));

            var returnResultExpression =
                        InvocationExpression(
                            MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                getPropertieExpression,
                                IdentifierName("Result")));

            return
                MethodDeclaration(
                    returnType,
                    methodName)
                .AddModifiers(modBuilder.Build(AccessModifier.@public))
                .AddParameterListParameters(
                    Parameter(
                        Identifier(property.Name))
                        .WithType(ParseTypeName(property.Type.Name)))
                .AddBodyStatements(
                    ExpressionStatement(
                        returnResultExpression
                            .AddArgumentListArguments(Argument(IdentifierName(property.Name)))))
                .AddBodyStatements(ReturnStatement(ThisExpression()));
        }
    }
}
