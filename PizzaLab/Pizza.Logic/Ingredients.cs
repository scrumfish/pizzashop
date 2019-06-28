using Pizza.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Logic
{
    public class Ingredients : IIngredients
    {
        private static IList<string> ingredients = new List<string> { "Pepperoni", "Cheese", "Olives" };
        public IList<string> AvailableToppings
        {
            get
            {
                return ingredients;
            }
        }
    } 
}
