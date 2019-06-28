using System.Collections.Generic;

namespace Pizza.Objects
{
    public interface IIngredients
    {
        IList<string> AvailableToppings { get; }
    }
}
