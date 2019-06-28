using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pizza.Objects;

namespace Pizza.Logic.UnitTests
{
    [TestClass]
    public class PizzaTests
    {
        private Pizza target;
        private Mock<IIngredients> ingredientsMock;

        [TestInitialize]
        public void Setup()
        {
            ingredientsMock = new Mock<IIngredients>();
            ingredientsMock.Setup(i => i.AvailableToppings).Returns(new List<string>() { "test 1", "test 2" });
            target = new Pizza(ingredientsMock.Object);
        }

        [TestMethod]
        public void Adds_toppings_to_pizza()
        {
            var expected = new List<string>() { "test 1", "test 2" };
            target.AddToppings(expected);
            Assert.IsTrue(target.Toppings.All(t => expected.Contains(t)));
        }

        [TestMethod]
        public void Validates_throws_exception_if_toppings_not_real()
        {
            var toppings = new List<string>() { "test 3", "test 2" };

            Assert.ThrowsException<Exception>(() => target.AddToppings(toppings));
        }

        [DataTestMethod]
        [DataRow((20.0 + (3 * 2)),Sizes.Large)]
        [DataRow((15.0 + (2 * 2)), Sizes.Medium)]
        [DataRow((10.0 + (1 * 2)), Sizes.Small)]
        public void Calculates_price_based_on_toppings_and_size(double expected, Sizes size)
        {
            target.Size = size;
            target.AddToppings(new List<string>() { "test 1", "test 2" });
            var result = target.GetPrice();
            Assert.AreEqual(expected, result);

        }
    }

}
