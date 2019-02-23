using Buildalyzer;
using Buildalyzer.Workspaces;
using CSharpTools.CodeManipulator.Helpers.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using System;

namespace CSharpTools.CodeManipulator.Helpers.Domain
{
    public class CodeFormatterWorkerspace : ICodeFormatter
    {
        private readonly string projectFile;

        public CodeFormatterWorkerspace(
            string projectFile)
        {
            this.projectFile = projectFile;
        }

        public SyntaxNode Format(SyntaxNode tree)
        {
            AnalyzerManager manager = new AnalyzerManager();
            ProjectAnalyzer analyzer = manager.GetProject(projectFile);
            var workspace = analyzer.GetWorkspace();

            return Formatter.Format(tree, workspace);
        }
    }
}
