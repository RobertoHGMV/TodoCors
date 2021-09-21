using NUnit.Framework;
using Todo.Domain.Commands.Users;

namespace Todo.Tests.Domain.CommandTests
{
    [TestFixture]
    public class UpdateUserCommandTests
    {
        [Test]
        [TestCase("", "Jack", "Chan", "jack@gmail.com")]
        [TestCase("jack", "", "Chan", "jack@gmail.com")]
        [TestCase("jack", "Jack", "", "jack@gmail.com")]
        [TestCase("jack", "Jack", "Chan", "")]
        public void Dado_um_comando_invalido_deve_adicionar_notificacao(string userName, string firstName, string lastName, string email)
        {
            var sut = new UpdateUserCommand(userName, firstName, lastName, email);
            sut.Validate();

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("jack", "Jack", "Chan", "jack@gmail.com")]
        public void Dado_um_comando_valido_nao_deve_adicionar_notificacao(string userName, string firstName, string lastName, string email)
        {
            var sut = new UpdateUserCommand(userName, firstName, lastName, email);
            sut.Validate();

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }
    }
}
