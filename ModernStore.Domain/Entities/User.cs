using System;

namespace ModernStore.Domain.Entities
{
    public class User
    {
        public User(string username, string email)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Active = false;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; set; }
        public bool Active { get; private set; }


        public void Activate() => Active = true;

        public void Deactivate() => Active = false;
     
    }
}
