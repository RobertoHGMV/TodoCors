using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Models.Users;
using Todo.Domain.Queries.Users;
using Todo.Domain.ValueObjects.EmailObj;
using Todo.Domain.ValueObjects.LoginObj;
using Todo.Domain.ValueObjects.NameObj;

namespace Todo.Tests.Domain.Queries.Users
{
    [TestFixture]
    public class UserQueryTests
    {
        private List<User> _users;

        public UserQueryTests()
        {
            _users = new List<User> 
            {
                new User(new Name("Jack", "Chan"), new Login("jack", "12345", "12345"), new Email("jack@gmail.com")),
                new User(new Name("Sebastian", "Vetel"), new Login("vet", "12345", "12345"), new Email("vet@gmail.com"))
            };
        }

        [Test]
        public void Dada_consulta_deve_retornar_usuario_com_nome_de_usuario_especificado()
        {
            var sut = _users.AsQueryable().FirstOrDefault(UserQuery.GetByUserName("jack"));

            var result = sut.Login.UserName;

            Assert.AreEqual("jack", result);
        }
    }
}
