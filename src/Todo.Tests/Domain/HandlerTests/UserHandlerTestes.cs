using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Users;
using Todo.Domain.Handlers.Users;
using Todo.Domain.Repositories;
using Todo.Tests.Helpers;

namespace Todo.Tests.Domain.HandlerTests
{
    [TestFixture]
    public class UserHandlerTestes
    {
        private Mock<IUow> _uowMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private UserHelper _userHelper;

        public UserHandlerTestes()
        {
            _userHelper = new UserHelper();
        }

        [SetUp]
        public void Setup()
        {
            _uowMock = new Mock<IUow>();
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Test]
        public void Dado_comando_invalido_deve_interromper_criacao()
        {
            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.CreateUserCommandInvalid);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void Dado_comando_invalido_deve_realizar_criacao()
        {
            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.CreateUserCommandValid);

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void Dado_comando_com_nome_de_usuario_existente_deve_interromper_criacao()
        {
            _userRepositoryMock.Setup(user => user.GetByUserName("jack")).Returns(_userHelper.UserValid);

            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.CreateUserCommandValid);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void Dado_comando_invalido_deve_interromper_atualizacao()
        {
            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.UpdateUserCommandInvalid);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void Dado_comando_invalido_deve_realizar_atualizacao()
        {
            _userRepositoryMock.Setup(user => user.GetByUserName("jack")).Returns(_userHelper.UserValid);

            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.UpdateUserCommandValid);

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void Dado_comando_com_nome_de_usuario_inexistente_deve_interromper_atualizacao()
        {
            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.UpdateUserCommandValid);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void Dado_comando_invalido_deve_interromper_remocao()
        {
            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.DeleteUserCommandInvalid);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void Dado_comando_invalido_deve_realizar_remocao()
        {
            _userRepositoryMock.Setup(user => user.GetByUserName("jack")).Returns(_userHelper.UserValid);

            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.DeleteUserCommandValid);

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void Dado_comando_com_nome_de_usuario_inexistente_deve_interromper_remocao()
        {
            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.DeleteUserCommandValid);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void Dado_comando_invalido_nao_deve_retornar_usuario()
        {
            _userRepositoryMock.Setup(user => user.GetByUserName("jack")).Returns(_userHelper.UserValid);

            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.GetUserCommandInvalid);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void Dado_comando_valido_deve_retornar_usuario()
        {
            _userRepositoryMock.Setup(user => user.GetByUserName("jack")).Returns(_userHelper.UserValid);

            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.GetUserCommandValid);

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void Dado_comando_com_nome_de_usuario_inexistente_nao_deve_retornar_usuario()
        {
            var sut = new UserHandler(_uowMock.Object, _userRepositoryMock.Object);

            var result = (GenericCommandResult)sut.Handle(_userHelper.GetUserCommandInvalid);

            Assert.IsFalse(result.Success);
        }
    }
}
