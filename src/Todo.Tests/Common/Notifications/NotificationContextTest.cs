using NUnit.Framework;
using System.Collections.Generic;
using Todo.Common.Notifications;

namespace Todo.Tests.Common.Notifications
{
    [TestFixture]
    public class NotificationContextTest
    {
        private NotificationContext _notificationContext;
        private Notification _notification = new Notification("Id", "Código não informado");

        [SetUp]
        public void Setup()
        {
            _notificationContext = new NotificationContext();
        }

        [Test]
        public void DadoChaveEMensagemDeveAdicionarNotificacao()
        {
            _notificationContext.AddNotification("Id", "Código não informado");

            var result = _notificationContext.Notifications.Count;

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void DadoObjetoNotificacaoDeveAdicionarNotificacao()
        {
            _notificationContext.AddNotification(_notification);

            var result = _notificationContext.Notifications.Count;

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void DadaColecaoApenasLeituraDeNotificacoesDeveAdicionarNotificacao()
        {
            var sut = new List<Notification> { _notification };
            _notificationContext.AddNotifications((IReadOnlyCollection<Notification>)sut);

            var result = _notificationContext.Notifications.Count;

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void DadaListaDeNotificacoesDeveAdicionarNotificacao()
        {
            var sut = new List<Notification> { _notification };
            _notificationContext.AddNotifications((IList<Notification>)sut);

            var result = _notificationContext.Notifications.Count;

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void DadaColecaoDeNotificacoesDeveAdicionarNotificacao()
        {
            var sut = new List<Notification> { _notification };
            _notificationContext.AddNotifications((ICollection<Notification>)sut);

            var result = _notificationContext.Notifications.Count;

            Assert.AreEqual(result, 1);
        }
    }
}
