using System.Collections.Generic;

namespace Pizza.Objects
{
    public class Pizza
    {
        public Sizes Size { get; set; }
        public List<string> Toppings { get; set; }
    }
}
