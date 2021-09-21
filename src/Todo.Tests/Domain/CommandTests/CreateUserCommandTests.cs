using NUnit.Framework;
using Todo.Domain.Commands.Users;

namespace Todo.Tests.Domain.CommandTests
{
    [TestFixture]
    public class CreateUserCommandTests
    {
        [Test]
        [TestCase("", "Chan", "jack", "jack123", "jack123", "jack@gmail.com")]
        [TestCase("Jack", "", "jack", "jack123", "jack123", "jack@gmail.com")]
        [TestCase("Jack", "Chan", "", "jack123", "jack123", "jack@gmail.com")]
        [TestCase("Jack", "Chan", "jack", "", "jack123", "jack@gmail.com")]
        [TestCase("Jack", "Chan", "jack", "jack123", "", "jack@gmail.com")]
        [TestCase("Jack", "Chan", "jack", "jack123", "jack", "jack@gmail.com")]
        [TestCase("Jack", "Chan", "jack", "jack123", "jack123", "")]
        [TestCase("Jack", "Chan", "jack", "jack123", "jack123", "jack@gmail")]
        public void Dado_um_comando_invalido_deve_adicionar_notificacao(string firstName, string lastName, string userName, string password, string confirmPassword, string email)
        {
            var sut = new CreateUserCommand(firstName, lastName, userName, password, confirmPassword, email);
            sut.Validate();

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("Jack", "Chan", "jack", "jack123", "jack123", "jack@gmail.com")]
        public void Dado_um_comando_valido_nao_deve_adicionar_notificacao(string firstName, string lastName, string userName, string password, string confirmPassword, string email)
        {
            var sut = new CreateUserCommand(firstName, lastName, userName, password, confirmPassword, email);
            sut.Validate();

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }
    }
}
