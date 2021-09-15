using NUnit.Framework;
using System;
using Todo.Common.Notifications;

namespace Todo.Tests.Common.Validations
{
    [TestFixture]
    public class ValidationTest
    {
        private Notifiable _validation;

        [SetUp]
        public void Setup()
        {
            _validation = new Notifiable();
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void DadoValorInvalidoDeveAdicionarValidacao(string value)
        {
            var sut = _validation.IsNullOrEmpty(value, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("teste")]
        public void DadoValorValidoNaoDeveAdicionarValidacao(string value)
        {
            var sut = _validation.IsNullOrEmpty(value, "", "");

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("", 2)]
        [TestCase("teste", 6)]
        public void DadoTextoMenorQueEspecificadoDeveAdicionarValidacao(string val, int min)
        {
            var sut = _validation.HasMinLen(val, min, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("teste", 2)]
        [TestCase("teste", 5)]
        public void DadoTextoMaiorOuIgualQueEspecificadoNaoDeveAdicionarValidacao(string val, int min)
        {
            var sut = _validation.HasMinLen(val, min, "", "");

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }

        [Test]
        public void DadoTextoMaiorQueEspecificadoDeveAdicionarValidacao()
        {
            var sut = _validation.HasMaxLen("teste", 4, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("teste", 6)]
        [TestCase("teste", 5)]
        public void DadoTextoMenorOuIgualQueEspecificadoNaoDeveAdicionarValidacao(string val, int min)
        {
            var sut = _validation.HasMaxLen(val, min, "", "");

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }

        [Test]
        public void DadaDataMinimaDeveAdicionarValidacao()
        {
            var sut = _validation.IsInvalidValidDate(DateTime.MinValue, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        public void DadaDataMaximaDeveAdicionarValidacao()
        {
            var sut = _validation.IsInvalidValidDate(DateTime.MaxValue, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        public void DadaDataValidaNaoDeveAdicionarValidacao()
        {
            var sut = _validation.IsInvalidValidDate(DateTime.Now, "", "");

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }

        [Test]
        public void DadoValoresIguaisDeveAdicionarValidacao()
        {
            var sut = _validation.AreEquals(5, 5, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        public void DadoValoresDiferentesNaoDeveAdicionarValidacao()
        {
            var sut = _validation.AreEquals(5, 6, "", "");

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase("true", "true")]
        [TestCase(true, true)]
        public void DadoValoresIguaisDeveAdicionarValidacao(object val1, object val2)
        {
            var sut = _validation.AreEquals(val1, val2, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(true, "true")]
        [TestCase(0, false)]
        [TestCase(1, true)]
        public void DadoValoresDiferentesNaoDeveAdicionarValidacao(object val1, object val2)
        {
            var sut = _validation.AreEquals(val1, val2, "", "");

            var result = sut.HasNotifications;

            Assert.False(result);
        }

        [Test]
        public void DadoDoisObjetosNaoDeveAdicionarValidacao()
        {
            var sut = _validation.AreEquals(new Notifiable(), new Notifiable(), "", "");

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }

        [Test]
        public void DadoValoresDiferentesDeveAdicionarValidacao()
        {
            var sut = _validation.AreNotEquals(5, 6, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        public void DadoValoresIguaisNaoDeveAdicionarValidacao()
        {
            var sut = _validation.AreNotEquals(5, 5, "", "");

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(true, "true")]
        [TestCase(0, false)]
        [TestCase(1, true)]
        public void DadoValoresDiferentesDeveAdicionarValidacao(object val1, object val2)
        {
            var sut = _validation.AreNotEquals(val1, val2, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase("true", "true")]
        [TestCase(true, true)]
        public void DadoValoresIguaisNaoDeveAdicionarValidacao(object val1, object val2)
        {
            var sut = _validation.AreNotEquals(val1, val2, "", "");

            var result = sut.HasNotifications;

            Assert.False(result);
        }

        [Test]
        public void DadoValorMaiorQueEspecificadoDeveAdicionarValidacao()
        {
            var sut = _validation.IsGreater(10.5m, 10, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        public void DadoValorMenorQueEspecificadoNaoDeveAdicionarValidacao()
        {
            var sut = _validation.IsGreater(10.5m, 10, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        public void DadoValorIgualEspecificadoNaoDeveAdicionarValidacao()
        {
            var sut = _validation.IsGreater(10.0m, 10, "", "");

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("")]
        [TestCase("teste")]
        [TestCase("teste@hotmail")]
        [TestCase("teste@com")]
        public void DadoEmailInvalidoDeveAdicionarValidacao(string val)
        {
            var sut = _validation.IsInvalidEmail(val, "", "");

            var result = sut.HasNotifications;

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("teste@hotmail.com")]
        [TestCase("teste@gmail.com")]
        public void DadoEmailValidoNaoDeveAdicionarValidacao(string val)
        {
            var sut = _validation.IsInvalidEmail(val, "", "");

            var result = sut.HasNotifications;

            Assert.IsFalse(result);
        }
    }
}
