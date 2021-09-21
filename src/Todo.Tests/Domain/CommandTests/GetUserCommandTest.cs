using NUnit.Framework;
using Todo.Domain.Commands.Users;

namespace Todo.Tests.Domain.CommandTests
{
    [TestFixture]
    public class GetUserCommandTest
    {
        [Test]
        public void Dado_um_comando_invalido_deve_adicionar_notificacao()
        {
            var sut = new GetUserCommand("");
            sut.Validate();

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        public void Dado_um_comando_valido_nao_deve_adicionar_notificacao()
        {
            var sut = new GetUserCommand("jack");
            sut.Validate();

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }
    }
}
