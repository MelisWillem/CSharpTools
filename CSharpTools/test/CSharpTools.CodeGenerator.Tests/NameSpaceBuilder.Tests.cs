using CSharpTools.CodeManipulator.Helpers.Domain;
using CSharpTools.CodeWriter.Domain.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Xunit;

namespace CSharpTools.CodeGenerator.Tests
{
    public class NameSpaceBuilderTests
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void Given_Namespace_Generate_CSharp(
			string testName,
			List<string> @namespace,
			string expectedCode)
        {
            Debug.Write(testName);
            var codeFormatter = new CodeFormatterWorkerspace(@"../../../CSharpTools.CodeGenerator.Tests.csproj");

            var sut = new NamespaceBuilder();

            var res = codeFormatter.Format(sut.Build(@namespace));

            Assert.Equal(expectedCode, res.ToFullString());
        }

        public static string ReadFile(string fileName)
            => File.ReadAllText(@"../../../namespaceData/" + fileName + ".txt", Encoding.UTF8);

        public static TheoryData<string, List<string>, string> GetData()
        {
            return new TheoryData<string, List<string>, string>
            {
                {
                    "Test1: simple single name namespace",
                    new List<string>{ "Namespace1"},
                    ReadFile("Namespace1")
                },
                {
                    "Test2: long namespace name",
                    new List<string>{ "Namespace2" , "Long" , "Test"},
                    ReadFile("Namespace2")
                }
            };
        }
    }
}
