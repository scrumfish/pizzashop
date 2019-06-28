using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pizza.Objects;

namespace Pizza.Api.Controllers
{
    public class OrderController : ApiController
    {
        private IOrder Order { get; set; }

        public OrderController(IOrder order)
        {
            Order = order;
        }

        [HttpPost]
        public void Post(Objects.Pizza pizza)
        {
            Order.AddPizza(pizza);
        }
    }
}
