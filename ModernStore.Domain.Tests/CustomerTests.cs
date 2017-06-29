using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {

        //Dado algo retorna algo
        //Given = dado // Should Return = retorna algo

        //Obs.: o pior caso seria o Falso Positivo
        //onde o teste retorna TRUE mas o teste está falso


        private User user = new User("diego", "123");
        private Name name = new Name("Diego", "Fernandes");
        private Email email = new Email("diego@mail.com");
        private Document CPF = new Document("12345678999");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnNotification()
        {          
            var customer = new Customer(name, email, CPF, user);
            Assert.IsFalse(customer.isValid());        
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnNotification()
        {
            var customer = new Customer(name, email, CPF, user);
            Assert.IsFalse(customer.isValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnNotification()
        {
            var customer = new Customer(name, email, CPF, user);
            Assert.IsFalse(customer.isValid());
        }
    }
}
