using CSharpTools.CodeReader.Contracts;

namespace CSharpTools.CodeReader.Domain
{
    public class SingleSourceFileReader : ISourceFileReader
    {
        public string Read(string filePath) => System.IO.File.ReadAllText(filePath);
    }
}
