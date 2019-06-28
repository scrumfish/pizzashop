using Pizza.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Logic
{
    public class Pizza : IPizza
    {
        private IIngredients Ingredients { get; set; }

        public Pizza(IIngredients ingredients)
        {
            Ingredients = ingredients;
        }

        public Sizes Size { get; set; }
        public IList<string> Toppings { get; set; }

        public void AddToppings(List<string> toppings)
        {
            if ( ! toppings.All(t => Ingredients.AvailableToppings.Contains(t)) )
            {
                throw new Exception("Invalid topping");
            }

            Toppings = new List<string>(toppings);
        }

        public double GetPrice()
        {
            switch (Size)
            {
                case Sizes.Large:
                    return 20.0 + (Toppings.Count() * 3);
                case Sizes.Medium:
                    return 15.0 + (Toppings.Count() * 2);
                case Sizes.Small:
                    return 10.0 + (Toppings.Count() * 1);
            }
            throw new Exception("Not a valid size");
        }
    }
}
