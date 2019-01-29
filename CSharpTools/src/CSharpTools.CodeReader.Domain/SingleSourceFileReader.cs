using CSharpTools.CodeReader.Contracts;

namespace CSharpTools.CodeReader.Domain
{
    public class SingleSourceFileReader : ISourceFileReader
    {
        private readonly string filePath;

        public SingleSourceFileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public string Read() => System.IO.File.ReadAllText(filePath);
    }
}
