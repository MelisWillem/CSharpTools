using CSharpTools.CodeReader.Domain;
using CSharpTools.Entities;
using System.Diagnostics;
using Xunit;
using CSharpTools.TestTools;
using CSharpTools.Helpers;
using System.Linq;
using Autofac;
using CSharpTools.IOC;
using System.Collections.Generic;
using CSharpTools.Generic.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpTools.CodeReader.Tests
{
    public class InterfaceBuilderTests
    {
        [Theory]
        [MemberData(nameof(GetData))]
        void Given_Interface_Check_Interface_Entity(
            string testName,
            string testFileName,
            Interface expected)
        {
            Debug.WriteLine(testName);
            var basePath = @"../../../TestFiles";
            var fullFilePath = basePath + "/" + testFileName + ".txt";

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<CodeReaderModule>();
            containerBuilder.RegisterModule<HelpersModule>();
            var container = containerBuilder.Build();

            var namespaceBuilder = container
                .Resolve<IGenerator<Type, NamespaceDeclarationSyntax>>();
            var sut = new CSharpReader(new SingleSourceFileReader(fullFilePath), namespaceBuilder);

            var res = sut.Read().OfType<Interface>().First();

            Assert.Equal(expected, res, container.Resolve<IEqualityComparer<Interface>>()); 
        }

        public static TheoryData<string, string, Interface> GetData()
        {
            return new TheoryData<string, string, Interface>
            {
                {
                    "Test1",
                    "Interface1",
                    new TestTools.InterfaceBuilder()
                        .WithName(new TestTools.TypeNameBuilder()
                            .WithName("Interface1")
                            .WithNamespace("CSharpTools","TestData","Contracts")
                            .Build())
                        .WithProperties()
                        .Build()
                },
                {
                    "Test2",
                    "Interface2",
                    new TestTools.InterfaceBuilder()
                        .WithName(new TestTools.TypeNameBuilder()
                            .WithName("Interface2")
                            .WithNamespace("CSharpTools","TestData","Contracts")
                            .Build())
                        .WithProperties(new TestTools.InterfacePropertyBuilder()
                            .WithName("Test")
                            .WithType(new TestTools.TypeNameBuilder()
                                .WithName("int")
                                .Build())
                            .Build())
                        .Build()
                }
            };
        }
    }
}
