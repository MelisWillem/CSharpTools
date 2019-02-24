using Autofac;
using CSharpTools.CodeManipulator.Helpers.Domain;
using CSharpTools.CodeReader.Domain;
using CSharpTools.CodeReader.Domain.Builders;
using CSharpTools.CodeWriter.Domain.Builders;
using CSharpTools.Entities;
using CSharpTools.Generic.Contracts;
using CSharpTools.IOC;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace CSharpTools.CodeGenerator.Tests
{
    public class InterfaceMockBuilderTests
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void Given_Interface_Create_MockedInterfaceBuilder(
            string testName,
            Interface @interface,
            string expectedMockedInterfaceBuilder)
        {
            Debug.Write(testName);

            var namespaceBuilder = BuildIoC().Resolve<IBuilder<NamespaceDeclarationSyntax, List<string>>>();
            var @namespace = namespaceBuilder.Build(new List<string> { "Test" });

            var sut = BuildIoC().Resolve< IBuilder<ClassDeclarationSyntax, Interface>>();
            var res = sut.Build(@interface);
            @namespace  = @namespace.AddMembers(res);

            var codeFormatter = new CodeFormatterWorkerspace(@"../../../CSharpTools.CodeGenerator.Tests.csproj");
            var formattedResult = codeFormatter.Format(@namespace).ToFullString();
            Assert.Equal(
                expectedMockedInterfaceBuilder,
                formattedResult);
        }

        public static string ReadFile(string basePath, string fileName)
            => File.ReadAllText(basePath + fileName + ".txt", Encoding.UTF8);

        public static TheoryData<string, Interface, string> GetData()
        {
            var reader = BuildIoC().Resolve<CSharpReader>();
            var basePath = "../../../interfaceData/";
            var interface1 = reader.Read(basePath + "interface1.txt").OfType<Interface>().First();
            var interface2 = reader.Read(basePath + "interface2.txt").OfType<Interface>().First();

            return new TheoryData<string, Interface, string>
            {
                //{
                //"Test1: simple interface with 3 properties",
                //interface1,
                //ReadFile(basePath,"MockedInterface1Builder")
                //},
                {
                "Test2: simple interface with 1 costum class property",
                interface2,
                ReadFile(basePath,"MockedInterface2Builder")
                }
            };
        }

        public static IContainer BuildIoC()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new CodeReaderModule { Reader = new SingleSourceFileReader() });
            containerBuilder.RegisterModule<HelpersModule>();
            containerBuilder.RegisterModule<CodeWriterModule>();
            return containerBuilder.Build();
        }
    }
}
