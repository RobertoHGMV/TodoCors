using Todo.Common.Commands;
using Todo.Common.Notifications;

namespace Todo.Domain.Commands.Users
{
    public class GetUserCommand : Notifiable, ICommand
    {
        public GetUserCommand() { }

        public GetUserCommand(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }

        public void Validate()
        {
            IsNullOrEmpty(UserName, "UserName", "Nome de usuário não informado");
        }
    }
}
