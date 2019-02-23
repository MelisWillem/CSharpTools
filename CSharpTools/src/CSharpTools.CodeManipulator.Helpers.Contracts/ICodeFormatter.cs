using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.CodeManipulator.Helpers.Contracts
{
    public interface ICodeFormatter
    {
        SyntaxNode Format(SyntaxNode tree);
    }
}
