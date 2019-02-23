using CSharpTools.CodeReader.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.CodeReader.Domain
{
    public class StringSourceFileReader : ISourceFileReader
    {
        public string Read(string sourceString) => sourceString;
    }
}
