using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.CodeWriter.Domain.Builders
{
    public class TypeBuilder : IBuilder<TypeSyntax, TypeName>
    {
        public TypeSyntax Build(TypeName input)
        {
            //return new TypeSyntax()
            throw new NotImplementedException();
        }
    }
}
