using NUnit.Framework;
using Todo.Domain.Commands.Users;

namespace Todo.Tests.Domain.CommandTests
{
    [TestFixture]
    public class DeleteUserCommandTests
    {
        [Test]
        public void Dado_um_comando_invalido_deve_adicionar_notificacao()
        {
            var sut = new DeleteUserCommand("");
            sut.Validate();

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        public void Dado_um_comando_valido_nao_deve_adicionar_notificacao()
        {
            var sut = new DeleteUserCommand("jack");
            sut.Validate();

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }
    }
}
