using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {

        public Customer(string firstName, string lastName, string email, User user)
        {
          
            FirstName = firstName;
            LastName = lastName;
            BirthDate = null;
            Email = email;
            User = user;

            //Validações
            new FluentValidator.ValidationContract<Customer>(this)
                            .IsRequired(x => x.FirstName, "Nome é obrigatório!")
                            .HasMaxLenght(x => x.FirstName, 60)
                            .HasMinLenght(x => x.FirstName, 3)
                            .IsRequired(x=> x.LastName, "Sobrenome é obrigatório!")
                            .HasMaxLenght(x => x.LastName, 60)
                            .HasMinLenght(x => x.LastName, 3)
                            .IsEmail(x => x.Email, "E-mail inválido!");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }
 
        public void Update(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public void setBirthDay()
        {

        }

    }
}
