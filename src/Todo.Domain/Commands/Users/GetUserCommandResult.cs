using System;
using Todo.Common.Commands;

namespace Todo.Domain.Commands.Users
{
    public class GetUserCommandResult : ICommandResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
