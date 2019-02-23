using System.Collections.Generic;

namespace CSharpTools.Entities
{
    public class Interface : Type
    {
        public List<Property> Properties { get; set; }

        public class Property 
        {
            public string Name { get; set; }

            public TypeName Type { get; set; }
        }
    }
}
