using Todo.Common.Entities;

namespace Todo.Domain.ValueObjects.LoginObj
{
    public class Login
    {
        protected Login() { }

        public Login(string userName, string password, string confirmPassword)
        {
            UserName = userName?.ToLower().Trim() ?? string.Empty;
            Password = password?.Trim() ?? string.Empty;
            ConfirmPassword = confirmPassword?.Trim() ?? string.Empty;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }

        public bool Authenticate(string userName, string password)
        {
            return UserName.Equals(userName) && Password.Equals(password);
        }
    }
}
