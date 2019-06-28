using Pizza.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pizza.Api.Controllers
{
    public class IngredientsController : ApiController
    {
        
        public IngredientsController(IIngredients ingredients)
        {
            Ingredients = ingredients;
        }

        private IIngredients Ingredients { get; set; }



        [HttpGet]
        public IList<string> Get()
        {
            return Ingredients.AvailableToppings;
        }
    }
}
