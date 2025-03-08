using NUnit.Framework;
using Todo.Domain.Commands.Users;

namespace Todo.Tests.Domain.CommandTests
{
    [TestFixture]
    public class UpdateUserCommandTests
    {
        [Test]
        [TestCase("Jack", "Chan", "", "jack@gmail.com")]
        [TestCase("", "Chan", "jack", "jack@gmail.com")]
        [TestCase("Jack", "", "jack", "jack@gmail.com")]
        [TestCase("Jack", "Chan", "jack", "")]
        public void Dado_um_comando_invalido_deve_adicionar_notificacao(string firstName, string lastName, string userName, string email)
        {
            var sut = new UpdateUserCommand(firstName, lastName, userName, email);
            sut.Validate();

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("jack", "Jack", "Chan", "jack@gmail.com")]
        public void Dado_um_comando_valido_nao_deve_adicionar_notificacao(string firstName, string lastName, string userName, string email)
        {
            var sut = new UpdateUserCommand(firstName, lastName, userName, email);
            sut.Validate();

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }
    }
}
