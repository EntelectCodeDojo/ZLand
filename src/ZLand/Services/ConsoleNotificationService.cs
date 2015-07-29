using System;

namespace ZLand.Services
{
    public class SimpleNotificationService : INotificiationService
    {
        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}