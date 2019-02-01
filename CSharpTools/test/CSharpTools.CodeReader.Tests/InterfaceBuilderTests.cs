using CSharpTools.CodeReader.Domain;
using CSharpTools.Entities;
using System.Diagnostics;
using Xunit;
using CSharpTools.TestTools;
using CSharpTools.Helpers;
using System.Linq;

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

            var sut = CodeReaderFactory.CreateCSharpReaderSingleFile(basePath + "/" + testFileName + ".txt");

            var res = sut.Read().OfType<Interface>().First();

            Assert.Equal(expected, res, EqualityComparerFactory.CreateInterfaceEqualityComparer()); 
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
                }
            };
        }
    }
}
