using Todo.Common.Validations;

namespace Todo.Domain.Models.Users
{
    public class UserValidator : Validation
    {
        public UserValidator(User user)
        {
            AddNotifications(user.Name.Notifications);
            AddNotifications(user.Login.Notifications);
            AddNotifications(user.Email.Notifications);
        }
    }
}
