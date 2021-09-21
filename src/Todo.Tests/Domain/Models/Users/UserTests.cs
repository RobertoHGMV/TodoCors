using NUnit.Framework;
using Todo.Domain.Models.Users;
using Todo.Domain.ValueObjects.EmailObj;
using Todo.Domain.ValueObjects.LoginObj;
using Todo.Domain.ValueObjects.NameObj;

namespace Todo.Tests.Domain.Models.Users
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Dado_Nome_e_email_deve_atualizar_usuario()
        {
            var nameToUpdate = new Name("Jack", "Chan");
            var emailToUpdate = new Email("jack@hotmail.com");

            var name = new Name("Jack", "Chan");
            var email = new Email("jack@gmail.com");
            var login = new Login("jack", "12345", "12345");
            var sut = new User(name, login, email);

            sut.Update(nameToUpdate, emailToUpdate);

            var result = sut.Name.FirstName.Equals(nameToUpdate.FirstName) &&
                sut.Name.LastName.Equals(nameToUpdate.LastName) &&
                sut.Email.Address.Equals(emailToUpdate.Address);

            Assert.IsTrue(result);
        }
    }
}
