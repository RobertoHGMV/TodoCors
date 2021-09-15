using System;
using Todo.Domain.ValueObjects.EmailObj;
using Todo.Domain.ValueObjects.LoginObj;
using Todo.Domain.ValueObjects.NameObj;

namespace Todo.Domain.Models.Users
{
    public class User
    {
        public User(Name name, Login login, Email email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Login = login;
            Email = email;
        }

        protected User() { }

        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Login Login { get; private set; }
        public Email Email { get; private set; }

        public void Update(Name name, Email email)
        {
            Name = name;
            Email = email;
        }
    }
}
