using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pizza.Api.Controllers;
using Pizza.Objects;

namespace Pizza.Api.UnitTests
{
    [TestClass]
    public class IngredientsControllerTests
    {
        private IngredientsController target;
        private Mock<IIngredients> ingredientsMock;

        [TestInitialize]
        public void Setup()
        {
            ingredientsMock = new Mock<IIngredients>();
            ingredientsMock.Setup(i => i.AvailableToppings).Returns(new List<string> { "test1", "test2" });
            target = new IngredientsController(ingredientsMock.Object);
        }

        [TestMethod]
        public void Get_returns_list_of_toppings()
        {
            var result = target.Get();
            Assert.IsTrue(result.Any());
        }
    }
}
