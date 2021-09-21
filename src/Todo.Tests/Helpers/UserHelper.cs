using Todo.Domain.Commands.Users;
using Todo.Domain.Models.Users;
using Todo.Domain.ValueObjects.EmailObj;
using Todo.Domain.ValueObjects.LoginObj;
using Todo.Domain.ValueObjects.NameObj;

namespace Todo.Tests.Helpers
{
    public class UserHelper
    {
        public readonly User UserValid = new User(
            new Name("Jack", "Chan"),
            new Login("jack", "12345", "12345"),
            new Email("jack@gmail.com"));

        public readonly CreateUserCommand CreateUserCommandValid = new CreateUserCommand("Jack", "Chan", "jack", "12345", "12345", "jack@gmail.com");
        public readonly CreateUserCommand CreateUserCommandInvalid = new CreateUserCommand("", "", "", "", "", "");
        public readonly UpdateUserCommand UpdateUserCommandValid = new UpdateUserCommand("jack", "Jack", "Chan", "jack@gmail.com"); 
        public readonly UpdateUserCommand UpdateUserCommandInvalid = new UpdateUserCommand("", "", "", "");
        public readonly DeleteUserCommand DeleteUserCommandValid = new DeleteUserCommand("jack");
        public readonly DeleteUserCommand DeleteUserCommandInvalid = new DeleteUserCommand("");
        public readonly GetUserCommand GetUserCommandValid = new GetUserCommand("jack");
        public readonly GetUserCommand GetUserCommandInvalid = new GetUserCommand("");
    }
}
