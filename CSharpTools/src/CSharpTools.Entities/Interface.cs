using System.Collections.Generic;

namespace CSharpTools.Entities
{
    public class Interface : Type
    {
        public List<Property> Properties { get; set; }

        public class Property 
        {
            public bool HasGeter { get; set; }

            public bool HasSetter { get; set; }

            public string Name { get; set; }

            public TypeName Type { get; set; }
        }
    }
}
