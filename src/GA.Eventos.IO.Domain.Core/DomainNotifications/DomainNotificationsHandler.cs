using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA.Eventos.IO.Domain.Core.DomainNotifications
{
    public class DomainNotificationsHandler : IDomainNotificationHandler<DomainNotification>
    {
        public DomainNotificationsHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        private List<DomainNotification> _notifications;

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(DomainNotification message)
        {
            _notifications.Add(message);
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
