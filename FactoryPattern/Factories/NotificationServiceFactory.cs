namespace FactoryPattern.Factories
{
    public class NotificationServiceFactory
    {
        public class EmailNotificationService : INotificationService
        {
            public void Send(string message)
            {
                Console.WriteLine($"Email enviado: {message}");
            }
        }

        public class SmsNotificationService : INotificationService
        {
            public void Send(string message)
            {
                Console.WriteLine($"SMS enviado: {message}");
            }
        }

        public class PushNotificationService : INotificationService
        {
            public void Send(string message)
            {
                Console.WriteLine($"Push enviado: {message}");
            }
        }
    }
}
