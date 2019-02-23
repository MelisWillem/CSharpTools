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
    public class PropertyBuilder : IBuilder<PropertyDeclarationSyntax, Interface.Property>
    {
        private readonly IBuilder<SyntaxToken, AccessModifier> accesBuilder;

        public PropertyBuilder(IBuilder<SyntaxToken, AccessModifier> accesBuilder)
        {
            this.accesBuilder = accesBuilder;
        }

        public PropertyDeclarationSyntax Build(Interface.Property property)
        {
            var syntaxProp =  SyntaxFactory.PropertyDeclaration(
                SyntaxFactory.ParseName(property.Type.Name),
                SyntaxFactory.Identifier(property.Name));

            // interface property is always public
            syntaxProp.AddModifiers(accesBuilder.Build(AccessModifier.@public));

            if (property.HasGeter)
            {
                syntaxProp.AddAccessorListAccessors(
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));
            }

            if (property.HasSetter)
            {
                syntaxProp.AddAccessorListAccessors(
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));
            }

            return syntaxProp;
        }
    }
}
