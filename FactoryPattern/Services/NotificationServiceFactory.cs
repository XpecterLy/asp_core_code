using FactoryPattern.Factories;
using FactoryPattern.Types;
using static FactoryPattern.Factories.NotificationServiceFactory;

namespace FactoryPattern.Services
{
    public interface INotificationServiceFactory
    {
        INotificationService Create(NotificationType type);
    }

    public class NotificationServiceFactory : INotificationServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificationServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public INotificationService Create(NotificationType type)
        {
            return type switch
            {
                NotificationType.Email => _serviceProvider.GetRequiredService<EmailNotificationService>(),
                NotificationType.Sms => _serviceProvider.GetRequiredService<SmsNotificationService>(),
                NotificationType.Push => _serviceProvider.GetRequiredService<PushNotificationService>(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), $"Tipo {type} no soportado")
            };
        }
    }
}
