using Todo.Common.Validations;

namespace Todo.Domain.ValueObjects.NameObj
{
    public class NameValidator : Validation
    {
        public NameValidator(Name name)
        {
            IsNullOrEmpty(name.FirstName, "FirstName", "Nome não informado");
            IsNullOrEmpty(name.LastName, "LastName", "Sobrenome não informado");
        }
    }
}
