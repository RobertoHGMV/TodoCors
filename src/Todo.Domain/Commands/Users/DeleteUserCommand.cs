using Todo.Common.Commands;
using Todo.Common.Notifications;

namespace Todo.Domain.Commands.Users
{
    public class DeleteUserCommand : Notifiable, ICommand
    {
        public DeleteUserCommand() { }

        public DeleteUserCommand(string username)
        {
            UserName = username;
        }

        public string UserName { get; set; }

        public void Validate()
        {
            IsNullOrEmpty(UserName, "UserName", "Nome de usuário não informado");
        }
    }
}
