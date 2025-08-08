using DevIO.Business.Notifications;

namespace DevIO.Business.Interfaces;

public interface INotificator
{
    IReadOnlyCollection<Notification> GetNotifications();
    void Handle(Notification notification);
    bool HasNotifications();
}
