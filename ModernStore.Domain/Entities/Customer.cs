using System;

namespace ModernStore.Domain.Entities
{
    public class Customer
    {

        public Customer(string firstName, string lastName, string email, User user)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            User = user;
        }
 
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }

        public void setBirthDay()
        {

        }

    }
}
