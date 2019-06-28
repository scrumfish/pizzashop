using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pizza.Api.Controllers;
using Pizza.Objects;

namespace Pizza.Api.UnitTests
{
    [TestClass]
    public class OrderControllerTests
    {
        OrderController target;
        Mock<IOrder> orderMock;

        [TestInitialize]
        public void Setup()
        {
            orderMock = new Mock<IOrder>();
            target = new OrderController(orderMock.Object);
        }

        [TestMethod]
        public void Post_adds_pizza_to_order()
        {
            var expected = new Pizza.Objects.Pizza
            {
                Size = Sizes.Medium,
                Toppings = new List<string> { "Pepporoni", "Cheese" }
            };

            target.Post(expected);

            orderMock.Verify(o => o.AddPizza(It.Is<Pizza.Objects.Pizza>(p => p.Size == expected.Size)), Times.Once);
        }
    }
}
