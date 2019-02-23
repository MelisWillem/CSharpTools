using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTools.CodeWriter.Domain.Builders
{
    public class NamespaceBuilder : IBuilder<NamespaceDeclarationSyntax, List<string>>
    {
        public NamespaceDeclarationSyntax Build(List<string> input)
        {
            // temp hack 
            var namespaceFullNameLocation = String.Join(".",input.Take(input.Count() - 1));
            var namespaceName = input.Last();

            NameSyntax namespaceSyntaxName = (input.Count < 2) 
                ?  SyntaxFactory.IdentifierName(namespaceName)
                :  (NameSyntax) SyntaxFactory.QualifiedName(
                    SyntaxFactory.ParseName(namespaceFullNameLocation),
                    SyntaxFactory.IdentifierName(namespaceName));

            return SyntaxFactory.NamespaceDeclaration(namespaceSyntaxName);
        }
    }
}
