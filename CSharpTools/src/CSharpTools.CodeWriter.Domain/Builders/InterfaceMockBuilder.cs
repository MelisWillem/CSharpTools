using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp;
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
        private readonly IBuilder<MethodDeclarationSyntax, Interface.Property> methodBuilder;

        public InterfaceMockBuilder(IBuilder<MethodDeclarationSyntax, Interface.Property> methodBuilder)
        {
            this.methodBuilder = methodBuilder;
        }

        public ClassDeclarationSyntax Build(Interface @interface)
        {
            var builder = SyntaxFactory.ClassDeclaration("Mocked"
                + @interface.Name.Name
                + "BuilderBuilder");

            @interface.Properties
                .Select(methodBuilder.Build)
                .ForEach(m=>builder.AddMembers(m));

            return builder;
        }
    }
}
