using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        private User user = new User("diego", "123");
        private Name name = new Name("Diego", "Fernandes");
        private Email email = new Email("diego@mail.com");
        private Document CPF = new Document("12345678999");

        private readonly Customer _customer;


        public OrderTests()
        {
            _customer = new Customer(name, email, CPF, user);
        }
        

        

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnOutOfStockProductShouldReturnAnError()
        {
            var user = new User("Diego", "123");
            var mouse = new Product("Mouse", 299, "mouse.jpg", 0);

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsFalse(order.isValid());
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnInStockProductShoudUpdateQuantityOnHand()
        {
            //Checa se o calculo da compra e retirada está retornando o valor correto
           
            var mouse = new Product("Mouse", 299, "mouse.jpg", 20);

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsTrue(mouse.QuantityOnHand == 18);
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAValidOrderItShouldReturnBe310()
        {
            //Checa se o calculo da compra e retirada está retornando o valor correto

            var mouse = new Product("Mouse", 300, "mouse.jpg", 20);

            var order = new Order(_customer, 12, 1);
            order.AddItem(new OrderItem(mouse, 1));

            Assert.IsTrue(order.Total() == 310);
        }

    }
}
