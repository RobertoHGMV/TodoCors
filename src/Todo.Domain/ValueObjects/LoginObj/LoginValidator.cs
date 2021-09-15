using Todo.Common.Validations;

namespace Todo.Domain.ValueObjects.LoginObj
{
    public class LoginValidator : Validation
    {
        public LoginValidator(Login login)
        {
            IsNullOrEmpty(login.UserName, "UserName", "Nome de usuário inválido");
            IsNullOrEmpty(login.Password, "Password", "Senha inválida");
            HasMinLen(login.UserName, 3, "UserName", "Nome de usuário tem que ter no mínimo 3 caracteres");
            HasMinLen(login.Password, 3, "UserName", "Senha tem que ter no mínimo 3 caracteres");
            AreNotEquals(login.Password, login.ConfirmPassword, "Login", "Senha e confirmação de senha não coincidem");
        }
    }
}
