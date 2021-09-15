using System.Collections.Generic;
using Todo.Common.Notifications;
using Todo.Common.Validations;

namespace Todo.Common.Entities
{
    public abstract class Entity
    {
        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public IReadOnlyCollection<Notification> Notifications { get; private set; }

        public bool Validate(Validation validation)
        {
            Notifications = validation.Notifications;
            return Valid = !validation.HasNotifications;
        }
    }
}
