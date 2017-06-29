using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        public User(string username, string password)
        {
            //Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Active = true;
        }

       // public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; set; }
        public bool Active { get; private set; }


        public void Activate() => Active = true;

        public void Deactivate() => Active = false;
     
    }
}
