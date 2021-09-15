using Todo.Common.Commands;
using Todo.Common.Notifications;

namespace Todo.Domain.Commands.Users
{
    public class UpdateUserCommand : Notifiable, ICommand
    {
        public UpdateUserCommand() { }

        public UpdateUserCommand(string userName, string firstName, string lastName, string email)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            IsNullOrEmpty(FirstName, "FirstName", "Nome não informado");
            HasMinLen(FirstName, 3, "FirstName", "Nome deve ter de 03 a 60 caracteres");
            HasMaxLen(FirstName, 60, "FirstName", "Nome deve ter de 03 a 60 caracteres");

            IsNullOrEmpty(LastName, "LastName", "Sobrenome não informado");
            HasMinLen(LastName, 3, "LastName", "Sobrenome deve ter de 03 a 60 caracteres");
            HasMaxLen(LastName, 60, "LastName", "Sobrenome deve ter de 03 a 60 caracteres");

            IsInvalidEmail(Email, "Email", "E-mail inválido");
        }
    }
}
