using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

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

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnNotification()
        {          
            var customer = new Customer("","Fernandes", "diego@mail.com", user);
            Assert.IsFalse(customer.isValid());        
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnNotification()
        {
            var customer = new Customer("diego", "", "diego@mail.com", user);
            Assert.IsFalse(customer.isValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnNotification()
        {
            var customer = new Customer("diego", "Fernandes", "a", user);
            Assert.IsFalse(customer.isValid());
        }
    }
}
