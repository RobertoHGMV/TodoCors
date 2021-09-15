using System.Collections.Generic;
using Todo.Common.Notifications;

namespace Todo.Common.Entities
{
    public abstract class Entity
    {
        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public IReadOnlyCollection<Notification> Notifications { get; private set; }

        public bool Validate(Notifiable validation)
        {
            Notifications = validation.Notifications;
            return Valid = !validation.HasNotifications;
        }
    }
}
