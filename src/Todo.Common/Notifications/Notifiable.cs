using System;
using System.Text.RegularExpressions;

namespace Todo.Common.Notifications
{
    public class Notifiable : NotificationContext
    {
        public Notifiable IsNullOrEmpty(string val, string property, string message)
        {
            if (string.IsNullOrEmpty(val))
                AddNotification(property, message);

            return this;
        }

        public Notifiable HasMinLen(string val, int min, string property, string message)
        {
            if ((val ?? "").Length < min)
                AddNotification(property, message);

            return this;
        }

        public Notifiable HasMaxLen(string val, int max, string property, string message)
        {
            if ((val ?? "").Length > max)
                AddNotification(property, message);

            return this;
        }

        public Notifiable IsInvalidValidDate(DateTime val, string property, string message)
        {
            if (val == DateTime.MinValue || val == DateTime.MaxValue)
                AddNotification(property, message);

            return this;
        }

        public Notifiable AreEquals(int val, int comparer, string property, string message)
        {
            if (val == comparer)
                AddNotification(property, message);

            return this;
        }

        public Notifiable AreEquals(object val, object comparer, string property, string message)
        {
            if (val.Equals(comparer))
                AddNotification(property, message);

            return this;
        }

        public Notifiable AreNotEquals(int val, int comparer, string property, string message)
        {
            if (val != comparer)
                AddNotification(property, message);

            return this;
        }

        public Notifiable AreNotEquals(object val, object comparer, string property, string message)
        {
            if (!val.Equals(comparer))
                AddNotification(property, message);

            return this;
        }

        public Notifiable IsGreater(decimal val, int comparer, string property, string message)
        {
            if ((double)val > comparer)
                AddNotification(property, message);

            return this;
        }

        public Notifiable IsInvalidEmail(string val, string property, string msgError)
        {
            if (!Regex.IsMatch(val,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase))
                AddNotification(property, msgError);

            return this;
        }
    }
}
