using DevIO.Business.Interfaces;

namespace DevIO.Business.Notifications;

public class Notificator : INotificator
{
    private readonly List<Notification> _notifications;

    public Notificator() => _notifications = [];

    public IReadOnlyCollection<Notification> GetNotifications() => _notifications.AsReadOnly();
    public void Handle(Notification notification)
    {
        if (notification is not null)
        {
            _notifications.Add(notification);
        }
    }
    public bool HasNotifications() => _notifications.Any();
}
