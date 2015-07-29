using System;

namespace ZLand.Services
{
    public class ConsoleNotificationService : INotificiationService
    {
        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}