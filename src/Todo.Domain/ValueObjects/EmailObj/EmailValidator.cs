using Todo.Common.Validations;

namespace Todo.Domain.ValueObjects.EmailObj
{
    public class EmailValidator : Validation
    {
        public EmailValidator(Email email)
        {
            IsNullOrEmpty(email.Address, "Email", "E-mail não informado");
            IsInvalidEmail(email.Address, "Email", "E-mail inválido");
        }
    }
}
