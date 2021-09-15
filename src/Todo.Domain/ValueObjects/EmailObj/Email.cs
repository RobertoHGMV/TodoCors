using Todo.Common.Entities;

namespace Todo.Domain.ValueObjects.EmailObj
{
    public class Email : Entity
    {
        protected Email() { }

        public Email(string address)
        {
            Address = address;
            Validate(new EmailValidator(this));
        }

        public string Address { get; private set; }
    }
}
