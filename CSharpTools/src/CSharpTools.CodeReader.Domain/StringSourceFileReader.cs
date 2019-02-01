using CSharpTools.CodeReader.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTools.CodeReader.Domain
{
    public class StringSourceFileReader : ISourceFileReader
    {
        private readonly string sourceString;

        public StringSourceFileReader(string sourceString)
        {
            this.sourceString = sourceString;
        }

        public string Read() => sourceString;
    }
}
