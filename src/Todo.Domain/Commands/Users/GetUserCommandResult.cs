using System;
using Todo.Common.Commands;

namespace Todo.Domain.Commands.Users
{
    public class GetUserCommandResult : ICommandResult
    {
        public GetUserCommandResult() { }

        public GetUserCommandResult(string firstName, string lastName, string userName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
