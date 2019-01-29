using System.Collections.Generic;

namespace CSharpTools.Entities
{
    public class TypeName
    {
        public string Name { get; set; }

        public List<string> Namespace { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
