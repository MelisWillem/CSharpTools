using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.CodeWriter.Domain.Builders
{
    public class AccessModifierBuilder : IBuilder<SyntaxToken, AccessModifier>
    {
        public SyntaxToken  Build(AccessModifier input)
        => SyntaxFactory.Token(GetSyntaxKind(input));

        private SyntaxKind GetSyntaxKind(AccessModifier input)
        {
            switch (input)
            {
                case AccessModifier.@public:
                    return SyntaxKind.PublicKeyword;
                case AccessModifier.@private:
                    return SyntaxKind.PrivateKeyword;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
