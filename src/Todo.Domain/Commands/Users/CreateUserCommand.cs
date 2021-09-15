using System;
using System.Collections.Generic;
using System.Text;
using Todo.Common.Commands;
using Todo.Common.Notifications;

namespace Todo.Domain.Commands.Users
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public CreateUserCommand() { }

        public CreateUserCommand(string firstName, string lastName, string userName, string password, string confirmPassword, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            ConfirmPassword = confirmPassword;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            IsNullOrEmpty(FirstName, "FirstName", "Nome não informado");
            HasMinLen(FirstName, 3, "FirstName", "Nome deve ter de 03 a 60 caracteres");
            HasMaxLen(FirstName, 60, "FirstName", "Nome deve ter de 03 a 60 caracteres");

            IsNullOrEmpty(LastName, "LastName", "Sobrenome não informado");
            HasMinLen(LastName, 3, "LastName", "Sobrenome deve ter de 03 a 60 caracteres");
            HasMaxLen(LastName, 60, "LastName", "Sobrenome deve ter de 03 a 60 caracteres");

            IsNullOrEmpty(UserName, "UserName", "Nome de usuário inválido");
            HasMinLen(UserName, 3, "LastName", "Nome de usuário deve ter de 3 a 20 caracteres");
            HasMaxLen(UserName, 20, "LastName", "Nome de usuário deve ter de 3 a 20 caracteres");

            IsNullOrEmpty(Password, "Password", "Senha inválida");
            HasMinLen(Password, 3, "Password", "Senha deve ter de 3 a 10 caracteres.");
            HasMaxLen(Password, 10, "Password", "Senha deve ter de 3 a 10 caracteres.");

            AreNotEquals(Password, ConfirmPassword, "Login", "Senha e confirmação de senha não coincidem");
            IsInvalidEmail(Email, "Email", "E-mail inválido");
        }
    }
}
