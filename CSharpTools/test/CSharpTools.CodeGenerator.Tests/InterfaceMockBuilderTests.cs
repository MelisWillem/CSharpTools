using Autofac;
using CSharpTools.CodeManipulator.Helpers.Domain;
using CSharpTools.CodeReader.Domain;
using CSharpTools.CodeReader.Domain.Builders;
using CSharpTools.CodeWriter.Domain.Builders;
using CSharpTools.Entities;
using CSharpTools.IOC;
using System;
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
            var codeFormatter = new CodeFormatterWorkerspace(@"../../../CSharpTools.CodeGenerator.Tests.csproj");

            var sut = BuildIoC().Resolve<InterfaceMockBuilder>();
            var res = codeFormatter.Format(sut.Build(@interface)).ToFullString();

            //TODO
            //Assert.Equal(expectedMockedInterfaceBuilder, res);
        }

        public static string ReadFile(string basePath, string fileName)
            => File.ReadAllText(basePath + fileName + ".txt", Encoding.UTF8);

        public static TheoryData<string, Interface, string> GetData()
        {
            var reader = BuildIoC().Resolve<CSharpReader>();
            var basePath = "../../../interfaceData/";
            var interface1 = reader.Read(basePath + "interface1.txt").OfType<Interface>().First();

            return new TheoryData<string, Interface, string>
            {
                {
                "Test1: simple interface with 3 properties",
                interface1,
                ReadFile(basePath,"MockedInterface1Builder")
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
